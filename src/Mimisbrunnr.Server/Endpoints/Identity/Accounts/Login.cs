using Microsoft.AspNetCore.Identity;
using Mimisbrunnr.Shared.Identity.Accounts;

namespace Mimisbrunnr.Server.Endpoints.Identity.Accounts;

/// <summary>
/// Login Endpoint.
/// See https://fast-endpoints.com/
/// </summary>
/// <param name="signInManager"></param>
public class Login(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager) : Endpoint<AccountRequest.Login, Result>
{
    private const bool UseCookies = true;
    private const bool UseSessionCookies = true;
    public override void Configure()
    {
        Post("/api/identity/accounts/login");
        AllowAnonymous();
    }

    public override async Task<Result> ExecuteAsync(AccountRequest.Login req, CancellationToken ctx)
    {
        var useCookieScheme = UseCookies || UseSessionCookies;
        var isPersistent = UseCookies && (UseSessionCookies != true);
        signInManager.AuthenticationScheme = useCookieScheme ? IdentityConstants.ApplicationScheme : IdentityConstants.BearerScheme;
        
        var user = await userManager.FindByEmailAsync(req.Email!);
        if (user == null)
        {
            // Don't reveal whether the account exists
            return Result.Unauthorized(SignInResult.Failed.ToString());
        }
        
        var result = await signInManager.PasswordSignInAsync(user, req.Password!, isPersistent, lockoutOnFailure: true);

        if (result.RequiresTwoFactor)
        {
            if (!string.IsNullOrEmpty(req.TwoFactorCode))
            {
                result = await signInManager.TwoFactorAuthenticatorSignInAsync(req.TwoFactorCode, isPersistent, rememberClient: isPersistent);
            }
            else if (!string.IsNullOrEmpty(req.TwoFactorRecoveryCode))
            {
                result = await signInManager.TwoFactorRecoveryCodeSignInAsync(req.TwoFactorRecoveryCode);
            }
        }

        if (!result.Succeeded)
        {
            return Result.Unauthorized(result.ToString());
        }

        // The signInManager already produced the needed response in the form of a cookie or bearer token.
        
        return Result.Success();
    }
}