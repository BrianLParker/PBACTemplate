// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// UserRolesServiceTests.Exceptions.cs See LICENSE.txt in the root folder of the solution.

using PBACTemplate.Data;
using PBACTemplate.Services.Foundations.UserRoles.Exceptions;

namespace PBACTemplate.Tests.Unit;

public partial class UserRolesServiceTests
{
    [Fact]
    public async Task ShouldThrowUserRolesServiceExceptionOnAddToRoleAsyncIfExceptionOccurs()
    {
        // Given
        ApplicationUser user = CreateUser();
        string role = GetRandomString();
        var someException = new Exception(GetRandomString());

        this.userManagerBrokerMock.Setup(broker =>
            broker.AddToRoleAsync(user, role))
                .ThrowsAsync(someException);

        var expectedException = new UserRolesServiceException(
            "User roles service error occurred, contact support.",
            new FailedUserRolesServiceException(
                "Failed user roles service error occurred, contact support.",
                someException));

        // When
        Func<Task> action = async () => await this.userRolesService
            .AddToRoleAsync(user, role);

        // Then
        UserRolesServiceException actualException =
            await Assert.ThrowsAsync<UserRolesServiceException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);
        Assert.IsType<FailedUserRolesServiceException>(actualException.InnerException);

        this.userManagerBrokerMock.Verify(broker =>
            broker.AddToRoleAsync(user, role),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldThrowUserRolesServiceExceptionOnAddToRolesAsyncIfExceptionOccurs()
    {
        // Given
        ApplicationUser user = CreateUser();
        IEnumerable<string> roles = CreateRoles(GetRandomString());
        var someException = new Exception(GetRandomString());

        this.userManagerBrokerMock.Setup(broker =>
            broker.AddToRolesAsync(user, roles))
                .ThrowsAsync(someException);

        var expectedException = new UserRolesServiceException(
            "User roles service error occurred, contact support.",
            new FailedUserRolesServiceException(
                "Failed user roles service error occurred, contact support.",
                someException));

        // When
        Func<Task> action = async () => await this.userRolesService
            .AddToRolesAsync(user, roles);

        // Then
        UserRolesServiceException actualException =
            await Assert.ThrowsAsync<UserRolesServiceException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);
        Assert.IsType<FailedUserRolesServiceException>(actualException.InnerException);

        this.userManagerBrokerMock.Verify(broker =>
            broker.AddToRolesAsync(user, roles),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldThrowUserRolesServiceExceptionOnRemoveFromRoleAsyncIfExceptionOccurs()
    {
        // Given
        ApplicationUser user = CreateUser();
        string role = GetRandomString();
        var someException = new Exception(GetRandomString());

        this.userManagerBrokerMock.Setup(broker =>
            broker.RemoveFromRoleAsync(user, role))
                .ThrowsAsync(someException);

        var expectedException = new UserRolesServiceException(
            "User roles service error occurred, contact support.",
            new FailedUserRolesServiceException(
                "Failed user roles service error occurred, contact support.",
                someException));

        // When
        Func<Task> action = async () => await this.userRolesService
            .RemoveFromRoleAsync(user, role);

        // Then
        UserRolesServiceException actualException =
            await Assert.ThrowsAsync<UserRolesServiceException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);
        Assert.IsType<FailedUserRolesServiceException>(actualException.InnerException);

        this.userManagerBrokerMock.Verify(broker =>
            broker.RemoveFromRoleAsync(user, role),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldThrowUserRolesServiceExceptionOnRemoveFromRolesAsyncIfExceptionOccurs()
    {
        // Given
        ApplicationUser user = CreateUser();
        IEnumerable<string> roles = CreateRoles(GetRandomString(), GetRandomString());
        var someException = new Exception(GetRandomString());

        this.userManagerBrokerMock.Setup(broker =>
            broker.RemoveFromRolesAsync(user, roles))
                .ThrowsAsync(someException);

        var expectedException = new UserRolesServiceException(
            "User roles service error occurred, contact support.",
            new FailedUserRolesServiceException(
                "Failed user roles service error occurred, contact support.",
                someException));

        // When
        Func<Task> action = async () => await this.userRolesService
            .RemoveFromRolesAsync(user, roles);

        // Then
        UserRolesServiceException actualException =
            await Assert.ThrowsAsync<UserRolesServiceException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);
        Assert.IsType<FailedUserRolesServiceException>(actualException.InnerException);

        this.userManagerBrokerMock.Verify(broker =>
            broker.RemoveFromRolesAsync(user, roles),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldThrowUserRolesServiceExceptionOnRetrieveRolesAsyncIfExceptionOccurs()
    {
        // Given
        ApplicationUser user = CreateUser();
        var someException = new Exception(GetRandomString());

        this.userManagerBrokerMock.Setup(broker =>
            broker.GetRolesAsync(user))
                .ThrowsAsync(someException);

        var expectedException = new UserRolesServiceException(
            "User roles service error occurred, contact support.",
            new FailedUserRolesServiceException(
                "Failed user roles service error occurred, contact support.",
                someException));

        // When
        Func<Task> action = async () => await this.userRolesService
            .RetrieveRolesAsync(user);

        // Then
        UserRolesServiceException actualException =
            await Assert.ThrowsAsync<UserRolesServiceException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);
        Assert.IsType<FailedUserRolesServiceException>(actualException.InnerException);

        this.userManagerBrokerMock.Verify(broker =>
            broker.GetRolesAsync(user),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldThrowUserRolesServiceExceptionOnIsInRoleAsyncIfExceptionOccurs()
    {
        // Given
        ApplicationUser user = CreateUser();
        string role = GetRandomString();
        var someException = new Exception(GetRandomString());

        this.userManagerBrokerMock.Setup(broker =>
            broker.IsInRoleAsync(user, role))
                .ThrowsAsync(someException);

        var expectedException = new UserRolesServiceException(
            "User roles service error occurred, contact support.",
            new FailedUserRolesServiceException(
                "Failed user roles service error occurred, contact support.",
                someException));

        // When
        Func<Task> action = async () => await this.userRolesService
            .IsInRoleAsync(user, role);

        // Then
        UserRolesServiceException actualException =
            await Assert.ThrowsAsync<UserRolesServiceException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);
        Assert.IsType<FailedUserRolesServiceException>(actualException.InnerException);

        this.userManagerBrokerMock.Verify(broker =>
            broker.IsInRoleAsync(user, role),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldThrowUserRolesServiceExceptionOnRetrieveUsersInRoleAsyncIfExceptionOccurs()
    {
        // Given
        string roleName = GetRandomString();
        var someException = new Exception(GetRandomString());

        this.userManagerBrokerMock.Setup(broker =>
            broker.GetUsersInRoleAsync(roleName))
                .ThrowsAsync(someException);

        var expectedException = new UserRolesServiceException(
            "User roles service error occurred, contact support.",
            new FailedUserRolesServiceException(
                "Failed user roles service error occurred, contact support.",
                someException));

        // When
        Func<Task> action = async () => await this.userRolesService
            .RetrieveUsersInRoleAsync(roleName);

        // Then
        UserRolesServiceException actualException =
            await Assert.ThrowsAsync<UserRolesServiceException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);
        Assert.IsType<FailedUserRolesServiceException>(actualException.InnerException);

        this.userManagerBrokerMock.Verify(broker =>
            broker.GetUsersInRoleAsync(roleName),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }
}