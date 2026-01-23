// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// UserServiceTests.Exceptions.cs See LICENSE.txt in the root folder of the solution.

using PBACTemplate.Client.Models.Users;
using PBACTemplate.Models.Users;
using PBACTemplate.Services.Foundations.Users.Exceptions;

namespace PBACTemplate.Tests.Unit;

public partial class UserServiceTests
{
    [Fact]
    public async Task ShouldThrowUsersServiceExceptionOnCreateUserAsyncIfExceptionOccurs()
    {
        // Given
        User inputUser = CreateClientUser();
        var someException = new Exception(GetRandomString());

        this.userManagerBrokerMock.Setup(broker =>
            broker.CreateAsync(It.IsAny<ApplicationUser>()))
                .ThrowsAsync(someException);

        var expectedException = new UsersServiceException(
            "Users service error occurred, contact support.",
            new FailedUsersServiceException(
                "Failed users service error occurred, contact support.",
                someException));

        // When
        Func<Task> action = async () => await this.userService.CreateUserAsync(inputUser);

        // Then
        UsersServiceException actualException =
            await Assert.ThrowsAsync<UsersServiceException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);
        Assert.IsType<FailedUsersServiceException>(actualException.InnerException);

        this.userManagerBrokerMock.Verify(broker =>
            broker.CreateAsync(It.IsAny<ApplicationUser>()), Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldThrowUsersServiceExceptionOnRemoveUserAsyncIfExceptionOccurs()
    {
        // Given
        string userId = GetRandomString();
        var someException = new Exception(GetRandomString());

        this.userManagerBrokerMock.Setup(broker =>
            broker.FindByIdAsync(userId))
                .ThrowsAsync(someException);

        var expectedException = new UsersServiceException(
            "Users service error occurred, contact support.",
            new FailedUsersServiceException(
                "Failed users service error occurred, contact support.",
                someException));

        // When
        Func<Task> action = async () => await this.userService.RemoveUserAsync(userId);

        // Then
        UsersServiceException actualException =
            await Assert.ThrowsAsync<UsersServiceException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);
        Assert.IsType<FailedUsersServiceException>(actualException.InnerException);

        this.userManagerBrokerMock.Verify(broker =>
            broker.FindByIdAsync(userId), Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldThrowUsersServiceExceptionOnRetrieveUserByIdAsyncIfExceptionOccurs()
    {
        // Given
        string userId = GetRandomString();
        var someException = new Exception(GetRandomString());

        this.userManagerBrokerMock.Setup(broker =>
            broker.FindByIdAsync(userId))
                .ThrowsAsync(someException);

        var expectedException = new UsersServiceException(
            "Users service error occurred, contact support.",
            new FailedUsersServiceException(
                "Failed users service error occurred, contact support.",
                someException));

        // When
        Func<Task> action = async () => await this.userService.RetrieveUserByIdAsync(userId);

        // Then
        UsersServiceException actualException =
            await Assert.ThrowsAsync<UsersServiceException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);
        Assert.IsType<FailedUsersServiceException>(actualException.InnerException);

        this.userManagerBrokerMock.Verify(broker =>
            broker.FindByIdAsync(userId), Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldThrowUsersServiceExceptionOnRetrieveUsersAsyncIfExceptionOccurs()
    {
        // Given
        var someException = new Exception(GetRandomString());

        this.userManagerBrokerMock.SetupGet(broker => broker.Users)
            .Throws(someException);

        var expectedException = new UsersServiceException(
            "Users service error occurred, contact support.",
            new FailedUsersServiceException(
                "Failed users service error occurred, contact support.",
                someException));

        // When
        Func<Task> action = async () => await this.userService.RetrieveUsersAsync();

        // Then
        UsersServiceException actualException =
            await Assert.ThrowsAsync<UsersServiceException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);
        Assert.IsType<FailedUsersServiceException>(actualException.InnerException);

        this.userManagerBrokerMock.VerifyGet(broker => broker.Users, Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldThrowUsersServiceExceptionOnUpdateUserAsyncIfExceptionOccurs()
    {
        // Given
        string userId = GetRandomString();
        User inputUser = CreateClientUser();
        var someException = new Exception(GetRandomString());

        this.userManagerBrokerMock.Setup(broker =>
            broker.UpdateAsync(It.IsAny<ApplicationUser>()))
                .ThrowsAsync(someException);

        var expectedException = new UsersServiceException(
            "Users service error occurred, contact support.",
            new FailedUsersServiceException(
                "Failed users service error occurred, contact support.",
                someException));

        // When
        Func<Task> action = async () => await this.userService.UpdateUserAsync(userId, inputUser);

        // Then
        UsersServiceException actualException =
            await Assert.ThrowsAsync<UsersServiceException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);
        Assert.IsType<FailedUsersServiceException>(actualException.InnerException);

        this.userManagerBrokerMock.Verify(broker =>
            broker.UpdateAsync(It.IsAny<ApplicationUser>()), Times.Once);

        VerifyNoOtherBrokerCalls();
    }
}