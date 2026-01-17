// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// ISignInService.cs See LICENSE.txt in the root folder of the solution.

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using PBACTemplate.Models.Users;
using System.Security.Claims;

namespace PBACTemplate.Services.Foundations.SignIn;

public interface ISignInService
{
    // Sign-in status
    bool IsSignedIn(ClaimsPrincipal principal);
    ValueTask<bool> CanSignInAsync(ApplicationUser user);

    // Sign-in operations
    ValueTask SignInAsync(ApplicationUser user, bool isPersistent, string? authenticationMethod = null);
    ValueTask SignInAsync(ApplicationUser user, AuthenticationProperties authenticationProperties, string? authenticationMethod = null);
    ValueTask SignInWithClaimsAsync(ApplicationUser user, bool isPersistent, IEnumerable<Claim> additionalClaims);
    ValueTask SignInWithClaimsAsync(ApplicationUser user, AuthenticationProperties? authenticationProperties, IEnumerable<Claim> additionalClaims);
    ValueTask RefreshSignInAsync(ApplicationUser user);
    ValueTask SignOutAsync();

    // Principal operations
    ValueTask<ClaimsPrincipal> CreateUserPrincipalAsync(ApplicationUser user);

    // Password sign-in
    ValueTask<SignInResult> PasswordSignInAsync(ApplicationUser user, string password, bool isPersistent, bool lockoutOnFailure);
    ValueTask<SignInResult> PasswordSignInAsync(string userName, string password, bool isPersistent, bool lockoutOnFailure);
    ValueTask<SignInResult> CheckPasswordSignInAsync(ApplicationUser user, string password, bool lockoutOnFailure);

    // Two-factor authentication
    ValueTask<bool> IsTwoFactorClientRememberedAsync(ApplicationUser user);
    ValueTask RememberTwoFactorClientAsync(ApplicationUser user);
    ValueTask ForgetTwoFactorClientAsync();
    ValueTask<SignInResult> TwoFactorRecoveryCodeSignInAsync(string recoveryCode);
    ValueTask<SignInResult> TwoFactorAuthenticatorSignInAsync(string code, bool isPersistent, bool rememberClient);
    ValueTask<SignInResult> TwoFactorSignInAsync(string provider, string code, bool isPersistent, bool rememberClient);
    ValueTask<ApplicationUser?> GetTwoFactorAuthenticationUserAsync();

    // External login
    ValueTask<SignInResult> ExternalLoginSignInAsync(string loginProvider, string providerKey, bool isPersistent);
    ValueTask<SignInResult> ExternalLoginSignInAsync(string loginProvider, string providerKey, bool isPersistent, bool bypassTwoFactor);
    ValueTask<IEnumerable<AuthenticationScheme>> GetExternalAuthenticationSchemesAsync();
    AuthenticationProperties ConfigureExternalAuthenticationProperties(string? provider, string? redirectUrl, string? userId = null);
    ValueTask<ExternalLoginInfo?> GetExternalLoginInfoAsync(string? expectedXsrf = null);
    ValueTask<IdentityResult> UpdateExternalAuthenticationTokensAsync(ExternalLoginInfo externalLogin);

    // Passkey operations
    ValueTask<string> MakePasskeyRequestOptionsAsync(ApplicationUser? user);
    ValueTask<string> MakePasskeyCreationOptionsAsync(PasskeyUserEntity user);
    ValueTask<SignInResult> PasskeySignInAsync(string credentialJson);
    ValueTask<PasskeyAttestationResult> PerformPasskeyAttestationAsync(string credentialJson);
}
