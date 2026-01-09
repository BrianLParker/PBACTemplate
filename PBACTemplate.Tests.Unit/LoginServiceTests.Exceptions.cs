// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// LoginServiceTests.Exceptions.cs See LICENSE.txt in the root folder of the solution.

using Microsoft.AspNetCore.Identity;
using PBACTemplate.Models.User;
using PBACTemplate.Services.Foundations.Login.Exceptions;

namespace PBACTemplate.Tests.Unit;

public partial class LoginServiceTests
{
    [Fact]
    public async Task ShouldThrowLoginServiceExceptionOnAddLoginAsyncIfExceptionOccurs()
    {
        // Given
        ApplicationUser user = CreateUser();
        UserLoginInfo login = CreateLogin();
        var someException = new Exception(GetRandomString());

        this.userManagerBrokerMock.Setup(broker =>
            broker.AddLoginAsync(user, login))
                .ThrowsAsync(someException);

        var expectedException = new LoginServiceException(
            "Login service error occurred, contact support.",
            new FailedLoginServiceException(
                "Failed login service error occurred, contact support.",
                someException));

        // When
        Func<Task> action = async () => await this.loginService.AddLoginAsync(user, login);

        // Then
        LoginServiceException actualException =
            await Assert.ThrowsAsync<LoginServiceException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);
        Assert.IsType<FailedLoginServiceException>(actualException.InnerException);

        this.userManagerBrokerMock.Verify(broker =>
            broker.AddLoginAsync(user, login),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldThrowLoginServiceExceptionOnRemoveLoginAsyncIfExceptionOccurs()
    {
        // Given
        ApplicationUser user = CreateUser();
        string provider = GetRandomString();
        string providerKey = GetRandomString();
        var someException = new Exception(GetRandomString());

        this.userManagerBrokerMock.Setup(broker =>
            broker.RemoveLoginAsync(user, provider, providerKey))
                .ThrowsAsync(someException);

        var expectedException = new LoginServiceException(
            "Login service error occurred, contact support.",
            new FailedLoginServiceException(
                "Failed login service error occurred, contact support.",
                someException));

        // When
        Func<Task> action = async () => await this.loginService.RemoveLoginAsync(user, provider, providerKey);

        // Then
        LoginServiceException actualException =
            await Assert.ThrowsAsync<LoginServiceException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);
        Assert.IsType<FailedLoginServiceException>(actualException.InnerException);

        this.userManagerBrokerMock.Verify(broker =>
            broker.RemoveLoginAsync(user, provider, providerKey),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldThrowLoginServiceExceptionOnRetrieveLoginsAsyncIfExceptionOccurs()
    {
        // Given
        ApplicationUser user = CreateUser();
        var someException = new Exception(GetRandomString());

        this.userManagerBrokerMock.Setup(broker =>
            broker.GetLoginsAsync(user))
                .ThrowsAsync(someException);

        var expectedException = new LoginServiceException(
            "Login service error occurred, contact support.",
            new FailedLoginServiceException(
                "Failed login service error occurred, contact support.",
                someException));

        // When
        Func<Task> action = async () => await this.loginService.RetrieveLoginsAsync(user);

        // Then
        LoginServiceException actualException =
            await Assert.ThrowsAsync<LoginServiceException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);
        Assert.IsType<FailedLoginServiceException>(actualException.InnerException);

        this.userManagerBrokerMock.Verify(broker =>
            broker.GetLoginsAsync(user),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }
}