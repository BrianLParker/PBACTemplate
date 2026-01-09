// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// ISignInManagerBroker.cs See LICENSE.txt in the root folder of the solution.

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using PBACTemplate.Models.User;
using System.Security.Claims;

namespace PBACTemplate.Brokers.SignIn;

public interface ISignInManagerBroker
{
    bool IsSignedIn(ClaimsPrincipal principal);
    Task<bool> CanSignInAsync(ApplicationUser user);
    Task RefreshSignInAsync(ApplicationUser user);
    Task SignInAsync(ApplicationUser user, bool isPersistent, string? authenticationMethod = null);
    Task SignInAsync(ApplicationUser user, AuthenticationProperties authenticationProperties, string? authenticationMethod = null);
    Task SignInWithClaimsAsync(ApplicationUser user, bool isPersistent, IEnumerable<Claim> additionalClaims);
    Task SignInWithClaimsAsync(ApplicationUser user, AuthenticationProperties? authenticationProperties, IEnumerable<Claim> additionalClaims);
    Task SignOutAsync();
    Task<ClaimsPrincipal> CreateUserPrincipalAsync(ApplicationUser user);
    Task<SignInResult> PasswordSignInAsync(ApplicationUser user, string password, bool isPersistent, bool lockoutOnFailure);
    Task<SignInResult> PasswordSignInAsync(string userName, string password, bool isPersistent, bool lockoutOnFailure);
    Task<SignInResult> CheckPasswordSignInAsync(ApplicationUser user, string password, bool lockoutOnFailure);
    Task<bool> IsTwoFactorClientRememberedAsync(ApplicationUser user);
    Task RememberTwoFactorClientAsync(ApplicationUser user);
    Task ForgetTwoFactorClientAsync();
    Task<SignInResult> TwoFactorRecoveryCodeSignInAsync(string recoveryCode);
    Task<SignInResult> TwoFactorAuthenticatorSignInAsync(string code, bool isPersistent, bool rememberClient);
    Task<SignInResult> TwoFactorSignInAsync(string provider, string code, bool isPersistent, bool rememberClient);
    Task<ApplicationUser?> GetTwoFactorAuthenticationUserAsync();
    Task<SignInResult> ExternalLoginSignInAsync(string loginProvider, string providerKey, bool isPersistent);
    Task<SignInResult> ExternalLoginSignInAsync(string loginProvider, string providerKey, bool isPersistent, bool bypassTwoFactor);
    Task<IEnumerable<AuthenticationScheme>> GetExternalAuthenticationSchemesAsync();
    AuthenticationProperties ConfigureExternalAuthenticationProperties(string? provider, string? redirectUrl, string? userId = null);
    Task<ExternalLoginInfo?> GetExternalLoginInfoAsync(string? expectedXsrf = null);
    Task<IdentityResult> UpdateExternalAuthenticationTokensAsync(ExternalLoginInfo externalLogin);
    Task<string> MakePasskeyRequestOptionsAsync(ApplicationUser? user);
    Task<string> MakePasskeyCreationOptionsAsync(PasskeyUserEntity user);
    Task<SignInResult> PasskeySignInAsync(string credentialJson);
    Task<PasskeyAttestationResult> PerformPasskeyAttestationAsync(string credentialJson);

    ILogger Logger { get; set; }
    UserManager<ApplicationUser> UserManager { get; }
    IUserClaimsPrincipalFactory<ApplicationUser> ClaimsFactory { get; }
    IdentityOptions Options { get; }
}
