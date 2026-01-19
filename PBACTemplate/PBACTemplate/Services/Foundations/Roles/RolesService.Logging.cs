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
        Message = "Removing role {RoleName}")]
    private partial void LogRemovingRole(string roleName);

    [LoggerMessage(
        Level = LogLevel.Information,
        Message = "Retrieving role {RoleName}")]
    private partial void LogRetrievingRole(string roleName);

    [LoggerMessage(
        Level = LogLevel.Information,
        Message = "Retrieving all roles")]
    private partial void LogRetrievingRoles();

    [LoggerMessage(
        Level = LogLevel.Information,
        Message = "Updating role {RoleName} to {NewRoleName}")]
    private partial void LogUpdatingRole(string roleName, string newRoleName);

    [LoggerMessage(
        Level = LogLevel.Error,
        Message = "Failed roles service error occurred, contact support.")]
    private partial void LogFailedRolesServiceException(Exception exception);
}