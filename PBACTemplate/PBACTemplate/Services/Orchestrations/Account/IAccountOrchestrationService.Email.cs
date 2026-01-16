// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// IAccountOrchestrationService.Email.cs See LICENSE.txt in the root folder of the solution.

using Microsoft.AspNetCore.Identity;
using PBACTemplate.Models.Users;

namespace PBACTemplate.Services.Orchestrations.Account;

public partial interface IAccountOrchestrationService
{
    // Email operations
    Task<string?> GetEmailAsync(ApplicationUser user);
    Task<IdentityResult> SetEmailAsync(ApplicationUser user, string? email);
    Task UpdateNormalizedEmailAsync(ApplicationUser user);
    string? NormalizeEmail(string? email);
    Task<bool> IsEmailConfirmedAsync(ApplicationUser user);
    Task<string> GenerateEmailConfirmationTokenAsync(ApplicationUser user);
    Task<IdentityResult> ConfirmEmailAsync(ApplicationUser user, string token);
    Task<string> GenerateChangeEmailTokenAsync(ApplicationUser user, string newEmail);
    Task<IdentityResult> ChangeEmailAsync(ApplicationUser user, string newEmail, string token);
}