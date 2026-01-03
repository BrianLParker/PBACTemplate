// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// UserManagerBroker.UserCrud.cs See LICENSE.txt in the root folder of the solution.

using Microsoft.AspNetCore.Identity;
using PBACTemplate.Data;

namespace PBACTemplate.Brokers.User;

public sealed partial class UserManagerBroker
{
    public Task<IdentityResult> CreateAsync(ApplicationUser user) =>
        userManager.CreateAsync(user);

    public Task<IdentityResult> CreateAsync(ApplicationUser user, string password) =>
        userManager.CreateAsync(user, password);

    public Task<IdentityResult> UpdateAsync(ApplicationUser user) =>
        userManager.UpdateAsync(user);

    public Task<IdentityResult> DeleteAsync(ApplicationUser user) =>
        userManager.DeleteAsync(user);

    public Task<ApplicationUser?> FindByIdAsync(string userId) =>
        userManager.FindByIdAsync(userId);

    public Task<ApplicationUser?> FindByNameAsync(string userName) =>
        userManager.FindByNameAsync(userName);

    public Task<ApplicationUser?> FindByEmailAsync(string email) =>
        userManager.FindByEmailAsync(email);

    public Task<ApplicationUser?> FindByLoginAsync(string loginProvider, string providerKey) =>
        userManager.FindByLoginAsync(loginProvider, providerKey);
}