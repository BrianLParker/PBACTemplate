// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// RoleIndex.razor.cs See LICENSE.txt in the root folder of the solution.

using Microsoft.AspNetCore.Components;
using PBACTemplate.Services.Orchestrations.Administration;
using System.Collections.Immutable;

namespace PBACTemplate.Components.Administration.Pages;

public partial class RoleIndex
{
    private ImmutableList<string>? Roles;

    [Inject]
    private IAdministrationOrchestrationService AdministrationOrchestrationService { get; set; } = default!;

    protected override async Task OnInitializedAsync()
    {
        Roles = await AdministrationOrchestrationService.RetrieveRolesAsync();
    }

}