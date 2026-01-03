// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// UserOrchestrationService.TwoFactor.cs See LICENSE.txt in the root folder of the solution.

using Microsoft.AspNetCore.Identity;
using PBACTemplate.Data;

namespace PBACTemplate.Services.Orchestrations.Users;

public partial class UserOrchestrationService
{
    public async Task<bool> GetTwoFactorEnabledAsync(ApplicationUser user) =>
        await this.twoFactorService.GetTwoFactorEnabledAsync(user);

    public async Task<IdentityResult> SetTwoFactorEnabledAsync(ApplicationUser user, bool enabled)
    {
        await this.twoFactorService.SetTwoFactorEnabledAsync(user, enabled);

        return IdentityResult.Success;
    }

    public async Task<IList<string>> GetValidTwoFactorProvidersAsync(ApplicationUser user) =>
        await this.twoFactorService.RetrieveValidTwoFactorProvidersAsync(user);

    public async Task<string> GenerateTwoFactorTokenAsync(ApplicationUser user, string tokenProvider) =>
        await this.twoFactorService.GenerateTwoFactorTokenAsync(user, tokenProvider);

    public async Task<bool> VerifyTwoFactorTokenAsync(ApplicationUser user, string tokenProvider, string token) =>
        await this.twoFactorService.VerifyTwoFactorTokenAsync(user, tokenProvider, token);
}