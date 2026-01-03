// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// UserCrudService.cs See LICENSE.txt in the root folder of the solution.

using PBACTemplate.Brokers.User;
using PBACTemplate.Data;

namespace PBACTemplate.Services.Foundations.UserCrud;

public sealed partial class UserCrudService(
    IUserManagerBroker userManagerBroker,
    ILogger<UserCrudService> logger) : IUserCrudService
{
    private readonly IUserManagerBroker userManagerBroker = userManagerBroker;
    private readonly ILogger<UserCrudService> logger = logger;

    public ValueTask<ApplicationUser> CreateUserAsync(ApplicationUser user) =>
        TryCatch(async () =>
        {
            ValidateUser(user);

            LogCreatingUser();

            var result = await this.userManagerBroker.CreateAsync(user);
            ValidateIdentityResult(result);

            return user;
        });

    public ValueTask<ApplicationUser> CreateUserWithPasswordAsync(ApplicationUser user, string password) =>
        TryCatch(async () =>
        {
            ValidateUser(user);
            ValidatePassword(password);

            LogCreatingUserWithPassword();

            var result = await this.userManagerBroker.CreateAsync(user, password);
            ValidateIdentityResult(result);

            return user;
        });

    public ValueTask<ApplicationUser> UpdateUserAsync(ApplicationUser user) =>
        TryCatch(async () =>
        {
            ValidateUser(user);

            LogUpdatingUser(user.Id);

            var result = await this.userManagerBroker.UpdateAsync(user);
            ValidateIdentityResult(result);

            return user;
        });

    public ValueTask<ApplicationUser> DeleteUserAsync(ApplicationUser user) =>
        TryCatch(async () =>
        {
            ValidateUser(user);

            LogDeletingUser(user.Id);

            var result = await this.userManagerBroker.DeleteAsync(user);
            ValidateIdentityResult(result);

            return user;
        });

    public ValueTask<ApplicationUser?> RetrieveUserByIdAsync(string userId) =>
        TryCatch(async () =>
        {
            ValidateUserId(userId);

            LogRetrievingUserById(userId);

            return await this.userManagerBroker.FindByIdAsync(userId);
        });

    public ValueTask<ApplicationUser?> RetrieveUserByNameAsync(string userName) =>
        TryCatch(async () =>
        {
            ValidateUserName(userName);

            LogRetrievingUserByName(userName);

            return await this.userManagerBroker.FindByNameAsync(userName);
        });

    public ValueTask<ApplicationUser?> RetrieveUserByEmailAsync(string email) =>
        TryCatch(async () =>
        {
            ValidateEmail(email);

            LogRetrievingUserByEmail();

            return await this.userManagerBroker.FindByEmailAsync(email);
        });

    public ValueTask<ApplicationUser?> RetrieveUserByLoginAsync(string loginProvider, string providerKey) =>
        TryCatch(async () =>
        {
            ValidateLoginProvider(loginProvider);
            ValidateProviderKey(providerKey);

            LogRetrievingUserByLogin(loginProvider);

            return await this.userManagerBroker.FindByLoginAsync(loginProvider, providerKey);
        });
}