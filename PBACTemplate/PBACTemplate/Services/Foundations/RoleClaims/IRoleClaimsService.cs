// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// IRoleClaimsService.cs See LICENSE.txt in the root folder of the solution.

using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace PBACTemplate.Services.Foundations.RoleClaims;

public interface IRoleClaimsService
{
    ValueTask<IList<Claim>> RetrieveClaimsAsync(IdentityRole role);
    ValueTask<IdentityRole> AddClaimAsync(IdentityRole role, Claim claim);
    ValueTask<IdentityRole> RemoveClaimAsync(IdentityRole role, Claim claim);
}