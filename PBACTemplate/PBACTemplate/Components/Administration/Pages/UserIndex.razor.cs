// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// UserIndex.razor.cs See LICENSE.txt in the root folder of the solution.

using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using PBACTemplate.Client.Models;
using PBACTemplate.Models.Administration;
using PBACTemplate.Models.User;
using PBACTemplate.Services.Orchestrations.Account;

namespace PBACTemplate.Components.Administration.Pages;

public partial class UserIndex
{
    private List<ApplicationUser>? Users;

    [Inject]
    private IAccountOrchestrationService AccountOrchestrationService { get; set; } = default!;

    protected override async Task OnInitializedAsync()
    {
        Users = await AccountOrchestrationService.Users.ToListAsync();
    }
}