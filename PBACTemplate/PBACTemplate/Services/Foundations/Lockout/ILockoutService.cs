// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// ILockoutService.cs See LICENSE.txt in the root folder of the solution.

using PBACTemplate.Models.User;

namespace PBACTemplate.Services.Foundations.Lockout;

public interface ILockoutService
{
    ValueTask<bool> IsLockedOutAsync(ApplicationUser user);
    ValueTask<ApplicationUser> SetLockoutEnabledAsync(ApplicationUser user, bool enabled);
    ValueTask<bool> GetLockoutEnabledAsync(ApplicationUser user);
    ValueTask<DateTimeOffset?> RetrieveLockoutEndDateAsync(ApplicationUser user);
    ValueTask<ApplicationUser> SetLockoutEndDateAsync(ApplicationUser user, DateTimeOffset? lockoutEnd);
    ValueTask<ApplicationUser> RecordAccessFailedAsync(ApplicationUser user);
    ValueTask<ApplicationUser> ResetAccessFailedCountAsync(ApplicationUser user);
    ValueTask<int> RetrieveAccessFailedCountAsync(ApplicationUser user);
}