// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// EmailService.Validations.cs See LICENSE.txt in the root folder of the solution.

using Microsoft.AspNetCore.Identity;
using PBACTemplate.Models.User;
using PBACTemplate.Services.Foundations.Email.Exceptions;

namespace PBACTemplate.Services.Foundations.Email;

public partial class EmailService
{
    private static void ValidateUser(ApplicationUser user)
    {
        if (user is null)
        {
            throw new NullEmailException("User cannot be null.");
        }
    }

    private static void ValidateEmail(string email)
    {
        if (string.IsNullOrWhiteSpace(email))
        {
            throw new InvalidEmailException("Email cannot be null or whitespace.");
        }
    }

    private static void ValidateToken(string token)
    {
        if (string.IsNullOrWhiteSpace(token))
        {
            throw new InvalidEmailException("Token cannot be null or whitespace.");
        }
    }

    private static void ValidateIdentityResult(IdentityResult result)
    {
        if (!result.Succeeded)
        {
            var errors = string.Join(", ", result.Errors.Select(e => e.Description));

            throw new FailedEmailOperationException(
                $"Identity operation failed: {errors}");
        }
    }
}