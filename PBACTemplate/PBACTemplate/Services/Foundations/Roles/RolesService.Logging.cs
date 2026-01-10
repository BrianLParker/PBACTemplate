// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// RolesService.Logging.cs See LICENSE.txt in the root folder of the solution.

namespace PBACTemplate.Services.Foundations.Roles;

public sealed partial class RolesService
{
    [LoggerMessage(
        Level = LogLevel.Information,
        Message = "Creating role {RoleName}")]
    private partial void LogCreatingRole(string roleName);

    [LoggerMessage(
        Level = LogLevel.Information,
        Message = "Updating role {RoleId} name to {NewName}")]
    private partial void LogUpdatingRoleName(string roleId, string newName);

    [LoggerMessage(
        Level = LogLevel.Information,
        Message = "Deleting role {RoleId}")]
    private partial void LogDeletingRole(string roleId);

    [LoggerMessage(
        Level = LogLevel.Information,
        Message = "Checking existence of role {RoleName}")]
    private partial void LogCheckingRoleExists(string roleName);

    [LoggerMessage(
        Level = LogLevel.Information,
        Message = "Retrieving role by ID {RoleId}")]
    private partial void LogRetrievingRoleById(string roleId);

    [LoggerMessage(
        Level = LogLevel.Information,
        Message = "Retrieving role by name {RoleName}")]
    private partial void LogRetrievingRoleByName(string roleName);

    [LoggerMessage(
        Level = LogLevel.Error,
        Message = "Failed roles service error occurred, contact support.")]
    private partial void LogFailedRolesServiceException(Exception exception);
}