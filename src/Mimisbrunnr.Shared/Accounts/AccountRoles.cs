namespace Mimisbrunnr.Shared.Accounts;

public class AccountRoles
{
    public required int Id { get; init; }
    public required List<string> Roles { get; init; }
    public required bool IsCurrentUser { get; init; }
}

public partial class AccountRequest
{
    public class PutAccountRoles
    {
        // An empty list intentionally removes every role.
        public required List<string> Roles { get; init; }

        public class Validator : AbstractValidator<PutAccountRoles>
        {
            public Validator()
            {
                RuleFor(x => x.Roles).NotNull();
                RuleForEach(x => x.Roles).NotEmpty().MaximumLength(256);
            }
        }
    }
}

public interface IAccountRoleService
{
    Task<Result<AccountRoles>> GetRoles(int id, CancellationToken ct);
    Task<Result<AccountRoles>> PutRoles(int id, AccountRequest.PutAccountRoles req, CancellationToken ct);
}
