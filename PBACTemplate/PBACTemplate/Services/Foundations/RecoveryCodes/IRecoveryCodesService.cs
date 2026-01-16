// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// IRecoveryCodesService.cs See LICENSE.txt in the root folder of the solution.

using PBACTemplate.Models.Users;

namespace PBACTemplate.Services.Foundations.RecoveryCodes;

public interface IRecoveryCodesService
{
    ValueTask<IEnumerable<string>?> GenerateNewTwoFactorRecoveryCodesAsync(ApplicationUser user, int number);
    ValueTask<ApplicationUser> RedeemTwoFactorRecoveryCodeAsync(ApplicationUser user, string code);
    ValueTask<int> CountRecoveryCodesAsync(ApplicationUser user);
}