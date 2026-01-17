// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// PasswordService.cs See LICENSE.txt in the root folder of the solution.

using PBACTemplate.Brokers.User;
using PBACTemplate.Models.Users;

namespace PBACTemplate.Services.Foundations.Password;

public sealed partial class PasswordService(
    IUserManagerBroker userManagerBroker,
    ILogger<PasswordService> logger) : IPasswordService
{
    private readonly IUserManagerBroker userManagerBroker = userManagerBroker;
    private readonly ILogger<PasswordService> logger = logger;

    public ValueTask<bool> CheckPasswordAsync(ApplicationUser user, string password) =>
        TryCatch(async () =>
        {
            ValidateUser(user);
            ValidatePassword(password);

            LogCheckingPassword(user.Id);

            return await this.userManagerBroker.CheckPasswordAsync(user, password);
        });

    public ValueTask<bool> HasPasswordAsync(ApplicationUser user) =>
        TryCatch(async () =>
        {
            ValidateUser(user);

            LogCheckingHasPassword(user.Id);

            return await this.userManagerBroker.HasPasswordAsync(user);
        });

    public ValueTask<ApplicationUser> AddPasswordAsync(ApplicationUser user, string password) =>
        TryCatch(async () =>
        {
            ValidateUser(user);
            ValidatePassword(password);

            LogAddingPassword(user.Id);

            var result = await this.userManagerBroker.AddPasswordAsync(user, password);
            ValidateIdentityResult(result);

            return user;
        });

    public ValueTask<ApplicationUser> ChangePasswordAsync(
        ApplicationUser user,
        string currentPassword,
        string newPassword) =>
        TryCatch(async () =>
        {
            ValidateUser(user);
            ValidatePassword(currentPassword, nameof(currentPassword));
            ValidatePassword(newPassword, nameof(newPassword));

            LogChangingPassword(user.Id);

            var result = await this.userManagerBroker.ChangePasswordAsync(user, currentPassword, newPassword);
            ValidateIdentityResult(result);

            return user;
        });

    public ValueTask<ApplicationUser> RemovePasswordAsync(ApplicationUser user) =>
        TryCatch(async () =>
        {
            ValidateUser(user);

            LogRemovingPassword(user.Id);

            var result = await this.userManagerBroker.RemovePasswordAsync(user);
            ValidateIdentityResult(result);

            return user;
        });

    public ValueTask<string> GeneratePasswordResetTokenAsync(ApplicationUser user) =>
        TryCatch(async () =>
        {
            ValidateUser(user);

            LogGeneratingPasswordResetToken(user.Id);

            return await this.userManagerBroker.GeneratePasswordResetTokenAsync(user);
        });

    public ValueTask<ApplicationUser> ResetPasswordAsync(ApplicationUser user, string token, string newPassword) =>
        TryCatch(async () =>
        {
            ValidateUser(user);
            ValidateToken(token);
            ValidatePassword(newPassword, nameof(newPassword));

            LogResettingPassword(user.Id);

            var result = await this.userManagerBroker.ResetPasswordAsync(user, token, newPassword);
            ValidateIdentityResult(result);

            return user;
        });
}