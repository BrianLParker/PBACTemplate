// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// UserOrchestrationService.Tokens.cs See LICENSE.txt in the root folder of the solution.

using Microsoft.AspNetCore.Identity;
using PBACTemplate.Data;

namespace PBACTemplate.Services.Orchestrations.Users;

public partial class UserOrchestrationService
{
    public async Task<string> GenerateUserTokenAsync(ApplicationUser user, string tokenProvider, string purpose) =>
        await this.tokensService.GenerateUserTokenAsync(user, tokenProvider, purpose);

    public async Task<bool> VerifyUserTokenAsync(
        ApplicationUser user,
        string tokenProvider,
        string purpose,
        string token) =>
        await this.tokensService.VerifyUserTokenAsync(user, tokenProvider, purpose, token);

    public void RegisterTokenProvider(string providerName, IUserTwoFactorTokenProvider<ApplicationUser> provider)
    {
        // Token provider registration is handled at the Identity configuration level
        // This is a no-op at the orchestration layer
    }
}