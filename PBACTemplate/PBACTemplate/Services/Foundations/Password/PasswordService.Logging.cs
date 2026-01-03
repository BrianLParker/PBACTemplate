// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// PasswordService.Logging.cs See LICENSE.txt in the root folder of the solution.

namespace PBACTemplate.Services.Foundations.Password;

public partial class PasswordService
{
    [LoggerMessage(
        Level = LogLevel.Information,
        Message = "Checking password for user {UserId}")]
    private partial void LogCheckingPassword(string userId);

    [LoggerMessage(
        Level = LogLevel.Information,
        Message = "Checking if user {UserId} has password")]
    private partial void LogCheckingHasPassword(string userId);

    [LoggerMessage(
        Level = LogLevel.Information,
        Message = "Adding password for user {UserId}")]
    private partial void LogAddingPassword(string userId);

    [LoggerMessage(
        Level = LogLevel.Information,
        Message = "Changing password for user {UserId}")]
    private partial void LogChangingPassword(string userId);

    [LoggerMessage(
        Level = LogLevel.Information,
        Message = "Removing password for user {UserId}")]
    private partial void LogRemovingPassword(string userId);

    [LoggerMessage(
        Level = LogLevel.Information,
        Message = "Generating password reset token for user {UserId}")]
    private partial void LogGeneratingPasswordResetToken(string userId);

    [LoggerMessage(
        Level = LogLevel.Information,
        Message = "Resetting password for user {UserId}")]
    private partial void LogResettingPassword(string userId);

    [LoggerMessage(
        Level = LogLevel.Error,
        Message = "Failed password service error occurred, contact support.")]
    private partial void LogFailedPasswordServiceException(Exception exception);
}