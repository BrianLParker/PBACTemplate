// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// IUserManagerBroker.Roles.cs See LICENSE.txt in the root folder of the solution.

using Microsoft.AspNetCore.Identity;
using PBACTemplate.Data;

namespace PBACTemplate.Brokers.User;

public partial interface IUserManagerBroker
{
    // Role operations
    Task<IdentityResult> AddToRoleAsync(ApplicationUser user, string role);
    Task<IdentityResult> AddToRolesAsync(ApplicationUser user, IEnumerable<string> roles);
    Task<IdentityResult> RemoveFromRoleAsync(ApplicationUser user, string role);
    Task<IdentityResult> RemoveFromRolesAsync(ApplicationUser user, IEnumerable<string> roles);
    Task<IList<string>> GetRolesAsync(ApplicationUser user);
    Task<bool> IsInRoleAsync(ApplicationUser user, string role);
    Task<IList<ApplicationUser>> GetUsersInRoleAsync(string roleName);
}