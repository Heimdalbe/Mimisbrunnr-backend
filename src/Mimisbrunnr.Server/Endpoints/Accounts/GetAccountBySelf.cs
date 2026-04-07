using Mimisbrunnr.Services.Identity;
using Mimisbrunnr.Shared.Accounts;
using Mimisbrunnr.Shared.Accounts.Dtos;
using Mimisbrunnr.Shared.Identity;

namespace Mimisbrunnr.Server.Endpoints.Accounts;

public class GetAccountBySelf(IAccountService accountService) : EndpointWithoutRequest<Result<AccountDto.Detailed>>
{
    public override void Configure()
    {
        Get("/api/accounts/self");
        Roles(AppRoles.Feut, AppRoles.Schacht, AppRoles.Commilitones);
    }

    public override Task<Result<AccountDto.Detailed>> ExecuteAsync(CancellationToken ct)
    {
        return accountService.GetAccountBySelf(ct);
    }
}