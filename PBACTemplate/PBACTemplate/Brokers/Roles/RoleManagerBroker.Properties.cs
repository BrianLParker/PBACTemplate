// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// RoleManagerBroker.Properties.cs See LICENSE.txt in the root folder of the solution.

using Microsoft.AspNetCore.Identity;

namespace PBACTemplate.Brokers.Roles;

public sealed partial class RoleManagerBroker
{
    public ILogger Logger
    {
        get => roleManager.Logger;
        set => roleManager.Logger = value;
    }

    public IList<IRoleValidator<IdentityRole>> RoleValidators => roleManager.RoleValidators;

    public ILookupNormalizer KeyNormalizer
    {
        get => roleManager.KeyNormalizer;
        set => roleManager.KeyNormalizer = value;
    }

    public IdentityErrorDescriber ErrorDescriber
    {
        get => roleManager.ErrorDescriber;
        set => roleManager.ErrorDescriber = value;
    }

    public bool SupportsRoleClaims => roleManager.SupportsRoleClaims;

    public IQueryable<IdentityRole> Roles => roleManager.Roles;
}