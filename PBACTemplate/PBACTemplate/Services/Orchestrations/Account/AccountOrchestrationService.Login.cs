// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// AccountOrchestrationService.Login.cs See LICENSE.txt in the root folder of the solution.

using Microsoft.AspNetCore.Identity;
using PBACTemplate.Models.Users;

namespace PBACTemplate.Services.Orchestrations.Account;

public partial class AccountOrchestrationService
{
    public async Task<IdentityResult> AddLoginAsync(ApplicationUser user, UserLoginInfo login)
    {
        await this.loginService.AddLoginAsync(user, login);

        return IdentityResult.Success;
    }

    public async Task<IdentityResult> RemoveLoginAsync(ApplicationUser user, string loginProvider, string providerKey)
    {
        await this.loginService.RemoveLoginAsync(user, loginProvider, providerKey);

        return IdentityResult.Success;
    }

    public async Task<IList<UserLoginInfo>> GetLoginsAsync(ApplicationUser user) =>
        await this.loginService.RetrieveLoginsAsync(user);
}