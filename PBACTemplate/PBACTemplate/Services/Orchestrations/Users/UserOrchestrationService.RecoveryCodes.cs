// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// UserOrchestrationService.RecoveryCodes.cs See LICENSE.txt in the root folder of the solution.

using Microsoft.AspNetCore.Identity;
using PBACTemplate.Data;

namespace PBACTemplate.Services.Orchestrations.Users;

public partial class UserOrchestrationService
{
    public async Task<IEnumerable<string>?> GenerateNewTwoFactorRecoveryCodesAsync(ApplicationUser user, int number) =>
        await this.recoveryCodesService.GenerateNewTwoFactorRecoveryCodesAsync(user, number);

    public async Task<IdentityResult> RedeemTwoFactorRecoveryCodeAsync(ApplicationUser user, string code)
    {
        await this.recoveryCodesService.RedeemTwoFactorRecoveryCodeAsync(user, code);

        return IdentityResult.Success;
    }

    public async Task<int> CountRecoveryCodesAsync(ApplicationUser user) =>
        await this.recoveryCodesService.CountRecoveryCodesAsync(user);
}