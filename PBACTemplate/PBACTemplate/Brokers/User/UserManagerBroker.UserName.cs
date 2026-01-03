// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// UserManagerBroker.UserName.cs See LICENSE.txt in the root folder of the solution.

using Microsoft.AspNetCore.Identity;
using PBACTemplate.Data;
using System.Security.Claims;

namespace PBACTemplate.Brokers.User;

public sealed partial class UserManagerBroker
{
    public string? GetUserName(ClaimsPrincipal principal) =>
        userManager.GetUserName(principal);

    public Task<string?> GetUserNameAsync(ApplicationUser user) =>
        userManager.GetUserNameAsync(user);

    public Task<IdentityResult> SetUserNameAsync(ApplicationUser user, string? userName) =>
        userManager.SetUserNameAsync(user, userName);

    public Task UpdateNormalizedUserNameAsync(ApplicationUser user) =>
        userManager.UpdateNormalizedUserNameAsync(user);

    public string? NormalizeName(string? name) =>
        userManager.NormalizeName(name);

    public string? GetUserId(ClaimsPrincipal principal) =>
        userManager.GetUserId(principal);

    public Task<string> GetUserIdAsync(ApplicationUser user) =>
        userManager.GetUserIdAsync(user);

    public Task<ApplicationUser?> GetUserAsync(ClaimsPrincipal principal) =>
        userManager.GetUserAsync(principal);
}