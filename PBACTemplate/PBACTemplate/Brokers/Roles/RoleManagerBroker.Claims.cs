// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// RoleManagerBroker.Claims.cs See LICENSE.txt in the root folder of the solution.

using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace PBACTemplate.Brokers.Roles;

public sealed partial class RoleManagerBroker
{
    public Task<IList<Claim>> GetClaimsAsync(IdentityRole role) =>
        roleManager.GetClaimsAsync(role);

    public Task<IdentityResult> AddClaimAsync(IdentityRole role, Claim claim) =>
        roleManager.AddClaimAsync(role, claim);

    public Task<IdentityResult> RemoveClaimAsync(IdentityRole role, Claim claim) =>
        roleManager.RemoveClaimAsync(role, claim);
}