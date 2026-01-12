// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// IAccountOrchestrationService.RecoveryCodes.cs See LICENSE.txt in the root folder of the solution.

using Microsoft.AspNetCore.Identity;
using PBACTemplate.Models.User;

namespace PBACTemplate.Services.Orchestrations.Account;

public partial interface IAccountOrchestrationService
{
    // Recovery code operations
    Task<IEnumerable<string>?> GenerateNewTwoFactorRecoveryCodesAsync(ApplicationUser user, int number);
    Task<IdentityResult> RedeemTwoFactorRecoveryCodeAsync(ApplicationUser user, string code);
    Task<int> CountRecoveryCodesAsync(ApplicationUser user);
}