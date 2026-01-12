// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// AccountOrchestrationService.UserCrud.cs See LICENSE.txt in the root folder of the solution.

using Microsoft.AspNetCore.Identity;
using PBACTemplate.Models.User;

namespace PBACTemplate.Services.Orchestrations.Account;

public partial class AccountOrchestrationService
{
    public async Task<IdentityResult> CreateAsync(ApplicationUser user)
    {
        await this.userCrudService.CreateUserAsync(user);

        return IdentityResult.Success;
    }

    public async Task<IdentityResult> CreateAsync(ApplicationUser user, string password)
    {
        await this.userCrudService.CreateUserWithPasswordAsync(user, password);

        return IdentityResult.Success;
    }

    public async Task<IdentityResult> UpdateAsync(ApplicationUser user)
    {
        await this.userCrudService.UpdateUserAsync(user);

        return IdentityResult.Success;
    }

    public async Task<IdentityResult> DeleteAsync(ApplicationUser user)
    {
        await this.userCrudService.DeleteUserAsync(user);

        return IdentityResult.Success;
    }

    public async Task<ApplicationUser?> FindByIdAsync(string userId) =>
        await this.userCrudService.RetrieveUserByIdAsync(userId);

    public async Task<ApplicationUser?> FindByNameAsync(string userName) =>
        await this.userCrudService.RetrieveUserByNameAsync(userName);

    public async Task<ApplicationUser?> FindByEmailAsync(string email) =>
        await this.userCrudService.RetrieveUserByEmailAsync(email);

    public async Task<ApplicationUser?> FindByLoginAsync(string loginProvider, string providerKey) =>
        await this.userCrudService.RetrieveUserByLoginAsync(loginProvider, providerKey);
}