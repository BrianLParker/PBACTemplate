// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// TwoFactorService.cs See LICENSE.txt in the root folder of the solution.

using PBACTemplate.Brokers.User;
using PBACTemplate.Data;

namespace PBACTemplate.Services.Foundations.TwoFactor;

public partial class TwoFactorService(
    IUserManagerBroker userManagerBroker,
    ILogger<TwoFactorService> logger) : ITwoFactorService
{
    private readonly IUserManagerBroker userManagerBroker = userManagerBroker;
    private readonly ILogger<TwoFactorService> logger = logger;

    public ValueTask<bool> GetTwoFactorEnabledAsync(ApplicationUser user) =>
        TryCatch(async () =>
        {
            ValidateUser(user);

            LogGettingTwoFactorEnabled(user.Id);

            return await this.userManagerBroker.GetTwoFactorEnabledAsync(user);
        });

    public ValueTask<ApplicationUser> SetTwoFactorEnabledAsync(ApplicationUser user, bool enabled) =>
        TryCatch(async () =>
        {
            ValidateUser(user);

            LogSettingTwoFactorEnabled(user.Id, enabled);

            var result = await this.userManagerBroker.SetTwoFactorEnabledAsync(user, enabled);
            ValidateIdentityResult(result);

            return user;
        });

    public ValueTask<IList<string>> RetrieveValidTwoFactorProvidersAsync(ApplicationUser user) =>
        TryCatch(async () =>
        {
            ValidateUser(user);

            LogRetrievingValidTwoFactorProviders(user.Id);

            return await this.userManagerBroker.GetValidTwoFactorProvidersAsync(user);
        });

    public ValueTask<string> GenerateTwoFactorTokenAsync(ApplicationUser user, string tokenProvider) =>
        TryCatch(async () =>
        {
            ValidateUser(user);
            ValidateTokenProvider(tokenProvider);

            LogGeneratingTwoFactorToken(user.Id, tokenProvider);

            return await this.userManagerBroker.GenerateTwoFactorTokenAsync(user, tokenProvider);
        });

    public ValueTask<bool> VerifyTwoFactorTokenAsync(ApplicationUser user, string tokenProvider, string token) =>
        TryCatch(async () =>
        {
            ValidateUser(user);
            ValidateTokenProvider(tokenProvider);
            ValidateToken(token);

            LogVerifyingTwoFactorToken(user.Id, tokenProvider);

            return await this.userManagerBroker.VerifyTwoFactorTokenAsync(user, tokenProvider, token);
        });
}