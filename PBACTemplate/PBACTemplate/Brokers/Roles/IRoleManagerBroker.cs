// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// IRoleManagerBroker.cs See LICENSE.txt in the root folder of the solution.

using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace PBACTemplate.Brokers.Roles;

public partial interface IRoleManagerBroker
{
    // Properties
    ILogger Logger { get; set; }
    IList<IRoleValidator<IdentityRole>> RoleValidators { get; }
    ILookupNormalizer KeyNormalizer { get; set; }
    IdentityErrorDescriber ErrorDescriber { get; set; }
    bool SupportsRoleClaims { get; }
    IQueryable<IdentityRole> Roles { get; }

    // Role CRUD
    Task<IdentityResult> CreateAsync(IdentityRole role);
    Task<IdentityResult> UpdateAsync(IdentityRole role);
    Task<IdentityResult> DeleteAsync(IdentityRole role);

    // Role queries
    Task<bool> RoleExistsAsync(string roleName);
    Task<IdentityRole?> FindByIdAsync(string roleId);
    Task<IdentityRole?> FindByNameAsync(string roleName);
    Task<string> GetRoleIdAsync(IdentityRole role);
    Task<string?> GetRoleNameAsync(IdentityRole role);
    Task<IdentityResult> SetRoleNameAsync(IdentityRole role, string name);

    // Role claims (permissions)
    Task<IList<Claim>> GetClaimsAsync(IdentityRole role);
    Task<IdentityResult> AddClaimAsync(IdentityRole role, Claim claim);
    Task<IdentityResult> RemoveClaimAsync(IdentityRole role, Claim claim);
}
