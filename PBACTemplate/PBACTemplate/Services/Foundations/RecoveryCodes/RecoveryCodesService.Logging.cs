// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// RecoveryCodesService.Logging.cs See LICENSE.txt in the root folder of the solution.

namespace PBACTemplate.Services.Foundations.RecoveryCodes;

public partial class RecoveryCodesService
{
    [LoggerMessage(
        Level = LogLevel.Information,
        Message = "Generating {Count} recovery codes for user {UserId}")]
    private partial void LogGeneratingRecoveryCodes(string userId, int count);

    [LoggerMessage(
        Level = LogLevel.Information,
        Message = "Redeeming recovery code for user {UserId}")]
    private partial void LogRedeemingRecoveryCode(string userId);

    [LoggerMessage(
        Level = LogLevel.Information,
        Message = "Counting recovery codes for user {UserId}")]
    private partial void LogCountingRecoveryCodes(string userId);

    [LoggerMessage(
        Level = LogLevel.Error,
        Message = "Failed recovery codes service error occurred, contact support.")]
    private partial void LogFailedRecoveryCodesServiceException(Exception exception);
}