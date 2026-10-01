using Mimisbrunnr.Shared.Accounts;
using Mimisbrunnr.Shared.Identity;

namespace Mimisbrunnr.Server.Endpoints.Accounts;

public class PutAccountRoles(IAccountRoleService accountRoleService)
    : Endpoint<AccountRequest.PutAccountRoles, Result<AccountRoles>>
{
    public override void Configure()
    {
        Put("/api/accounts/{id:int}/roles");
        Roles(AppRoles.Hmdl);
    }

    public override Task<Result<AccountRoles>> ExecuteAsync(AccountRequest.PutAccountRoles req, CancellationToken ct) =>
        accountRoleService.PutRoles(Route<int>("id"), req, ct);
}
