// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// NavigationService.Logging.cs See LICENSE.txt in the root folder of the solution.

namespace PBACTemplate.Client.Services.Foundations.Navigation;

public sealed partial class NavigationService
{
    [LoggerMessage(
        Level = LogLevel.Information,
        Message = "Navigating to {Uri}, force load: {ForceLoad}")]
    private partial void LogNavigatingTo(string uri, bool forceLoad);

    [LoggerMessage(
        Level = LogLevel.Information,
        Message = "Navigating to {Uri}, force load: {ForceLoad}, replace: {Replace}")]
    private partial void LogNavigatingToWithReplace(string uri, bool forceLoad, bool replace);

    [LoggerMessage(
        Level = LogLevel.Information,
        Message = "Navigating to {Uri} with navigation options")]
    private partial void LogNavigatingToWithOptions(string uri);

    [LoggerMessage(
        Level = LogLevel.Information,
        Message = "Refreshing page, force reload: {ForceReload}")]
    private partial void LogRefreshing(bool forceReload);

    [LoggerMessage(
        Level = LogLevel.Information,
        Message = "Triggering not found")]
    private partial void LogNotFound();

    [LoggerMessage(
        Level = LogLevel.Debug,
        Message = "Converting to absolute URI: {RelativeUri}")]
    private partial void LogConvertingToAbsoluteUri(string? relativeUri);

    [LoggerMessage(
        Level = LogLevel.Debug,
        Message = "Converting to base relative path: {Uri}")]
    private partial void LogConvertingToBaseRelativePath(string uri);

    [LoggerMessage(
        Level = LogLevel.Debug,
        Message = "Location changed to: {Location}")]
    private partial void LogLocationChanged(string location);

    [LoggerMessage(
        Level = LogLevel.Warning,
        Message = "Not found event triggered")]
    private partial void LogNotFoundEvent();

    [LoggerMessage(
        Level = LogLevel.Error,
        Message = "Failed navigation service error occurred, contact support.")]
    private partial void LogFailedNavigationServiceException(Exception exception);
}