// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// PhoneService.Logging.cs See LICENSE.txt in the root folder of the solution.

namespace PBACTemplate.Services.Foundations.Phone;

public partial class PhoneService
{
    [LoggerMessage(
        Level = LogLevel.Information,
        Message = "Retrieving phone number for user {UserId}")]
    private partial void LogRetrievingPhoneNumber(string userId);

    [LoggerMessage(
        Level = LogLevel.Information,
        Message = "Setting phone number for user {UserId}")]
    private partial void LogSettingPhoneNumber(string userId);

    [LoggerMessage(
        Level = LogLevel.Information,
        Message = "Checking if phone number is confirmed for user {UserId}")]
    private partial void LogCheckingPhoneNumberConfirmed(string userId);

    [LoggerMessage(
        Level = LogLevel.Information,
        Message = "Generating change phone number token for user {UserId}")]
    private partial void LogGeneratingChangePhoneNumberToken(string userId);

    [LoggerMessage(
        Level = LogLevel.Information,
        Message = "Verifying change phone number token for user {UserId}")]
    private partial void LogVerifyingChangePhoneNumberToken(string userId);

    [LoggerMessage(
        Level = LogLevel.Information,
        Message = "Changing phone number for user {UserId}")]
    private partial void LogChangingPhoneNumber(string userId);

    [LoggerMessage(
        Level = LogLevel.Error,
        Message = "Failed phone service error occurred, contact support.")]
    private partial void LogFailedPhoneServiceException(Exception exception);
}