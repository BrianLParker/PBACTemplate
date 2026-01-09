// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// UserOrchestrationService.AuthTokens.cs See LICENSE.txt in the root folder of the solution.

using Microsoft.AspNetCore.Identity;
using PBACTemplate.Models.User;

namespace PBACTemplate.Services.Orchestrations.Users;

public partial class UserOrchestrationService
{
    public async Task<string?> GetAuthenticationTokenAsync(
        ApplicationUser user,
        string loginProvider,
        string tokenName) =>
        await this.authTokensService.RetrieveAuthenticationTokenAsync(user, loginProvider, tokenName);

    public async Task<IdentityResult> SetAuthenticationTokenAsync(
        ApplicationUser user,
        string loginProvider,
        string tokenName,
        string? tokenValue)
    {
        await this.authTokensService.SetAuthenticationTokenAsync(user, loginProvider, tokenName, tokenValue);

        return IdentityResult.Success;
    }

    public async Task<IdentityResult> RemoveAuthenticationTokenAsync(
        ApplicationUser user,
        string loginProvider,
        string tokenName)
    {
        await this.authTokensService.RemoveAuthenticationTokenAsync(user, loginProvider, tokenName);

        return IdentityResult.Success;
    }

    public async Task<string?> GetAuthenticatorKeyAsync(ApplicationUser user) =>
        await this.authTokensService.RetrieveAuthenticatorKeyAsync(user);

    public async Task<IdentityResult> ResetAuthenticatorKeyAsync(ApplicationUser user)
    {
        await this.authTokensService.ResetAuthenticatorKeyAsync(user);

        return IdentityResult.Success;
    }

    public string GenerateNewAuthenticatorKey() =>
        this.authTokensService.GenerateNewAuthenticatorKey();
}