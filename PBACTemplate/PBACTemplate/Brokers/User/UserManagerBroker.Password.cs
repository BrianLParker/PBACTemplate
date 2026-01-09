// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// UserManagerBroker.Password.cs See LICENSE.txt in the root folder of the solution.

using Microsoft.AspNetCore.Identity;
using PBACTemplate.Models.User;

namespace PBACTemplate.Brokers.User;

public sealed partial class UserManagerBroker
{
    public Task<bool> CheckPasswordAsync(ApplicationUser user, string password) =>
        userManager.CheckPasswordAsync(user, password);

    public Task<bool> HasPasswordAsync(ApplicationUser user) =>
        userManager.HasPasswordAsync(user);

    public Task<IdentityResult> AddPasswordAsync(ApplicationUser user, string password) =>
        userManager.AddPasswordAsync(user, password);

    public Task<IdentityResult> ChangePasswordAsync(ApplicationUser user, string currentPassword, string newPassword) =>
        userManager.ChangePasswordAsync(user, currentPassword, newPassword);

    public Task<IdentityResult> RemovePasswordAsync(ApplicationUser user) =>
        userManager.RemovePasswordAsync(user);

    public Task<string> GeneratePasswordResetTokenAsync(ApplicationUser user) =>
        userManager.GeneratePasswordResetTokenAsync(user);

    public Task<IdentityResult> ResetPasswordAsync(ApplicationUser user, string token, string newPassword) =>
        userManager.ResetPasswordAsync(user, token, newPassword);
}