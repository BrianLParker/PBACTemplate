// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// UserOrchestrationService.Claims.cs See LICENSE.txt in the root folder of the solution.

using Microsoft.AspNetCore.Identity;
using PBACTemplate.Models.User;
using System.Security.Claims;

namespace PBACTemplate.Services.Orchestrations.Users;

public partial class UserOrchestrationService
{
    public async Task<IdentityResult> AddClaimAsync(ApplicationUser user, Claim claim)
    {
        await this.claimsService.AddClaimAsync(user, claim);

        return IdentityResult.Success;
    }

    public async Task<IdentityResult> AddClaimsAsync(ApplicationUser user, IEnumerable<Claim> claims)
    {
        await this.claimsService.AddClaimsAsync(user, claims);

        return IdentityResult.Success;
    }

    public async Task<IdentityResult> ReplaceClaimAsync(ApplicationUser user, Claim claim, Claim newClaim)
    {
        await this.claimsService.ReplaceClaimAsync(user, claim, newClaim);

        return IdentityResult.Success;
    }

    public async Task<IdentityResult> RemoveClaimAsync(ApplicationUser user, Claim claim)
    {
        await this.claimsService.RemoveClaimAsync(user, claim);

        return IdentityResult.Success;
    }

    public async Task<IdentityResult> RemoveClaimsAsync(ApplicationUser user, IEnumerable<Claim> claims)
    {
        await this.claimsService.RemoveClaimsAsync(user, claims);

        return IdentityResult.Success;
    }

    public async Task<IList<Claim>> GetClaimsAsync(ApplicationUser user) =>
        await this.claimsService.RetrieveClaimsAsync(user);

    public async Task<IList<ApplicationUser>> GetUsersForClaimAsync(Claim claim) =>
        await this.claimsService.RetrieveUsersForClaimAsync(claim);
}