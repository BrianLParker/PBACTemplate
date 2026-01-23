// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// UserServiceTests.Exceptions.cs See LICENSE.txt in the root folder of the solution.

using PBACTemplate.Client.Models.Users;
using PBACTemplate.Client.Services.Foundations.Users.Exceptions;

namespace PBACTemplate.Client.Tests.Unit;

public partial class UserServiceTests
{
    [Fact]
    public async Task ShouldThrowUsersServiceExceptionOnCreateIfBrokerThrows()
    {
        // Given
        User inputUser = CreateUser();
        var someException = new Exception("boom");

        this.httpClientBrokerMock.Setup(broker =>
            broker.CreateAdministrationUserAsync(inputUser, It.IsAny<CancellationToken>()))
            .ThrowsAsync(someException);

        var expectedException = new UsersServiceException(
            "Users service error occurred, contact support.",
            new FailedUsersServiceException(
                "Failed users service error occurred, contact support.",
                someException));

        // When
        Func<Task> action = async () =>
            await this.userService.CreateAdministrationUserAsync(inputUser);

        // Then
        UsersServiceException actualException =
            await Assert.ThrowsAsync<UsersServiceException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);
        Assert.IsType<FailedUsersServiceException>(actualException.InnerException);

        this.httpClientBrokerMock.Verify(broker =>
            broker.CreateAdministrationUserAsync(inputUser, It.IsAny<CancellationToken>()),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldThrowUsersServiceExceptionOnUpdateIfBrokerThrows()
    {
        // Given
        string userId = GetRandomString();
        User inputUser = CreateUser();
        var someException = new Exception("boom");

        this.httpClientBrokerMock.Setup(broker =>
            broker.UpdateAdministrationUserAsync(userId, inputUser, It.IsAny<CancellationToken>()))
            .ThrowsAsync(someException);

        var expectedException = new UsersServiceException(
            "Users service error occurred, contact support.",
            new FailedUsersServiceException(
                "Failed users service error occurred, contact support.",
                someException));

        // When
        Func<Task> action = async () =>
            await this.userService.UpdateAdministrationUserAsync(userId, inputUser);

        // Then
        UsersServiceException actualException =
            await Assert.ThrowsAsync<UsersServiceException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);
        Assert.IsType<FailedUsersServiceException>(actualException.InnerException);

        this.httpClientBrokerMock.Verify(broker =>
            broker.UpdateAdministrationUserAsync(userId, inputUser, It.IsAny<CancellationToken>()),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldThrowUsersServiceExceptionOnDeleteIfBrokerThrows()
    {
        // Given
        string userId = GetRandomString();
        var someException = new Exception("boom");

        this.httpClientBrokerMock.Setup(broker =>
            broker.DeleteAdministrationUserAsync(userId, It.IsAny<CancellationToken>()))
            .ThrowsAsync(someException);

        var expectedException = new UsersServiceException(
            "Users service error occurred, contact support.",
            new FailedUsersServiceException(
                "Failed users service error occurred, contact support.",
                someException));

        // When
        Func<Task> action = async () =>
            await this.userService.DeleteAdministrationUserAsync(userId);

        // Then
        UsersServiceException actualException =
            await Assert.ThrowsAsync<UsersServiceException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);
        Assert.IsType<FailedUsersServiceException>(actualException.InnerException);

        this.httpClientBrokerMock.Verify(broker =>
            broker.DeleteAdministrationUserAsync(userId, It.IsAny<CancellationToken>()),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldThrowUsersServiceExceptionOnGetByIdIfBrokerThrows()
    {
        // Given
        string userId = GetRandomString();
        var someException = new Exception("boom");

        this.httpClientBrokerMock.Setup(broker =>
            broker.GetAdministrationUserAsync(userId, It.IsAny<CancellationToken>()))
            .ThrowsAsync(someException);

        var expectedException = new UsersServiceException(
            "Users service error occurred, contact support.",
            new FailedUsersServiceException(
                "Failed users service error occurred, contact support.",
                someException));

        // When
        Func<Task> action = async () =>
            await this.userService.GetAdministrationUserAsync(userId);

        // Then
        UsersServiceException actualException =
            await Assert.ThrowsAsync<UsersServiceException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);
        Assert.IsType<FailedUsersServiceException>(actualException.InnerException);

        this.httpClientBrokerMock.Verify(broker =>
            broker.GetAdministrationUserAsync(userId, It.IsAny<CancellationToken>()),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldThrowUsersServiceExceptionOnGetAllIfBrokerThrows()
    {
        // Given
        var someException = new Exception("boom");

        this.httpClientBrokerMock.Setup(broker =>
            broker.GetAdministrationUsersAsync(It.IsAny<CancellationToken>()))
            .ThrowsAsync(someException);

        var expectedException = new UsersServiceException(
            "Users service error occurred, contact support.",
            new FailedUsersServiceException(
                "Failed users service error occurred, contact support.",
                someException));

        // When
        Func<Task> action = async () =>
            await this.userService.GetAdministrationUsersAsync();

        // Then
        UsersServiceException actualException =
            await Assert.ThrowsAsync<UsersServiceException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);
        Assert.IsType<FailedUsersServiceException>(actualException.InnerException);

        this.httpClientBrokerMock.Verify(broker =>
            broker.GetAdministrationUsersAsync(It.IsAny<CancellationToken>()),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldThrowFailedUsersOperationExceptionOnCreateIfBrokerReturnsNull()
    {
        // Given
        User inputUser = CreateUser();
        var expectedException = new FailedUsersOperationException("Failed to create user.");

        this.httpClientBrokerMock.Setup(broker =>
            broker.CreateAdministrationUserAsync(inputUser, It.IsAny<CancellationToken>()))
            .ReturnsAsync((User?)null);

        // When
        Func<Task> action = async () =>
            await this.userService.CreateAdministrationUserAsync(inputUser);

        // Then
        FailedUsersOperationException actualException =
            await Assert.ThrowsAsync<FailedUsersOperationException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);

        this.httpClientBrokerMock.Verify(broker =>
            broker.CreateAdministrationUserAsync(inputUser, It.IsAny<CancellationToken>()),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldThrowFailedUsersOperationExceptionOnUpdateIfBrokerReturnsNull()
    {
        // Given
        string userId = GetRandomString();
        User inputUser = CreateUser();
        var expectedException = new FailedUsersOperationException("Failed to update user.");

        this.httpClientBrokerMock.Setup(broker =>
            broker.UpdateAdministrationUserAsync(userId, inputUser, It.IsAny<CancellationToken>()))
            .ReturnsAsync((User?)null);

        // When
        Func<Task> action = async () =>
            await this.userService.UpdateAdministrationUserAsync(userId, inputUser);

        // Then
        FailedUsersOperationException actualException =
            await Assert.ThrowsAsync<FailedUsersOperationException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);

        this.httpClientBrokerMock.Verify(broker =>
            broker.UpdateAdministrationUserAsync(userId, inputUser, It.IsAny<CancellationToken>()),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldThrowFailedUsersOperationExceptionOnDeleteIfBrokerReturnsFalse()
    {
        // Given
        string userId = GetRandomString();
        var expectedException = new FailedUsersOperationException("Failed to delete user.");

        this.httpClientBrokerMock.Setup(broker =>
            broker.DeleteAdministrationUserAsync(userId, It.IsAny<CancellationToken>()))
            .ReturnsAsync(false);

        // When
        Func<Task> action = async () =>
            await this.userService.DeleteAdministrationUserAsync(userId);

        // Then
        FailedUsersOperationException actualException =
            await Assert.ThrowsAsync<FailedUsersOperationException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);

        this.httpClientBrokerMock.Verify(broker =>
            broker.DeleteAdministrationUserAsync(userId, It.IsAny<CancellationToken>()),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }
}