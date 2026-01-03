// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// SecurityService.Logging.cs See LICENSE.txt in the root folder of the solution.

namespace PBACTemplate.Services.Foundations.Security;

public partial class SecurityService
{
    [LoggerMessage(
        Level = LogLevel.Information,
        Message = "Retrieving security stamp for user {UserId}")]
    private partial void LogRetrievingSecurityStamp(string userId);

    [LoggerMessage(
        Level = LogLevel.Information,
        Message = "Updating security stamp for user {UserId}")]
    private partial void LogUpdatingSecurityStamp(string userId);

    [LoggerMessage(
        Level = LogLevel.Information,
        Message = "Creating security token for user {UserId}")]
    private partial void LogCreatingSecurityToken(string userId);

    [LoggerMessage(
        Level = LogLevel.Information,
        Message = "Generating concurrency stamp for user {UserId}")]
    private partial void LogGeneratingConcurrencyStamp(string userId);

    [LoggerMessage(
        Level = LogLevel.Error,
        Message = "Failed security service error occurred, contact support.")]
    private partial void LogFailedSecurityServiceException(Exception exception);
}