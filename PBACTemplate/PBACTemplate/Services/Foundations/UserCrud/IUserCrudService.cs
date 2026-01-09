// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// IUserCrudService.cs See LICENSE.txt in the root folder of the solution.

using PBACTemplate.Models.User;

namespace PBACTemplate.Services.Foundations.UserCrud;

public interface IUserCrudService
{
    ValueTask<ApplicationUser> CreateUserAsync(ApplicationUser user);
    ValueTask<ApplicationUser> CreateUserWithPasswordAsync(ApplicationUser user, string password);
    ValueTask<ApplicationUser> UpdateUserAsync(ApplicationUser user);
    ValueTask<ApplicationUser> DeleteUserAsync(ApplicationUser user);
    ValueTask<ApplicationUser?> RetrieveUserByIdAsync(string userId);
    ValueTask<ApplicationUser?> RetrieveUserByNameAsync(string userName);
    ValueTask<ApplicationUser?> RetrieveUserByEmailAsync(string email);
    ValueTask<ApplicationUser?> RetrieveUserByLoginAsync(string loginProvider, string providerKey);
}