// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// IUserOrchestrationService.AuthTokens.cs See LICENSE.txt in the root folder of the solution.

using Microsoft.AspNetCore.Identity;
using PBACTemplate.Data;

namespace PBACTemplate.Services.Orchestrations.Users;

public partial interface IUserOrchestrationService
{
    // Authentication token operations
    Task<string?> GetAuthenticationTokenAsync(ApplicationUser user, string loginProvider, string tokenName);
    Task<IdentityResult> SetAuthenticationTokenAsync(ApplicationUser user, string loginProvider, string tokenName, string? tokenValue);
    Task<IdentityResult> RemoveAuthenticationTokenAsync(ApplicationUser user, string loginProvider, string tokenName);

    // Authenticator key operations
    Task<string?> GetAuthenticatorKeyAsync(ApplicationUser user);
    Task<IdentityResult> ResetAuthenticatorKeyAsync(ApplicationUser user);
    string GenerateNewAuthenticatorKey();
}