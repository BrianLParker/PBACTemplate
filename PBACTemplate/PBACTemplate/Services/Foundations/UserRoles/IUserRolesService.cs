// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// IUserRolesService.cs See LICENSE.txt in the root folder of the solution.

using PBACTemplate.Models.User;

namespace PBACTemplate.Services.Foundations.UserRoles;

public interface IUserRolesService
{
    ValueTask<ApplicationUser> AddToRoleAsync(ApplicationUser user, string role);
    ValueTask<ApplicationUser> AddToRolesAsync(ApplicationUser user, IEnumerable<string> roles);
    ValueTask<ApplicationUser> RemoveFromRoleAsync(ApplicationUser user, string role);
    ValueTask<ApplicationUser> RemoveFromRolesAsync(ApplicationUser user, IEnumerable<string> roles);
    ValueTask<IList<string>> RetrieveRolesAsync(ApplicationUser user);
    ValueTask<bool> IsInRoleAsync(ApplicationUser user, string role);
    ValueTask<IList<ApplicationUser>> RetrieveUsersInRoleAsync(string roleName);
}