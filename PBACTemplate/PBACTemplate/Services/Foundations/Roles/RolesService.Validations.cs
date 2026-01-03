// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// RolesService.Validations.cs See LICENSE.txt in the root folder of the solution.

using Microsoft.AspNetCore.Identity;
using PBACTemplate.Data;
using PBACTemplate.Services.Foundations.Roles.Exceptions;

namespace PBACTemplate.Services.Foundations.Roles;

public partial class RolesService
{
    private static void ValidateUser(ApplicationUser user)
    {
        if (user is null)
        {
            throw new NullRolesException("User cannot be null.");
        }
    }

    private static void ValidateRole(string role)
    {
        if (string.IsNullOrWhiteSpace(role))
        {
            throw new InvalidRolesException("Role cannot be null or whitespace.");
        }
    }

    private static void ValidateRoles(IEnumerable<string> roles)
    {
        if (roles is null)
        {
            throw new NullRolesException("Roles cannot be null.");
        }

        if (!roles.Any())
        {
            throw new InvalidRolesException("Roles cannot be empty.");
        }
    }

    private static void ValidateIdentityResult(IdentityResult result)
    {
        if (!result.Succeeded)
        {
            var errors = string.Join(", ", result.Errors.Select(e => e.Description));

            throw new FailedRolesOperationException(
                $"Identity operation failed: {errors}");
        }
    }
}