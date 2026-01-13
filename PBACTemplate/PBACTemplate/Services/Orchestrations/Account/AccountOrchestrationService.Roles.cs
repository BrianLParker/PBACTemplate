// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// AccountOrchestrationService.Roles.cs See LICENSE.txt in the root folder of the solution.

using Microsoft.AspNetCore.Identity;
using PBACTemplate.Models.User;

namespace PBACTemplate.Services.Orchestrations.Account;

public partial class AccountOrchestrationService
{
    public async Task<IdentityResult> AddToRoleAsync(ApplicationUser user, string role)
    {
        await this.rolesService.AddToRoleAsync(user, role);

        return IdentityResult.Success;
    }

    public async Task<IdentityResult> AddToRolesAsync(ApplicationUser user, IEnumerable<string> roles)
    {
        await this.rolesService.AddToRolesAsync(user, roles);

        return IdentityResult.Success;
    }

    public async Task<IdentityResult> RemoveFromRoleAsync(ApplicationUser user, string role)
    {
        await this.rolesService.RemoveFromRoleAsync(user, role);

        return IdentityResult.Success;
    }

    public async Task<IdentityResult> RemoveFromRolesAsync(ApplicationUser user, IEnumerable<string> roles)
    {
        await this.rolesService.RemoveFromRolesAsync(user, roles);

        return IdentityResult.Success;
    }

    public async Task<IList<string>> GetRolesAsync(ApplicationUser user) =>
        await this.rolesService.RetrieveRolesAsync(user);

    public async Task<bool> IsInRoleAsync(ApplicationUser user, string role) =>
        await this.rolesService.IsInRoleAsync(user, role);

    public async Task<IList<ApplicationUser>> GetUsersInRoleAsync(string roleName) =>
        await this.rolesService.RetrieveUsersInRoleAsync(roleName);
}