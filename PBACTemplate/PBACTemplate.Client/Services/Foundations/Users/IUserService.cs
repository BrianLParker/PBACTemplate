// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// IUserService.cs See LICENSE.txt in the root folder of the solution.

using PBACTemplate.Client.Models.Users;
using System.Collections.Immutable;

namespace PBACTemplate.Client.Services.Foundations.Users;

public interface IUserService
{
    ValueTask<ImmutableList<User>> GetAdministrationUsersAsync(CancellationToken cancellationToken = default);
    ValueTask<User?> GetAdministrationUserAsync(string userId, CancellationToken cancellationToken = default);
    ValueTask<User?> CreateAdministrationUserAsync(User user, CancellationToken cancellationToken = default);
    ValueTask<User?> UpdateAdministrationUserAsync(string userId, User user, CancellationToken cancellationToken = default);
    ValueTask<bool> DeleteAdministrationUserAsync(string userId, CancellationToken cancellationToken = default);
}
