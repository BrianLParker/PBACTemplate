// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// IUserOrchestrationService.Tokens.cs See LICENSE.txt in the root folder of the solution.

using Microsoft.AspNetCore.Identity;
using PBACTemplate.Data;

namespace PBACTemplate.Services.Orchestrations.Users;

public partial interface IUserOrchestrationService
{
    // Token operations
    Task<string> GenerateUserTokenAsync(ApplicationUser user, string tokenProvider, string purpose);
    Task<bool> VerifyUserTokenAsync(ApplicationUser user, string tokenProvider, string purpose, string token);
    void RegisterTokenProvider(string providerName, IUserTwoFactorTokenProvider<ApplicationUser> provider);
}