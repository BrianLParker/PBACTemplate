// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// RolesService.cs See LICENSE.txt in the root folder of the solution.

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PBACTemplate.Brokers.Roles;
using PBACTemplate.Services.Foundations.Roles.Exceptions;
using System.Collections.Immutable;

namespace PBACTemplate.Services.Foundations.Roles;

public sealed partial class RolesService(
    IRoleManagerBroker roleManagerBroker,
    ILogger<RolesService> logger) : IRolesService
{
    private readonly IRoleManagerBroker roleManagerBroker = roleManagerBroker;
    private readonly ILogger<RolesService> logger = logger;

    public ValueTask<string> CreateRoleAsync(string roleName) =>
        TryCatch(async () =>
        {
            ValidateRoleName(roleName);

            LogCreatingRole(roleName);

            bool exists = await roleManagerBroker.RoleExistsAsync(roleName);

            if (exists)
            {
                throw new InvalidRolesException($"Role '{roleName}' already exists.");
            }

            IdentityRole role = new(roleName);

            IdentityResult result = await roleManagerBroker.CreateAsync(role);

            ValidateIdentityResult(result);

            return roleName;
        });

    public ValueTask<bool> RemoveRoleAsync(string roleName) =>
        TryCatch(async () =>
        {
            ValidateRoleName(roleName);

            IdentityRole? role = await roleManagerBroker.FindByNameAsync(roleName);

            if (role is null)
            {
                throw new NullRolesException($"Role '{roleName}' was not found.");
            }

            LogRemovingRole(roleName);

            IdentityResult result = await roleManagerBroker.DeleteAsync(role);

            ValidateIdentityResult(result);

            return true;
        });

    public ValueTask<string?> RetrieveRoleAsync(string roleName) =>
        TryCatch(async () =>
        {
            ValidateRoleName(roleName);

            LogRetrievingRole(roleName);

            IdentityRole? role = await roleManagerBroker.FindByNameAsync(roleName);

            if (role is null)
            {
                return null;
            }

            return await roleManagerBroker.GetRoleNameAsync(role);
        });

    public ValueTask<ImmutableList<string>> RetrieveRolesAsync() =>
        TryCatch(async () =>
        {
            LogRetrievingRoles();

            List<string> roleNames = await roleManagerBroker.Roles
                .Select(role => role.Name!)
                .Where(name => !string.IsNullOrWhiteSpace(name))
                .ToListAsync();

            return roleNames.ToImmutableList();
        });

    public ValueTask<string> UpdateRoleAsync(string roleName, string newRoleName) =>
        TryCatch(async () =>
        {
            ValidateRoleName(roleName);
            ValidateRoleName(newRoleName);

            IdentityRole? role = await roleManagerBroker.FindByNameAsync(roleName);

            if (role is null)
            {
                throw new NullRolesException($"Role '{roleName}' was not found.");
            }

            if (!string.Equals(roleName, newRoleName, StringComparison.OrdinalIgnoreCase))
            {
                bool duplicate = await roleManagerBroker.RoleExistsAsync(newRoleName);

                if (duplicate)
                {
                    throw new InvalidRolesException($"Role '{newRoleName}' already exists.");
                }
            }

            LogUpdatingRole(roleName, newRoleName);

            IdentityResult renameResult = await roleManagerBroker.SetRoleNameAsync(role, newRoleName);
            ValidateIdentityResult(renameResult);

            IdentityResult updateResult = await roleManagerBroker.UpdateAsync(role);
            ValidateIdentityResult(updateResult);

            return newRoleName;
        });
}