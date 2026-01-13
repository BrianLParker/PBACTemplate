// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// RedirectToLogin.cs See LICENSE.txt in the root folder of the solution.

using Microsoft.AspNetCore.Components;
using PBACTemplate.Client.Services.Foundations.Navigation;

namespace PBACTemplate.Client.Components;

public class RedirectToLogin : ComponentBase
{
    [Inject]
    private INavigationService NavigationService { get; set; } = default!;

    protected override void OnInitialized()
    {
        NavigationService.NavigateTo($"Account/Login?returnUrl={Uri.EscapeDataString(NavigationService.Uri)}", forceLoad: true);
    }
}