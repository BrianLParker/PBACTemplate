// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// AuthTokensService.Validations.cs See LICENSE.txt in the root folder of the solution.

using Microsoft.AspNetCore.Identity;
using PBACTemplate.Models.Users;
using PBACTemplate.Services.Foundations.AuthTokens.Exceptions;

namespace PBACTemplate.Services.Foundations.AuthTokens;

public partial class AuthTokensService
{
    private static void ValidateUser(ApplicationUser user)
    {
        if (user is null)
        {
            throw new NullAuthTokensException("User cannot be null.");
        }
    }

    private static void ValidateLoginProvider(string loginProvider)
    {
        if (string.IsNullOrWhiteSpace(loginProvider))
        {
            throw new InvalidAuthTokensException("Login provider cannot be null or whitespace.");
        }
    }

    private static void ValidateTokenName(string tokenName)
    {
        if (string.IsNullOrWhiteSpace(tokenName))
        {
            throw new InvalidAuthTokensException("Token name cannot be null or whitespace.");
        }
    }

    private static void ValidateIdentityResult(IdentityResult result)
    {
        if (!result.Succeeded)
        {
            var errors = string.Join(", ", result.Errors.Select(e => e.Description));

            throw new FailedAuthTokensOperationException(
                $"Identity operation failed: {errors}");
        }
    }
}