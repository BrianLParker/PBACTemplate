// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// RoleService.Validations.cs See LICENSE.txt in the root folder of the solution.

using PBACTemplate.Client.Services.Foundations.Roles.Exceptions;

namespace PBACTemplate.Client.Services.Foundations.Roles;

public sealed partial class RoleService
{
    private static void ValidateRoleName(string roleName)
    {
        if (roleName is null)
        {
            throw new NullRolesException("Role name cannot be null.");
        }

        if (string.IsNullOrWhiteSpace(roleName))
        {
            throw new InvalidRolesException("Role name cannot be empty or whitespace.");
        }
    }
}