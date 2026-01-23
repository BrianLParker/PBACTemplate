// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// UserService.Logging.cs See LICENSE.txt in the root folder of the solution.

namespace PBACTemplate.Services.Foundations.Users;

public sealed partial class UserService
{
    [LoggerMessage(
        Level = LogLevel.Information,
        Message = "Creating user {UserId}")]
    private partial void LogCreatingUser(string userId);

    [LoggerMessage(
        Level = LogLevel.Information,
        Message = "Updating user {UserId}")]
    private partial void LogUpdatingUser(string userId);

    [LoggerMessage(
        Level = LogLevel.Information,
        Message = "Removing user {UserId}")]
    private partial void LogRemovingUser(string userId);

    [LoggerMessage(
        Level = LogLevel.Information,
        Message = "Retrieving user by ID {UserId}")]
    private partial void LogRetrievingUserById(string userId);

    [LoggerMessage(
        Level = LogLevel.Information,
        Message = "Retrieving users")]
    private partial void LogRetrievingUsers();

    [LoggerMessage(
        Level = LogLevel.Error,
        Message = "Failed users service error occurred, contact support.")]
    private partial void LogFailedUsersServiceException(Exception exception);
}