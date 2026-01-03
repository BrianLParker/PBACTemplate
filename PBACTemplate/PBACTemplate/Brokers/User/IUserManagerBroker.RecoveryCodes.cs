// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// IUserManagerBroker.RecoveryCodes.cs See LICENSE.txt in the root folder of the solution.

using Microsoft.AspNetCore.Identity;
using PBACTemplate.Data;

namespace PBACTemplate.Brokers.User;

public partial interface IUserManagerBroker
{
    // Recovery code operations
    Task<IEnumerable<string>?> GenerateNewTwoFactorRecoveryCodesAsync(ApplicationUser user, int number);
    Task<IdentityResult> RedeemTwoFactorRecoveryCodeAsync(ApplicationUser user, string code);
    Task<int> CountRecoveryCodesAsync(ApplicationUser user);
}