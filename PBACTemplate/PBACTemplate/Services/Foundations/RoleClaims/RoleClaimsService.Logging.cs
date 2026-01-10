// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// RoleClaimsService.Logging.cs See LICENSE.txt in the root folder of the solution.

namespace PBACTemplate.Services.Foundations.RoleClaims;

public sealed partial class RoleClaimsService
{
    [LoggerMessage(
        Level = LogLevel.Information,
        Message = "Retrieving claims for role {RoleId}")]
    private partial void LogRetrievingRoleClaims(string roleId);

    [LoggerMessage(
        Level = LogLevel.Information,
        Message = "Adding claim {ClaimType} to role {RoleId}")]
    private partial void LogAddingRoleClaim(string roleId, string claimType);

    [LoggerMessage(
        Level = LogLevel.Information,
        Message = "Removing claim {ClaimType} from role {RoleId}")]
    private partial void LogRemovingRoleClaim(string roleId, string claimType);

    [LoggerMessage(
        Level = LogLevel.Error,
        Message = "Failed role claims service error occurred, contact support.")]
    private partial void LogFailedRoleClaimsServiceException(Exception exception);
}