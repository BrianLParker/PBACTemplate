// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// IUserOrchestrationService.Lockout.cs See LICENSE.txt in the root folder of the solution.

using Microsoft.AspNetCore.Identity;
using PBACTemplate.Models.User;

namespace PBACTemplate.Services.Orchestrations.Users;

public partial interface IUserOrchestrationService
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