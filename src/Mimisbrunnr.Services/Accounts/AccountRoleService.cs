using System.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Mimisbrunnr.Persistence;
using Mimisbrunnr.Services.Identity;
using Mimisbrunnr.Shared.Accounts;
using Mimisbrunnr.Shared.Identity;

namespace Mimisbrunnr.Services.Accounts;

public class AccountRoleService(
    ApplicationDbContext dbContext,
    ISessionContextProvider sessionContextProvider,
    UserManager<IdentityUser> userManager,
    RoleManager<IdentityRole> roleManager) : IAccountRoleService
{
    public async Task<Result<AccountRoles>> GetRoles(int id, CancellationToken ct)
    {
        if (sessionContextProvider.User?.IsInRole(AppRoles.Hmdl) != true)
            return Result.Forbidden();

        var account = await dbContext.Accounts.AsNoTracking().FirstOrDefaultAsync(a => a.Id == id, ct);
        if (account is null || await userManager.FindByIdAsync(account.UserId) is not { } user)
            return Result.NotFound("Account not found.");

        return Result.Success(await CreateResponse(id, user));
    }

    public async Task<Result<AccountRoles>> PutRoles(int id, AccountRequest.PutAccountRoles req, CancellationToken ct)
    {
        if (sessionContextProvider.User?.IsInRole(AppRoles.Hmdl) != true)
            return Result.Forbidden();

        if (req.Roles is null || req.Roles.Any(string.IsNullOrWhiteSpace))
            return Result.Invalid(new ValidationError { Identifier = "Roles", ErrorMessage = "Provide valid role names." });

        // Identity writes save immediately; a transaction prevents a partially updated role set.
        await using var transaction = await dbContext.Database.BeginTransactionAsync(IsolationLevel.Serializable, ct);
        var account = await dbContext.Accounts.AsNoTracking().FirstOrDefaultAsync(a => a.Id == id, ct);
        if (account is null || await userManager.FindByIdAsync(account.UserId) is not { } user)
            return Result.NotFound("Account not found.");

        var availableRoles = await roleManager.Roles.ToListAsync(ct);
        var requestedRoles = new List<string>();
        foreach (var name in req.Roles)
        {
            var role = availableRoles.FirstOrDefault(r => r.NormalizedName == roleManager.NormalizeKey(name));
            if (role?.Name is null)
                return Result.Invalid(new ValidationError { Identifier = "Roles", ErrorMessage = $"Unknown role: {name}." });
            requestedRoles.Add(role.Name);
        }
        requestedRoles = requestedRoles.Distinct(StringComparer.OrdinalIgnoreCase).ToList();

        if (user.Id == sessionContextProvider.User.GetUserId() && !requestedRoles.Contains(AppRoles.Hmdl))
            return Result.Conflict("You cannot remove your own Hmdl administrator role.");

        var currentRoles = await userManager.GetRolesAsync(user);
        var toAdd = requestedRoles.Except(currentRoles, StringComparer.OrdinalIgnoreCase).ToArray();
        var toRemove = currentRoles.Except(requestedRoles, StringComparer.OrdinalIgnoreCase).ToArray();

        if (toAdd.Length > 0)
        {
            var added = await userManager.AddToRolesAsync(user, toAdd);
            if (!added.Succeeded)
                return IdentityFailure(added);
        }
        if (toRemove.Length > 0)
        {
            var removed = await userManager.RemoveFromRolesAsync(user, toRemove);
            if (!removed.Succeeded)
                return IdentityFailure(removed);
        }

        await transaction.CommitAsync(ct);
        return Result.Success(await CreateResponse(id, user));
    }

    private async Task<AccountRoles> CreateResponse(int id, IdentityUser user) => new()
    {
        Id = id,
        Roles = (await userManager.GetRolesAsync(user)).OrderBy(r => r).ToList(),
        IsCurrentUser = user.Id == sessionContextProvider.User?.GetUserId()
    };

    private static Result<AccountRoles> IdentityFailure(IdentityResult result) =>
        result.Errors.Any(e => e.Code == "ConcurrencyFailure")
            ? Result.Conflict("This account changed while saving. Reload and try again.")
            : Result.Error(string.Join(" ", result.Errors.Select(e => e.Description)));
}
