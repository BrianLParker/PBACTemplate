// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// TwoFactorService.Validations.cs See LICENSE.txt in the root folder of the solution.

using Microsoft.AspNetCore.Identity;
using PBACTemplate.Models.Users;
using PBACTemplate.Services.Foundations.TwoFactor.Exceptions;

namespace PBACTemplate.Services.Foundations.TwoFactor;

public partial class TwoFactorService
{
    private static void ValidateUser(ApplicationUser user)
    {
        if (user is null)
        {
            throw new NullTwoFactorException("User cannot be null.");
        }
    }

    private static void ValidateTokenProvider(string tokenProvider)
    {
        if (string.IsNullOrWhiteSpace(tokenProvider))
        {
            throw new InvalidTwoFactorException("Token provider cannot be null or whitespace.");
        }
    }

    private static void ValidateToken(string token)
    {
        if (string.IsNullOrWhiteSpace(token))
        {
            throw new InvalidTwoFactorException("Token cannot be null or whitespace.");
        }
    }

    private static void ValidateIdentityResult(IdentityResult result)
    {
        if (!result.Succeeded)
        {
            var errors = string.Join(", ", result.Errors.Select(e => e.Description));

            throw new FailedTwoFactorOperationException(
                $"Identity operation failed: {errors}");
        }
    }
}