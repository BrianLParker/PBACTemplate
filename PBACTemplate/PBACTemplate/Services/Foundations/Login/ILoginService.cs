// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// ILoginService.cs See LICENSE.txt in the root folder of the solution.

using Microsoft.AspNetCore.Identity;
using PBACTemplate.Models.Users;

namespace PBACTemplate.Services.Foundations.Login;

public interface ILoginService
{
    ValueTask<ApplicationUser> AddLoginAsync(ApplicationUser user, UserLoginInfo login);
    ValueTask<ApplicationUser> RemoveLoginAsync(ApplicationUser user, string loginProvider, string providerKey);
    ValueTask<IList<UserLoginInfo>> RetrieveLoginsAsync(ApplicationUser user);
}