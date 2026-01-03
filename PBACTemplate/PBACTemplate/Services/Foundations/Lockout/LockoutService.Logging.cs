// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// LockoutService.Logging.cs See LICENSE.txt in the root folder of the solution.

namespace PBACTemplate.Services.Foundations.Lockout;

public partial class LockoutService
{
    [LoggerMessage(
        Level = LogLevel.Information,
        Message = "Checking if user {UserId} is locked out")]
    private partial void LogCheckingIsLockedOut(string userId);

    [LoggerMessage(
        Level = LogLevel.Information,
        Message = "Setting lockout enabled to {Enabled} for user {UserId}")]
    private partial void LogSettingLockoutEnabled(string userId, bool enabled);

    [LoggerMessage(
        Level = LogLevel.Information,
        Message = "Getting lockout enabled for user {UserId}")]
    private partial void LogGettingLockoutEnabled(string userId);

    [LoggerMessage(
        Level = LogLevel.Information,
        Message = "Retrieving lockout end date for user {UserId}")]
    private partial void LogRetrievingLockoutEndDate(string userId);

    [LoggerMessage(
        Level = LogLevel.Information,
        Message = "Setting lockout end date to {LockoutEnd} for user {UserId}")]
    private partial void LogSettingLockoutEndDate(string userId, DateTimeOffset? lockoutEnd);

    [LoggerMessage(
        Level = LogLevel.Information,
        Message = "Recording access failed for user {UserId}")]
    private partial void LogRecordingAccessFailed(string userId);

    [LoggerMessage(
        Level = LogLevel.Information,
        Message = "Resetting access failed count for user {UserId}")]
    private partial void LogResettingAccessFailedCount(string userId);

    [LoggerMessage(
        Level = LogLevel.Information,
        Message = "Retrieving access failed count for user {UserId}")]
    private partial void LogRetrievingAccessFailedCount(string userId);

    [LoggerMessage(
        Level = LogLevel.Error,
        Message = "Failed lockout service error occurred, contact support.")]
    private partial void LogFailedLockoutServiceException(Exception exception);
}