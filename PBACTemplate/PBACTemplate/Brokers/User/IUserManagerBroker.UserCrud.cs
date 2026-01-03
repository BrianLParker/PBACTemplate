// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// IUserManagerBroker.UserCrud.cs See LICENSE.txt in the root folder of the solution.

using Microsoft.AspNetCore.Identity;
using PBACTemplate.Data;

namespace PBACTemplate.Brokers.User;

public partial interface IUserManagerBroker
{
    // User CRUD operations
    Task<IdentityResult> CreateAsync(ApplicationUser user);
    Task<IdentityResult> CreateAsync(ApplicationUser user, string password);
    Task<IdentityResult> UpdateAsync(ApplicationUser user);
    Task<IdentityResult> DeleteAsync(ApplicationUser user);
    Task<ApplicationUser?> FindByIdAsync(string userId);
    Task<ApplicationUser?> FindByNameAsync(string userName);
    Task<ApplicationUser?> FindByEmailAsync(string email);
    Task<ApplicationUser?> FindByLoginAsync(string loginProvider, string providerKey);
}