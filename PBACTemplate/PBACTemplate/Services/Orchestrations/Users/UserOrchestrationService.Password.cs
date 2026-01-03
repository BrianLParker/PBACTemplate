// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// UserOrchestrationService.Password.cs See LICENSE.txt in the root folder of the solution.

using Microsoft.AspNetCore.Identity;
using PBACTemplate.Data;

namespace PBACTemplate.Services.Orchestrations.Users;

public partial class UserOrchestrationService
{
    public async Task<bool> CheckPasswordAsync(ApplicationUser user, string password) =>
        await this.passwordService.CheckPasswordAsync(user, password);

    public async Task<bool> HasPasswordAsync(ApplicationUser user) =>
        await this.passwordService.HasPasswordAsync(user);

    public async Task<IdentityResult> AddPasswordAsync(ApplicationUser user, string password)
    {
        await this.passwordService.AddPasswordAsync(user, password);

        return IdentityResult.Success;
    }

    public async Task<IdentityResult> ChangePasswordAsync(
        ApplicationUser user,
        string currentPassword,
        string newPassword)
    {
        await this.passwordService.ChangePasswordAsync(user, currentPassword, newPassword);

        return IdentityResult.Success;
    }

    public async Task<IdentityResult> RemovePasswordAsync(ApplicationUser user)
    {
        await this.passwordService.RemovePasswordAsync(user);

        return IdentityResult.Success;
    }

    public async Task<string> GeneratePasswordResetTokenAsync(ApplicationUser user) =>
        await this.passwordService.GeneratePasswordResetTokenAsync(user);

    public async Task<IdentityResult> ResetPasswordAsync(ApplicationUser user, string token, string newPassword)
    {
        await this.passwordService.ResetPasswordAsync(user, token, newPassword);

        return IdentityResult.Success;
    }
}