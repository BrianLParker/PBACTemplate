// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// IUserOrchestrationService.RecoveryCodes.cs See LICENSE.txt in the root folder of the solution.

using Microsoft.AspNetCore.Identity;
using PBACTemplate.Data;

namespace PBACTemplate.Services.Orchestrations.Users;

public partial interface IUserOrchestrationService
{
    // Recovery code operations
    Task<IEnumerable<string>?> GenerateNewTwoFactorRecoveryCodesAsync(ApplicationUser user, int number);
    Task<IdentityResult> RedeemTwoFactorRecoveryCodeAsync(ApplicationUser user, string code);
    Task<int> CountRecoveryCodesAsync(ApplicationUser user);
}