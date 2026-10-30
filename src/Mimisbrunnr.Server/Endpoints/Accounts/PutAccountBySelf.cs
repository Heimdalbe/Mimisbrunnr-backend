using Microsoft.AspNetCore.Identity;
using Mimisbrunnr.Shared.Accounts;
using Mimisbrunnr.Shared.Identity;

namespace Mimisbrunnr.Server.Endpoints.Accounts;

public class PutAccountBySelf(IAccountService accountService, SignInManager<IdentityUser> signInManager) : Endpoint<AccountRequest.PutAccount, Result<AccountResponse.PutAccount>>
{
    public override void Configure()
    {
        Put("/api/accounts/self");
        Roles(AppRoles.Heimie, AppRoles.Feut, AppRoles.Schacht, AppRoles.Commilitones);
    }

    public override async Task<Result<AccountResponse.PutAccount>> ExecuteAsync(AccountRequest.PutAccount req, CancellationToken ct)
    {
        var result = await accountService.PutAccountBySelf(req, ct);
        if (result.IsSuccess && await signInManager.UserManager.GetUserAsync(User) is { } user)
            await signInManager.RefreshSignInAsync(user);
        return result;
    }
}
