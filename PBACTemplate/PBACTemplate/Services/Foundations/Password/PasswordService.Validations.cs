// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// PasswordService.Validations.cs See LICENSE.txt in the root folder of the solution.

using Microsoft.AspNetCore.Identity;
using PBACTemplate.Data;
using PBACTemplate.Services.Foundations.Password.Exceptions;

namespace PBACTemplate.Services.Foundations.Password;

public partial class PasswordService
{
    private static void ValidateUser(ApplicationUser user)
    {
        if (user is null)
        {
            throw new NullPasswordException("User cannot be null.");
        }
    }

    private static void ValidatePassword(string password, string parameterName = "password")
    {
        if (string.IsNullOrWhiteSpace(password))
        {
            throw new InvalidPasswordException($"{parameterName} cannot be null or whitespace.");
        }
    }

    private static void ValidateToken(string token)
    {
        if (string.IsNullOrWhiteSpace(token))
        {
            throw new InvalidPasswordException("Token cannot be null or whitespace.");
        }
    }

    private static void ValidateIdentityResult(IdentityResult result)
    {
        if (!result.Succeeded)
        {
            var errors = string.Join(", ", result.Errors.Select(e => e.Description));

            throw new FailedPasswordOperationException(
                $"Identity operation failed: {errors}");
        }
    }
}