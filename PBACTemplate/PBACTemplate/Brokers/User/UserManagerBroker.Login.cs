// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// UserManagerBroker.Login.cs See LICENSE.txt in the root folder of the solution.

using Microsoft.AspNetCore.Identity;
using PBACTemplate.Data;

namespace PBACTemplate.Brokers.User;

public sealed partial class UserManagerBroker
{
    public Task<IdentityResult> AddLoginAsync(ApplicationUser user, UserLoginInfo login) =>
        userManager.AddLoginAsync(user, login);

    public Task<IdentityResult> RemoveLoginAsync(ApplicationUser user, string loginProvider, string providerKey) =>
        userManager.RemoveLoginAsync(user, loginProvider, providerKey);

    public Task<IList<UserLoginInfo>> GetLoginsAsync(ApplicationUser user) =>
        userManager.GetLoginsAsync(user);
}