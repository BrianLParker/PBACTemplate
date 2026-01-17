// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// TokensService.cs See LICENSE.txt in the root folder of the solution.

using PBACTemplate.Brokers.User;
using PBACTemplate.Models.Users;

namespace PBACTemplate.Services.Foundations.Tokens;

public sealed partial class TokensService(
    IUserManagerBroker userManagerBroker,
    ILogger<TokensService> logger) : ITokensService
{
    private readonly IUserManagerBroker userManagerBroker = userManagerBroker;
    private readonly ILogger<TokensService> logger = logger;

    public ValueTask<string> GenerateUserTokenAsync(ApplicationUser user, string tokenProvider, string purpose) =>
        TryCatch(async () =>
        {
            ValidateUser(user);
            ValidateTokenProvider(tokenProvider);
            ValidatePurpose(purpose);

            LogGeneratingUserToken(user.Id, tokenProvider, purpose);

            return await this.userManagerBroker.GenerateUserTokenAsync(user, tokenProvider, purpose);
        });

    public ValueTask<bool> VerifyUserTokenAsync(ApplicationUser user, string tokenProvider, string purpose, string token) =>
        TryCatch(async () =>
        {
            ValidateUser(user);
            ValidateTokenProvider(tokenProvider);
            ValidatePurpose(purpose);
            ValidateToken(token);

            LogVerifyingUserToken(user.Id, tokenProvider, purpose);

            return await this.userManagerBroker.VerifyUserTokenAsync(user, tokenProvider, purpose, token);
        });
}