// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// IPasswordService.cs See LICENSE.txt in the root folder of the solution.

using PBACTemplate.Data;

namespace PBACTemplate.Services.Foundations.Password;

public interface IPasswordService
{
    ValueTask<bool> CheckPasswordAsync(ApplicationUser user, string password);
    ValueTask<bool> HasPasswordAsync(ApplicationUser user);
    ValueTask<ApplicationUser> AddPasswordAsync(ApplicationUser user, string password);
    ValueTask<ApplicationUser> ChangePasswordAsync(ApplicationUser user, string currentPassword, string newPassword);
    ValueTask<ApplicationUser> RemovePasswordAsync(ApplicationUser user);
    ValueTask<string> GeneratePasswordResetTokenAsync(ApplicationUser user);
    ValueTask<ApplicationUser> ResetPasswordAsync(ApplicationUser user, string token, string newPassword);
}