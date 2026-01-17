// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// UserCrudService.Logging.cs See LICENSE.txt in the root folder of the solution.

namespace PBACTemplate.Services.Foundations.UserCrud;

public partial class UserCrudService
{
    [LoggerMessage(
        Level = LogLevel.Information,
        Message = "Creating new user")]
    private partial void LogCreatingUser();

    [LoggerMessage(
        Level = LogLevel.Information,
        Message = "Creating new user with password")]
    private partial void LogCreatingUserWithPassword();

    [LoggerMessage(
        Level = LogLevel.Information,
        Message = "Updating user {UserId}")]
    private partial void LogUpdatingUser(string userId);

    [LoggerMessage(
        Level = LogLevel.Information,
        Message = "Deleting user {UserId}")]
    private partial void LogDeletingUser(string userId);

    [LoggerMessage(
        Level = LogLevel.Information,
        Message = "Retrieving users")]
    private partial void LogRetrievingUsers();

    [LoggerMessage(
        Level = LogLevel.Information,
        Message = "Retrieving user by ID {UserId}")]
    private partial void LogRetrievingUserById(string userId);

    [LoggerMessage(
        Level = LogLevel.Information,
        Message = "Retrieving user by name {UserName}")]
    private partial void LogRetrievingUserByName(string userName);

    [LoggerMessage(
        Level = LogLevel.Information,
        Message = "Retrieving user by email")]
    private partial void LogRetrievingUserByEmail();

    [LoggerMessage(
        Level = LogLevel.Information,
        Message = "Retrieving user by login provider {LoginProvider}")]
    private partial void LogRetrievingUserByLogin(string loginProvider);

    [LoggerMessage(
        Level = LogLevel.Error,
        Message = "Failed user CRUD service error occurred, contact support.")]
    private partial void LogFailedUserCrudServiceException(Exception exception);
}