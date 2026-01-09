// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// AuthTokensServiceTests.Logic.cs See LICENSE.txt in the root folder of the solution.

using Microsoft.AspNetCore.Identity;
using PBACTemplate.Models.User;

namespace PBACTemplate.Tests.Unit;

public partial class AuthTokensServiceTests
{
    [Fact]
    public async Task ShouldRetrieveAuthenticationTokenAsync()
    {
        // Given
        ApplicationUser inputUser = CreateUser();
        string inputLoginProvider = GetRandomString();
        string inputTokenName = GetRandomString();
        string? expectedToken = GetRandomString();

        this.userManagerBrokerMock.Setup(broker =>
            broker.GetAuthenticationTokenAsync(inputUser, inputLoginProvider, inputTokenName))
                .ReturnsAsync(expectedToken);

        // When
        string? actualToken =
            await this.authTokensService.RetrieveAuthenticationTokenAsync(
                inputUser,
                inputLoginProvider,
                inputTokenName);

        // Then
        Assert.Equal(expectedToken, actualToken);

        this.userManagerBrokerMock.Verify(broker =>
            broker.GetAuthenticationTokenAsync(inputUser, inputLoginProvider, inputTokenName),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldSetAuthenticationTokenAsync()
    {
        // Given
        ApplicationUser inputUser = CreateUser();
        string inputLoginProvider = GetRandomString();
        string inputTokenName = GetRandomString();
        string? inputTokenValue = GetRandomString();

        this.userManagerBrokerMock.Setup(broker =>
            broker.SetAuthenticationTokenAsync(
                inputUser,
                inputLoginProvider,
                inputTokenName,
                inputTokenValue))
                    .ReturnsAsync(IdentityResult.Success);

        // When
        ApplicationUser actualUser =
            await this.authTokensService.SetAuthenticationTokenAsync(
                inputUser,
                inputLoginProvider,
                inputTokenName,
                inputTokenValue);

        // Then
        Assert.Equal(inputUser, actualUser);

        this.userManagerBrokerMock.Verify(broker =>
            broker.SetAuthenticationTokenAsync(
                inputUser,
                inputLoginProvider,
                inputTokenName,
                inputTokenValue),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldRemoveAuthenticationTokenAsync()
    {
        // Given
        ApplicationUser inputUser = CreateUser();
        string inputLoginProvider = GetRandomString();
        string inputTokenName = GetRandomString();

        this.userManagerBrokerMock.Setup(broker =>
            broker.RemoveAuthenticationTokenAsync(inputUser, inputLoginProvider, inputTokenName))
                .ReturnsAsync(IdentityResult.Success);

        // When
        ApplicationUser actualUser =
            await this.authTokensService.RemoveAuthenticationTokenAsync(
                inputUser,
                inputLoginProvider,
                inputTokenName);

        // Then
        Assert.Equal(inputUser, actualUser);

        this.userManagerBrokerMock.Verify(broker =>
            broker.RemoveAuthenticationTokenAsync(inputUser, inputLoginProvider, inputTokenName),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldRetrieveAuthenticatorKeyAsync()
    {
        // Given
        ApplicationUser inputUser = CreateUser();
        string? expectedKey = GetRandomString();

        this.userManagerBrokerMock.Setup(broker =>
            broker.GetAuthenticatorKeyAsync(inputUser))
                .ReturnsAsync(expectedKey);

        // When
        string? actualKey =
            await this.authTokensService.RetrieveAuthenticatorKeyAsync(inputUser);

        // Then
        Assert.Equal(expectedKey, actualKey);

        this.userManagerBrokerMock.Verify(broker =>
            broker.GetAuthenticatorKeyAsync(inputUser),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldResetAuthenticatorKeyAsync()
    {
        // Given
        ApplicationUser inputUser = CreateUser();

        this.userManagerBrokerMock.Setup(broker =>
            broker.ResetAuthenticatorKeyAsync(inputUser))
                .ReturnsAsync(IdentityResult.Success);

        // When
        ApplicationUser actualUser =
            await this.authTokensService.ResetAuthenticatorKeyAsync(inputUser);

        // Then
        Assert.Equal(inputUser, actualUser);

        this.userManagerBrokerMock.Verify(broker =>
            broker.ResetAuthenticatorKeyAsync(inputUser),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public void ShouldGenerateNewAuthenticatorKey()
    {
        // Given
        string expectedKey = GetRandomString();

        this.userManagerBrokerMock.Setup(broker =>
            broker.GenerateNewAuthenticatorKey())
                .Returns(expectedKey);

        // When
        string actualKey = this.authTokensService.GenerateNewAuthenticatorKey();

        // Then
        Assert.Equal(expectedKey, actualKey);

        this.userManagerBrokerMock.Verify(broker =>
            broker.GenerateNewAuthenticatorKey(),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }
}