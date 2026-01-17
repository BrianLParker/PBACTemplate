// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// UserIndex.razor.cs See LICENSE.txt in the root folder of the solution.

using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using PBACTemplate.Client.Models;
using PBACTemplate.Client.Models.Users;
using PBACTemplate.Models.Administration;
using PBACTemplate.Models.Users;
using PBACTemplate.Services.Orchestrations.Administration;

namespace PBACTemplate.Components.Administration.Pages;

public partial class UserIndex
{
    private List<User>? Users;

    [Inject]
    private IAdministrationOrchestrationService AdminService { get; set; } = default!;

    protected override async Task OnInitializedAsync()
    {
        Users = await AdminService.Users.ToListAsync();
    }
}