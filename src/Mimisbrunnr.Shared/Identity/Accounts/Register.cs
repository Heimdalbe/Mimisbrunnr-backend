using Destructurama.Attributed;

namespace Mimisbrunnr.Shared.Identity.Accounts;

/// <summary>
/// Represents a request structure for account-related operations, such as registration or authentication.
/// </summary>
public static partial class AccountRequest
{
    public class Register
    {
        /// <summary>
        /// The user's name.
        /// </summary>
        public string? Name { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        
        /// <summary>
        /// The user's email address.
        /// </summary>
        public string? Email { get; set; }

        /// <summary>
        /// The user's password.
        /// </summary>
        [LogMasked]
        public string? Password { get; set; }
        
        /// <summary>
        /// The user's password.
        /// </summary>
        [LogMasked]
        public string? ConfirmPassword { get; set; }
        
        /// <summary>
        /// Provides validation rules for the Register class fields such as email and password.
        /// </summary>
        public class Validator : AbstractValidator<Register>
        {
            public Validator()
            {
                RuleFor(x => x.Name).NotNull().NotEmpty().MaximumLength(50);
                RuleFor(x => x.FirstName).MaximumLength(100);
                RuleFor(x => x.LastName).MaximumLength(100);
                RuleFor(x => x.Email).NotEmpty().EmailAddress();
                RuleFor(x => x.Password).NotEmpty();
                RuleFor(x => x.ConfirmPassword)
                    .Equal(x => x.Password)
                    .WithMessage("Passwords do not match.");
            }
        }
    }
}
