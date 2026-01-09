// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// LoginServiceTests.Validations.cs See LICENSE.txt in the root folder of the solution.

using Microsoft.AspNetCore.Identity;
using PBACTemplate.Models.User;
using PBACTemplate.Services.Foundations.Login.Exceptions;

namespace PBACTemplate.Tests.Unit;

public partial class LoginServiceTests
{
    [Fact]
    public async Task ShouldThrowNullLoginExceptionOnAddLoginAsyncIfUserIsNull()
    {
        // Given
        ApplicationUser? nullUser = null;
        UserLoginInfo login = CreateLogin();

        var expectedException = new NullLoginException("User cannot be null.");

        // When
        Func<Task> action = async () => await this.loginService.AddLoginAsync(nullUser!, login);

        // Then
        NullLoginException actualException =
            await Assert.ThrowsAsync<NullLoginException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);

        this.userManagerBrokerMock.Verify(broker =>
            broker.AddLoginAsync(It.IsAny<ApplicationUser>(), It.IsAny<UserLoginInfo>()),
            Times.Never);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldThrowNullLoginExceptionOnAddLoginAsyncIfLoginInfoIsNull()
    {
        // Given
        ApplicationUser user = CreateUser();
        UserLoginInfo? nullLogin = null;

        var expectedException = new NullLoginException("Login info cannot be null.");

        // When
        Func<Task> action = async () => await this.loginService.AddLoginAsync(user, nullLogin!);

        // Then
        NullLoginException actualException =
            await Assert.ThrowsAsync<NullLoginException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);

        this.userManagerBrokerMock.Verify(broker =>
            broker.AddLoginAsync(It.IsAny<ApplicationUser>(), It.IsAny<UserLoginInfo>()),
            Times.Never);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldThrowFailedLoginOperationExceptionOnAddLoginAsyncIfIdentityResultFailed()
    {
        // Given
        ApplicationUser user = CreateUser();
        UserLoginInfo login = CreateLogin();
        var identityError = new IdentityError { Description = GetRandomString() };
        IdentityResult failedResult = IdentityResult.Failed(identityError);

        this.userManagerBrokerMock.Setup(broker =>
            broker.AddLoginAsync(user, login))
                .ReturnsAsync(failedResult);

        var expectedException = new FailedLoginOperationException(
            $"Identity operation failed: {identityError.Description}");

        // When
        Func<Task> action = async () => await this.loginService.AddLoginAsync(user, login);

        // Then
        FailedLoginOperationException actualException =
            await Assert.ThrowsAsync<FailedLoginOperationException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);

        this.userManagerBrokerMock.Verify(broker =>
            broker.AddLoginAsync(user, login),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldThrowNullLoginExceptionOnRemoveLoginAsyncIfUserIsNull()
    {
        // Given
        ApplicationUser? nullUser = null;
        string provider = GetRandomString();
        string providerKey = GetRandomString();

        var expectedException = new NullLoginException("User cannot be null.");

        // When
        Func<Task> action = async () => await this.loginService.RemoveLoginAsync(nullUser!, provider, providerKey);

        // Then
        NullLoginException actualException =
            await Assert.ThrowsAsync<NullLoginException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);

        this.userManagerBrokerMock.Verify(broker =>
            broker.RemoveLoginAsync(It.IsAny<ApplicationUser>(), It.IsAny<string>(), It.IsAny<string>()),
            Times.Never);

        VerifyNoOtherBrokerCalls();
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("   ")]
    public async Task ShouldThrowInvalidLoginExceptionOnRemoveLoginAsyncIfProviderIsInvalid(string? invalidProvider)
    {
        // Given
        ApplicationUser user = CreateUser();
        string providerKey = GetRandomString();

        var expectedException = new InvalidLoginException("Login provider cannot be null or whitespace.");

        // When
        Func<Task> action = async () => await this.loginService.RemoveLoginAsync(user, invalidProvider!, providerKey);

        // Then
        InvalidLoginException actualException =
            await Assert.ThrowsAsync<InvalidLoginException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);

        this.userManagerBrokerMock.Verify(broker =>
            broker.RemoveLoginAsync(It.IsAny<ApplicationUser>(), It.IsAny<string>(), It.IsAny<string>()),
            Times.Never);

        VerifyNoOtherBrokerCalls();
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("   ")]
    public async Task ShouldThrowInvalidLoginExceptionOnRemoveLoginAsyncIfProviderKeyIsInvalid(string? invalidProviderKey)
    {
        // Given
        ApplicationUser user = CreateUser();
        string provider = GetRandomString();

        var expectedException = new InvalidLoginException("Provider key cannot be null or whitespace.");

        // When
        Func<Task> action = async () => await this.loginService.RemoveLoginAsync(user, provider, invalidProviderKey!);

        // Then
        InvalidLoginException actualException =
            await Assert.ThrowsAsync<InvalidLoginException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);

        this.userManagerBrokerMock.Verify(broker =>
            broker.RemoveLoginAsync(It.IsAny<ApplicationUser>(), It.IsAny<string>(), It.IsAny<string>()),
            Times.Never);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldThrowFailedLoginOperationExceptionOnRemoveLoginAsyncIfIdentityResultFailed()
    {
        // Given
        ApplicationUser user = CreateUser();
        string provider = GetRandomString();
        string providerKey = GetRandomString();
        var identityError = new IdentityError { Description = GetRandomString() };
        IdentityResult failedResult = IdentityResult.Failed(identityError);

        this.userManagerBrokerMock.Setup(broker =>
            broker.RemoveLoginAsync(user, provider, providerKey))
                .ReturnsAsync(failedResult);

        var expectedException = new FailedLoginOperationException(
            $"Identity operation failed: {identityError.Description}");

        // When
        Func<Task> action = async () => await this.loginService.RemoveLoginAsync(user, provider, providerKey);

        // Then
        FailedLoginOperationException actualException =
            await Assert.ThrowsAsync<FailedLoginOperationException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);

        this.userManagerBrokerMock.Verify(broker =>
            broker.RemoveLoginAsync(user, provider, providerKey),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldThrowNullLoginExceptionOnRetrieveLoginsAsyncIfUserIsNull()
    {
        // Given
        ApplicationUser? nullUser = null;

        var expectedException = new NullLoginException("User cannot be null.");

        // When
        Func<Task> action = async () => await this.loginService.RetrieveLoginsAsync(nullUser!);

        // Then
        NullLoginException actualException =
            await Assert.ThrowsAsync<NullLoginException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);

        this.userManagerBrokerMock.Verify(broker =>
            broker.GetLoginsAsync(It.IsAny<ApplicationUser>()),
            Times.Never);

        VerifyNoOtherBrokerCalls();
    }
}