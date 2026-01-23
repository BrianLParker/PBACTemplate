// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// UserService.cs See LICENSE.txt in the root folder of the solution.

using PBACTemplate.Client.Brokers.HttpClients;
using PBACTemplate.Client.Models.Users;
using PBACTemplate.Client.Services.Foundations.Users.Exceptions;
using System.Collections.Immutable;

namespace PBACTemplate.Client.Services.Foundations.Users;

public sealed partial class UserService(
    IHttpClientBroker httpClient,
    ILogger<UserService> logger) : IUserService
{
    private readonly IHttpClientBroker httpClient = httpClient;
    private readonly ILogger<UserService> logger = logger;

    public ValueTask<User?> CreateAdministrationUserAsync(
        User user,
        CancellationToken cancellationToken = default) =>
        TryCatch(async () =>
        {
            ValidateUser(user);

            LogCreatingUser(user.UserName);

            var createdUser = await this.httpClient.CreateAdministrationUserAsync(user, cancellationToken);

            if (createdUser is null)
            {
                throw new FailedUsersOperationException("Failed to create user.");
            }

            return createdUser;
        });

    public ValueTask<bool> DeleteAdministrationUserAsync(
        string userId,
        CancellationToken cancellationToken = default) =>
        TryCatch(async () =>
        {
            ValidateUserId(userId);

            LogRemovingUser(userId);

            bool deleted = await this.httpClient.DeleteAdministrationUserAsync(userId, cancellationToken);

            if (!deleted)
            {
                throw new FailedUsersOperationException("Failed to delete user.");
            }

            return true;
        });

    public ValueTask<User?> GetAdministrationUserAsync(
        string userId,
        CancellationToken cancellationToken = default) =>
        TryCatch(async () =>
        {
            ValidateUserId(userId);

            LogRetrievingUserById(userId);

            return await this.httpClient.GetAdministrationUserAsync(userId, cancellationToken);
        });

    public ValueTask<ImmutableList<User>> GetAdministrationUsersAsync(
        CancellationToken cancellationToken = default) =>
        TryCatch(async () =>
        {
            LogRetrievingUsers();

            return await this.httpClient.GetAdministrationUsersAsync(cancellationToken);
        });

    public ValueTask<User?> UpdateAdministrationUserAsync(
        string userId,
        User user,
        CancellationToken cancellationToken = default) =>
        TryCatch(async () =>
        {
            ValidateUserId(userId);
            ValidateUser(user);

            LogUpdatingUser(userId);

            var updatedUser = await this.httpClient.UpdateAdministrationUserAsync(userId, user, cancellationToken);

            if (updatedUser is null)
            {
                throw new FailedUsersOperationException("Failed to update user.");
            }

            return updatedUser;
        });
}
