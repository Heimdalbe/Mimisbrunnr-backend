using Mimisbrunnr.Shared.Accounts;
using Mimisbrunnr.Shared.Identity;

namespace Mimisbrunnr.Server.Endpoints.Accounts;

public class GetAccountRoles(IAccountRoleService accountRoleService) : EndpointWithoutRequest<Result<AccountRoles>>
{
    public override void Configure()
    {
        Get("/api/accounts/{id:int}/roles");
        Roles(AppRoles.Hmdl);
    }

    public override Task<Result<AccountRoles>> ExecuteAsync(CancellationToken ct) =>
        accountRoleService.GetRoles(Route<int>("id"), ct);
}
