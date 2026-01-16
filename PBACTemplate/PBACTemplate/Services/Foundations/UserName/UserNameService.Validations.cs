// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// UserNameService.Validations.cs See LICENSE.txt in the root folder of the solution.

using Microsoft.AspNetCore.Identity;
using PBACTemplate.Models.Users;
using PBACTemplate.Services.Foundations.UserName.Exceptions;
using System.Security.Claims;

namespace PBACTemplate.Services.Foundations.UserName;

public partial class UserNameService
{
    private static void ValidateUser(ApplicationUser user)
    {
        if (user is null)
        {
            throw new NullUserNameException("User cannot be null.");
        }
    }

    private static void ValidatePrincipal(ClaimsPrincipal principal)
    {
        if (principal is null)
        {
            throw new NullUserNameException("Claims principal cannot be null.");
        }
    }

    private static void ValidateIdentityResult(IdentityResult result)
    {
        if (!result.Succeeded)
        {
            var errors = string.Join(", ", result.Errors.Select(e => e.Description));

            throw new FailedUserNameOperationException(
                $"Identity operation failed: {errors}");
        }
    }
}