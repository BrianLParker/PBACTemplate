// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// IAdministrationOrchestrationService.cs See LICENSE.txt in the root folder of the solution.

using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace PBACTemplate.Services.Orchestrations.Administration;

public interface IAdministrationOrchestrationService
{
    IQueryable<IdentityRole> Roles { get; }

    ValueTask<IdentityRole> CreateRoleAsync(string roleName);
    ValueTask<IdentityRole> UpdateRoleNameAsync(IdentityRole role, string newName);
    ValueTask<IdentityRole> DeleteRoleAsync(IdentityRole role);
    ValueTask<bool> RoleExistsAsync(string roleName);
    ValueTask<IdentityRole?> RetrieveRoleByIdAsync(string roleId);
    ValueTask<IdentityRole?> RetrieveRoleByNameAsync(string roleName);
    ValueTask<IList<Claim>> RetrieveClaimsAsync(IdentityRole role);
    ValueTask<IdentityRole> AddClaimAsync(IdentityRole role, Claim claim);
    ValueTask<IdentityRole> RemoveClaimAsync(IdentityRole role, Claim claim);

}
