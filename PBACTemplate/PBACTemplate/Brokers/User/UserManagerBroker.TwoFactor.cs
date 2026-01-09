// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// UserManagerBroker.TwoFactor.cs See LICENSE.txt in the root folder of the solution.

using Microsoft.AspNetCore.Identity;
using PBACTemplate.Models.User;

namespace PBACTemplate.Brokers.User;

public sealed partial class UserManagerBroker
{
    public Task<bool> GetTwoFactorEnabledAsync(ApplicationUser user) =>
        userManager.GetTwoFactorEnabledAsync(user);

    public Task<IdentityResult> SetTwoFactorEnabledAsync(ApplicationUser user, bool enabled) =>
        userManager.SetTwoFactorEnabledAsync(user, enabled);

    public Task<IList<string>> GetValidTwoFactorProvidersAsync(ApplicationUser user) =>
        userManager.GetValidTwoFactorProvidersAsync(user);

    public Task<string> GenerateTwoFactorTokenAsync(ApplicationUser user, string tokenProvider) =>
        userManager.GenerateTwoFactorTokenAsync(user, tokenProvider);

    public Task<bool> VerifyTwoFactorTokenAsync(ApplicationUser user, string tokenProvider, string token) =>
        userManager.VerifyTwoFactorTokenAsync(user, tokenProvider, token);
}