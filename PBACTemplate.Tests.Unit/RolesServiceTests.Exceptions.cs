// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// RolesServiceTests.Exceptions.cs See LICENSE.txt in the root folder of the solution.

using Microsoft.AspNetCore.Identity;
using PBACTemplate.Services.Foundations.Roles.Exceptions;

namespace PBACTemplate.Tests.Unit;

public partial class RolesServiceTests
{
    [Fact]
    public async Task ShouldThrowRolesServiceExceptionOnCreateRoleAsyncIfExceptionOccurs()
    {
        // Given
        string roleName = GetRandomString();
        var someException = new Exception(GetRandomString());

        this.roleManagerBrokerMock.Setup(broker =>
            broker.CreateAsync(It.Is<IdentityRole>(role => role.Name == roleName)))
                .ThrowsAsync(someException);

        var expectedException = new RolesServiceException(
            "Roles service error occurred, contact support.",
            new FailedRolesServiceException(
                "Failed roles service error occurred, contact support.",
                someException));

        // When
        Func<Task> action = async () => await this.rolesService
            .CreateRoleAsync(roleName);

        // Then
        RolesServiceException actualException =
            await Assert.ThrowsAsync<RolesServiceException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);
        Assert.IsType<FailedRolesServiceException>(actualException.InnerException);

        this.roleManagerBrokerMock.Verify(broker =>
            broker.CreateAsync(It.Is<IdentityRole>(role => role.Name == roleName)),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldThrowRolesServiceExceptionOnUpdateRoleNameAsyncIfExceptionOccurs()
    {
        // Given
        IdentityRole role = CreateRole();
        string newName = GetRandomString();
        var someException = new Exception(GetRandomString());

        this.roleManagerBrokerMock.Setup(broker =>
            broker.SetRoleNameAsync(role, newName))
                .ThrowsAsync(someException);

        var expectedException = new RolesServiceException(
            "Roles service error occurred, contact support.",
            new FailedRolesServiceException(
                "Failed roles service error occurred, contact support.",
                someException));

        // When
        Func<Task> action = async () => await this.rolesService
            .UpdateRoleNameAsync(role, newName);

        // Then
        RolesServiceException actualException =
            await Assert.ThrowsAsync<RolesServiceException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);
        Assert.IsType<FailedRolesServiceException>(actualException.InnerException);

        this.roleManagerBrokerMock.Verify(broker =>
            broker.SetRoleNameAsync(role, newName),
            Times.Once);

        this.roleManagerBrokerMock.Verify(broker =>
            broker.UpdateAsync(It.IsAny<IdentityRole>()),
            Times.Never);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldThrowRolesServiceExceptionOnUpdateRoleNameAsyncIfExceptionOccursDuringUpdate()
    {
        // Given
        IdentityRole role = CreateRole();
        string newName = GetRandomString();

        this.roleManagerBrokerMock.Setup(broker =>
            broker.SetRoleNameAsync(role, newName))
                .ReturnsAsync(IdentityResult.Success);

        var someException = new Exception(GetRandomString());

        this.roleManagerBrokerMock.Setup(broker =>
            broker.UpdateAsync(role))
                .ThrowsAsync(someException);

        var expectedException = new RolesServiceException(
            "Roles service error occurred, contact support.",
            new FailedRolesServiceException(
                "Failed roles service error occurred, contact support.",
                someException));

        // When
        Func<Task> action = async () => await this.rolesService
            .UpdateRoleNameAsync(role, newName);

        // Then
        RolesServiceException actualException =
            await Assert.ThrowsAsync<RolesServiceException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);
        Assert.IsType<FailedRolesServiceException>(actualException.InnerException);

        this.roleManagerBrokerMock.Verify(broker =>
            broker.SetRoleNameAsync(role, newName),
            Times.Once);

        this.roleManagerBrokerMock.Verify(broker =>
            broker.UpdateAsync(role),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldThrowRolesServiceExceptionOnDeleteRoleAsyncIfExceptionOccurs()
    {
        // Given
        IdentityRole role = CreateRole();
        var someException = new Exception(GetRandomString());

        this.roleManagerBrokerMock.Setup(broker =>
            broker.DeleteAsync(role))
                .ThrowsAsync(someException);

        var expectedException = new RolesServiceException(
            "Roles service error occurred, contact support.",
            new FailedRolesServiceException(
                "Failed roles service error occurred, contact support.",
                someException));

        // When
        Func<Task> action = async () => await this.rolesService
            .DeleteRoleAsync(role);

        // Then
        RolesServiceException actualException =
            await Assert.ThrowsAsync<RolesServiceException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);
        Assert.IsType<FailedRolesServiceException>(actualException.InnerException);

        this.roleManagerBrokerMock.Verify(broker =>
            broker.DeleteAsync(role),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldThrowRolesServiceExceptionOnRoleExistsAsyncIfExceptionOccurs()
    {
        // Given
        string roleName = GetRandomString();
        var someException = new Exception(GetRandomString());

        this.roleManagerBrokerMock.Setup(broker =>
            broker.RoleExistsAsync(roleName))
                .ThrowsAsync(someException);

        var expectedException = new RolesServiceException(
            "Roles service error occurred, contact support.",
            new FailedRolesServiceException(
                "Failed roles service error occurred, contact support.",
                someException));

        // When
        Func<Task> action = async () => await this.rolesService
            .RoleExistsAsync(roleName);

        // Then
        RolesServiceException actualException =
            await Assert.ThrowsAsync<RolesServiceException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);
        Assert.IsType<FailedRolesServiceException>(actualException.InnerException);

        this.roleManagerBrokerMock.Verify(broker =>
            broker.RoleExistsAsync(roleName),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldThrowRolesServiceExceptionOnRetrieveRoleByIdAsyncIfExceptionOccurs()
    {
        // Given
        IdentityRole role = CreateRole();
        var someException = new Exception(GetRandomString());

        this.roleManagerBrokerMock.Setup(broker =>
            broker.FindByIdAsync(role.Id))
                .ThrowsAsync(someException);

        var expectedException = new RolesServiceException(
            "Roles service error occurred, contact support.",
            new FailedRolesServiceException(
                "Failed roles service error occurred, contact support.",
                someException));

        // When
        Func<Task> action = async () => await this.rolesService
            .RetrieveRoleByIdAsync(role.Id);

        // Then
        RolesServiceException actualException =
            await Assert.ThrowsAsync<RolesServiceException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);
        Assert.IsType<FailedRolesServiceException>(actualException.InnerException);

        this.roleManagerBrokerMock.Verify(broker =>
            broker.FindByIdAsync(role.Id),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldThrowRolesServiceExceptionOnRetrieveRoleByNameAsyncIfExceptionOccurs()
    {
        // Given
        IdentityRole role = CreateRole();
        var someException = new Exception(GetRandomString());

        this.roleManagerBrokerMock.Setup(broker =>
            broker.FindByNameAsync(role.Name!))
                .ThrowsAsync(someException);

        var expectedException = new RolesServiceException(
            "Roles service error occurred, contact support.",
            new FailedRolesServiceException(
                "Failed roles service error occurred, contact support.",
                someException));

        // When
        Func<Task> action = async () => await this.rolesService
            .RetrieveRoleByNameAsync(role.Name!);

        // Then
        RolesServiceException actualException =
            await Assert.ThrowsAsync<RolesServiceException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);
        Assert.IsType<FailedRolesServiceException>(actualException.InnerException);

        this.roleManagerBrokerMock.Verify(broker =>
            broker.FindByNameAsync(role.Name!),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }
}