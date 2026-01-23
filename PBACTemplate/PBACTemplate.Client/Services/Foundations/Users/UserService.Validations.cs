// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// UserService.Validations.cs See LICENSE.txt in the root folder of the solution.

using PBACTemplate.Client.Models.Users;
using PBACTemplate.Client.Services.Foundations.Users.Exceptions;

namespace PBACTemplate.Client.Services.Foundations.Users;

public sealed partial class UserService
{
    private static void ValidateUser(User user)
    {
        if (user is null)
        {
            throw new NullUsersException("User cannot be null.");
        }

        if (string.IsNullOrWhiteSpace(user.UserName))
        {
            throw new InvalidUsersException("User name cannot be null or whitespace.");
        }

        if (string.IsNullOrWhiteSpace(user.Email))
        {
            throw new InvalidUsersException("Email cannot be null or whitespace.");
        }
    }

    private static void ValidateUserId(string userId)
    {
        if (string.IsNullOrWhiteSpace(userId))
        {
            throw new InvalidUsersException("User ID cannot be null or whitespace.");
        }
    }
}