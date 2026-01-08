// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// AuthTokensServiceTests.Exceptions.cs See LICENSE.txt in the root folder of the solution.

using PBACTemplate.Data;
using PBACTemplate.Services.Foundations.AuthTokens.Exceptions;

namespace PBACTemplate.Tests.Unit;

public partial class AuthTokensServiceTests
{
    [Fact]
    public async Task ShouldThrowAuthTokensServiceExceptionOnRetrieveAuthenticationTokenAsyncIfExceptionOccurs()
    {
        // Given
        ApplicationUser inputUser = CreateUser();
        string loginProvider = GetRandomString();
        string tokenName = GetRandomString();
        var someException = new Exception(GetRandomString());

        this.userManagerBrokerMock.Setup(broker =>
            broker.GetAuthenticationTokenAsync(inputUser, loginProvider, tokenName))
                .ThrowsAsync(someException);

        var expectedException = new AuthTokensServiceException(
            "Auth tokens service error occurred, contact support.",
            new FailedAuthTokensServiceException(
                "Failed auth tokens service error occurred, contact support.",
                someException));

        // When
        Func<Task> action = async () => await this.authTokensService
            .RetrieveAuthenticationTokenAsync(inputUser, loginProvider, tokenName);

        // Then
        AuthTokensServiceException actualException =
            await Assert.ThrowsAsync<AuthTokensServiceException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);
        Assert.IsType<FailedAuthTokensServiceException>(actualException.InnerException);

        this.userManagerBrokerMock.Verify(broker =>
            broker.GetAuthenticationTokenAsync(inputUser, loginProvider, tokenName),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldThrowAuthTokensServiceExceptionOnSetAuthenticationTokenAsyncIfExceptionOccurs()
    {
        // Given
        ApplicationUser inputUser = CreateUser();
        string loginProvider = GetRandomString();
        string tokenName = GetRandomString();
        string? tokenValue = GetRandomString();
        var someException = new Exception(GetRandomString());

        this.userManagerBrokerMock.Setup(broker =>
            broker.SetAuthenticationTokenAsync(
                inputUser,
                loginProvider,
                tokenName,
                tokenValue))
                    .ThrowsAsync(someException);

        var expectedException = new AuthTokensServiceException(
            "Auth tokens service error occurred, contact support.",
            new FailedAuthTokensServiceException(
                "Failed auth tokens service error occurred, contact support.",
                someException));

        // When
        Func<Task> action = async () => await this.authTokensService
            .SetAuthenticationTokenAsync(inputUser, loginProvider, tokenName, tokenValue);

        // Then
        AuthTokensServiceException actualException =
            await Assert.ThrowsAsync<AuthTokensServiceException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);
        Assert.IsType<FailedAuthTokensServiceException>(actualException.InnerException);

        this.userManagerBrokerMock.Verify(broker =>
            broker.SetAuthenticationTokenAsync(
                inputUser,
                loginProvider,
                tokenName,
                tokenValue),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldThrowAuthTokensServiceExceptionOnRemoveAuthenticationTokenAsyncIfExceptionOccurs()
    {
        // Given
        ApplicationUser inputUser = CreateUser();
        string loginProvider = GetRandomString();
        string tokenName = GetRandomString();
        var someException = new Exception(GetRandomString());

        this.userManagerBrokerMock.Setup(broker =>
            broker.RemoveAuthenticationTokenAsync(inputUser, loginProvider, tokenName))
                .ThrowsAsync(someException);

        var expectedException = new AuthTokensServiceException(
            "Auth tokens service error occurred, contact support.",
            new FailedAuthTokensServiceException(
                "Failed auth tokens service error occurred, contact support.",
                someException));

        // When
        Func<Task> action = async () => await this.authTokensService
            .RemoveAuthenticationTokenAsync(inputUser, loginProvider, tokenName);

        // Then
        AuthTokensServiceException actualException =
            await Assert.ThrowsAsync<AuthTokensServiceException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);
        Assert.IsType<FailedAuthTokensServiceException>(actualException.InnerException);

        this.userManagerBrokerMock.Verify(broker =>
            broker.RemoveAuthenticationTokenAsync(inputUser, loginProvider, tokenName),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldThrowAuthTokensServiceExceptionOnRetrieveAuthenticatorKeyAsyncIfExceptionOccurs()
    {
        // Given
        ApplicationUser inputUser = CreateUser();
        var someException = new Exception(GetRandomString());

        this.userManagerBrokerMock.Setup(broker =>
            broker.GetAuthenticatorKeyAsync(inputUser))
                .ThrowsAsync(someException);

        var expectedException = new AuthTokensServiceException(
            "Auth tokens service error occurred, contact support.",
            new FailedAuthTokensServiceException(
                "Failed auth tokens service error occurred, contact support.",
                someException));

        // When
        Func<Task> action = async () => await this.authTokensService
            .RetrieveAuthenticatorKeyAsync(inputUser);

        // Then
        AuthTokensServiceException actualException =
            await Assert.ThrowsAsync<AuthTokensServiceException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);
        Assert.IsType<FailedAuthTokensServiceException>(actualException.InnerException);

        this.userManagerBrokerMock.Verify(broker =>
            broker.GetAuthenticatorKeyAsync(inputUser),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldThrowAuthTokensServiceExceptionOnResetAuthenticatorKeyAsyncIfExceptionOccurs()
    {
        // Given
        ApplicationUser inputUser = CreateUser();
        var someException = new Exception(GetRandomString());

        this.userManagerBrokerMock.Setup(broker =>
            broker.ResetAuthenticatorKeyAsync(inputUser))
                .ThrowsAsync(someException);

        var expectedException = new AuthTokensServiceException(
            "Auth tokens service error occurred, contact support.",
            new FailedAuthTokensServiceException(
                "Failed auth tokens service error occurred, contact support.",
                someException));

        // When
        Func<Task> action = async () => await this.authTokensService
            .ResetAuthenticatorKeyAsync(inputUser);

        // Then
        AuthTokensServiceException actualException =
            await Assert.ThrowsAsync<AuthTokensServiceException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);
        Assert.IsType<FailedAuthTokensServiceException>(actualException.InnerException);

        this.userManagerBrokerMock.Verify(broker =>
            broker.ResetAuthenticatorKeyAsync(inputUser),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public void ShouldThrowAuthTokensServiceExceptionOnGenerateNewAuthenticatorKeyIfExceptionOccurs()
    {
        // Given
        var someException = new Exception(GetRandomString());

        this.userManagerBrokerMock.Setup(broker =>
            broker.GenerateNewAuthenticatorKey())
                .Throws(someException);

        var expectedException = new AuthTokensServiceException(
            "Auth tokens service error occurred, contact support.",
            new FailedAuthTokensServiceException(
                "Failed auth tokens service error occurred, contact support.",
                someException));

        // When
        Func<string> action = () => this.authTokensService.GenerateNewAuthenticatorKey();

        // Then
        AuthTokensServiceException actualException =
            Assert.Throws<AuthTokensServiceException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);
        Assert.IsType<FailedAuthTokensServiceException>(actualException.InnerException);

        this.userManagerBrokerMock.Verify(broker =>
            broker.GenerateNewAuthenticatorKey(),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }
}