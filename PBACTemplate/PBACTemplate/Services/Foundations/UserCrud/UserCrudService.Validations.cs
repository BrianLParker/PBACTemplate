// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// UserCrudService.Validations.cs See LICENSE.txt in the root folder of the solution.

using Microsoft.AspNetCore.Identity;
using PBACTemplate.Data;
using PBACTemplate.Services.Foundations.UserCrud.Exceptions;

namespace PBACTemplate.Services.Foundations.UserCrud;

public partial class UserCrudService
{
    private static void ValidateUser(ApplicationUser user)
    {
        if (user is null)
        {
            throw new NullUserCrudException("User cannot be null.");
        }
    }

    private static void ValidateUserId(string userId)
    {
        if (string.IsNullOrWhiteSpace(userId))
        {
            throw new InvalidUserCrudException("User ID cannot be null or whitespace.");
        }
    }

    private static void ValidateUserName(string userName)
    {
        if (string.IsNullOrWhiteSpace(userName))
        {
            throw new InvalidUserCrudException("User name cannot be null or whitespace.");
        }
    }

    private static void ValidateEmail(string email)
    {
        if (string.IsNullOrWhiteSpace(email))
        {
            throw new InvalidUserCrudException("Email cannot be null or whitespace.");
        }
    }

    private static void ValidatePassword(string password)
    {
        if (string.IsNullOrWhiteSpace(password))
        {
            throw new InvalidUserCrudException("Password cannot be null or whitespace.");
        }
    }

    private static void ValidateLoginProvider(string loginProvider)
    {
        if (string.IsNullOrWhiteSpace(loginProvider))
        {
            throw new InvalidUserCrudException("Login provider cannot be null or whitespace.");
        }
    }

    private static void ValidateProviderKey(string providerKey)
    {
        if (string.IsNullOrWhiteSpace(providerKey))
        {
            throw new InvalidUserCrudException("Provider key cannot be null or whitespace.");
        }
    }

    private static void ValidateIdentityResult(IdentityResult result)
    {
        if (!result.Succeeded)
        {
            var errors = string.Join(", ", result.Errors.Select(e => e.Description));

            throw new FailedUserCrudOperationException(
                $"Identity operation failed: {errors}");
        }
    }
}