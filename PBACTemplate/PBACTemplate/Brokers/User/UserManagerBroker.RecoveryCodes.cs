// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// UserManagerBroker.RecoveryCodes.cs See LICENSE.txt in the root folder of the solution.

using Microsoft.AspNetCore.Identity;
using PBACTemplate.Models.Users;

namespace PBACTemplate.Brokers.User;

public sealed partial class UserManagerBroker
{
    public Task<IEnumerable<string>?> GenerateNewTwoFactorRecoveryCodesAsync(ApplicationUser user, int number) =>
        userManager.GenerateNewTwoFactorRecoveryCodesAsync(user, number);

    public Task<IdentityResult> RedeemTwoFactorRecoveryCodeAsync(ApplicationUser user, string code) =>
        userManager.RedeemTwoFactorRecoveryCodeAsync(user, code);

    public Task<int> CountRecoveryCodesAsync(ApplicationUser user) =>
        userManager.CountRecoveryCodesAsync(user);
}