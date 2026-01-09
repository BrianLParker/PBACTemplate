// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// UserOrchestrationService.Security.cs See LICENSE.txt in the root folder of the solution.

using Microsoft.AspNetCore.Identity;
using PBACTemplate.Models.User;

namespace PBACTemplate.Services.Orchestrations.Users;

public partial class UserOrchestrationService
{
    public async Task<string> GetSecurityStampAsync(ApplicationUser user) =>
        await this.securityService.RetrieveSecurityStampAsync(user);

    public async Task<IdentityResult> UpdateSecurityStampAsync(ApplicationUser user)
    {
        await this.securityService.UpdateSecurityStampAsync(user);

        return IdentityResult.Success;
    }

    public async Task<byte[]> CreateSecurityTokenAsync(ApplicationUser user) =>
        await this.securityService.CreateSecurityTokenAsync(user);

    public async Task<string> GenerateConcurrencyStampAsync(ApplicationUser user) =>
        await this.securityService.GenerateConcurrencyStampAsync(user);
}