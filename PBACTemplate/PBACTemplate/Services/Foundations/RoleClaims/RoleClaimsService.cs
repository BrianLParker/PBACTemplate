// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// RoleClaimsService.cs See LICENSE.txt in the root folder of the solution.

using Microsoft.AspNetCore.Identity;
using PBACTemplate.Brokers.Roles;
using System.Security.Claims;

namespace PBACTemplate.Services.Foundations.RoleClaims;

public sealed partial class RoleClaimsService(
    IRoleManagerBroker roleManagerBroker,
    ILogger<RoleClaimsService> logger) : IRoleClaimsService
{
    private readonly IRoleManagerBroker roleManagerBroker = roleManagerBroker;
    private readonly ILogger<RoleClaimsService> logger = logger;

    public ValueTask<IList<Claim>> RetrieveClaimsAsync(IdentityRole role) =>
        TryCatch(async () =>
        {
            ValidateRole(role);

            LogRetrievingRoleClaims(role.Id);

            return await this.roleManagerBroker.GetClaimsAsync(role);
        });

    public ValueTask<IdentityRole> AddClaimAsync(IdentityRole role, Claim claim) =>
        TryCatch(async () =>
        {
            ValidateRole(role);
            ValidateClaim(claim);

            LogAddingRoleClaim(role.Id, claim.Type);

            var result = await this.roleManagerBroker.AddClaimAsync(role, claim);
            ValidateIdentityResult(result);

            return role;
        });

    public ValueTask<IdentityRole> RemoveClaimAsync(IdentityRole role, Claim claim) =>
        TryCatch(async () =>
        {
            ValidateRole(role);
            ValidateClaim(claim);

            LogRemovingRoleClaim(role.Id, claim.Type);

            var result = await this.roleManagerBroker.RemoveClaimAsync(role, claim);
            ValidateIdentityResult(result);

            return role;
        });
}