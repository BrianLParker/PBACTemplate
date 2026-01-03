// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// AuthTokensService.Logging.cs See LICENSE.txt in the root folder of the solution.

namespace PBACTemplate.Services.Foundations.AuthTokens;

public partial class AuthTokensService
{
    [LoggerMessage(
        Level = LogLevel.Information,
        Message = "Retrieving authentication token for user {UserId}, provider {LoginProvider}, token {TokenName}")]
    private partial void LogRetrievingAuthenticationToken(string userId, string loginProvider, string tokenName);

    [LoggerMessage(
        Level = LogLevel.Information,
        Message = "Setting authentication token for user {UserId}, provider {LoginProvider}, token {TokenName}")]
    private partial void LogSettingAuthenticationToken(string userId, string loginProvider, string tokenName);

    [LoggerMessage(
        Level = LogLevel.Information,
        Message = "Removing authentication token for user {UserId}, provider {LoginProvider}, token {TokenName}")]
    private partial void LogRemovingAuthenticationToken(string userId, string loginProvider, string tokenName);

    [LoggerMessage(
        Level = LogLevel.Information,
        Message = "Retrieving authenticator key for user {UserId}")]
    private partial void LogRetrievingAuthenticatorKey(string userId);

    [LoggerMessage(
        Level = LogLevel.Information,
        Message = "Resetting authenticator key for user {UserId}")]
    private partial void LogResettingAuthenticatorKey(string userId);

    [LoggerMessage(
        Level = LogLevel.Information,
        Message = "Generating new authenticator key")]
    private partial void LogGeneratingNewAuthenticatorKey();

    [LoggerMessage(
        Level = LogLevel.Error,
        Message = "Failed auth tokens service error occurred, contact support.")]
    private partial void LogFailedAuthTokensServiceException(Exception exception);
}