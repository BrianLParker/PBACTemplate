// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// UserManagerBroker.Roles.cs See LICENSE.txt in the root folder of the solution.

using Microsoft.AspNetCore.Identity;
using PBACTemplate.Models.User;

namespace PBACTemplate.Brokers.User;

public sealed partial class UserManagerBroker
{
    public Task<IdentityResult> AddToRoleAsync(ApplicationUser user, string role) =>
        userManager.AddToRoleAsync(user, role);

    public Task<IdentityResult> AddToRolesAsync(ApplicationUser user, IEnumerable<string> roles) =>
        userManager.AddToRolesAsync(user, roles);

    public Task<IdentityResult> RemoveFromRoleAsync(ApplicationUser user, string role) =>
        userManager.RemoveFromRoleAsync(user, role);

    public Task<IdentityResult> RemoveFromRolesAsync(ApplicationUser user, IEnumerable<string> roles) =>
        userManager.RemoveFromRolesAsync(user, roles);

    public Task<IList<string>> GetRolesAsync(ApplicationUser user) =>
        userManager.GetRolesAsync(user);

    public Task<bool> IsInRoleAsync(ApplicationUser user, string role) =>
        userManager.IsInRoleAsync(user, role);

    public Task<IList<ApplicationUser>> GetUsersInRoleAsync(string roleName) =>
        userManager.GetUsersInRoleAsync(roleName);
}