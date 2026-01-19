// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// IRoleService.cs See LICENSE.txt in the root folder of the solution.

namespace PBACTemplate.Client.Services.Foundations.Roles;

public interface IRoleService
{
    ValueTask<IReadOnlyList<string>> RetrieveRolesAsync();
    ValueTask<string?> RetrieveRoleAsync(string roleName);
    ValueTask<string> CreateRoleAsync(string roleName);
    ValueTask<string> UpdateRoleAsync(string roleName, string newRoleName);
    ValueTask<bool> RemoveRoleAsync(string roleName);
}
