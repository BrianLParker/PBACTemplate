// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// PhoneService.Validations.cs See LICENSE.txt in the root folder of the solution.

using Microsoft.AspNetCore.Identity;
using PBACTemplate.Data;
using PBACTemplate.Services.Foundations.Phone.Exceptions;

namespace PBACTemplate.Services.Foundations.Phone;

public partial class PhoneService
{
    private static void ValidateUser(ApplicationUser user)
    {
        if (user is null)
        {
            throw new NullPhoneException("User cannot be null.");
        }
    }

    private static void ValidatePhoneNumber(string phoneNumber)
    {
        if (string.IsNullOrWhiteSpace(phoneNumber))
        {
            throw new InvalidPhoneException("Phone number cannot be null or whitespace.");
        }
    }

    private static void ValidateToken(string token)
    {
        if (string.IsNullOrWhiteSpace(token))
        {
            throw new InvalidPhoneException("Token cannot be null or whitespace.");
        }
    }

    private static void ValidateIdentityResult(IdentityResult result)
    {
        if (!result.Succeeded)
        {
            var errors = string.Join(", ", result.Errors.Select(e => e.Description));

            throw new FailedPhoneOperationException(
                $"Identity operation failed: {errors}");
        }
    }
}