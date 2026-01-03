// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// UserNameService.cs See LICENSE.txt in the root folder of the solution.

using PBACTemplate.Brokers.User;
using PBACTemplate.Data;
using System.Security.Claims;

namespace PBACTemplate.Services.Foundations.UserName;

public partial class UserNameService(
    IUserManagerBroker userManagerBroker,
    ILogger<UserNameService> logger) : IUserNameService
{
    private readonly IUserManagerBroker userManagerBroker = userManagerBroker;
    private readonly ILogger<UserNameService> logger = logger;

    public string? RetrieveUserName(ClaimsPrincipal principal) =>
        TryCatch(() =>
        {
            ValidatePrincipal(principal);

            LogRetrievingUserNameFromPrincipal();

            return this.userManagerBroker.GetUserName(principal);
        });

    public ValueTask<string?> RetrieveUserNameAsync(ApplicationUser user) =>
        TryCatch(async () =>
        {
            ValidateUser(user);

            LogRetrievingUserName(user.Id);

            return await this.userManagerBroker.GetUserNameAsync(user);
        });

    public ValueTask<ApplicationUser> SetUserNameAsync(ApplicationUser user, string? userName) =>
        TryCatch(async () =>
        {
            ValidateUser(user);

            LogSettingUserName(user.Id);

            var result = await this.userManagerBroker.SetUserNameAsync(user, userName);
            ValidateIdentityResult(result);

            await this.userManagerBroker.UpdateNormalizedUserNameAsync(user);

            return user;
        });

    public string? NormalizeName(string? name) =>
        TryCatch(() =>
        {
            LogNormalizingName();

            return this.userManagerBroker.NormalizeName(name);
        });

    public string? RetrieveUserId(ClaimsPrincipal principal) =>
        TryCatch(() =>
        {
            ValidatePrincipal(principal);

            LogRetrievingUserIdFromPrincipal();

            return this.userManagerBroker.GetUserId(principal);
        });

    public ValueTask<string> RetrieveUserIdAsync(ApplicationUser user) =>
        TryCatch(async () =>
        {
            ValidateUser(user);

            LogRetrievingUserId(user.Id);

            return await this.userManagerBroker.GetUserIdAsync(user);
        });

    public ValueTask<ApplicationUser?> RetrieveUserAsync(ClaimsPrincipal principal) =>
        TryCatch(async () =>
        {
            ValidatePrincipal(principal);

            LogRetrievingUserFromPrincipal();

            return await this.userManagerBroker.GetUserAsync(principal);
        });
}