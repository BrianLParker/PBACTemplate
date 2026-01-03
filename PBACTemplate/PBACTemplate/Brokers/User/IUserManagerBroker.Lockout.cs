// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// IUserManagerBroker.Lockout.cs See LICENSE.txt in the root folder of the solution.

using Microsoft.AspNetCore.Identity;
using PBACTemplate.Data;

namespace PBACTemplate.Brokers.User;

public partial interface IUserManagerBroker
{
    // Lockout operations
    Task<bool> IsLockedOutAsync(ApplicationUser user);
    Task<IdentityResult> SetLockoutEnabledAsync(ApplicationUser user, bool enabled);
    Task<bool> GetLockoutEnabledAsync(ApplicationUser user);
    Task<DateTimeOffset?> GetLockoutEndDateAsync(ApplicationUser user);
    Task<IdentityResult> SetLockoutEndDateAsync(ApplicationUser user, DateTimeOffset? lockoutEnd);
    Task<IdentityResult> AccessFailedAsync(ApplicationUser user);
    Task<IdentityResult> ResetAccessFailedCountAsync(ApplicationUser user);
    Task<int> GetAccessFailedCountAsync(ApplicationUser user);
}