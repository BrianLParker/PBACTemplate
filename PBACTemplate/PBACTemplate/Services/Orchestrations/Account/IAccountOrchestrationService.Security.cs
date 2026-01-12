// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// IUserOrchestrationService.Security.cs See LICENSE.txt in the root folder of the solution.

using Microsoft.AspNetCore.Identity;
using PBACTemplate.Models.User;

namespace PBACTemplate.Services.Orchestrations.Account;

public partial interface IAccountOrchestrationService
{
    // Security stamp operations
    Task<string> GetSecurityStampAsync(ApplicationUser user);
    Task<IdentityResult> UpdateSecurityStampAsync(ApplicationUser user);
    Task<byte[]> CreateSecurityTokenAsync(ApplicationUser user);
    Task<string> GenerateConcurrencyStampAsync(ApplicationUser user);
}