// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// RedirectToLogin.cs See LICENSE.txt in the root folder of the solution.

using Microsoft.AspNetCore.Components;
using PBACTemplate.Client.Services.Orchestration.Navigation;

namespace PBACTemplate.Client.Components;

public class RedirectToLogin : ComponentBase
{
    [Inject]
    private INavigationOrchestrationService NavigationService { get; set; } = default!;

    protected override void OnInitialized() => NavigationService.RedirectToLogin();
}