// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// AccountOrchestrationService.Lockout.cs See LICENSE.txt in the root folder of the solution.

using Microsoft.AspNetCore.Identity;
using PBACTemplate.Models.User;

namespace PBACTemplate.Services.Orchestrations.Account;

public partial class AccountOrchestrationService
{
    public async Task<bool> IsLockedOutAsync(ApplicationUser user) =>
        await this.lockoutService.IsLockedOutAsync(user);

    public async Task<IdentityResult> SetLockoutEnabledAsync(ApplicationUser user, bool enabled)
    {
        await this.lockoutService.SetLockoutEnabledAsync(user, enabled);

        return IdentityResult.Success;
    }

    public async Task<bool> GetLockoutEnabledAsync(ApplicationUser user) =>
        await this.lockoutService.GetLockoutEnabledAsync(user);

    public async Task<DateTimeOffset?> GetLockoutEndDateAsync(ApplicationUser user) =>
        await this.lockoutService.RetrieveLockoutEndDateAsync(user);

    public async Task<IdentityResult> SetLockoutEndDateAsync(ApplicationUser user, DateTimeOffset? lockoutEnd)
    {
        await this.lockoutService.SetLockoutEndDateAsync(user, lockoutEnd);

        return IdentityResult.Success;
    }

    public async Task<IdentityResult> AccessFailedAsync(ApplicationUser user)
    {
        await this.lockoutService.RecordAccessFailedAsync(user);

        return IdentityResult.Success;
    }

    public async Task<IdentityResult> ResetAccessFailedCountAsync(ApplicationUser user)
    {
        await this.lockoutService.ResetAccessFailedCountAsync(user);

        return IdentityResult.Success;
    }

    public async Task<int> GetAccessFailedCountAsync(ApplicationUser user) =>
        await this.lockoutService.RetrieveAccessFailedCountAsync(user);
}