// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// SignInService.cs See LICENSE.txt in the root folder of the solution.

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using PBACTemplate.Brokers.SignIn;
using PBACTemplate.Data;
using System.Security.Claims;

namespace PBACTemplate.Services.Foundations.SignIn;

public sealed partial class SignInService(
    ISignInManagerBroker signInManagerBroker,
    ILogger<SignInService> logger) : ISignInService
{
    private readonly ISignInManagerBroker signInManagerBroker = signInManagerBroker;
    private readonly ILogger<SignInService> logger = logger;

    // Sign-in status
    public bool IsSignedIn(ClaimsPrincipal principal) =>
        TryCatch(() =>
        {
            ValidatePrincipal(principal);

            LogCheckingIsSignedIn();

            return this.signInManagerBroker.IsSignedIn(principal);
        });

    public ValueTask<bool> CanSignInAsync(ApplicationUser user) =>
        TryCatch(async () =>
        {
            ValidateUser(user);

            LogCheckingCanSignIn(user.Id);

            return await this.signInManagerBroker.CanSignInAsync(user);
        });

    // Sign-in operations
    public ValueTask SignInAsync(ApplicationUser user, bool isPersistent, string? authenticationMethod = null) =>
        TryCatch(async () =>
        {
            ValidateUser(user);

            LogSigningIn(user.Id, isPersistent);

            await this.signInManagerBroker.SignInAsync(user, isPersistent, authenticationMethod);
        });

    public ValueTask SignInAsync(
        ApplicationUser user,
        AuthenticationProperties authenticationProperties,
        string? authenticationMethod = null) =>
        TryCatch(async () =>
        {
            ValidateUser(user);
            ValidateAuthenticationProperties(authenticationProperties);

            LogSigningInWithProperties(user.Id);

            await this.signInManagerBroker.SignInAsync(user, authenticationProperties, authenticationMethod);
        });

    public ValueTask SignInWithClaimsAsync(
        ApplicationUser user,
        bool isPersistent,
        IEnumerable<Claim> additionalClaims) =>
        TryCatch(async () =>
        {
            ValidateUser(user);
            ValidateClaims(additionalClaims);

            LogSigningInWithClaims(user.Id, isPersistent);

            await this.signInManagerBroker.SignInWithClaimsAsync(user, isPersistent, additionalClaims);
        });

    public ValueTask SignInWithClaimsAsync(
        ApplicationUser user,
        AuthenticationProperties? authenticationProperties,
        IEnumerable<Claim> additionalClaims) =>
        TryCatch(async () =>
        {
            ValidateUser(user);
            ValidateClaims(additionalClaims);

            LogSigningInWithClaimsAndProperties(user.Id);

            await this.signInManagerBroker.SignInWithClaimsAsync(user, authenticationProperties, additionalClaims);
        });

    public ValueTask RefreshSignInAsync(ApplicationUser user) =>
        TryCatch(async () =>
        {
            ValidateUser(user);

            LogRefreshingSignIn(user.Id);

            await this.signInManagerBroker.RefreshSignInAsync(user);
        });

    public ValueTask SignOutAsync() =>
        TryCatch(async () =>
        {
            LogSigningOut();

            await this.signInManagerBroker.SignOutAsync();
        });

    // Principal operations
    public ValueTask<ClaimsPrincipal> CreateUserPrincipalAsync(ApplicationUser user) =>
        TryCatch(async () =>
        {
            ValidateUser(user);

            LogCreatingUserPrincipal(user.Id);

            return await this.signInManagerBroker.CreateUserPrincipalAsync(user);
        });

    // Password sign-in
    public ValueTask<SignInResult> PasswordSignInAsync(
        ApplicationUser user,
        string password,
        bool isPersistent,
        bool lockoutOnFailure) =>
        TryCatch(async () =>
        {
            ValidateUser(user);
            ValidatePassword(password);

            LogPasswordSignIn(user.Id);

            return await this.signInManagerBroker.PasswordSignInAsync(user, password, isPersistent, lockoutOnFailure);
        });

    public ValueTask<SignInResult> PasswordSignInAsync(
        string userName,
        string password,
        bool isPersistent,
        bool lockoutOnFailure) =>
        TryCatch(async () =>
        {
            ValidateUserName(userName);
            ValidatePassword(password);

            LogPasswordSignInByUserName();

            return await this.signInManagerBroker.PasswordSignInAsync(userName, password, isPersistent, lockoutOnFailure);
        });

    public ValueTask<SignInResult> CheckPasswordSignInAsync(
        ApplicationUser user,
        string password,
        bool lockoutOnFailure) =>
        TryCatch(async () =>
        {
            ValidateUser(user);
            ValidatePassword(password);

            LogCheckingPasswordSignIn(user.Id);

            return await this.signInManagerBroker.CheckPasswordSignInAsync(user, password, lockoutOnFailure);
        });

    // Two-factor authentication
    public ValueTask<bool> IsTwoFactorClientRememberedAsync(ApplicationUser user) =>
        TryCatch(async () =>
        {
            ValidateUser(user);

            LogCheckingTwoFactorClientRemembered(user.Id);

            return await this.signInManagerBroker.IsTwoFactorClientRememberedAsync(user);
        });

    public ValueTask RememberTwoFactorClientAsync(ApplicationUser user) =>
        TryCatch(async () =>
        {
            ValidateUser(user);

            LogRememberingTwoFactorClient(user.Id);

            await this.signInManagerBroker.RememberTwoFactorClientAsync(user);
        });

    public ValueTask ForgetTwoFactorClientAsync() =>
        TryCatch(async () =>
        {
            LogForgettingTwoFactorClient();

            await this.signInManagerBroker.ForgetTwoFactorClientAsync();
        });

    public ValueTask<SignInResult> TwoFactorRecoveryCodeSignInAsync(string recoveryCode) =>
        TryCatch(async () =>
        {
            ValidateRecoveryCode(recoveryCode);

            LogTwoFactorRecoveryCodeSignIn();

            return await this.signInManagerBroker.TwoFactorRecoveryCodeSignInAsync(recoveryCode);
        });

    public ValueTask<SignInResult> TwoFactorAuthenticatorSignInAsync(
        string code,
        bool isPersistent,
        bool rememberClient) =>
        TryCatch(async () =>
        {
            ValidateCode(code);

            LogTwoFactorAuthenticatorSignIn();

            return await this.signInManagerBroker.TwoFactorAuthenticatorSignInAsync(code, isPersistent, rememberClient);
        });

    public ValueTask<SignInResult> TwoFactorSignInAsync(
        string provider,
        string code,
        bool isPersistent,
        bool rememberClient) =>
        TryCatch(async () =>
        {
            ValidateProvider(provider);
            ValidateCode(code);

            LogTwoFactorSignIn(provider);

            return await this.signInManagerBroker.TwoFactorSignInAsync(provider, code, isPersistent, rememberClient);
        });

    public ValueTask<ApplicationUser?> GetTwoFactorAuthenticationUserAsync() =>
        TryCatch(async () =>
        {
            LogGettingTwoFactorAuthenticationUser();

            return await this.signInManagerBroker.GetTwoFactorAuthenticationUserAsync();
        });

    // External login
    public ValueTask<SignInResult> ExternalLoginSignInAsync(
        string loginProvider,
        string providerKey,
        bool isPersistent) =>
        TryCatch(async () =>
        {
            ValidateLoginProvider(loginProvider);
            ValidateProviderKey(providerKey);

            LogExternalLoginSignIn(loginProvider);

            return await this.signInManagerBroker.ExternalLoginSignInAsync(loginProvider, providerKey, isPersistent);
        });

    public ValueTask<SignInResult> ExternalLoginSignInAsync(
        string loginProvider,
        string providerKey,
        bool isPersistent,
        bool bypassTwoFactor) =>
        TryCatch(async () =>
        {
            ValidateLoginProvider(loginProvider);
            ValidateProviderKey(providerKey);

            LogExternalLoginSignInWithBypass(loginProvider, bypassTwoFactor);

            return await this.signInManagerBroker.ExternalLoginSignInAsync(
                loginProvider,
                providerKey,
                isPersistent,
                bypassTwoFactor);
        });

    public ValueTask<IEnumerable<AuthenticationScheme>> GetExternalAuthenticationSchemesAsync() =>
        TryCatch(async () =>
        {
            LogGettingExternalAuthenticationSchemes();

            return await this.signInManagerBroker.GetExternalAuthenticationSchemesAsync();
        });

    public AuthenticationProperties ConfigureExternalAuthenticationProperties(
        string? provider,
        string? redirectUrl,
        string? userId = null) =>
        TryCatch(() =>
        {
            LogConfiguringExternalAuthenticationProperties(provider);

            return this.signInManagerBroker.ConfigureExternalAuthenticationProperties(provider, redirectUrl, userId);
        });

    public ValueTask<ExternalLoginInfo?> GetExternalLoginInfoAsync(string? expectedXsrf = null) =>
        TryCatch(async () =>
        {
            LogGettingExternalLoginInfo();

            return await this.signInManagerBroker.GetExternalLoginInfoAsync(expectedXsrf);
        });

    public ValueTask<IdentityResult> UpdateExternalAuthenticationTokensAsync(ExternalLoginInfo externalLogin) =>
        TryCatch(async () =>
        {
            ValidateExternalLoginInfo(externalLogin);

            LogUpdatingExternalAuthenticationTokens(externalLogin.LoginProvider);

            return await this.signInManagerBroker.UpdateExternalAuthenticationTokensAsync(externalLogin);
        });

    // Passkey operations
    public ValueTask<string> MakePasskeyRequestOptionsAsync(ApplicationUser? user) =>
        TryCatch(async () =>
        {
            LogMakingPasskeyRequestOptions(user?.Id ?? "");

            return await this.signInManagerBroker.MakePasskeyRequestOptionsAsync(user);
        });

    public ValueTask<string> MakePasskeyCreationOptionsAsync(PasskeyUserEntity user) =>
        TryCatch(async () =>
        {
            ValidatePasskeyUserEntity(user);

            LogMakingPasskeyCreationOptions(user.Name);

            return await this.signInManagerBroker.MakePasskeyCreationOptionsAsync(user);
        });

    public ValueTask<SignInResult> PasskeySignInAsync(string credentialJson) =>
        TryCatch(async () =>
        {
            ValidateCredentialJson(credentialJson);

            LogPasskeySignIn();

            return await this.signInManagerBroker.PasskeySignInAsync(credentialJson);
        });

    public ValueTask<PasskeyAttestationResult> PerformPasskeyAttestationAsync(string credentialJson) =>
        TryCatch(async () =>
        {
            ValidateCredentialJson(credentialJson);

            LogPerformingPasskeyAttestation();

            return await this.signInManagerBroker.PerformPasskeyAttestationAsync(credentialJson);
        });
}
