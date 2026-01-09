// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// UserManagerBroker.AuthTokens.cs See LICENSE.txt in the root folder of the solution.

using Microsoft.AspNetCore.Identity;
using PBACTemplate.Models.User;

namespace PBACTemplate.Brokers.User;

public sealed partial class UserManagerBroker
{
    public Task<string?> GetAuthenticationTokenAsync(ApplicationUser user, string loginProvider, string tokenName) =>
        userManager.GetAuthenticationTokenAsync(user, loginProvider, tokenName);

    public Task<IdentityResult> SetAuthenticationTokenAsync(ApplicationUser user, string loginProvider, string tokenName, string? tokenValue) =>
        userManager.SetAuthenticationTokenAsync(user, loginProvider, tokenName, tokenValue);

    public Task<IdentityResult> RemoveAuthenticationTokenAsync(ApplicationUser user, string loginProvider, string tokenName) =>
        userManager.RemoveAuthenticationTokenAsync(user, loginProvider, tokenName);

    public Task<string?> GetAuthenticatorKeyAsync(ApplicationUser user) =>
        userManager.GetAuthenticatorKeyAsync(user);

    public Task<IdentityResult> ResetAuthenticatorKeyAsync(ApplicationUser user) =>
        userManager.ResetAuthenticatorKeyAsync(user);

    public string GenerateNewAuthenticatorKey() =>
        userManager.GenerateNewAuthenticatorKey();
}