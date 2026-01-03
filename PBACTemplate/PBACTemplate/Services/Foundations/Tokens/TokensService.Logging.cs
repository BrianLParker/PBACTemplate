// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// TokensService.Logging.cs See LICENSE.txt in the root folder of the solution.

namespace PBACTemplate.Services.Foundations.Tokens;

public partial class TokensService
{
    [LoggerMessage(
        Level = LogLevel.Information,
        Message = "Generating user token for user {UserId}, provider {TokenProvider}, purpose {Purpose}")]
    private partial void LogGeneratingUserToken(string userId, string tokenProvider, string purpose);

    [LoggerMessage(
        Level = LogLevel.Information,
        Message = "Verifying user token for user {UserId}, provider {TokenProvider}, purpose {Purpose}")]
    private partial void LogVerifyingUserToken(string userId, string tokenProvider, string purpose);

    [LoggerMessage(
        Level = LogLevel.Error,
        Message = "Failed tokens service error occurred, contact support.")]
    private partial void LogFailedTokensServiceException(Exception exception);
}