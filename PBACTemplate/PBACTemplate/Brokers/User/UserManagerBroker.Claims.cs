// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// UserManagerBroker.Claims.cs See LICENSE.txt in the root folder of the solution.

using Microsoft.AspNetCore.Identity;
using PBACTemplate.Models.User;
using System.Security.Claims;

namespace PBACTemplate.Brokers.User;

public sealed partial class UserManagerBroker
{
    public Task<IdentityResult> AddClaimAsync(ApplicationUser user, Claim claim) =>
        userManager.AddClaimAsync(user, claim);

    public Task<IdentityResult> AddClaimsAsync(ApplicationUser user, IEnumerable<Claim> claims) =>
        userManager.AddClaimsAsync(user, claims);

    public Task<IdentityResult> ReplaceClaimAsync(ApplicationUser user, Claim claim, Claim newClaim) =>
        userManager.ReplaceClaimAsync(user, claim, newClaim);

    public Task<IdentityResult> RemoveClaimAsync(ApplicationUser user, Claim claim) =>
        userManager.RemoveClaimAsync(user, claim);

    public Task<IdentityResult> RemoveClaimsAsync(ApplicationUser user, IEnumerable<Claim> claims) =>
        userManager.RemoveClaimsAsync(user, claims);

    public Task<IList<Claim>> GetClaimsAsync(ApplicationUser user) =>
        userManager.GetClaimsAsync(user);

    public Task<IList<ApplicationUser>> GetUsersForClaimAsync(Claim claim) =>
        userManager.GetUsersForClaimAsync(claim);
}