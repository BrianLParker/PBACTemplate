// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// IUserOrchestrationService.Claims.cs See LICENSE.txt in the root folder of the solution.

using Microsoft.AspNetCore.Identity;
using PBACTemplate.Models.User;
using System.Security.Claims;

namespace PBACTemplate.Services.Orchestrations.Users;

public partial interface IUserOrchestrationService
{
    // Claim operations
    Task<IdentityResult> AddClaimAsync(ApplicationUser user, Claim claim);
    Task<IdentityResult> AddClaimsAsync(ApplicationUser user, IEnumerable<Claim> claims);
    Task<IdentityResult> ReplaceClaimAsync(ApplicationUser user, Claim claim, Claim newClaim);
    Task<IdentityResult> RemoveClaimAsync(ApplicationUser user, Claim claim);
    Task<IdentityResult> RemoveClaimsAsync(ApplicationUser user, IEnumerable<Claim> claims);
    Task<IList<Claim>> GetClaimsAsync(ApplicationUser user);
    Task<IList<ApplicationUser>> GetUsersForClaimAsync(Claim claim);
}