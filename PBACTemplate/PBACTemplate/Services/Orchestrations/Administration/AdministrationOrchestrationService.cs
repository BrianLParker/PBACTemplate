// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// AdministrationOrchestrationService.cs See LICENSE.txt in the root folder of the solution.

using Microsoft.AspNetCore.Identity;
using PBACTemplate.Brokers.Roles;
using PBACTemplate.Services.Foundations.RoleClaims;
using PBACTemplate.Services.Foundations.Roles;
using System.Security.Claims;

namespace PBACTemplate.Services.Orchestrations.Administration;

public sealed partial class AdministrationOrchestrationService(
    IRoleClaimsService roleClaimsService,
    IRolesService rolesService,
    ILogger<AdministrationOrchestrationService> logger) : IAdministrationOrchestrationService
{
    private readonly IRoleClaimsService roleClaimsService = roleClaimsService;
    private readonly IRolesService rolesService = rolesService;
    private readonly ILogger<AdministrationOrchestrationService> logger = logger;

    public IQueryable<IdentityRole> Roles => this.rolesService.Roles;

    public ValueTask<IdentityRole> AddClaimAsync(IdentityRole role, Claim claim) =>
        TryCatch(() => this.roleClaimsService.AddClaimAsync(role, claim));

    public ValueTask<IdentityRole> CreateRoleAsync(string roleName) =>
        TryCatch(() => this.rolesService.CreateRoleAsync(roleName));

    public ValueTask<IdentityRole> DeleteRoleAsync(IdentityRole role) =>
        TryCatch(() => this.rolesService.DeleteRoleAsync(role));

    public ValueTask<IdentityRole> RemoveClaimAsync(IdentityRole role, Claim claim) =>
        TryCatch(() => this.roleClaimsService.RemoveClaimAsync(role, claim));

    public ValueTask<IList<Claim>> RetrieveClaimsAsync(IdentityRole role) =>
        TryCatch(() => this.roleClaimsService.RetrieveClaimsAsync(role));

    public ValueTask<IdentityRole?> RetrieveRoleByIdAsync(string roleId) =>
        TryCatch(() => this.rolesService.RetrieveRoleByIdAsync(roleId));

    public ValueTask<IdentityRole?> RetrieveRoleByNameAsync(string roleName) =>
        TryCatch(() => this.rolesService.RetrieveRoleByNameAsync(roleName));

    public ValueTask<bool> RoleExistsAsync(string roleName) =>
        TryCatch(() => this.rolesService.RoleExistsAsync(roleName));

    public ValueTask<IdentityRole> UpdateRoleNameAsync(IdentityRole role, string newName) =>
        TryCatch(() => this.rolesService.UpdateRoleNameAsync(role, newName));
}
