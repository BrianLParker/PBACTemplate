// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// IAccountOrchestrationService.Password.cs See LICENSE.txt in the root folder of the solution.

using Microsoft.AspNetCore.Identity;
using PBACTemplate.Models.Users;

namespace PBACTemplate.Services.Orchestrations.Account;

public partial interface IAccountOrchestrationService
{
    // Password operations
    Task<bool> CheckPasswordAsync(ApplicationUser user, string password);
    Task<bool> HasPasswordAsync(ApplicationUser user);
    Task<IdentityResult> AddPasswordAsync(ApplicationUser user, string password);
    Task<IdentityResult> ChangePasswordAsync(ApplicationUser user, string currentPassword, string newPassword);
    Task<IdentityResult> RemovePasswordAsync(ApplicationUser user);
    Task<string> GeneratePasswordResetTokenAsync(ApplicationUser user);
    Task<IdentityResult> ResetPasswordAsync(ApplicationUser user, string token, string newPassword);
}