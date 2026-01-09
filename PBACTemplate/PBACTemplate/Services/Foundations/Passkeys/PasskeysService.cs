// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// PasskeysService.cs See LICENSE.txt in the root folder of the solution.

using Microsoft.AspNetCore.Identity;
using PBACTemplate.Brokers.User;
using PBACTemplate.Models.User;

namespace PBACTemplate.Services.Foundations.Passkeys;

public sealed partial class PasskeysService(
    IUserManagerBroker userManagerBroker,
    ILogger<PasskeysService> logger) : IPasskeysService
{
    private readonly IUserManagerBroker userManagerBroker = userManagerBroker;
    private readonly ILogger<PasskeysService> logger = logger;

    public ValueTask<ApplicationUser> AddOrUpdatePasskeyAsync(ApplicationUser user, UserPasskeyInfo passkey) =>
        TryCatch(async () =>
        {
            ValidateUser(user);
            ValidatePasskey(passkey);

            LogAddingOrUpdatingPasskey(user.Id);

            var result = await this.userManagerBroker.AddOrUpdatePasskeyAsync(user, passkey);
            ValidateIdentityResult(result);

            return user;
        });

    public ValueTask<IList<UserPasskeyInfo>> RetrievePasskeysAsync(ApplicationUser user) =>
        TryCatch(async () =>
        {
            ValidateUser(user);

            LogRetrievingPasskeys(user.Id);

            return await this.userManagerBroker.GetPasskeysAsync(user);
        });

    public ValueTask<UserPasskeyInfo?> RetrievePasskeyAsync(ApplicationUser user, byte[] credentialId) =>
        TryCatch(async () =>
        {
            ValidateUser(user);
            ValidateCredentialId(credentialId);

            LogRetrievingPasskey(user.Id);

            return await this.userManagerBroker.GetPasskeyAsync(user, credentialId);
        });

    public ValueTask<ApplicationUser?> RetrieveUserByPasskeyIdAsync(byte[] credentialId) =>
        TryCatch(async () =>
        {
            ValidateCredentialId(credentialId);

            LogRetrievingUserByPasskeyId();

            return await this.userManagerBroker.FindByPasskeyIdAsync(credentialId);
        });

    public ValueTask<ApplicationUser> RemovePasskeyAsync(ApplicationUser user, byte[] credentialId) =>
        TryCatch(async () =>
        {
            ValidateUser(user);
            ValidateCredentialId(credentialId);

            LogRemovingPasskey(user.Id);

            var result = await this.userManagerBroker.RemovePasskeyAsync(user, credentialId);
            ValidateIdentityResult(result);

            return user;
        });
}