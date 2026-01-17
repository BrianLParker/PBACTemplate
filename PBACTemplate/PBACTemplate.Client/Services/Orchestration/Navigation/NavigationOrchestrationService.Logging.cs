// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// NavigationOrchestrationService.Logging.cs See LICENSE.txt in the root folder of the solution.

namespace PBACTemplate.Client.Services.Orchestration.Navigation;

public partial class NavigationOrchestrationService
{
    [LoggerMessage(Level = LogLevel.Information, Message = "Redirecting to login with returnUrl: {ReturnUrl}")]
    public partial void LogRedirectToLogin(string returnUrl);
}
