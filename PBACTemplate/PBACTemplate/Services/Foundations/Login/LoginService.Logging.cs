// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// LoginService.Logging.cs See LICENSE.txt in the root folder of the solution.

namespace PBACTemplate.Services.Foundations.Login;

public partial class LoginService
{
    [LoggerMessage(
        Level = LogLevel.Information,
        Message = "Adding login {LoginProvider} for user {UserId}")]
    private partial void LogAddingLogin(string userId, string loginProvider);

    [LoggerMessage(
        Level = LogLevel.Information,
        Message = "Removing login {LoginProvider} for user {UserId}")]
    private partial void LogRemovingLogin(string userId, string loginProvider);

    [LoggerMessage(
        Level = LogLevel.Information,
        Message = "Retrieving logins for user {UserId}")]
    private partial void LogRetrievingLogins(string userId);

    [LoggerMessage(
        Level = LogLevel.Error,
        Message = "Failed login service error occurred, contact support.")]
    private partial void LogFailedLoginServiceException(Exception exception);
}