// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// IAccountOrchestrationService.Tokens.cs See LICENSE.txt in the root folder of the solution.

using Microsoft.AspNetCore.Identity;
using PBACTemplate.Models.Users;

namespace PBACTemplate.Services.Orchestrations.Account;

public partial interface IAccountOrchestrationService
{
    // Token operations
    Task<string> GenerateUserTokenAsync(ApplicationUser user, string tokenProvider, string purpose);
    Task<bool> VerifyUserTokenAsync(ApplicationUser user, string tokenProvider, string purpose, string token);
    void RegisterTokenProvider(string providerName, IUserTwoFactorTokenProvider<ApplicationUser> provider);
}