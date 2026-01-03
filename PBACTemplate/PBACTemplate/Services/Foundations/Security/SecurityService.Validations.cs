// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// SecurityService.Validations.cs See LICENSE.txt in the root folder of the solution.

using Microsoft.AspNetCore.Identity;
using PBACTemplate.Data;
using PBACTemplate.Services.Foundations.Security.Exceptions;

namespace PBACTemplate.Services.Foundations.Security;

public partial class SecurityService
{
    private static void ValidateUser(ApplicationUser user)
    {
        if (user is null)
        {
            throw new NullSecurityException("User cannot be null.");
        }
    }

    private static void ValidateIdentityResult(IdentityResult result)
    {
        if (!result.Succeeded)
        {
            var errors = string.Join(", ", result.Errors.Select(e => e.Description));

            throw new FailedSecurityOperationException(
                $"Identity operation failed: {errors}");
        }
    }
}