// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// IRolesService.cs See LICENSE.txt in the root folder of the solution.

using Microsoft.AspNetCore.Identity;

namespace PBACTemplate.Services.Foundations.Roles;

public interface IRolesService
{
    IQueryable<IdentityRole> Roles { get; }

    ValueTask<IdentityRole> CreateRoleAsync(string roleName);
    ValueTask<IdentityRole> UpdateRoleNameAsync(IdentityRole role, string newName);
    ValueTask<IdentityRole> DeleteRoleAsync(IdentityRole role);

    ValueTask<bool> RoleExistsAsync(string roleName);
    ValueTask<IdentityRole?> RetrieveRoleByIdAsync(string roleId);
    ValueTask<IdentityRole?> RetrieveRoleByNameAsync(string roleName);
}