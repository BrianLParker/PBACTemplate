// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// EmailService.Logging.cs See LICENSE.txt in the root folder of the solution.

namespace PBACTemplate.Services.Foundations.Email;

public partial class EmailService
{
    [LoggerMessage(
        Level = LogLevel.Information,
        Message = "Retrieving email for user {UserId}")]
    private partial void LogRetrievingEmail(string userId);

    [LoggerMessage(
        Level = LogLevel.Information,
        Message = "Setting email for user {UserId}")]
    private partial void LogSettingEmail(string userId);

    [LoggerMessage(
        Level = LogLevel.Information,
        Message = "Normalizing email")]
    private partial void LogNormalizingEmail();

    [LoggerMessage(
        Level = LogLevel.Information,
        Message = "Checking email confirmation for user {UserId}")]
    private partial void LogCheckingEmailConfirmation(string userId);

    [LoggerMessage(
        Level = LogLevel.Information,
        Message = "Generating email confirmation token for user {UserId}")]
    private partial void LogGeneratingEmailConfirmationToken(string userId);

    [LoggerMessage(
        Level = LogLevel.Information,
        Message = "Confirming email for user {UserId}")]
    private partial void LogConfirmingEmail(string userId);

    [LoggerMessage(
        Level = LogLevel.Information,
        Message = "Generating change email token for user {UserId}")]
    private partial void LogGeneratingChangeEmailToken(string userId);

    [LoggerMessage(
        Level = LogLevel.Information,
        Message = "Changing email for user {UserId}")]
    private partial void LogChangingEmail(string userId);

    [LoggerMessage(
        Level = LogLevel.Error,
        Message = "Failed email service error occurred, contact support.")]
    private partial void LogFailedEmailServiceException(Exception exception);
}