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
    IRoleManagerBroker roleManagerBroker,
    ILogger<AdministrationOrchestrationService> logger) : IAdministrationOrchestrationService
{
    private readonly IRoleClaimsService roleClaimsService = roleClaimsService;
    private readonly IRolesService rolesService = rolesService;
    private readonly IRoleManagerBroker roleManagerBroker = roleManagerBroker;
    private readonly ILogger<AdministrationOrchestrationService> logger = logger;

    public IQueryable<IdentityRole> Roles => this.roleManagerBroker.Roles;

    public Task<IdentityResult> AddClaimAsync(IdentityRole role, Claim claim) =>
        TryCatch(async () =>
        {
            await this.roleClaimsService.AddClaimAsync(role, claim);
            return IdentityResult.Success;
        });

    public Task<IdentityResult> CreateAsync(IdentityRole role) =>
        TryCatch(async () => await this.roleManagerBroker.CreateAsync(role));

    public Task<IdentityResult> DeleteAsync(IdentityRole role) =>
        TryCatch(async () => await this.roleManagerBroker.DeleteAsync(role));

    public Task<IdentityRole?> FindByIdAsync(string roleId) =>
        TryCatch(async () => await this.rolesService.RetrieveRoleByIdAsync(roleId));

    public Task<IdentityRole?> FindByNameAsync(string roleName) =>
        TryCatch(async () => await this.rolesService.RetrieveRoleByNameAsync(roleName));

    public Task<IList<Claim>> GetClaimsAsync(IdentityRole role) =>
        TryCatch(async () => await this.roleClaimsService.RetrieveClaimsAsync(role));

    public Task<string> GetRoleIdAsync(IdentityRole role) =>
        TryCatch(async () => await this.roleManagerBroker.GetRoleIdAsync(role));

    public Task<string?> GetRoleNameAsync(IdentityRole role) =>
        TryCatch(async () => await this.roleManagerBroker.GetRoleNameAsync(role));

    public Task<IdentityResult> RemoveClaimAsync(IdentityRole role, Claim claim) =>
        TryCatch(async () =>
        {
            await this.roleClaimsService.RemoveClaimAsync(role, claim);
            return IdentityResult.Success;
        });

    public Task<bool> RoleExistsAsync(string roleName) =>
        TryCatch(async () => await this.rolesService.RoleExistsAsync(roleName));

    public Task<IdentityResult> SetRoleNameAsync(IdentityRole role, string name) =>
        TryCatch(async () =>
        {
            await this.rolesService.UpdateRoleNameAsync(role, name);
            return IdentityResult.Success;
        });

    public Task<IdentityResult> UpdateAsync(IdentityRole role) =>
        TryCatch(async () => await this.roleManagerBroker.UpdateAsync(role));
}
