// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// PasskeysService.Logging.cs See LICENSE.txt in the root folder of the solution.

namespace PBACTemplate.Services.Foundations.Passkeys;

public partial class PasskeysService
{
    [LoggerMessage(
        Level = LogLevel.Information,
        Message = "Adding or updating passkey for user {UserId}")]
    private partial void LogAddingOrUpdatingPasskey(string userId);

    [LoggerMessage(
        Level = LogLevel.Information,
        Message = "Retrieving passkeys for user {UserId}")]
    private partial void LogRetrievingPasskeys(string userId);

    [LoggerMessage(
        Level = LogLevel.Information,
        Message = "Retrieving passkey for user {UserId}")]
    private partial void LogRetrievingPasskey(string userId);

    [LoggerMessage(
        Level = LogLevel.Information,
        Message = "Retrieving user by passkey ID")]
    private partial void LogRetrievingUserByPasskeyId();

    [LoggerMessage(
        Level = LogLevel.Information,
        Message = "Removing passkey for user {UserId}")]
    private partial void LogRemovingPasskey(string userId);

    [LoggerMessage(
        Level = LogLevel.Error,
        Message = "Failed passkeys service error occurred, contact support.")]
    private partial void LogFailedPasskeysServiceException(Exception exception);
}