// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// SecurityService.cs See LICENSE.txt in the root folder of the solution.

using PBACTemplate.Brokers.User;
using PBACTemplate.Data;

namespace PBACTemplate.Services.Foundations.Security;

public sealed partial class SecurityService(
    IUserManagerBroker userManagerBroker,
    ILogger<SecurityService> logger) : ISecurityService
{
    private readonly IUserManagerBroker userManagerBroker = userManagerBroker;
    private readonly ILogger<SecurityService> logger = logger;

    public ValueTask<string> RetrieveSecurityStampAsync(ApplicationUser user) =>
        TryCatch(async () =>
        {
            ValidateUser(user);

            LogRetrievingSecurityStamp(user.Id);

            return await this.userManagerBroker.GetSecurityStampAsync(user);
        });

    public ValueTask<ApplicationUser> UpdateSecurityStampAsync(ApplicationUser user) =>
        TryCatch(async () =>
        {
            ValidateUser(user);

            LogUpdatingSecurityStamp(user.Id);

            var result = await this.userManagerBroker.UpdateSecurityStampAsync(user);
            ValidateIdentityResult(result);

            return user;
        });

    public ValueTask<byte[]> CreateSecurityTokenAsync(ApplicationUser user) =>
        TryCatch(async () =>
        {
            ValidateUser(user);

            LogCreatingSecurityToken(user.Id);

            return await this.userManagerBroker.CreateSecurityTokenAsync(user);
        });

    public ValueTask<string> GenerateConcurrencyStampAsync(ApplicationUser user) =>
        TryCatch(async () =>
        {
            ValidateUser(user);

            LogGeneratingConcurrencyStamp(user.Id);

            return await this.userManagerBroker.GenerateConcurrencyStampAsync(user);
        });
}