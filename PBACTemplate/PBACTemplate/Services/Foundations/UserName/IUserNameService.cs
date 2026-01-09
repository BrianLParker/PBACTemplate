// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// IUserNameService.cs See LICENSE.txt in the root folder of the solution.

using PBACTemplate.Models.User;
using System.Security.Claims;

namespace PBACTemplate.Services.Foundations.UserName;

public interface IUserNameService
{
    string? RetrieveUserName(ClaimsPrincipal principal);
    ValueTask<string?> RetrieveUserNameAsync(ApplicationUser user);
    ValueTask<ApplicationUser> SetUserNameAsync(ApplicationUser user, string? userName);
    string? NormalizeName(string? name);
    string? RetrieveUserId(ClaimsPrincipal principal);
    ValueTask<string> RetrieveUserIdAsync(ApplicationUser user);
    ValueTask<ApplicationUser?> RetrieveUserAsync(ClaimsPrincipal principal);
}