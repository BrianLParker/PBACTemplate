// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// EmailService.cs See LICENSE.txt in the root folder of the solution.

using PBACTemplate.Brokers.User;
using PBACTemplate.Models.User;

namespace PBACTemplate.Services.Foundations.Email;

public sealed partial class EmailService(
    IUserManagerBroker userManagerBroker,
    ILogger<EmailService> logger) : IEmailService
{
    private readonly IUserManagerBroker userManagerBroker = userManagerBroker;
    private readonly ILogger<EmailService> logger = logger;

    public ValueTask<string?> RetrieveEmailAsync(ApplicationUser user) =>
        TryCatch(async () =>
        {
            ValidateUser(user);

            LogRetrievingEmail(user.Id);

            return await this.userManagerBroker.GetEmailAsync(user);
        });

    public ValueTask<ApplicationUser> SetEmailAsync(ApplicationUser user, string? email) =>
        TryCatch(async () =>
        {
            ValidateUser(user);

            LogSettingEmail(user.Id);

            var result = await this.userManagerBroker.SetEmailAsync(user, email);
            ValidateIdentityResult(result);

            await this.userManagerBroker.UpdateNormalizedEmailAsync(user);

            return user;
        });

    public string? NormalizeEmail(string? email) =>
        TryCatch(() =>
        {
            ValidateEmail(email!);
            LogNormalizingEmail();

            return this.userManagerBroker.NormalizeEmail(email);
        });

    public ValueTask<bool> IsEmailConfirmedAsync(ApplicationUser user) =>
        TryCatch(async () =>
        {
            ValidateUser(user);

            LogCheckingEmailConfirmation(user.Id);

            return await this.userManagerBroker.IsEmailConfirmedAsync(user);
        });

    public ValueTask<string> GenerateEmailConfirmationTokenAsync(ApplicationUser user) =>
        TryCatch(async () =>
        {
            ValidateUser(user);

            LogGeneratingEmailConfirmationToken(user.Id);

            return await this.userManagerBroker.GenerateEmailConfirmationTokenAsync(user);
        });

    public ValueTask<ApplicationUser> ConfirmEmailAsync(ApplicationUser user, string token) =>
        TryCatch(async () =>
        {
            ValidateUser(user);
            ValidateToken(token);

            LogConfirmingEmail(user.Id);

            var result = await this.userManagerBroker.ConfirmEmailAsync(user, token);
            ValidateIdentityResult(result);

            return user;
        });

    public ValueTask<string> GenerateChangeEmailTokenAsync(ApplicationUser user, string newEmail) =>
        TryCatch(async () =>
        {
            ValidateUser(user);
            ValidateEmail(newEmail);

            LogGeneratingChangeEmailToken(user.Id);

            return await this.userManagerBroker.GenerateChangeEmailTokenAsync(user, newEmail);
        });

    public ValueTask<ApplicationUser> ChangeEmailAsync(ApplicationUser user, string newEmail, string token) =>
        TryCatch(async () =>
        {
            ValidateUser(user);
            ValidateEmail(newEmail);
            ValidateToken(token);

            LogChangingEmail(user.Id);

            var result = await this.userManagerBroker.ChangeEmailAsync(user, newEmail, token);
            ValidateIdentityResult(result);

            return user;
        });
}