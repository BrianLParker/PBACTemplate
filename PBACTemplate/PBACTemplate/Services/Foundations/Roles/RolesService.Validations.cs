// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// RolesService.Validations.cs See LICENSE.txt in the root folder of the solution.

using Microsoft.AspNetCore.Identity;
using PBACTemplate.Services.Foundations.Roles.Exceptions;

namespace PBACTemplate.Services.Foundations.Roles;

public sealed partial class RolesService
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

    private static void ValidateIdentityResult(IdentityResult result)
    {
        if (!result.Succeeded)
        {
            string errors = string.Join(", ", result.Errors.Select(error => error.Description));

            throw new FailedRolesOperationException($"Role identity operation failed: {errors}");
        }
    }
}