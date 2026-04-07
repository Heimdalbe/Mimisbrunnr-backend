using Mimisbrunnr.Shared.Accounts;
using Mimisbrunnr.Shared.Identity;

namespace Mimisbrunnr.Server.Endpoints.Accounts;

public class PutAccountBySelf(IAccountService accountService) : Endpoint<AccountRequest.PutAccount, Result<AccountResponse.PutAccount>>
{
    public override void Configure()
    {
        Put("/api/accounts/self");
        Roles(AppRoles.Feut, AppRoles.Schacht, AppRoles.Commilitones);
    }

    public override Task<Result<AccountResponse.PutAccount>> ExecuteAsync(AccountRequest.PutAccount req, CancellationToken ct)
    {
        return accountService.PutAccountBySelf(req,ct);
    }
}