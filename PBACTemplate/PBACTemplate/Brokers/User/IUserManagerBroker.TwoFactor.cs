// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// IUserManagerBroker.TwoFactor.cs See LICENSE.txt in the root folder of the solution.

using Microsoft.AspNetCore.Identity;
using PBACTemplate.Models.Users;

namespace PBACTemplate.Brokers.User;

public partial interface IUserManagerBroker
{
    // Two-factor authentication operations
    Task<bool> GetTwoFactorEnabledAsync(ApplicationUser user);
    Task<IdentityResult> SetTwoFactorEnabledAsync(ApplicationUser user, bool enabled);
    Task<IList<string>> GetValidTwoFactorProvidersAsync(ApplicationUser user);
    Task<string> GenerateTwoFactorTokenAsync(ApplicationUser user, string tokenProvider);
    Task<bool> VerifyTwoFactorTokenAsync(ApplicationUser user, string tokenProvider, string token);
}