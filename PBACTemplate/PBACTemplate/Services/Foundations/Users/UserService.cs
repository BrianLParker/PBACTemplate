// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// UserService.cs See LICENSE.txt in the root folder of the solution.

using PBACTemplate.Brokers.User;
using PBACTemplate.Client.Models.Users;
using PBACTemplate.Models.Users;
using System.Collections.Immutable;

namespace PBACTemplate.Services.Foundations.Users;

public sealed partial class UserService(
    IUserManagerBroker userManagerBroker,
    ILogger<UserService> logger) : IUserService
{
    private readonly IUserManagerBroker userManagerBroker = userManagerBroker;
    private readonly ILogger<UserService> logger = logger;

    public ValueTask<User> CreateUserAsync(User newUser) =>
        TryCatch(async () =>
        {
            ValidateUser(newUser);

            var applicationUser = MapToApplicationUser(newUser);

            LogCreatingUser(applicationUser.Id);

            var result = await this.userManagerBroker.CreateAsync(applicationUser);
            ValidateIdentityResult(result);

            return MapToUser(applicationUser);
        });

    public ValueTask<bool> RemoveUserAsync(string userId) =>
        TryCatch(async () =>
        {
            ValidateUserId(userId);

            var applicationUser = await this.userManagerBroker.FindByIdAsync(userId);

            if (applicationUser is null)
            {
                return false;
            }

            LogRemovingUser(userId);

            var result = await this.userManagerBroker.DeleteAsync(applicationUser);
            ValidateIdentityResult(result);

            return true;
        });

    public ValueTask<User?> RetrieveUserByIdAsync(string userId) =>
        TryCatch(async () =>
        {
            ValidateUserId(userId);

            LogRetrievingUserById(userId);

            var applicationUser = await this.userManagerBroker.FindByIdAsync(userId);

            return applicationUser is null
                ? null
                : MapToUser(applicationUser);
        });

    public ValueTask<ImmutableList<User>> RetrieveUsersAsync() =>
        TryCatch(async () =>
        {
            LogRetrievingUsers();

            var users = this.userManagerBroker.Users.ToList();

            return users
                .Select(MapToUser)
                .ToImmutableList();
        });

    public ValueTask<User> UpdateUserAsync(string userId, User newUser) =>
        TryCatch(async () =>
        {
            ValidateUserId(userId);
            ValidateUser(newUser);

            var applicationUser = MapToApplicationUser(newUser);
            applicationUser.Id = userId;

            LogUpdatingUser(userId);

            var result = await this.userManagerBroker.UpdateAsync(applicationUser);
            ValidateIdentityResult(result);

            return MapToUser(applicationUser);
        });

    internal static User MapToUser(ApplicationUser user)
    {
        ArgumentNullException.ThrowIfNull(user);

        return new User
        {
            Id = user.Id ?? string.Empty,
            UserName = user.UserName ?? string.Empty,
            Email = user.Email ?? string.Empty,
            EmailConfirmed = user.EmailConfirmed,
            FirstName = user.FirstName,
            LastName = user.LastName,
            PhoneNumber = user.PhoneNumber ?? string.Empty,
            PhoneNumberConfirmed = user.PhoneNumberConfirmed,
            LockoutEnd = user.LockoutEnd,
            CreatedAt = default,
            UpdatedAt = default,
            LastSignInAt = null,
            AccessFailedCount = user.AccessFailedCount,
            ConcurrencyStamp = user.ConcurrencyStamp,
            AvatarUrl = null,
            Roles = []
        };
    }

    internal static ApplicationUser MapToApplicationUser(User user)
    {
        ArgumentNullException.ThrowIfNull(user);

        string id = string.IsNullOrWhiteSpace(user.Id)
            ? Guid.NewGuid().ToString()
            : user.Id;

        return new ApplicationUser
        {
            Id = id,
            UserName = user.UserName,
            Email = user.Email,
            EmailConfirmed = user.EmailConfirmed,
            FirstName = user.FirstName,
            LastName = user.LastName,
            PhoneNumber = user.PhoneNumber,
            PhoneNumberConfirmed = user.PhoneNumberConfirmed,
            LockoutEnd = user.LockoutEnd,
            AccessFailedCount = user.AccessFailedCount,
            ConcurrencyStamp = user.ConcurrencyStamp
        };
    }
}
