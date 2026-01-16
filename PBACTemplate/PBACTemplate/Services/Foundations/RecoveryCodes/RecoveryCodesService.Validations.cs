// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// RecoveryCodesService.Validations.cs See LICENSE.txt in the root folder of the solution.

using Microsoft.AspNetCore.Identity;
using PBACTemplate.Models.Users;
using PBACTemplate.Services.Foundations.RecoveryCodes.Exceptions;

namespace PBACTemplate.Services.Foundations.RecoveryCodes;

public partial class RecoveryCodesService
{
    private static void ValidateUser(ApplicationUser user)
    {
        if (user is null)
        {
            throw new NullRecoveryCodesException("User cannot be null.");
        }
    }

    private static void ValidateRecoveryCode(string code)
    {
        if (string.IsNullOrWhiteSpace(code))
        {
            throw new InvalidRecoveryCodesException("Recovery code cannot be null or whitespace.");
        }
    }

    private static void ValidateRecoveryCodeCount(int number)
    {
        if (number <= 0)
        {
            throw new InvalidRecoveryCodesException("Recovery code count must be greater than zero.");
        }
    }

    private static void ValidateIdentityResult(IdentityResult result)
    {
        if (!result.Succeeded)
        {
            var errors = string.Join(", ", result.Errors.Select(e => e.Description));

            throw new FailedRecoveryCodesOperationException(
                $"Identity operation failed: {errors}");
        }
    }
}