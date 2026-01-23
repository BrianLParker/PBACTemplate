// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// UserService.cs See LICENSE.txt in the root folder of the solution.

using PBACTemplate.Brokers.User;
using PBACTemplate.Client.Models.Users;
using PBACTemplate.Services.Foundations.UserCrud;
using System.Collections.Immutable;

namespace PBACTemplate.Services.Foundations.Users;

public sealed partial class UserService(
    IUserManagerBroker userManagerBroker,
    ILogger<UserCrudService> logger) : IUserService
{
    private readonly IUserManagerBroker userManagerBroker = userManagerBroker;
    private readonly ILogger<UserCrudService> logger = logger;

    public ValueTask<User> CreateUserAsync(User newUser) => throw new NotImplementedException();
    public ValueTask<bool> RemoveUserAsync(string userId) => throw new NotImplementedException();
    public ValueTask<User?> RetrieveUserByIdAsync(string userId) => throw new NotImplementedException();
    public ValueTask<ImmutableList<User>> RetrieveUsersAsync() => throw new NotImplementedException();
    public ValueTask<User> UpdateUserAsync(string userId, User newUser) => throw new NotImplementedException();
}
