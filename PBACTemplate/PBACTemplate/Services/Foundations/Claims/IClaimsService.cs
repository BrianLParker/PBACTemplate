// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// IClaimsService.cs See LICENSE.txt in the root folder of the solution.

using PBACTemplate.Data;
using System.Security.Claims;

namespace PBACTemplate.Services.Foundations.Claims;

public interface IClaimsService
{
    ValueTask<ApplicationUser> AddClaimAsync(ApplicationUser user, Claim claim);
    ValueTask<ApplicationUser> AddClaimsAsync(ApplicationUser user, IEnumerable<Claim> claims);
    ValueTask<ApplicationUser> ReplaceClaimAsync(ApplicationUser user, Claim claim, Claim newClaim);
    ValueTask<ApplicationUser> RemoveClaimAsync(ApplicationUser user, Claim claim);
    ValueTask<ApplicationUser> RemoveClaimsAsync(ApplicationUser user, IEnumerable<Claim> claims);
    ValueTask<IList<Claim>> RetrieveClaimsAsync(ApplicationUser user);
    ValueTask<IList<ApplicationUser>> RetrieveUsersForClaimAsync(Claim claim);
}