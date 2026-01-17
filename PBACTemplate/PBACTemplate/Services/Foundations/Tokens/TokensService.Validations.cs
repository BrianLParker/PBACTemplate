// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// TokensService.Validations.cs See LICENSE.txt in the root folder of the solution.

using PBACTemplate.Models.Users;
using PBACTemplate.Services.Foundations.Tokens.Exceptions;

namespace PBACTemplate.Services.Foundations.Tokens;

public partial class TokensService
{
    private static void ValidateUser(ApplicationUser user)
    {
        if (user is null)
        {
            throw new NullTokensException("User cannot be null.");
        }
    }

    private static void ValidateTokenProvider(string tokenProvider)
    {
        if (string.IsNullOrWhiteSpace(tokenProvider))
        {
            throw new InvalidTokensException("Token provider cannot be null or whitespace.");
        }
    }

    private static void ValidatePurpose(string purpose)
    {
        if (string.IsNullOrWhiteSpace(purpose))
        {
            throw new InvalidTokensException("Purpose cannot be null or whitespace.");
        }
    }

    private static void ValidateToken(string token)
    {
        if (string.IsNullOrWhiteSpace(token))
        {
            throw new InvalidTokensException("Token cannot be null or whitespace.");
        }
    }
}