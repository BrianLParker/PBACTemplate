// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// PhoneService.cs See LICENSE.txt in the root folder of the solution.

using PBACTemplate.Brokers.User;
using PBACTemplate.Data;

namespace PBACTemplate.Services.Foundations.Phone;

public sealed partial class PhoneService(
    IUserManagerBroker userManagerBroker,
    ILogger<PhoneService> logger) : IPhoneService
{
    private readonly IUserManagerBroker userManagerBroker = userManagerBroker;
    private readonly ILogger<PhoneService> logger = logger;

    public ValueTask<string?> RetrievePhoneNumberAsync(ApplicationUser user) =>
        TryCatch(async () =>
        {
            ValidateUser(user);

            LogRetrievingPhoneNumber(user.Id);

            return await this.userManagerBroker.GetPhoneNumberAsync(user);
        });

    public ValueTask<ApplicationUser> SetPhoneNumberAsync(ApplicationUser user, string? phoneNumber) =>
        TryCatch(async () =>
        {
            ValidateUser(user);

            LogSettingPhoneNumber(user.Id);

            var result = await this.userManagerBroker.SetPhoneNumberAsync(user, phoneNumber);
            ValidateIdentityResult(result);

            return user;
        });

    public ValueTask<bool> IsPhoneNumberConfirmedAsync(ApplicationUser user) =>
        TryCatch(async () =>
        {
            ValidateUser(user);

            LogCheckingPhoneNumberConfirmed(user.Id);

            return await this.userManagerBroker.IsPhoneNumberConfirmedAsync(user);
        });

    public ValueTask<string> GenerateChangePhoneNumberTokenAsync(ApplicationUser user, string phoneNumber) =>
        TryCatch(async () =>
        {
            ValidateUser(user);
            ValidatePhoneNumber(phoneNumber);

            LogGeneratingChangePhoneNumberToken(user.Id);

            return await this.userManagerBroker.GenerateChangePhoneNumberTokenAsync(user, phoneNumber);
        });

    public ValueTask<bool> VerifyChangePhoneNumberTokenAsync(ApplicationUser user, string token, string phoneNumber) =>
        TryCatch(async () =>
        {
            ValidateUser(user);
            ValidateToken(token);
            ValidatePhoneNumber(phoneNumber);

            LogVerifyingChangePhoneNumberToken(user.Id);

            return await this.userManagerBroker.VerifyChangePhoneNumberTokenAsync(user, token, phoneNumber);
        });

    public ValueTask<ApplicationUser> ChangePhoneNumberAsync(ApplicationUser user, string phoneNumber, string token) =>
        TryCatch(async () =>
        {
            ValidateUser(user);
            ValidatePhoneNumber(phoneNumber);
            ValidateToken(token);

            LogChangingPhoneNumber(user.Id);

            var result = await this.userManagerBroker.ChangePhoneNumberAsync(user, phoneNumber, token);
            ValidateIdentityResult(result);

            return user;
        });
}