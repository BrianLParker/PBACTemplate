// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// UserNameServiceTests.Exceptions.cs See LICENSE.txt in the root folder of the solution.

using PBACTemplate.Data;
using PBACTemplate.Services.Foundations.UserName.Exceptions;
using System.Security.Claims;

namespace PBACTemplate.Tests.Unit;

public partial class UserNameServiceTests
{
    [Fact]
    public void ShouldThrowUserNameServiceExceptionOnRetrieveUserNameIfExceptionOccurs()
    {
        // Given
        ClaimsPrincipal principal = CreatePrincipal();
        var someException = new Exception(GetRandomString());

        this.userManagerBrokerMock.Setup(broker =>
            broker.GetUserName(principal))
                .Throws(someException);

        var expectedException = new UserNameServiceException(
            "User name service error occurred, contact support.",
            new FailedUserNameServiceException(
                "Failed user name service error occurred, contact support.",
                someException));

        // When
        Action action = () => this.userNameService.RetrieveUserName(principal);

        // Then
        UserNameServiceException actualException =
            Assert.Throws<UserNameServiceException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);
        Assert.IsType<FailedUserNameServiceException>(actualException.InnerException);

        this.userManagerBrokerMock.Verify(broker =>
            broker.GetUserName(principal),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldThrowUserNameServiceExceptionOnRetrieveUserNameAsyncIfExceptionOccurs()
    {
        // Given
        ApplicationUser inputUser = CreateUser();
        var someException = new Exception(GetRandomString());

        this.userManagerBrokerMock.Setup(broker =>
            broker.GetUserNameAsync(inputUser))
                .ThrowsAsync(someException);

        var expectedException = new UserNameServiceException(
            "User name service error occurred, contact support.",
            new FailedUserNameServiceException(
                "Failed user name service error occurred, contact support.",
                someException));

        // When
        Func<Task> action = async () => await this.userNameService
            .RetrieveUserNameAsync(inputUser);

        // Then
        UserNameServiceException actualException =
            await Assert.ThrowsAsync<UserNameServiceException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);
        Assert.IsType<FailedUserNameServiceException>(actualException.InnerException);

        this.userManagerBrokerMock.Verify(broker =>
            broker.GetUserNameAsync(inputUser),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldThrowUserNameServiceExceptionOnSetUserNameAsyncIfExceptionOccurs()
    {
        // Given
        ApplicationUser inputUser = CreateUser();
        string? userName = GetRandomString();
        var someException = new Exception(GetRandomString());

        this.userManagerBrokerMock.Setup(broker =>
            broker.SetUserNameAsync(inputUser, userName))
                .ThrowsAsync(someException);

        var expectedException = new UserNameServiceException(
            "User name service error occurred, contact support.",
            new FailedUserNameServiceException(
                "Failed user name service error occurred, contact support.",
                someException));

        // When
        Func<Task> action = async () => await this.userNameService
            .SetUserNameAsync(inputUser, userName);

        // Then
        UserNameServiceException actualException =
            await Assert.ThrowsAsync<UserNameServiceException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);
        Assert.IsType<FailedUserNameServiceException>(actualException.InnerException);

        this.userManagerBrokerMock.Verify(broker =>
            broker.SetUserNameAsync(inputUser, userName),
            Times.Once);

        this.userManagerBrokerMock.Verify(broker =>
            broker.UpdateNormalizedUserNameAsync(It.IsAny<ApplicationUser>()),
            Times.Never);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public void ShouldThrowUserNameServiceExceptionOnNormalizeNameIfExceptionOccurs()
    {
        // Given
        string? name = GetRandomString();
        var someException = new Exception(GetRandomString());

        this.userManagerBrokerMock.Setup(broker =>
            broker.NormalizeName(name))
                .Throws(someException);

        var expectedException = new UserNameServiceException(
            "User name service error occurred, contact support.",
            new FailedUserNameServiceException(
                "Failed user name service error occurred, contact support.",
                someException));

        // When
        Action action = () => this.userNameService.NormalizeName(name);

        // Then
        UserNameServiceException actualException =
            Assert.Throws<UserNameServiceException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);
        Assert.IsType<FailedUserNameServiceException>(actualException.InnerException);

        this.userManagerBrokerMock.Verify(broker =>
            broker.NormalizeName(name),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public void ShouldThrowUserNameServiceExceptionOnRetrieveUserIdIfExceptionOccurs()
    {
        // Given
        ClaimsPrincipal principal = CreatePrincipal();
        var someException = new Exception(GetRandomString());

        this.userManagerBrokerMock.Setup(broker =>
            broker.GetUserId(principal))
                .Throws(someException);

        var expectedException = new UserNameServiceException(
            "User name service error occurred, contact support.",
            new FailedUserNameServiceException(
                "Failed user name service error occurred, contact support.",
                someException));

        // When
        Action action = () => this.userNameService.RetrieveUserId(principal);

        // Then
        UserNameServiceException actualException =
            Assert.Throws<UserNameServiceException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);
        Assert.IsType<FailedUserNameServiceException>(actualException.InnerException);

        this.userManagerBrokerMock.Verify(broker =>
            broker.GetUserId(principal),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldThrowUserNameServiceExceptionOnRetrieveUserIdAsyncIfExceptionOccurs()
    {
        // Given
        ApplicationUser inputUser = CreateUser();
        var someException = new Exception(GetRandomString());

        this.userManagerBrokerMock.Setup(broker =>
            broker.GetUserIdAsync(inputUser))
                .ThrowsAsync(someException);

        var expectedException = new UserNameServiceException(
            "User name service error occurred, contact support.",
            new FailedUserNameServiceException(
                "Failed user name service error occurred, contact support.",
                someException));

        // When
        Func<Task> action = async () => await this.userNameService
            .RetrieveUserIdAsync(inputUser);

        // Then
        UserNameServiceException actualException =
            await Assert.ThrowsAsync<UserNameServiceException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);
        Assert.IsType<FailedUserNameServiceException>(actualException.InnerException);

        this.userManagerBrokerMock.Verify(broker =>
            broker.GetUserIdAsync(inputUser),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldThrowUserNameServiceExceptionOnRetrieveUserAsyncIfExceptionOccurs()
    {
        // Given
        ClaimsPrincipal principal = CreatePrincipal();
        var someException = new Exception(GetRandomString());

        this.userManagerBrokerMock.Setup(broker =>
            broker.GetUserAsync(principal))
                .ThrowsAsync(someException);

        var expectedException = new UserNameServiceException(
            "User name service error occurred, contact support.",
            new FailedUserNameServiceException(
                "Failed user name service error occurred, contact support.",
                someException));

        // When
        Func<Task> action = async () => await this.userNameService
            .RetrieveUserAsync(principal);

        // Then
        UserNameServiceException actualException =
            await Assert.ThrowsAsync<UserNameServiceException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);
        Assert.IsType<FailedUserNameServiceException>(actualException.InnerException);

        this.userManagerBrokerMock.Verify(broker =>
            broker.GetUserAsync(principal),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }
}