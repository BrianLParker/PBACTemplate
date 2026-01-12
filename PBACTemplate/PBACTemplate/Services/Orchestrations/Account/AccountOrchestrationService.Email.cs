// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// UserOrchestrationService.Email.cs See LICENSE.txt in the root folder of the solution.

using Microsoft.AspNetCore.Identity;
using PBACTemplate.Models.User;

namespace PBACTemplate.Services.Orchestrations.Account;

public partial class AccountOrchestrationService
{
    public async Task<string?> GetEmailAsync(ApplicationUser user) =>
        await this.emailService.RetrieveEmailAsync(user);

    public async Task<IdentityResult> SetEmailAsync(ApplicationUser user, string? email)
    {
        await this.emailService.SetEmailAsync(user, email);

        return IdentityResult.Success;
    }

    public Task UpdateNormalizedEmailAsync(ApplicationUser user) =>
        Task.CompletedTask;

    public string? NormalizeEmail(string? email) =>
        this.emailService.NormalizeEmail(email);

    public async Task<bool> IsEmailConfirmedAsync(ApplicationUser user) =>
        await this.emailService.IsEmailConfirmedAsync(user);

    public async Task<string> GenerateEmailConfirmationTokenAsync(ApplicationUser user) =>
        await this.emailService.GenerateEmailConfirmationTokenAsync(user);

    public async Task<IdentityResult> ConfirmEmailAsync(ApplicationUser user, string token)
    {
        await this.emailService.ConfirmEmailAsync(user, token);

        return IdentityResult.Success;
    }

    public async Task<string> GenerateChangeEmailTokenAsync(ApplicationUser user, string newEmail) =>
        await this.emailService.GenerateChangeEmailTokenAsync(user, newEmail);

    public async Task<IdentityResult> ChangeEmailAsync(ApplicationUser user, string newEmail, string token)
    {
        await this.emailService.ChangeEmailAsync(user, newEmail, token);

        return IdentityResult.Success;
    }
}