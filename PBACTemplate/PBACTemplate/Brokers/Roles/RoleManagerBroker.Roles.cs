// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// RoleManagerBroker.Roles.cs See LICENSE.txt in the root folder of the solution.

using Microsoft.AspNetCore.Identity;

namespace PBACTemplate.Brokers.Roles;

public sealed partial class RoleManagerBroker
{
    public Task<IdentityResult> CreateAsync(IdentityRole role) =>
        roleManager.CreateAsync(role);

    public Task<IdentityResult> UpdateAsync(IdentityRole role) =>
        roleManager.UpdateAsync(role);

    public Task<IdentityResult> DeleteAsync(IdentityRole role) =>
        roleManager.DeleteAsync(role);

    public Task<bool> RoleExistsAsync(string roleName) =>
        roleManager.RoleExistsAsync(roleName);

    public Task<IdentityRole?> FindByIdAsync(string roleId) =>
        roleManager.FindByIdAsync(roleId);

    public Task<IdentityRole?> FindByNameAsync(string roleName) =>
        roleManager.FindByNameAsync(roleName);

    public Task<string> GetRoleIdAsync(IdentityRole role) =>
        roleManager.GetRoleIdAsync(role);

    public Task<string?> GetRoleNameAsync(IdentityRole role) =>
        roleManager.GetRoleNameAsync(role);

    public Task<IdentityResult> SetRoleNameAsync(IdentityRole role, string name) =>
        roleManager.SetRoleNameAsync(role, name);
}