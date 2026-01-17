// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// RecoveryCodesService.cs See LICENSE.txt in the root folder of the solution.

using PBACTemplate.Brokers.User;
using PBACTemplate.Models.Users;

namespace PBACTemplate.Services.Foundations.RecoveryCodes;

public sealed partial class RecoveryCodesService(
    IUserManagerBroker userManagerBroker,
    ILogger<RecoveryCodesService> logger) : IRecoveryCodesService
{
    private readonly IUserManagerBroker userManagerBroker = userManagerBroker;
    private readonly ILogger<RecoveryCodesService> logger = logger;

    public ValueTask<IEnumerable<string>?> GenerateNewTwoFactorRecoveryCodesAsync(ApplicationUser user, int number) =>
        TryCatch(async () =>
        {
            ValidateUser(user);
            ValidateRecoveryCodeCount(number);

            LogGeneratingRecoveryCodes(user.Id, number);

            return await this.userManagerBroker.GenerateNewTwoFactorRecoveryCodesAsync(user, number);
        });

    public ValueTask<ApplicationUser> RedeemTwoFactorRecoveryCodeAsync(ApplicationUser user, string code) =>
        TryCatch(async () =>
        {
            ValidateUser(user);
            ValidateRecoveryCode(code);

            LogRedeemingRecoveryCode(user.Id);

            var result = await this.userManagerBroker.RedeemTwoFactorRecoveryCodeAsync(user, code);
            ValidateIdentityResult(result);

            return user;
        });

    public ValueTask<int> CountRecoveryCodesAsync(ApplicationUser user) =>
        TryCatch(async () =>
        {
            ValidateUser(user);

            LogCountingRecoveryCodes(user.Id);

            return await this.userManagerBroker.CountRecoveryCodesAsync(user);
        });
}