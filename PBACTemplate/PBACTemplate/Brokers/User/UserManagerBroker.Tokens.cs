// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// UserManagerBroker.Tokens.cs See LICENSE.txt in the root folder of the solution.

using Microsoft.AspNetCore.Identity;
using PBACTemplate.Models.User;

namespace PBACTemplate.Brokers.User;

public sealed partial class UserManagerBroker
{
    public Task<string> GenerateUserTokenAsync(ApplicationUser user, string tokenProvider, string purpose) =>
        userManager.GenerateUserTokenAsync(user, tokenProvider, purpose);

    public Task<bool> VerifyUserTokenAsync(ApplicationUser user, string tokenProvider, string purpose, string token) =>
        userManager.VerifyUserTokenAsync(user, tokenProvider, purpose, token);

    public void RegisterTokenProvider(string providerName, IUserTwoFactorTokenProvider<ApplicationUser> provider) =>
        userManager.RegisterTokenProvider(providerName, provider);
}