// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// UserCrudServiceTests.Exceptions.cs See LICENSE.txt in the root folder of the solution.

using PBACTemplate.Data;
using PBACTemplate.Services.Foundations.UserCrud.Exceptions;

namespace PBACTemplate.Tests.Unit;

public partial class UserCrudServiceTests
{
    [Fact]
    public async Task ShouldThrowUserCrudServiceExceptionOnCreateUserAsyncIfExceptionOccurs()
    {
        // Given
        ApplicationUser inputUser = CreateUser();
        var someException = new Exception(GetRandomString());

        this.userManagerBrokerMock.Setup(broker =>
            broker.CreateAsync(inputUser))
                .ThrowsAsync(someException);

        var expectedException = new UserCrudServiceException(
            "User CRUD service error occurred, contact support.",
            new FailedUserCrudServiceException(
                "Failed user CRUD service error occurred, contact support.",
                someException));

        // When
        Func<Task> action = async () => await this.userCrudService.CreateUserAsync(inputUser);

        // Then
        UserCrudServiceException actualException =
            await Assert.ThrowsAsync<UserCrudServiceException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);
        Assert.IsType<FailedUserCrudServiceException>(actualException.InnerException);

        this.userManagerBrokerMock.Verify(broker =>
            broker.CreateAsync(inputUser),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldThrowUserCrudServiceExceptionOnCreateUserWithPasswordAsyncIfExceptionOccurs()
    {
        // Given
        ApplicationUser inputUser = CreateUser();
        string password = GetRandomString();
        var someException = new Exception(GetRandomString());

        this.userManagerBrokerMock.Setup(broker =>
            broker.CreateAsync(inputUser, password))
                .ThrowsAsync(someException);

        var expectedException = new UserCrudServiceException(
            "User CRUD service error occurred, contact support.",
            new FailedUserCrudServiceException(
                "Failed user CRUD service error occurred, contact support.",
                someException));

        // When
        Func<Task> action = async () => await this.userCrudService
            .CreateUserWithPasswordAsync(inputUser, password);

        // Then
        UserCrudServiceException actualException =
            await Assert.ThrowsAsync<UserCrudServiceException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);
        Assert.IsType<FailedUserCrudServiceException>(actualException.InnerException);

        this.userManagerBrokerMock.Verify(broker =>
            broker.CreateAsync(inputUser, password),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldThrowUserCrudServiceExceptionOnUpdateUserAsyncIfExceptionOccurs()
    {
        // Given
        ApplicationUser inputUser = CreateUser();
        var someException = new Exception(GetRandomString());

        this.userManagerBrokerMock.Setup(broker =>
            broker.UpdateAsync(inputUser))
                .ThrowsAsync(someException);

        var expectedException = new UserCrudServiceException(
            "User CRUD service error occurred, contact support.",
            new FailedUserCrudServiceException(
                "Failed user CRUD service error occurred, contact support.",
                someException));

        // When
        Func<Task> action = async () => await this.userCrudService.UpdateUserAsync(inputUser);

        // Then
        UserCrudServiceException actualException =
            await Assert.ThrowsAsync<UserCrudServiceException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);
        Assert.IsType<FailedUserCrudServiceException>(actualException.InnerException);

        this.userManagerBrokerMock.Verify(broker =>
            broker.UpdateAsync(inputUser),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldThrowUserCrudServiceExceptionOnDeleteUserAsyncIfExceptionOccurs()
    {
        // Given
        ApplicationUser inputUser = CreateUser();
        var someException = new Exception(GetRandomString());

        this.userManagerBrokerMock.Setup(broker =>
            broker.DeleteAsync(inputUser))
                .ThrowsAsync(someException);

        var expectedException = new UserCrudServiceException(
            "User CRUD service error occurred, contact support.",
            new FailedUserCrudServiceException(
                "Failed user CRUD service error occurred, contact support.",
                someException));

        // When
        Func<Task> action = async () => await this.userCrudService.DeleteUserAsync(inputUser);

        // Then
        UserCrudServiceException actualException =
            await Assert.ThrowsAsync<UserCrudServiceException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);
        Assert.IsType<FailedUserCrudServiceException>(actualException.InnerException);

        this.userManagerBrokerMock.Verify(broker =>
            broker.DeleteAsync(inputUser),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldThrowUserCrudServiceExceptionOnRetrieveUserByIdAsyncIfExceptionOccurs()
    {
        // Given
        string userId = GetRandomString();
        var someException = new Exception(GetRandomString());

        this.userManagerBrokerMock.Setup(broker =>
            broker.FindByIdAsync(userId))
                .ThrowsAsync(someException);

        var expectedException = new UserCrudServiceException(
            "User CRUD service error occurred, contact support.",
            new FailedUserCrudServiceException(
                "Failed user CRUD service error occurred, contact support.",
                someException));

        // When
        Func<Task> action = async () => await this.userCrudService
            .RetrieveUserByIdAsync(userId);

        // Then
        UserCrudServiceException actualException =
            await Assert.ThrowsAsync<UserCrudServiceException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);
        Assert.IsType<FailedUserCrudServiceException>(actualException.InnerException);

        this.userManagerBrokerMock.Verify(broker =>
            broker.FindByIdAsync(userId),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldThrowUserCrudServiceExceptionOnRetrieveUserByNameAsyncIfExceptionOccurs()
    {
        // Given
        string userName = GetRandomString();
        var someException = new Exception(GetRandomString());

        this.userManagerBrokerMock.Setup(broker =>
            broker.FindByNameAsync(userName))
                .ThrowsAsync(someException);

        var expectedException = new UserCrudServiceException(
            "User CRUD service error occurred, contact support.",
            new FailedUserCrudServiceException(
                "Failed user CRUD service error occurred, contact support.",
                someException));

        // When
        Func<Task> action = async () => await this.userCrudService
            .RetrieveUserByNameAsync(userName);

        // Then
        UserCrudServiceException actualException =
            await Assert.ThrowsAsync<UserCrudServiceException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);
        Assert.IsType<FailedUserCrudServiceException>(actualException.InnerException);

        this.userManagerBrokerMock.Verify(broker =>
            broker.FindByNameAsync(userName),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldThrowUserCrudServiceExceptionOnRetrieveUserByEmailAsyncIfExceptionOccurs()
    {
        // Given
        string email = GetRandomString();
        var someException = new Exception(GetRandomString());

        this.userManagerBrokerMock.Setup(broker =>
            broker.FindByEmailAsync(email))
                .ThrowsAsync(someException);

        var expectedException = new UserCrudServiceException(
            "User CRUD service error occurred, contact support.",
            new FailedUserCrudServiceException(
                "Failed user CRUD service error occurred, contact support.",
                someException));

        // When
        Func<Task> action = async () => await this.userCrudService
            .RetrieveUserByEmailAsync(email);

        // Then
        UserCrudServiceException actualException =
            await Assert.ThrowsAsync<UserCrudServiceException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);
        Assert.IsType<FailedUserCrudServiceException>(actualException.InnerException);

        this.userManagerBrokerMock.Verify(broker =>
            broker.FindByEmailAsync(email),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldThrowUserCrudServiceExceptionOnRetrieveUserByLoginAsyncIfExceptionOccurs()
    {
        // Given
        string loginProvider = GetRandomString();
        string providerKey = GetRandomString();
        var someException = new Exception(GetRandomString());

        this.userManagerBrokerMock.Setup(broker =>
            broker.FindByLoginAsync(loginProvider, providerKey))
                .ThrowsAsync(someException);

        var expectedException = new UserCrudServiceException(
            "User CRUD service error occurred, contact support.",
            new FailedUserCrudServiceException(
                "Failed user CRUD service error occurred, contact support.",
                someException));

        // When
        Func<Task> action = async () => await this.userCrudService
            .RetrieveUserByLoginAsync(loginProvider, providerKey);

        // Then
        UserCrudServiceException actualException =
            await Assert.ThrowsAsync<UserCrudServiceException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);
        Assert.IsType<FailedUserCrudServiceException>(actualException.InnerException);

        this.userManagerBrokerMock.Verify(broker =>
            broker.FindByLoginAsync(loginProvider, providerKey),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }
}