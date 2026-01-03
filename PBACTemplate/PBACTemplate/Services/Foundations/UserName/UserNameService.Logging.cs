// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// UserNameService.Logging.cs See LICENSE.txt in the root folder of the solution.

namespace PBACTemplate.Services.Foundations.UserName;

public partial class UserNameService
{
    [LoggerMessage(
        Level = LogLevel.Information,
        Message = "Retrieving user name from claims principal")]
    private partial void LogRetrievingUserNameFromPrincipal();

    [LoggerMessage(
        Level = LogLevel.Information,
        Message = "Retrieving user name for user {UserId}")]
    private partial void LogRetrievingUserName(string userId);

    [LoggerMessage(
        Level = LogLevel.Information,
        Message = "Setting user name for user {UserId}")]
    private partial void LogSettingUserName(string userId);

    [LoggerMessage(
        Level = LogLevel.Information,
        Message = "Normalizing name")]
    private partial void LogNormalizingName();

    [LoggerMessage(
        Level = LogLevel.Information,
        Message = "Retrieving user ID from claims principal")]
    private partial void LogRetrievingUserIdFromPrincipal();

    [LoggerMessage(
        Level = LogLevel.Information,
        Message = "Retrieving user ID for user {UserId}")]
    private partial void LogRetrievingUserId(string userId);

    [LoggerMessage(
        Level = LogLevel.Information,
        Message = "Retrieving user from claims principal")]
    private partial void LogRetrievingUserFromPrincipal();

    [LoggerMessage(
        Level = LogLevel.Error,
        Message = "Failed user name service error occurred, contact support.")]
    private partial void LogFailedUserNameServiceException(Exception exception);
}