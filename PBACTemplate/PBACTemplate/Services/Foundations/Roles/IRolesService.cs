// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// IRolesService.cs See LICENSE.txt in the root folder of the solution.

using PBACTemplate.Data;

namespace PBACTemplate.Services.Foundations.Roles;

public interface IRolesService
{
    ValueTask<ApplicationUser> AddToRoleAsync(ApplicationUser user, string role);
    ValueTask<ApplicationUser> AddToRolesAsync(ApplicationUser user, IEnumerable<string> roles);
    ValueTask<ApplicationUser> RemoveFromRoleAsync(ApplicationUser user, string role);
    ValueTask<ApplicationUser> RemoveFromRolesAsync(ApplicationUser user, IEnumerable<string> roles);
    ValueTask<IList<string>> RetrieveRolesAsync(ApplicationUser user);
    ValueTask<bool> IsInRoleAsync(ApplicationUser user, string role);
    ValueTask<IList<ApplicationUser>> RetrieveUsersInRoleAsync(string roleName);
}