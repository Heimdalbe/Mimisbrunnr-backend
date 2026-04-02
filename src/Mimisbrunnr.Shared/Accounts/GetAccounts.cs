using Mimisbrunnr.Shared.Accounts.Dtos;

namespace Mimisbrunnr.Shared.Accounts;

public partial class AccountResponse
{
    public class GetAccounts
    {
        public required IReadOnlyList<AccountDto.Simple> Accounts { get; set; }
    }
}