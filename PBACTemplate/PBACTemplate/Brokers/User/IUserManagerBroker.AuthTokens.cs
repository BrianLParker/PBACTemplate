// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// IUserManagerBroker.AuthTokens.cs See LICENSE.txt in the root folder of the solution.

using Microsoft.AspNetCore.Identity;
using PBACTemplate.Models.User;

namespace PBACTemplate.Brokers.User;

public partial interface IUserManagerBroker
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