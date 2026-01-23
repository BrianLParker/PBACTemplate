// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// IUserService.cs See LICENSE.txt in the root folder of the solution.

using PBACTemplate.Client.Models.Users;
using System.Collections.Immutable;

namespace PBACTemplate.Client.Services.Foundations.Users;

public interface IUserService
{
    ValueTask<ImmutableList<User>> GetUsersAsync(CancellationToken cancellationToken = default);
    ValueTask<User?> GetUserAsync(string userId, CancellationToken cancellationToken = default);
    ValueTask<User?> CreateUserAsync(User user, CancellationToken cancellationToken = default);
    ValueTask<User?> UpdateUserAsync(string userId, User user, CancellationToken cancellationToken = default);
    ValueTask<bool> DeleteUserAsync(string userId, CancellationToken cancellationToken = default);
}
