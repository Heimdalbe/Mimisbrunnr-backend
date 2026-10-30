using Destructurama.Attributed;

namespace Mimisbrunnr.Shared.Accounts;

public partial class AccountResponse
{
    public class PutAccount
    {
        public required int Id { get; set; }
    }
}

public partial class AccountRequest
{
    public class PutAccount
    {
        public string? Name { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        [LogMasked]
        public string? Password { get; set; }
        [LogMasked]
        public string? CurrentPassword { get; set; }

        public class Validator : AbstractValidator<PutAccount>
        {
            public Validator()
            {
                RuleFor(x => x.Name).NotEmpty().MaximumLength(50).When(x => x.Name is not null);
                RuleFor(x => x.FirstName).MaximumLength(100);
                RuleFor(x => x.LastName).MaximumLength(100);
                RuleFor(x => x.Email).EmailAddress().When(x => x.Email is not null);
                RuleFor(x => x.Password).NotEmpty().When(x => x.Password is not null);
            }
        }
    }
}
