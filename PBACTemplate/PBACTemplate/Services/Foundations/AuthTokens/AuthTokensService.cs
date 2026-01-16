// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// AuthTokensService.cs See LICENSE.txt in the root folder of the solution.

using PBACTemplate.Brokers.User;
using PBACTemplate.Models.Users;

namespace PBACTemplate.Services.Foundations.AuthTokens;

public sealed partial class AuthTokensService(
    IUserManagerBroker userManagerBroker,
    ILogger<AuthTokensService> logger) : IAuthTokensService
{
    private readonly IUserManagerBroker userManagerBroker = userManagerBroker;
    private readonly ILogger<AuthTokensService> logger = logger;

    public ValueTask<string?> RetrieveAuthenticationTokenAsync(
        ApplicationUser user,
        string loginProvider,
        string tokenName) =>
        TryCatch(async () =>
        {
            ValidateUser(user);
            ValidateLoginProvider(loginProvider);
            ValidateTokenName(tokenName);

            LogRetrievingAuthenticationToken(user.Id, loginProvider, tokenName);

            return await this.userManagerBroker.GetAuthenticationTokenAsync(
                user,
                loginProvider,
                tokenName);
        });

    public ValueTask<ApplicationUser> SetAuthenticationTokenAsync(
        ApplicationUser user,
        string loginProvider,
        string tokenName,
        string? tokenValue) =>
        TryCatch(async () =>
        {
            ValidateUser(user);
            ValidateLoginProvider(loginProvider);
            ValidateTokenName(tokenName);

            LogSettingAuthenticationToken(user.Id, loginProvider, tokenName);

            var result = await this.userManagerBroker.SetAuthenticationTokenAsync(
                user,
                loginProvider,
                tokenName,
                tokenValue);

            ValidateIdentityResult(result);

            return user;
        });

    public ValueTask<ApplicationUser> RemoveAuthenticationTokenAsync(
        ApplicationUser user,
        string loginProvider,
        string tokenName) =>
        TryCatch(async () =>
        {
            ValidateUser(user);
            ValidateLoginProvider(loginProvider);
            ValidateTokenName(tokenName);

            LogRemovingAuthenticationToken(user.Id, loginProvider, tokenName);

            var result = await this.userManagerBroker.RemoveAuthenticationTokenAsync(
                user,
                loginProvider,
                tokenName);

            ValidateIdentityResult(result);

            return user;
        });

    public ValueTask<string?> RetrieveAuthenticatorKeyAsync(ApplicationUser user) =>
        TryCatch(async () =>
        {
            ValidateUser(user);

            LogRetrievingAuthenticatorKey(user.Id);

            return await this.userManagerBroker.GetAuthenticatorKeyAsync(user);
        });

    public ValueTask<ApplicationUser> ResetAuthenticatorKeyAsync(ApplicationUser user) =>
        TryCatch(async () =>
        {
            ValidateUser(user);

            LogResettingAuthenticatorKey(user.Id);

            var result = await this.userManagerBroker.ResetAuthenticatorKeyAsync(user);
            ValidateIdentityResult(result);

            return user;
        });

    public string GenerateNewAuthenticatorKey() =>
        TryCatch(() =>
        {
            LogGeneratingNewAuthenticatorKey();

            return this.userManagerBroker.GenerateNewAuthenticatorKey();
        });
}