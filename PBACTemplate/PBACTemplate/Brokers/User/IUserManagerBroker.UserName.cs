// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// IUserManagerBroker.UserName.cs See LICENSE.txt in the root folder of the solution.

using Microsoft.AspNetCore.Identity;
using PBACTemplate.Models.User;
using System.Security.Claims;

namespace PBACTemplate.Brokers.User;

public partial interface IUserManagerBroker
{
    // User name operations
    string? GetUserName(ClaimsPrincipal principal);
    Task<string?> GetUserNameAsync(ApplicationUser user);
    Task<IdentityResult> SetUserNameAsync(ApplicationUser user, string? userName);
    Task UpdateNormalizedUserNameAsync(ApplicationUser user);
    string? NormalizeName(string? name);

    // User ID operations
    string? GetUserId(ClaimsPrincipal principal);
    Task<string> GetUserIdAsync(ApplicationUser user);
    Task<ApplicationUser?> GetUserAsync(ClaimsPrincipal principal);
}