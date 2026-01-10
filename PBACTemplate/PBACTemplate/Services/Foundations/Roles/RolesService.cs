// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// RolesService.cs See LICENSE.txt in the root folder of the solution.

using Microsoft.AspNetCore.Identity;
using PBACTemplate.Brokers.Roles;

namespace PBACTemplate.Services.Foundations.Roles;

public sealed partial class RolesService(
    IRoleManagerBroker roleManagerBroker,
    ILogger<RolesService> logger) : IRolesService
{
    private readonly IRoleManagerBroker roleManagerBroker = roleManagerBroker;
    private readonly ILogger<RolesService> logger = logger;

    public ValueTask<IdentityRole> CreateRoleAsync(string roleName) =>
        TryCatch(async () =>
        {
            ValidateRoleName(roleName);

            LogCreatingRole(roleName);

            var role = new IdentityRole(roleName);
            var result = await this.roleManagerBroker.CreateAsync(role);
            ValidateIdentityResult(result);

            return role;
        });

    public ValueTask<IdentityRole> UpdateRoleNameAsync(IdentityRole role, string newName) =>
        TryCatch(async () =>
        {
            ValidateRole(role);
            ValidateRoleName(newName);

            LogUpdatingRoleName(role.Id, newName);

            var result = await this.roleManagerBroker.SetRoleNameAsync(role, newName);
            ValidateIdentityResult(result);

            result = await this.roleManagerBroker.UpdateAsync(role);
            ValidateIdentityResult(result);

            return role;
        });

    public ValueTask<IdentityRole> DeleteRoleAsync(IdentityRole role) =>
        TryCatch(async () =>
        {
            ValidateRole(role);

            LogDeletingRole(role.Id);

            var result = await this.roleManagerBroker.DeleteAsync(role);
            ValidateIdentityResult(result);

            return role;
        });

    public ValueTask<bool> RoleExistsAsync(string roleName) =>
        TryCatch(async () =>
        {
            ValidateRoleName(roleName);

            LogCheckingRoleExists(roleName);

            return await this.roleManagerBroker.RoleExistsAsync(roleName);
        });

    public ValueTask<IdentityRole?> RetrieveRoleByIdAsync(string roleId) =>
        TryCatch(async () =>
        {
            ValidateRoleId(roleId);

            LogRetrievingRoleById(roleId);

            return await this.roleManagerBroker.FindByIdAsync(roleId);
        });

    public ValueTask<IdentityRole?> RetrieveRoleByNameAsync(string roleName) =>
        TryCatch(async () =>
        {
            ValidateRoleName(roleName);

            LogRetrievingRoleByName(roleName);

            return await this.roleManagerBroker.FindByNameAsync(roleName);
        });
}