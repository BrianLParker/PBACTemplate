// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// LoginService.Validations.cs See LICENSE.txt in the root folder of the solution.

using Microsoft.AspNetCore.Identity;
using PBACTemplate.Models.Users;
using PBACTemplate.Services.Foundations.Login.Exceptions;

namespace PBACTemplate.Services.Foundations.Login;

public partial class LoginService
{
    private static void ValidateUser(ApplicationUser user)
    {
        if (user is null)
        {
            throw new NullLoginException("User cannot be null.");
        }
    }

    private static void ValidateLoginInfo(UserLoginInfo login)
    {
        if (login is null)
        {
            throw new NullLoginException("Login info cannot be null.");
        }
    }

    private static void ValidateLoginProvider(string loginProvider)
    {
        if (string.IsNullOrWhiteSpace(loginProvider))
        {
            throw new InvalidLoginException("Login provider cannot be null or whitespace.");
        }
    }

    private static void ValidateProviderKey(string providerKey)
    {
        if (string.IsNullOrWhiteSpace(providerKey))
        {
            throw new InvalidLoginException("Provider key cannot be null or whitespace.");
        }
    }

    private static void ValidateIdentityResult(IdentityResult result)
    {
        if (!result.Succeeded)
        {
            var errors = string.Join(", ", result.Errors.Select(e => e.Description));

            throw new FailedLoginOperationException(
                $"Identity operation failed: {errors}");
        }
    }
}