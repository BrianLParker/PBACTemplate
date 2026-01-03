// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// IUserOrchestrationService.Roles.cs See LICENSE.txt in the root folder of the solution.

using Microsoft.AspNetCore.Identity;
using PBACTemplate.Data;

namespace PBACTemplate.Services.Orchestrations.Users;

public partial interface IUserOrchestrationService
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