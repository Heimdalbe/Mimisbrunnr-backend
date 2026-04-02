using Mimisbrunnr.Shared.Accounts;
using Mimisbrunnr.Shared.Identity;

namespace Mimisbrunnr.Server.Endpoints.Accounts;

public class DeleteAccount(IAccountService accountService) : EndpointWithoutRequest<Result<AccountResponse.DeleteAccount>>
{
    public override void Configure()
    {
        Delete("/api/accounts/{id:int}");
        Roles(AppRoles.Hmdl);
    }

    public override Task<Result<AccountResponse.DeleteAccount>> ExecuteAsync(CancellationToken ct)
    {
        var id = Route<int>("id");
        return accountService.DeleteAccount(id, ct);
    }
}