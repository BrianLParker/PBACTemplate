// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// RolesService.Validations.cs See LICENSE.txt in the root folder of the solution.

using Microsoft.AspNetCore.Identity;
using PBACTemplate.Services.Foundations.Roles.Exceptions;

namespace PBACTemplate.Services.Foundations.Roles;

public sealed partial class RolesService
{
    private static void ValidateRole(IdentityRole role)
    {
        if (role is null)
        {
            throw new NullRolesException("Role cannot be null.");
        }
    }

    private static void ValidateRoleId(string roleId)
    {
        if (string.IsNullOrWhiteSpace(roleId))
        {
            throw new InvalidRolesException("Role ID cannot be null or whitespace.");
        }
    }

    private static void ValidateRoleName(string roleName)
    {
        if (string.IsNullOrWhiteSpace(roleName))
        {
            throw new InvalidRolesException("Role name cannot be null or whitespace.");
        }
    }

    private static void ValidateIdentityResult(IdentityResult result)
    {
        if (!result.Succeeded)
        {
            var errors = string.Join(", ", result.Errors.Select(error => error.Description));

            throw new FailedRolesOperationException(
                $"Role identity operation failed: {errors}");
        }
    }
}