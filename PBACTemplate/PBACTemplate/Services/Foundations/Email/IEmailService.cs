// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// IEmailService.cs See LICENSE.txt in the root folder of the solution.

using PBACTemplate.Models.User;

namespace PBACTemplate.Services.Foundations.Email;

public interface IEmailService
{
    ValueTask<string?> RetrieveEmailAsync(ApplicationUser user);
    ValueTask<ApplicationUser> SetEmailAsync(ApplicationUser user, string? email);
    string? NormalizeEmail(string? email);
    ValueTask<bool> IsEmailConfirmedAsync(ApplicationUser user);
    ValueTask<string> GenerateEmailConfirmationTokenAsync(ApplicationUser user);
    ValueTask<ApplicationUser> ConfirmEmailAsync(ApplicationUser user, string token);
    ValueTask<string> GenerateChangeEmailTokenAsync(ApplicationUser user, string newEmail);
    ValueTask<ApplicationUser> ChangeEmailAsync(ApplicationUser user, string newEmail, string token);
}