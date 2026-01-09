// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// IAuthTokensService.cs See LICENSE.txt in the root folder of the solution.

using PBACTemplate.Models.User;

namespace PBACTemplate.Services.Foundations.AuthTokens;

public interface IAuthTokensService
{
    ValueTask<string?> RetrieveAuthenticationTokenAsync(
        ApplicationUser user,
        string loginProvider,
        string tokenName);

    ValueTask<ApplicationUser> SetAuthenticationTokenAsync(
        ApplicationUser user,
        string loginProvider,
        string tokenName,
        string? tokenValue);

    ValueTask<ApplicationUser> RemoveAuthenticationTokenAsync(
        ApplicationUser user,
        string loginProvider,
        string tokenName);

    ValueTask<string?> RetrieveAuthenticatorKeyAsync(ApplicationUser user);
    ValueTask<ApplicationUser> ResetAuthenticatorKeyAsync(ApplicationUser user);
    string GenerateNewAuthenticatorKey();
}