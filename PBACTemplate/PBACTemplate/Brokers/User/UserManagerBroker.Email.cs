// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// UserManagerBroker.Email.cs See LICENSE.txt in the root folder of the solution.

using Microsoft.AspNetCore.Identity;
using PBACTemplate.Models.User;

namespace PBACTemplate.Brokers.User;

public sealed partial class UserManagerBroker
{
    public Task<string?> GetEmailAsync(ApplicationUser user) =>
        userManager.GetEmailAsync(user);

    public Task<IdentityResult> SetEmailAsync(ApplicationUser user, string? email) =>
        userManager.SetEmailAsync(user, email);

    public Task UpdateNormalizedEmailAsync(ApplicationUser user) =>
        userManager.UpdateNormalizedEmailAsync(user);

    public string? NormalizeEmail(string? email) =>
        userManager.NormalizeEmail(email);

    public Task<bool> IsEmailConfirmedAsync(ApplicationUser user) =>
        userManager.IsEmailConfirmedAsync(user);

    public Task<string> GenerateEmailConfirmationTokenAsync(ApplicationUser user) =>
        userManager.GenerateEmailConfirmationTokenAsync(user);

    public Task<IdentityResult> ConfirmEmailAsync(ApplicationUser user, string token) =>
        userManager.ConfirmEmailAsync(user, token);

    public Task<string> GenerateChangeEmailTokenAsync(ApplicationUser user, string newEmail) =>
        userManager.GenerateChangeEmailTokenAsync(user, newEmail);

    public Task<IdentityResult> ChangeEmailAsync(ApplicationUser user, string newEmail, string token) =>
        userManager.ChangeEmailAsync(user, newEmail, token);
}