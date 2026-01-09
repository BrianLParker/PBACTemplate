// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// LockoutService.cs See LICENSE.txt in the root folder of the solution.

using PBACTemplate.Brokers.User;
using PBACTemplate.Models.User;

namespace PBACTemplate.Services.Foundations.Lockout;

public sealed partial class LockoutService(
    IUserManagerBroker userManagerBroker,
    ILogger<LockoutService> logger) : ILockoutService
{
    private readonly IUserManagerBroker userManagerBroker = userManagerBroker;
    private readonly ILogger<LockoutService> logger = logger;

    public ValueTask<bool> IsLockedOutAsync(ApplicationUser user) =>
        TryCatch(async () =>
        {
            ValidateUser(user);

            LogCheckingIsLockedOut(user.Id);

            return await this.userManagerBroker.IsLockedOutAsync(user);
        });

    public ValueTask<ApplicationUser> SetLockoutEnabledAsync(ApplicationUser user, bool enabled) =>
        TryCatch(async () =>
        {
            ValidateUser(user);

            LogSettingLockoutEnabled(user.Id, enabled);

            var result = await this.userManagerBroker.SetLockoutEnabledAsync(user, enabled);
            ValidateIdentityResult(result);

            return user;
        });

    public ValueTask<bool> GetLockoutEnabledAsync(ApplicationUser user) =>
        TryCatch(async () =>
        {
            ValidateUser(user);

            LogGettingLockoutEnabled(user.Id);

            return await this.userManagerBroker.GetLockoutEnabledAsync(user);
        });

    public ValueTask<DateTimeOffset?> RetrieveLockoutEndDateAsync(ApplicationUser user) =>
        TryCatch(async () =>
        {
            ValidateUser(user);

            LogRetrievingLockoutEndDate(user.Id);

            return await this.userManagerBroker.GetLockoutEndDateAsync(user);
        });

    public ValueTask<ApplicationUser> SetLockoutEndDateAsync(ApplicationUser user, DateTimeOffset? lockoutEnd) =>
        TryCatch(async () =>
        {
            ValidateUser(user);

            LogSettingLockoutEndDate(user.Id, lockoutEnd);

            var result = await this.userManagerBroker.SetLockoutEndDateAsync(user, lockoutEnd);
            ValidateIdentityResult(result);

            return user;
        });

    public ValueTask<ApplicationUser> RecordAccessFailedAsync(ApplicationUser user) =>
        TryCatch(async () =>
        {
            ValidateUser(user);

            LogRecordingAccessFailed(user.Id);

            var result = await this.userManagerBroker.AccessFailedAsync(user);
            ValidateIdentityResult(result);

            return user;
        });

    public ValueTask<ApplicationUser> ResetAccessFailedCountAsync(ApplicationUser user) =>
        TryCatch(async () =>
        {
            ValidateUser(user);

            LogResettingAccessFailedCount(user.Id);

            var result = await this.userManagerBroker.ResetAccessFailedCountAsync(user);
            ValidateIdentityResult(result);

            return user;
        });

    public ValueTask<int> RetrieveAccessFailedCountAsync(ApplicationUser user) =>
        TryCatch(async () =>
        {
            ValidateUser(user);

            LogRetrievingAccessFailedCount(user.Id);

            return await this.userManagerBroker.GetAccessFailedCountAsync(user);
        });
}