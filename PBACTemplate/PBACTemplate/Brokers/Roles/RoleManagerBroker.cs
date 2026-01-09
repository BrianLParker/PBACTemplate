// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// RoleManagerBroker.cs See LICENSE.txt in the root folder of the solution.

using Microsoft.AspNetCore.Identity;

namespace PBACTemplate.Brokers.Roles;

public sealed partial class RoleManagerBroker(
    RoleManager<IdentityRole> roleManager) : IRoleManagerBroker
{
    private readonly RoleManager<IdentityRole> roleManager = roleManager;
}
