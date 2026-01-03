// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// RolesService.Logging.cs See LICENSE.txt in the root folder of the solution.

namespace PBACTemplate.Services.Foundations.Roles;

public partial class RolesService
{
    [LoggerMessage(
        Level = LogLevel.Information,
        Message = "Adding user {UserId} to role {Role}")]
    private partial void LogAddingToRole(string userId, string role);

    [LoggerMessage(
        Level = LogLevel.Information,
        Message = "Adding user {UserId} to {RoleCount} roles")]
    private partial void LogAddingToRoles(string userId, int roleCount);

    [LoggerMessage(
        Level = LogLevel.Information,
        Message = "Removing user {UserId} from role {Role}")]
    private partial void LogRemovingFromRole(string userId, string role);

    [LoggerMessage(
        Level = LogLevel.Information,
        Message = "Removing user {UserId} from {RoleCount} roles")]
    private partial void LogRemovingFromRoles(string userId, int roleCount);

    [LoggerMessage(
        Level = LogLevel.Information,
        Message = "Retrieving roles for user {UserId}")]
    private partial void LogRetrievingRoles(string userId);

    [LoggerMessage(
        Level = LogLevel.Information,
        Message = "Checking if user {UserId} is in role {Role}")]
    private partial void LogCheckingIsInRole(string userId, string role);

    [LoggerMessage(
        Level = LogLevel.Information,
        Message = "Retrieving users in role {RoleName}")]
    private partial void LogRetrievingUsersInRole(string roleName);

    [LoggerMessage(
        Level = LogLevel.Error,
        Message = "Failed roles service error occurred, contact support.")]
    private partial void LogFailedRolesServiceException(Exception exception);
}