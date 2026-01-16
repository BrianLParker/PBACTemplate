// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// IUserManagerBroker.Tokens.cs See LICENSE.txt in the root folder of the solution.

using Microsoft.AspNetCore.Identity;
using PBACTemplate.Models.Users;

namespace PBACTemplate.Brokers.User;

public partial interface IUserManagerBroker
{
    // Token operations
    Task<string> GenerateUserTokenAsync(ApplicationUser user, string tokenProvider, string purpose);
    Task<bool> VerifyUserTokenAsync(ApplicationUser user, string tokenProvider, string purpose, string token);
    void RegisterTokenProvider(string providerName, IUserTwoFactorTokenProvider<ApplicationUser> provider);
}