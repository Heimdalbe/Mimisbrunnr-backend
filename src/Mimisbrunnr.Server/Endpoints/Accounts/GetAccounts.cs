using Mimisbrunnr.Shared.Accounts;
using Mimisbrunnr.Shared.Identity;

namespace Mimisbrunnr.Server.Endpoints.Accounts;

public class GetAccounts(IAccountService accountService) : EndpointWithoutRequest<Result<AccountResponse.GetAccounts>>
{
    public override void Configure()
    {
        Get("/api/accounts");
        Roles(AppRoles.Hmdl);
    }

    public override Task<Result<AccountResponse.GetAccounts>> ExecuteAsync(CancellationToken ct)
    {
        return accountService.GetAccounts(ct);
    }
}