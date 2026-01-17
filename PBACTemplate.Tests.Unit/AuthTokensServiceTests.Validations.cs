// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// AuthTokensServiceTests.Validations.cs See LICENSE.txt in the root folder of the solution.

using Microsoft.AspNetCore.Identity;
using PBACTemplate.Models.Users;
using PBACTemplate.Services.Foundations.AuthTokens.Exceptions;

namespace PBACTemplate.Tests.Unit;

public partial class AuthTokensServiceTests
{
    [Fact]
    public async Task ShouldThrowNullAuthTokensExceptionOnRetrieveAuthenticationTokenAsyncIfUserIsNull()
    {
        // Given
        ApplicationUser? nullUser = null;
        string loginProvider = GetRandomString();
        string tokenName = GetRandomString();

        var expectedException = new NullAuthTokensException("User cannot be null.");

        // When
        Func<Task> action = async () => await this.authTokensService
            .RetrieveAuthenticationTokenAsync(nullUser!, loginProvider, tokenName);

        // Then
        NullAuthTokensException actualException =
            await Assert.ThrowsAsync<NullAuthTokensException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);

        this.userManagerBrokerMock.Verify(broker =>
            broker.GetAuthenticationTokenAsync(
                It.IsAny<ApplicationUser>(),
                It.IsAny<string>(),
                It.IsAny<string>()),
            Times.Never);

        VerifyNoOtherBrokerCalls();
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("   ")]
    public async Task ShouldThrowInvalidAuthTokensExceptionOnRetrieveAuthenticationTokenAsyncIfLoginProviderIsInvalid(
        string? invalidLoginProvider)
    {
        // Given
        ApplicationUser user = CreateUser();
        string tokenName = GetRandomString();

        var expectedException = new InvalidAuthTokensException(
            "Login provider cannot be null or whitespace.");

        // When
        Func<Task> action = async () => await this.authTokensService
            .RetrieveAuthenticationTokenAsync(user, invalidLoginProvider!, tokenName);

        // Then
        InvalidAuthTokensException actualException =
            await Assert.ThrowsAsync<InvalidAuthTokensException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);

        this.userManagerBrokerMock.Verify(broker =>
            broker.GetAuthenticationTokenAsync(
                It.IsAny<ApplicationUser>(),
                It.IsAny<string>(),
                It.IsAny<string>()),
            Times.Never);

        VerifyNoOtherBrokerCalls();
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("   ")]
    public async Task ShouldThrowInvalidAuthTokensExceptionOnRetrieveAuthenticationTokenAsyncIfTokenNameIsInvalid(
        string? invalidTokenName)
    {
        // Given
        ApplicationUser user = CreateUser();
        string loginProvider = GetRandomString();

        var expectedException = new InvalidAuthTokensException(
            "Token name cannot be null or whitespace.");

        // When
        Func<Task> action = async () => await this.authTokensService
            .RetrieveAuthenticationTokenAsync(user, loginProvider, invalidTokenName!);

        // Then
        InvalidAuthTokensException actualException =
            await Assert.ThrowsAsync<InvalidAuthTokensException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);

        this.userManagerBrokerMock.Verify(broker =>
            broker.GetAuthenticationTokenAsync(
                It.IsAny<ApplicationUser>(),
                It.IsAny<string>(),
                It.IsAny<string>()),
            Times.Never);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldThrowNullAuthTokensExceptionOnSetAuthenticationTokenAsyncIfUserIsNull()
    {
        // Given
        ApplicationUser? nullUser = null;
        string loginProvider = GetRandomString();
        string tokenName = GetRandomString();
        string? tokenValue = GetRandomString();

        var expectedException = new NullAuthTokensException("User cannot be null.");

        // When
        Func<Task> action = async () => await this.authTokensService
            .SetAuthenticationTokenAsync(nullUser!, loginProvider, tokenName, tokenValue);

        // Then
        NullAuthTokensException actualException =
            await Assert.ThrowsAsync<NullAuthTokensException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);

        this.userManagerBrokerMock.Verify(broker =>
            broker.SetAuthenticationTokenAsync(
                It.IsAny<ApplicationUser>(),
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<string?>()),
            Times.Never);

        VerifyNoOtherBrokerCalls();
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("   ")]
    public async Task ShouldThrowInvalidAuthTokensExceptionOnSetAuthenticationTokenAsyncIfLoginProviderIsInvalid(
        string? invalidLoginProvider)
    {
        // Given
        ApplicationUser user = CreateUser();
        string tokenName = GetRandomString();
        string? tokenValue = GetRandomString();

        var expectedException = new InvalidAuthTokensException(
            "Login provider cannot be null or whitespace.");

        // When
        Func<Task> action = async () => await this.authTokensService
            .SetAuthenticationTokenAsync(user, invalidLoginProvider!, tokenName, tokenValue);

        // Then
        InvalidAuthTokensException actualException =
            await Assert.ThrowsAsync<InvalidAuthTokensException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);

        this.userManagerBrokerMock.Verify(broker =>
            broker.SetAuthenticationTokenAsync(
                It.IsAny<ApplicationUser>(),
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<string?>()),
            Times.Never);

        VerifyNoOtherBrokerCalls();
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("   ")]
    public async Task ShouldThrowInvalidAuthTokensExceptionOnSetAuthenticationTokenAsyncIfTokenNameIsInvalid(
        string? invalidTokenName)
    {
        // Given
        ApplicationUser user = CreateUser();
        string loginProvider = GetRandomString();
        string? tokenValue = GetRandomString();

        var expectedException = new InvalidAuthTokensException(
            "Token name cannot be null or whitespace.");

        // When
        Func<Task> action = async () => await this.authTokensService
            .SetAuthenticationTokenAsync(user, loginProvider, invalidTokenName!, tokenValue);

        // Then
        InvalidAuthTokensException actualException =
            await Assert.ThrowsAsync<InvalidAuthTokensException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);

        this.userManagerBrokerMock.Verify(broker =>
            broker.SetAuthenticationTokenAsync(
                It.IsAny<ApplicationUser>(),
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<string?>()),
            Times.Never);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldThrowNullAuthTokensExceptionOnRemoveAuthenticationTokenAsyncIfUserIsNull()
    {
        // Given
        ApplicationUser? nullUser = null;
        string loginProvider = GetRandomString();
        string tokenName = GetRandomString();

        var expectedException = new NullAuthTokensException("User cannot be null.");

        // When
        Func<Task> action = async () => await this.authTokensService
            .RemoveAuthenticationTokenAsync(nullUser!, loginProvider, tokenName);

        // Then
        NullAuthTokensException actualException =
            await Assert.ThrowsAsync<NullAuthTokensException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);

        this.userManagerBrokerMock.Verify(broker =>
            broker.RemoveAuthenticationTokenAsync(
                It.IsAny<ApplicationUser>(),
                It.IsAny<string>(),
                It.IsAny<string>()),
            Times.Never);

        VerifyNoOtherBrokerCalls();
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("   ")]
    public async Task ShouldThrowInvalidAuthTokensExceptionOnRemoveAuthenticationTokenAsyncIfLoginProviderIsInvalid(
        string? invalidLoginProvider)
    {
        // Given
        ApplicationUser user = CreateUser();
        string tokenName = GetRandomString();

        var expectedException = new InvalidAuthTokensException(
            "Login provider cannot be null or whitespace.");

        // When
        Func<Task> action = async () => await this.authTokensService
            .RemoveAuthenticationTokenAsync(user, invalidLoginProvider!, tokenName);

        // Then
        InvalidAuthTokensException actualException =
            await Assert.ThrowsAsync<InvalidAuthTokensException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);

        this.userManagerBrokerMock.Verify(broker =>
            broker.RemoveAuthenticationTokenAsync(
                It.IsAny<ApplicationUser>(),
                It.IsAny<string>(),
                It.IsAny<string>()),
            Times.Never);

        VerifyNoOtherBrokerCalls();
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("   ")]
    public async Task ShouldThrowInvalidAuthTokensExceptionOnRemoveAuthenticationTokenAsyncIfTokenNameIsInvalid(
        string? invalidTokenName)
    {
        // Given
        ApplicationUser user = CreateUser();
        string loginProvider = GetRandomString();

        var expectedException = new InvalidAuthTokensException(
            "Token name cannot be null or whitespace.");

        // When
        Func<Task> action = async () => await this.authTokensService
            .RemoveAuthenticationTokenAsync(user, loginProvider, invalidTokenName!);

        // Then
        InvalidAuthTokensException actualException =
            await Assert.ThrowsAsync<InvalidAuthTokensException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);

        this.userManagerBrokerMock.Verify(broker =>
            broker.RemoveAuthenticationTokenAsync(
                It.IsAny<ApplicationUser>(),
                It.IsAny<string>(),
                It.IsAny<string>()),
            Times.Never);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldThrowFailedAuthTokensOperationExceptionOnSetAuthenticationTokenAsyncIfIdentityResultFailed()
    {
        // Given
        ApplicationUser user = CreateUser();
        string loginProvider = GetRandomString();
        string tokenName = GetRandomString();
        string? tokenValue = GetRandomString();
        var identityError = new IdentityError { Description = GetRandomString() };

        IdentityResult failedResult = IdentityResult.Failed(identityError);

        this.userManagerBrokerMock.Setup(broker =>
            broker.SetAuthenticationTokenAsync(
                user,
                loginProvider,
                tokenName,
                tokenValue))
                    .ReturnsAsync(failedResult);

        var expectedException = new FailedAuthTokensOperationException(
            $"Identity operation failed: {identityError.Description}");

        // When
        Func<Task> action = async () => await this.authTokensService
            .SetAuthenticationTokenAsync(user, loginProvider, tokenName, tokenValue);

        // Then
        FailedAuthTokensOperationException actualException =
            await Assert.ThrowsAsync<FailedAuthTokensOperationException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);

        this.userManagerBrokerMock.Verify(broker =>
            broker.SetAuthenticationTokenAsync(
                user,
                loginProvider,
                tokenName,
                tokenValue),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldThrowFailedAuthTokensOperationExceptionOnRemoveAuthenticationTokenAsyncIfIdentityResultFailed()
    {
        // Given
        ApplicationUser user = CreateUser();
        string loginProvider = GetRandomString();
        string tokenName = GetRandomString();
        var identityError = new IdentityError { Description = GetRandomString() };

        IdentityResult failedResult = IdentityResult.Failed(identityError);

        this.userManagerBrokerMock.Setup(broker =>
            broker.RemoveAuthenticationTokenAsync(user, loginProvider, tokenName))
                .ReturnsAsync(failedResult);

        var expectedException = new FailedAuthTokensOperationException(
            $"Identity operation failed: {identityError.Description}");

        // When
        Func<Task> action = async () => await this.authTokensService
            .RemoveAuthenticationTokenAsync(user, loginProvider, tokenName);

        // Then
        FailedAuthTokensOperationException actualException =
            await Assert.ThrowsAsync<FailedAuthTokensOperationException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);

        this.userManagerBrokerMock.Verify(broker =>
            broker.RemoveAuthenticationTokenAsync(user, loginProvider, tokenName),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldThrowFailedAuthTokensOperationExceptionOnResetAuthenticatorKeyAsyncIfIdentityResultFailed()
    {
        // Given
        ApplicationUser user = CreateUser();
        var identityError = new IdentityError { Description = GetRandomString() };

        IdentityResult failedResult = IdentityResult.Failed(identityError);

        this.userManagerBrokerMock.Setup(broker =>
            broker.ResetAuthenticatorKeyAsync(user))
                .ReturnsAsync(failedResult);

        var expectedException = new FailedAuthTokensOperationException(
            $"Identity operation failed: {identityError.Description}");

        // When
        Func<Task> action = async () => await this.authTokensService
            .ResetAuthenticatorKeyAsync(user);

        // Then
        FailedAuthTokensOperationException actualException =
            await Assert.ThrowsAsync<FailedAuthTokensOperationException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);

        this.userManagerBrokerMock.Verify(broker =>
            broker.ResetAuthenticatorKeyAsync(user),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldThrowNullAuthTokensExceptionOnRetrieveAuthenticatorKeyAsyncIfUserIsNull()
    {
        // Given
        ApplicationUser? nullUser = null;

        var expectedException = new NullAuthTokensException("User cannot be null.");

        // When
        Func<Task> action = async () => await this.authTokensService
            .RetrieveAuthenticatorKeyAsync(nullUser!);

        // Then
        NullAuthTokensException actualException =
            await Assert.ThrowsAsync<NullAuthTokensException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);

        this.userManagerBrokerMock.Verify(broker =>
            broker.GetAuthenticatorKeyAsync(It.IsAny<ApplicationUser>()),
            Times.Never);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldThrowNullAuthTokensExceptionOnResetAuthenticatorKeyAsyncIfUserIsNull()
    {
        // Given
        ApplicationUser? nullUser = null;

        var expectedException = new NullAuthTokensException("User cannot be null.");

        // When
        Func<Task> action = async () => await this.authTokensService
            .ResetAuthenticatorKeyAsync(nullUser!);

        // Then
        NullAuthTokensException actualException =
            await Assert.ThrowsAsync<NullAuthTokensException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);

        this.userManagerBrokerMock.Verify(broker =>
            broker.ResetAuthenticatorKeyAsync(It.IsAny<ApplicationUser>()),
            Times.Never);

        VerifyNoOtherBrokerCalls();
    }
}