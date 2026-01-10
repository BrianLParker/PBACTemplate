// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// RoleClaimsService.Validations.cs See LICENSE.txt in the root folder of the solution.

using Microsoft.AspNetCore.Identity;
using PBACTemplate.Services.Foundations.RoleClaims.Exceptions;
using System.Security.Claims;

namespace PBACTemplate.Services.Foundations.RoleClaims;

public sealed partial class RoleClaimsService
{
    private static void ValidateRole(IdentityRole role)
    {
        if (role is null)
        {
            throw new NullRoleClaimsException("Role cannot be null.");
        }
    }

    private static void ValidateClaim(Claim claim, string? paramName = null)
    {
        if (claim is null)
        {
            throw new NullRoleClaimsException($"{paramName ?? "Claim"} cannot be null.");
        }

        if (string.IsNullOrWhiteSpace(claim.Type))
        {
            throw new InvalidRoleClaimsException($"{paramName ?? "Claim"} type cannot be null or whitespace.");
        }
    }

    private static void ValidateIdentityResult(IdentityResult result)
    {
        if (!result.Succeeded)
        {
            var errors = string.Join(", ", result.Errors.Select(error => error.Description));

            throw new FailedRoleClaimsOperationException(
                $"Role claims identity operation failed: {errors}");
        }
    }
}