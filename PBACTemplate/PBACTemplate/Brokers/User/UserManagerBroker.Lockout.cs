// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// UserManagerBroker.Lockout.cs See LICENSE.txt in the root folder of the solution.

using Microsoft.AspNetCore.Identity;
using PBACTemplate.Models.User;

namespace PBACTemplate.Brokers.User;

public sealed partial class UserManagerBroker
{
    public Task<bool> IsLockedOutAsync(ApplicationUser user) =>
        userManager.IsLockedOutAsync(user);

    public Task<IdentityResult> SetLockoutEnabledAsync(ApplicationUser user, bool enabled) =>
        userManager.SetLockoutEnabledAsync(user, enabled);

    public Task<bool> GetLockoutEnabledAsync(ApplicationUser user) =>
        userManager.GetLockoutEnabledAsync(user);

    public Task<DateTimeOffset?> GetLockoutEndDateAsync(ApplicationUser user) =>
        userManager.GetLockoutEndDateAsync(user);

    public Task<IdentityResult> SetLockoutEndDateAsync(ApplicationUser user, DateTimeOffset? lockoutEnd) =>
        userManager.SetLockoutEndDateAsync(user, lockoutEnd);

    public Task<IdentityResult> AccessFailedAsync(ApplicationUser user) =>
        userManager.AccessFailedAsync(user);

    public Task<IdentityResult> ResetAccessFailedCountAsync(ApplicationUser user) =>
        userManager.ResetAccessFailedCountAsync(user);

    public Task<int> GetAccessFailedCountAsync(ApplicationUser user) =>
        userManager.GetAccessFailedCountAsync(user);
}