// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// AccountOrchestrationService.UserName.cs See LICENSE.txt in the root folder of the solution.

using Microsoft.AspNetCore.Identity;
using PBACTemplate.Models.Users;
using System.Security.Claims;

namespace PBACTemplate.Services.Orchestrations.Account;

public partial class AccountOrchestrationService
{
    public string? GetUserName(ClaimsPrincipal principal) =>
        this.userNameService.RetrieveUserName(principal);

    public async Task<string?> GetUserNameAsync(ApplicationUser user) =>
        await this.userNameService.RetrieveUserNameAsync(user);

    public async Task<IdentityResult> SetUserNameAsync(ApplicationUser user, string? userName)
    {
        await this.userNameService.SetUserNameAsync(user, userName);

        return IdentityResult.Success;
    }

    public Task UpdateNormalizedUserNameAsync(ApplicationUser user) =>
        Task.CompletedTask;

    public string? NormalizeName(string? name) =>
        this.userNameService.NormalizeName(name);

    public string? GetUserId(ClaimsPrincipal principal) =>
        this.userNameService.RetrieveUserId(principal);

    public async Task<string> GetUserIdAsync(ApplicationUser user) =>
        await this.userNameService.RetrieveUserIdAsync(user);

    public async Task<ApplicationUser?> GetUserAsync(ClaimsPrincipal principal) =>
        await this.userNameService.RetrieveUserAsync(principal);
}