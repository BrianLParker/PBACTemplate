// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// IAccountOrchestrationService.Login.cs See LICENSE.txt in the root folder of the solution.

using Microsoft.AspNetCore.Identity;
using PBACTemplate.Models.Users;

namespace PBACTemplate.Services.Orchestrations.Account;

public partial interface IAccountOrchestrationService
{
    // Login operations
    Task<IdentityResult> AddLoginAsync(ApplicationUser user, UserLoginInfo login);
    Task<IdentityResult> RemoveLoginAsync(ApplicationUser user, string loginProvider, string providerKey);
    Task<IList<UserLoginInfo>> GetLoginsAsync(ApplicationUser user);
}