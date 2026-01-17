// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// ClaimsService.Validations.cs See LICENSE.txt in the root folder of the solution.

using Microsoft.AspNetCore.Identity;
using PBACTemplate.Models.Users;
using PBACTemplate.Services.Foundations.Claims.Exceptions;
using System.Security.Claims;

namespace PBACTemplate.Services.Foundations.Claims;

public sealed partial class ClaimsService
{
    private static void ValidateUser(ApplicationUser user)
    {
        if (user is null)
        {
            throw new NullClaimsException("User cannot be null.");
        }
    }

    private static void ValidateClaim(Claim claim, string parameterName = "claim")
    {
        if (claim is null)
        {
            throw new NullClaimsException($"{parameterName} cannot be null.");
        }
    }

    private static void ValidateClaims(IEnumerable<Claim> claims)
    {
        if (claims is null)
        {
            throw new NullClaimsException("Claims cannot be null.");
        }

        if (!claims.Any())
        {
            throw new InvalidClaimsException("Claims cannot be empty.");
        }
    }

    private static void ValidateIdentityResult(IdentityResult result)
    {
        if (!result.Succeeded)
        {
            var errors = string.Join(", ", result.Errors.Select(e => e.Description));

            throw new FailedClaimsOperationException(
                $"Identity operation failed: {errors}");
        }
    }
}