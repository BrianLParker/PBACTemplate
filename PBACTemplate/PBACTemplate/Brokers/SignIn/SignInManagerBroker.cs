// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// SignInManagerBroker.cs See LICENSE.txt in the root folder of the solution.

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using PBACTemplate.Models.Users;
using System.Security.Claims;

namespace PBACTemplate.Brokers.SignIn;

public class SignInManagerBroker(SignInManager<ApplicationUser> signInManager) : ISignInManagerBroker
{
    private readonly SignInManager<ApplicationUser> signInManager = signInManager;

    public ILogger Logger
    {
        get => this.signInManager.Logger;
        set => this.signInManager.Logger = value;
    }

    public UserManager<ApplicationUser> UserManager =>
        this.signInManager.UserManager;

    public IUserClaimsPrincipalFactory<ApplicationUser> ClaimsFactory =>
        this.signInManager.ClaimsFactory;

    public IdentityOptions Options =>
        this.signInManager.Options;

    public bool IsSignedIn(ClaimsPrincipal principal) =>
        this.signInManager.IsSignedIn(principal);

    public Task<bool> CanSignInAsync(ApplicationUser user) =>
        this.signInManager.CanSignInAsync(user);

    public Task<string> MakePasskeyRequestOptionsAsync(ApplicationUser? user) =>
        this.signInManager.MakePasskeyRequestOptionsAsync(user);

    public Task<string> MakePasskeyCreationOptionsAsync(PasskeyUserEntity user) =>
        this.signInManager.MakePasskeyCreationOptionsAsync(user);

    public Task RefreshSignInAsync(ApplicationUser user) =>
        this.signInManager.RefreshSignInAsync(user);

    public Task SignInAsync(ApplicationUser user, bool isPersistent, string? authenticationMethod = null) =>
        this.signInManager.SignInAsync(user, isPersistent, authenticationMethod);

    public Task SignInAsync(
        ApplicationUser user,
        AuthenticationProperties authenticationProperties,
        string? authenticationMethod = null) =>
        this.signInManager.SignInAsync(user, authenticationProperties, authenticationMethod);

    public Task SignInWithClaimsAsync(
        ApplicationUser user,
        bool isPersistent,
        IEnumerable<Claim> additionalClaims) =>
        this.signInManager.SignInWithClaimsAsync(user, isPersistent, additionalClaims);

    public Task SignInWithClaimsAsync(
        ApplicationUser user,
        AuthenticationProperties? authenticationProperties,
        IEnumerable<Claim> additionalClaims) =>
        this.signInManager.SignInWithClaimsAsync(user, authenticationProperties, additionalClaims);

    public Task SignOutAsync() =>
        this.signInManager.SignOutAsync();

    public Task<ClaimsPrincipal> CreateUserPrincipalAsync(ApplicationUser user) =>
        this.signInManager.CreateUserPrincipalAsync(user);

    public Task<SignInResult> PasswordSignInAsync(
        ApplicationUser user,
        string password,
        bool isPersistent,
        bool lockoutOnFailure) =>
        this.signInManager.PasswordSignInAsync(user, password, isPersistent, lockoutOnFailure);

    public Task<SignInResult> PasswordSignInAsync(
        string userName,
        string password,
        bool isPersistent,
        bool lockoutOnFailure) =>
        this.signInManager.PasswordSignInAsync(userName, password, isPersistent, lockoutOnFailure);

    public Task<SignInResult> CheckPasswordSignInAsync(
        ApplicationUser user,
        string password,
        bool lockoutOnFailure) =>
        this.signInManager.CheckPasswordSignInAsync(user, password, lockoutOnFailure);

    public Task<bool> IsTwoFactorClientRememberedAsync(ApplicationUser user) =>
        this.signInManager.IsTwoFactorClientRememberedAsync(user);

    public Task RememberTwoFactorClientAsync(ApplicationUser user) =>
        this.signInManager.RememberTwoFactorClientAsync(user);

    public Task ForgetTwoFactorClientAsync() =>
        this.signInManager.ForgetTwoFactorClientAsync();

    public Task<SignInResult> TwoFactorRecoveryCodeSignInAsync(string recoveryCode) =>
        this.signInManager.TwoFactorRecoveryCodeSignInAsync(recoveryCode);

    public Task<SignInResult> TwoFactorAuthenticatorSignInAsync(
        string code,
        bool isPersistent,
        bool rememberClient) =>
        this.signInManager.TwoFactorAuthenticatorSignInAsync(code, isPersistent, rememberClient);

    public Task<SignInResult> TwoFactorSignInAsync(
        string provider,
        string code,
        bool isPersistent,
        bool rememberClient) =>
        this.signInManager.TwoFactorSignInAsync(provider, code, isPersistent, rememberClient);

    public Task<ApplicationUser?> GetTwoFactorAuthenticationUserAsync() =>
        this.signInManager.GetTwoFactorAuthenticationUserAsync();

    public Task<SignInResult> ExternalLoginSignInAsync(
        string loginProvider,
        string providerKey,
        bool isPersistent) =>
        this.signInManager.ExternalLoginSignInAsync(loginProvider, providerKey, isPersistent);

    public Task<SignInResult> ExternalLoginSignInAsync(
        string loginProvider,
        string providerKey,
        bool isPersistent,
        bool bypassTwoFactor) =>
        this.signInManager.ExternalLoginSignInAsync(loginProvider, providerKey, isPersistent, bypassTwoFactor);

    public Task<IEnumerable<AuthenticationScheme>> GetExternalAuthenticationSchemesAsync() =>
        this.signInManager.GetExternalAuthenticationSchemesAsync();

    public AuthenticationProperties ConfigureExternalAuthenticationProperties(
        string? provider,
        string? redirectUrl,
        string? userId = null) =>
        this.signInManager.ConfigureExternalAuthenticationProperties(provider, redirectUrl, userId);

    public Task<ExternalLoginInfo?> GetExternalLoginInfoAsync(string? expectedXsrf = null) =>
        this.signInManager.GetExternalLoginInfoAsync(expectedXsrf);

    public Task<IdentityResult> UpdateExternalAuthenticationTokensAsync(ExternalLoginInfo externalLogin) =>
        this.signInManager.UpdateExternalAuthenticationTokensAsync(externalLogin);

    public Task<SignInResult> PasskeySignInAsync(string credentialJson) =>
        this.signInManager.PasskeySignInAsync(credentialJson);

    public Task<PasskeyAttestationResult> PerformPasskeyAttestationAsync(string credentialJson) =>
        this.signInManager.PerformPasskeyAttestationAsync(credentialJson);

}
