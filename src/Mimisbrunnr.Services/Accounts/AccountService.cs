using System.Net.Mail;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Mimisbrunnr.Domain.Accounts;
using Mimisbrunnr.Persistence;
using Mimisbrunnr.Services.Identity;
using Mimisbrunnr.Shared.Accounts;
using Mimisbrunnr.Shared.Accounts.Dtos;
using Mimisbrunnr.Shared.Identity;
using static Mimisbrunnr.Services.Mappers.Mappers;

namespace Mimisbrunnr.Services.Accounts;

public class AccountService(ApplicationDbContext dbContext, ISessionContextProvider sessionContextProvider, UserManager<IdentityUser> userManager) : IAccountService
{
    #region Get

    public async Task<Result<AccountDto.Detailed>> GetAccount(int id, CancellationToken ct)
    {
        var account = await dbContext.Accounts.FirstOrDefaultAsync(a => a.Id == id, ct);

        if (account is null)
            return Result.NotFound($"Account with ID {id} not found");

        return Result.Success(AccountToDetailedDto(account));
    }

    public async Task<Result<AccountDto.Detailed>> GetAccountBySelf(CancellationToken ct)
    {
        var user = sessionContextProvider.User;

        var id = user?.GetUserId();

        if (id is null)
            return Result.Unauthorized($"You are not logged in.");

        var account = await dbContext.Accounts.FirstOrDefaultAsync(a => a.UserId == id, cancellationToken: ct);

        if (account is null)
            return Result.NotFound($"Account with ID {id} not found");

        return Result.Success(AccountToDetailedDto(account));
    }

    public async Task<Result<AccountResponse.GetAccounts>> GetAccounts(CancellationToken ct)
    {
        var accounts = await dbContext.Accounts.ToListAsync(ct);
        var dtos = accounts.Select(AccountToSimpleDto).ToList().AsReadOnly();

        return Result.Success(new AccountResponse.GetAccounts { Accounts = dtos });
    }

    #endregion
    
    #region Put

    public async Task<Result<AccountResponse.PutAccount>> PutAccountById(int id, AccountRequest.PutAccount req, CancellationToken ct)
    {
        var account = await dbContext.Accounts.FirstOrDefaultAsync(a => a.Id == id, ct);

        if (account is null)
            return Result.NotFound($"Account with ID {id} not found");

        var user = await dbContext.Users.FirstOrDefaultAsync(u => u.Id == account.UserId, ct);

        if (user is null)
            return Result.NotFound($"Account with ID {id} not found");

        return await PutAccount(account, user, req, ct);
    }

    public async Task<Result<AccountResponse.PutAccount>> PutAccountBySelf(AccountRequest.PutAccount req, CancellationToken ct)
    {
        var principal = sessionContextProvider.User;

        if (principal is null)
            return Result.Unauthorized($"You are not logged in.");

        var user = await dbContext.Users.FirstOrDefaultAsync(u => u.Id == principal.GetUserId(), cancellationToken: ct);

        if (user is null)
            return Result.NotFound($"User not found");

        var account = await dbContext.Accounts.FirstOrDefaultAsync(a => a.UserId == user.Id, cancellationToken: ct);

        if (account is null)
            return Result.NotFound($"Account not found");
        
        if (req.Email is not null && await userManager.FindByEmailAsync(req.Email) is not null && !req.Email.Equals(user.Email))
            return Result.Error("Een account met dit e-mailadres bestaat al.");

        if (req.Name is not null && await userManager.FindByNameAsync(req.Name) is not null && !req.Name.Equals(user.UserName))
            return Result.Error("Een account met deze naam bestaat al.");
        
        return await PutAccount(account, user, req, ct, requireCurrentPassword: true);
    }

    private async Task<Result<AccountResponse.PutAccount>> PutAccount(Account account, IdentityUser user, AccountRequest.PutAccount req, CancellationToken ct, bool requireCurrentPassword = false)
    {
        // Check the password before changing any profile fields.
        if (req.Password is not null)
        {
            if (requireCurrentPassword && string.IsNullOrEmpty(req.CurrentPassword))
                return Result.Invalid(new ValidationError { Identifier = "CurrentPassword", ErrorMessage = "Vul je huidige wachtwoord in." });

            var result = requireCurrentPassword
                ? await userManager.ChangePasswordAsync(user, req.CurrentPassword!, req.Password)
                : await userManager.ResetPasswordAsync(user, await userManager.GeneratePasswordResetTokenAsync(user), req.Password);

            if (!result.Succeeded)
                return Result.Invalid(result.Errors.Select(e => new ValidationError
                {
                    Identifier = e.Code == "PasswordMismatch" ? "CurrentPassword" : "Password",
                    ErrorMessage = e.Code == "PasswordMismatch" ? "Je huidige wachtwoord klopt niet." : e.Description
                }).ToList());
        }

        if (req.Name is not null)
        {
            account.Name = req.Name;
            await userManager.SetUserNameAsync(user, req.Name);
        }

        if (req.Email is not null)
        {
            account.Email = new MailAddress(req.Email);
            await userManager.SetEmailAsync(user, req.Email);
        }

        await dbContext.SaveChangesAsync(ct);
        return Result.Success(new AccountResponse.PutAccount { Id = account.Id, });
    }

    #endregion
    
    #region Delete

    public async Task<Result<AccountResponse.DeleteAccount>> DeleteAccount(int id, CancellationToken ct)
    {
        var account = await dbContext.Accounts.FirstOrDefaultAsync(a => a.Id == id, ct);
        if (account is null)
            return Result.NotFound($"Account with ID {id} not found");
        
        var user = await dbContext.Users.FirstOrDefaultAsync(u => u.Id == account.UserId, ct);
        if (user is null)
            return Result.NotFound($"User not found");

        await userManager.DeleteAsync(user);
        dbContext.Remove(account);
        
        await dbContext.SaveChangesAsync(ct);
        
        return Result.Success(new AccountResponse.DeleteAccount { Id = id });
    }
    
    #endregion
}
