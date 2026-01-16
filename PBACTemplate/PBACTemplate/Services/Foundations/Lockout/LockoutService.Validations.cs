// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// LockoutService.Validations.cs See LICENSE.txt in the root folder of the solution.

using Microsoft.AspNetCore.Identity;
using PBACTemplate.Models.Users;
using PBACTemplate.Services.Foundations.Lockout.Exceptions;

namespace PBACTemplate.Services.Foundations.Lockout;

public partial class LockoutService
{
    private static void ValidateUser(ApplicationUser user)
    {
        if (user is null)
        {
            throw new NullLockoutException("User cannot be null.");
        }
    }

    private static void ValidateIdentityResult(IdentityResult result)
    {
        if (!result.Succeeded)
        {
            var errors = string.Join(", ", result.Errors.Select(e => e.Description));

            throw new FailedLockoutOperationException(
                $"Identity operation failed: {errors}");
        }
    }
}