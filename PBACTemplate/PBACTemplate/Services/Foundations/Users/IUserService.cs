// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// IUserService.cs See LICENSE.txt in the root folder of the solution.

using PBACTemplate.Client.Models.Users;
using System.Collections.Immutable;

namespace PBACTemplate.Services.Foundations.Users;

public interface IUserService
{
    ValueTask<ImmutableList<User>> RetrieveUsersAsync();
    ValueTask<User?> RetrieveUserByIdAsync(string userId);
    ValueTask<User> CreateUserAsync(User newUser);
    ValueTask<User> UpdateUserAsync(string userId, User newUser);
    ValueTask<bool> RemoveUserAsync(string userId);
}
