// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// TwoFactorService.Logging.cs See LICENSE.txt in the root folder of the solution.

namespace PBACTemplate.Services.Foundations.TwoFactor;

public partial class TwoFactorService
{
    [LoggerMessage(
        Level = LogLevel.Information,
        Message = "Getting two-factor enabled status for user {UserId}")]
    private partial void LogGettingTwoFactorEnabled(string userId);

    [LoggerMessage(
        Level = LogLevel.Information,
        Message = "Setting two-factor enabled to {Enabled} for user {UserId}")]
    private partial void LogSettingTwoFactorEnabled(string userId, bool enabled);

    [LoggerMessage(
        Level = LogLevel.Information,
        Message = "Retrieving valid two-factor providers for user {UserId}")]
    private partial void LogRetrievingValidTwoFactorProviders(string userId);

    [LoggerMessage(
        Level = LogLevel.Information,
        Message = "Generating two-factor token for user {UserId}, provider {TokenProvider}")]
    private partial void LogGeneratingTwoFactorToken(string userId, string tokenProvider);

    [LoggerMessage(
        Level = LogLevel.Information,
        Message = "Verifying two-factor token for user {UserId}, provider {TokenProvider}")]
    private partial void LogVerifyingTwoFactorToken(string userId, string tokenProvider);

    [LoggerMessage(
        Level = LogLevel.Error,
        Message = "Failed two-factor service error occurred, contact support.")]
    private partial void LogFailedTwoFactorServiceException(Exception exception);
}