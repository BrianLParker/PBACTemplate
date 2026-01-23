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
            broker.CreateUserAsync(inputUser, It.IsAny<CancellationToken>()))
            .ThrowsAsync(someException);

        var expectedException = new UsersServiceException(
            "Users service error occurred, contact support.",
            new FailedUsersServiceException(
                "Failed users service error occurred, contact support.",
                someException));

        // When
        Func<Task> action = async () =>
            await this.userService.CreateUserAsync(inputUser);

        // Then
        UsersServiceException actualException =
            await Assert.ThrowsAsync<UsersServiceException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);
        Assert.IsType<FailedUsersServiceException>(actualException.InnerException);

        this.httpClientBrokerMock.Verify(broker =>
            broker.CreateUserAsync(inputUser, It.IsAny<CancellationToken>()),
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
            broker.UpdateUserAsync(userId, inputUser, It.IsAny<CancellationToken>()))
            .ThrowsAsync(someException);

        var expectedException = new UsersServiceException(
            "Users service error occurred, contact support.",
            new FailedUsersServiceException(
                "Failed users service error occurred, contact support.",
                someException));

        // When
        Func<Task> action = async () =>
            await this.userService.UpdateUserAsync(userId, inputUser);

        // Then
        UsersServiceException actualException =
            await Assert.ThrowsAsync<UsersServiceException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);
        Assert.IsType<FailedUsersServiceException>(actualException.InnerException);

        this.httpClientBrokerMock.Verify(broker =>
            broker.UpdateUserAsync(userId, inputUser, It.IsAny<CancellationToken>()),
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
            broker.DeleteUserAsync(userId, It.IsAny<CancellationToken>()))
            .ThrowsAsync(someException);

        var expectedException = new UsersServiceException(
            "Users service error occurred, contact support.",
            new FailedUsersServiceException(
                "Failed users service error occurred, contact support.",
                someException));

        // When
        Func<Task> action = async () =>
            await this.userService.DeleteUserAsync(userId);

        // Then
        UsersServiceException actualException =
            await Assert.ThrowsAsync<UsersServiceException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);
        Assert.IsType<FailedUsersServiceException>(actualException.InnerException);

        this.httpClientBrokerMock.Verify(broker =>
            broker.DeleteUserAsync(userId, It.IsAny<CancellationToken>()),
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
            broker.GetUserAsync(userId, It.IsAny<CancellationToken>()))
            .ThrowsAsync(someException);

        var expectedException = new UsersServiceException(
            "Users service error occurred, contact support.",
            new FailedUsersServiceException(
                "Failed users service error occurred, contact support.",
                someException));

        // When
        Func<Task> action = async () =>
            await this.userService.GetUserAsync(userId);

        // Then
        UsersServiceException actualException =
            await Assert.ThrowsAsync<UsersServiceException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);
        Assert.IsType<FailedUsersServiceException>(actualException.InnerException);

        this.httpClientBrokerMock.Verify(broker =>
            broker.GetUserAsync(userId, It.IsAny<CancellationToken>()),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldThrowUsersServiceExceptionOnGetAllIfBrokerThrows()
    {
        // Given
        var someException = new Exception("boom");

        this.httpClientBrokerMock.Setup(broker =>
            broker.GetUsersAsync(It.IsAny<CancellationToken>()))
            .ThrowsAsync(someException);

        var expectedException = new UsersServiceException(
            "Users service error occurred, contact support.",
            new FailedUsersServiceException(
                "Failed users service error occurred, contact support.",
                someException));

        // When
        Func<Task> action = async () =>
            await this.userService.GetUsersAsync();

        // Then
        UsersServiceException actualException =
            await Assert.ThrowsAsync<UsersServiceException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);
        Assert.IsType<FailedUsersServiceException>(actualException.InnerException);

        this.httpClientBrokerMock.Verify(broker =>
            broker.GetUsersAsync(It.IsAny<CancellationToken>()),
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
            broker.CreateUserAsync(inputUser, It.IsAny<CancellationToken>()))
            .ReturnsAsync((User?)null);

        // When
        Func<Task> action = async () =>
            await this.userService.CreateUserAsync(inputUser);

        // Then
        FailedUsersOperationException actualException =
            await Assert.ThrowsAsync<FailedUsersOperationException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);

        this.httpClientBrokerMock.Verify(broker =>
            broker.CreateUserAsync(inputUser, It.IsAny<CancellationToken>()),
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
            broker.UpdateUserAsync(userId, inputUser, It.IsAny<CancellationToken>()))
            .ReturnsAsync((User?)null);

        // When
        Func<Task> action = async () =>
            await this.userService.UpdateUserAsync(userId, inputUser);

        // Then
        FailedUsersOperationException actualException =
            await Assert.ThrowsAsync<FailedUsersOperationException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);

        this.httpClientBrokerMock.Verify(broker =>
            broker.UpdateUserAsync(userId, inputUser, It.IsAny<CancellationToken>()),
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
            broker.DeleteUserAsync(userId, It.IsAny<CancellationToken>()))
            .ReturnsAsync(false);

        // When
        Func<Task> action = async () =>
            await this.userService.DeleteUserAsync(userId);

        // Then
        FailedUsersOperationException actualException =
            await Assert.ThrowsAsync<FailedUsersOperationException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);

        this.httpClientBrokerMock.Verify(broker =>
            broker.DeleteUserAsync(userId, It.IsAny<CancellationToken>()),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }
}