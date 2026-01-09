// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// UserRolesService.Validations.cs See LICENSE.txt in the root folder of the solution.

using Microsoft.AspNetCore.Identity;
using PBACTemplate.Models.User;
using PBACTemplate.Services.Foundations.UserRoles.Exceptions;

namespace PBACTemplate.Services.Foundations.UserRoles;

public partial class UserRolesService
{
    private static void ValidateUser(ApplicationUser user)
    {
        if (user is null)
        {
            throw new NullUserRolesException("User cannot be null.");
        }
    }

    private static void ValidateRole(string role)
    {
        if (string.IsNullOrWhiteSpace(role))
        {
            throw new InvalidUserRolesException("Role name cannot be null or whitespace.");
        }
    }

    private static void ValidateRoles(IEnumerable<string> roles)
    {
        if (roles is null)
        {
            throw new NullUserRolesException("Roles collection cannot be null.");
        }

        if (!roles.Any())
        {
            throw new InvalidUserRolesException("Roles collection cannot be empty.");
        }
    }

    private static void ValidateIdentityResult(IdentityResult result)
    {
        if (!result.Succeeded)
        {
            var errors = string.Join(", ", result.Errors.Select(e => e.Description));

            throw new FailedUserRolesOperationException(
                $"User roles identity operation failed: {errors}");
        }
    }
}