// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// NavigationOrchestrationService.cs See LICENSE.txt in the root folder of the solution.

using PBACTemplate.Client.Services.Foundations.Navigation;

namespace PBACTemplate.Client.Services.Orchestration.Navigation;

public partial class NavigationOrchestrationService(
    INavigationService navigation,
    ILogger<NavigationOrchestrationService> logger) : INavigationOrchestrationService
{
    private readonly INavigationService navigation = navigation;
    private readonly ILogger<NavigationOrchestrationService> logger = logger;

    public void RedirectToLogin()
    {
        string currentUri = Uri.EscapeDataString(navigation.Uri);

        LogRedirectToLogin(currentUri);

        navigation.NavigateTo($"Account/Login?returnUrl={currentUri}", forceLoad: true);
    }
}

