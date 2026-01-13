// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// RoleIndex.razor.cs See LICENSE.txt in the root folder of the solution.

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PBACTemplate.Client.Models;
using PBACTemplate.Services.Orchestrations.Administration;

namespace PBACTemplate.Components.Administration.Pages;

public partial class RoleIndex
{
    private List<IdentityRole>? Roles;

    [Inject]
    private IAdministrationOrchestrationService AdministrationOrchestrationService { get; set; } = default!;

    protected override async Task OnInitializedAsync()
    {
        Roles = await AdministrationOrchestrationService.Roles.ToListAsync();
    }

}