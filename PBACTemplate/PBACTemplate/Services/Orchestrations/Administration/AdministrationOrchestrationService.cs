// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// AdministrationOrchestrationService.cs See LICENSE.txt in the root folder of the solution.

using PBACTemplate.Models.Users;
using PBACTemplate.Services.Foundations.RoleClaims;
using PBACTemplate.Services.Foundations.Roles;
using PBACTemplate.Services.Foundations.UserCrud;
using System.Collections.Immutable;

namespace PBACTemplate.Services.Orchestrations.Administration;

public sealed partial class AdministrationOrchestrationService(
    IRoleClaimsService roleClaimsService,
    IRolesService rolesService,
    IUserCrudService userCrudService,
    ILogger<AdministrationOrchestrationService> logger) : IAdministrationOrchestrationService
{
    private readonly IRoleClaimsService roleClaimsService = roleClaimsService;
    private readonly IRolesService rolesService = rolesService;
    private readonly IUserCrudService userCrudService = userCrudService;
    private readonly ILogger<AdministrationOrchestrationService> logger = logger;

    public async ValueTask<ImmutableList<string>> RetrieveRolesAsync() => await this.rolesService.RetrieveRolesAsync();
    public IQueryable<ApplicationUser> Users => this.userCrudService.Users;

}
