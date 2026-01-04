// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// SignInService.Logging.cs See LICENSE.txt in the root folder of the solution.

namespace PBACTemplate.Services.Foundations.SignIn;

public sealed partial class SignInService
{
    [LoggerMessage(
        Level = LogLevel.Information,
        Message = "Checking if user is signed in")]
    private partial void LogCheckingIsSignedIn();

    [LoggerMessage(
        Level = LogLevel.Information,
        Message = "Checking if user {UserId} can sign in")]
    private partial void LogCheckingCanSignIn(string userId);

    [LoggerMessage(
        Level = LogLevel.Information,
        Message = "Signing in user {UserId}, persistent: {IsPersistent}")]
    private partial void LogSigningIn(string userId, bool isPersistent);

    [LoggerMessage(
        Level = LogLevel.Information,
        Message = "Signing in user {UserId} with authentication properties")]
    private partial void LogSigningInWithProperties(string userId);

    [LoggerMessage(
        Level = LogLevel.Information,
        Message = "Signing in user {UserId} with claims, persistent: {IsPersistent}")]
    private partial void LogSigningInWithClaims(string userId, bool isPersistent);

    [LoggerMessage(
        Level = LogLevel.Information,
        Message = "Signing in user {UserId} with claims and authentication properties")]
    private partial void LogSigningInWithClaimsAndProperties(string userId);

    [LoggerMessage(
        Level = LogLevel.Information,
        Message = "Refreshing sign-in for user {UserId}")]
    private partial void LogRefreshingSignIn(string userId);

    [LoggerMessage(
        Level = LogLevel.Information,
        Message = "Signing out")]
    private partial void LogSigningOut();

    [LoggerMessage(
        Level = LogLevel.Information,
        Message = "Creating user principal for user {UserId}")]
    private partial void LogCreatingUserPrincipal(string userId);

    [LoggerMessage(
        Level = LogLevel.Information,
        Message = "Password sign-in for user {UserId}")]
    private partial void LogPasswordSignIn(string userId);

    [LoggerMessage(
        Level = LogLevel.Information,
        Message = "Password sign-in by user name")]
    private partial void LogPasswordSignInByUserName();

    [LoggerMessage(
        Level = LogLevel.Information,
        Message = "Checking password sign-in for user {UserId}")]
    private partial void LogCheckingPasswordSignIn(string userId);

    [LoggerMessage(
        Level = LogLevel.Information,
        Message = "Checking if two-factor client is remembered for user {UserId}")]
    private partial void LogCheckingTwoFactorClientRemembered(string userId);

    [LoggerMessage(
        Level = LogLevel.Information,
        Message = "Remembering two-factor client for user {UserId}")]
    private partial void LogRememberingTwoFactorClient(string userId);

    [LoggerMessage(
        Level = LogLevel.Information,
        Message = "Forgetting two-factor client")]
    private partial void LogForgettingTwoFactorClient();

    [LoggerMessage(
        Level = LogLevel.Information,
        Message = "Two-factor recovery code sign-in")]
    private partial void LogTwoFactorRecoveryCodeSignIn();

    [LoggerMessage(
        Level = LogLevel.Information,
        Message = "Two-factor authenticator sign-in")]
    private partial void LogTwoFactorAuthenticatorSignIn();

    [LoggerMessage(
        Level = LogLevel.Information,
        Message = "Two-factor sign-in with provider {Provider}")]
    private partial void LogTwoFactorSignIn(string provider);

    [LoggerMessage(
        Level = LogLevel.Information,
        Message = "Getting two-factor authentication user")]
    private partial void LogGettingTwoFactorAuthenticationUser();

    [LoggerMessage(
        Level = LogLevel.Information,
        Message = "External login sign-in with provider {LoginProvider}")]
    private partial void LogExternalLoginSignIn(string loginProvider);

    [LoggerMessage(
        Level = LogLevel.Information,
        Message = "External login sign-in with provider {LoginProvider}, bypass two-factor: {BypassTwoFactor}")]
    private partial void LogExternalLoginSignInWithBypass(string loginProvider, bool bypassTwoFactor);

    [LoggerMessage(
        Level = LogLevel.Information,
        Message = "Getting external authentication schemes")]
    private partial void LogGettingExternalAuthenticationSchemes();

    [LoggerMessage(
        Level = LogLevel.Information,
        Message = "Configuring external authentication properties for provider {Provider}")]
    private partial void LogConfiguringExternalAuthenticationProperties(string? provider);

    [LoggerMessage(
        Level = LogLevel.Information,
        Message = "Getting external login info")]
    private partial void LogGettingExternalLoginInfo();

    [LoggerMessage(
        Level = LogLevel.Information,
        Message = "Updating external authentication tokens for provider {LoginProvider}")]
    private partial void LogUpdatingExternalAuthenticationTokens(string loginProvider);

    [LoggerMessage(
        Level = LogLevel.Information,
        Message = "Making passkey request options for user {UserId}")]
    private partial void LogMakingPasskeyRequestOptions(string userId);

    [LoggerMessage(
        Level = LogLevel.Information,
        Message = "Making passkey creation options for user {UserName}")]
    private partial void LogMakingPasskeyCreationOptions(string userName);

    [LoggerMessage(
        Level = LogLevel.Information,
        Message = "Passkey sign-in")]
    private partial void LogPasskeySignIn();

    [LoggerMessage(
        Level = LogLevel.Information,
        Message = "Performing passkey attestation")]
    private partial void LogPerformingPasskeyAttestation();

    [LoggerMessage(
        Level = LogLevel.Error,
        Message = "Failed sign-in service error occurred, contact support.")]
    private partial void LogFailedSignInServiceException(Exception exception);
}