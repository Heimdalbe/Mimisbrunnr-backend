using Mimisbrunnr.Shared.Accounts;
using Mimisbrunnr.Shared.Accounts.Dtos;
using Mimisbrunnr.Shared.Identity;

namespace Mimisbrunnr.Server.Endpoints.Accounts;

public class GetAccountById(IAccountService accountService) : EndpointWithoutRequest<Result<AccountDto.Detailed>>
{
    public override void Configure()
    {
        Get("/api/accounts/{id:int}");
        Roles(AppRoles.Hmdl);
    }

    public override Task<Result<AccountDto.Detailed>> ExecuteAsync(CancellationToken ct)
    {
        var id = Route<int>("id");
        return accountService.GetAccount(id, ct);
    }
}