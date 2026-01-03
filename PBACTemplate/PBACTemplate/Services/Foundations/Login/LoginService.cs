// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// LoginService.cs See LICENSE.txt in the root folder of the solution.

using Microsoft.AspNetCore.Identity;
using PBACTemplate.Brokers.User;
using PBACTemplate.Data;

namespace PBACTemplate.Services.Foundations.Login;

public partial class LoginService(
    IUserManagerBroker userManagerBroker,
    ILogger<LoginService> logger) : ILoginService
{
    private readonly IUserManagerBroker userManagerBroker = userManagerBroker;
    private readonly ILogger<LoginService> logger = logger;

    public ValueTask<ApplicationUser> AddLoginAsync(ApplicationUser user, UserLoginInfo login) =>
        TryCatch(async () =>
        {
            ValidateUser(user);
            ValidateLoginInfo(login);

            LogAddingLogin(user.Id, login.LoginProvider);

            var result = await this.userManagerBroker.AddLoginAsync(user, login);
            ValidateIdentityResult(result);

            return user;
        });

    public ValueTask<ApplicationUser> RemoveLoginAsync(ApplicationUser user, string loginProvider, string providerKey) =>
        TryCatch(async () =>
        {
            ValidateUser(user);
            ValidateLoginProvider(loginProvider);
            ValidateProviderKey(providerKey);

            LogRemovingLogin(user.Id, loginProvider);

            var result = await this.userManagerBroker.RemoveLoginAsync(user, loginProvider, providerKey);
            ValidateIdentityResult(result);

            return user;
        });

    public ValueTask<IList<UserLoginInfo>> RetrieveLoginsAsync(ApplicationUser user) =>
        TryCatch(async () =>
        {
            ValidateUser(user);

            LogRetrievingLogins(user.Id);

            return await this.userManagerBroker.GetLoginsAsync(user);
        });
}