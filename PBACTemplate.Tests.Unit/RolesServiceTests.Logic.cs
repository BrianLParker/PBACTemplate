// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// RolesServiceTests.Logic.cs See LICENSE.txt in the root folder of the solution.

using Microsoft.AspNetCore.Identity;
using PBACTemplate.Services.Foundations.Roles.Exceptions;
using System.Collections.Immutable;

namespace PBACTemplate.Tests.Unit;

public partial class RolesServiceTests
{
    [Fact]
    public async Task ShouldCreateRoleAsync()
    {
        // Given
        string roleName = GetRandomString();
        IdentityRole createdRole = new(roleName);

        this.roleManagerBrokerMock.Setup(broker =>
            broker.RoleExistsAsync(roleName))
                .ReturnsAsync(false);

        this.roleManagerBrokerMock.Setup(broker =>
            broker.CreateAsync(It.Is<IdentityRole>(role => role.Name == roleName)))
                .ReturnsAsync(IdentityResult.Success);

        // When
        string actualRoleName = await this.rolesService.CreateRoleAsync(roleName);

        // Then
        Assert.Equal(roleName, actualRoleName);

        this.roleManagerBrokerMock.Verify(broker =>
            broker.RoleExistsAsync(roleName), Times.Once);

        this.roleManagerBrokerMock.Verify(broker =>
            broker.CreateAsync(It.Is<IdentityRole>(role => role.Name == roleName)),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldThrowInvalidRolesExceptionOnCreateRoleAsyncIfRoleAlreadyExists()
    {
        // Given
        string roleName = GetRandomString();
        var expectedException = new InvalidRolesException($"Role '{roleName}' already exists.");

        this.roleManagerBrokerMock.Setup(broker =>
            broker.RoleExistsAsync(roleName))
                .ReturnsAsync(true);

        // When
        Func<Task> action = async () => await this.rolesService.CreateRoleAsync(roleName);

        // Then
        InvalidRolesException actualException = await Assert.ThrowsAsync<InvalidRolesException>(action);
        Assert.Equal(expectedException.Message, actualException.Message);

        this.roleManagerBrokerMock.Verify(broker =>
            broker.RoleExistsAsync(roleName), Times.Once);

        this.roleManagerBrokerMock.Verify(broker =>
            broker.CreateAsync(It.IsAny<IdentityRole>()), Times.Never);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldThrowFailedRolesOperationExceptionOnCreateRoleAsyncIfIdentityResultFails()
    {
        // Given
        string roleName = GetRandomString();
        IdentityResult failedResult = IdentityResult.Failed(CreateIdentityError("error"));
        var expectedException = new FailedRolesOperationException("Role identity operation failed: error");

        this.roleManagerBrokerMock.Setup(broker =>
            broker.RoleExistsAsync(roleName))
                .ReturnsAsync(false);

        this.roleManagerBrokerMock.Setup(broker =>
            broker.CreateAsync(It.Is<IdentityRole>(role => role.Name == roleName)))
                .ReturnsAsync(failedResult);

        // When
        Func<Task> action = async () => await this.rolesService.CreateRoleAsync(roleName);

        // Then
        FailedRolesOperationException actualException =
            await Assert.ThrowsAsync<FailedRolesOperationException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);

        this.roleManagerBrokerMock.Verify(broker =>
            broker.RoleExistsAsync(roleName), Times.Once);

        this.roleManagerBrokerMock.Verify(broker =>
            broker.CreateAsync(It.Is<IdentityRole>(role => role.Name == roleName)),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldRemoveRoleAsync()
    {
        // Given
        string roleName = GetRandomString();
        IdentityRole role = CreateRole(roleName);

        this.roleManagerBrokerMock.Setup(broker =>
            broker.FindByNameAsync(roleName))
                .ReturnsAsync(role);

        this.roleManagerBrokerMock.Setup(broker =>
            broker.DeleteAsync(role))
                .ReturnsAsync(IdentityResult.Success);

        // When
        bool actualResult = await this.rolesService.RemoveRoleAsync(roleName);

        // Then
        Assert.True(actualResult);

        this.roleManagerBrokerMock.Verify(broker =>
            broker.FindByNameAsync(roleName), Times.Once);

        this.roleManagerBrokerMock.Verify(broker =>
            broker.DeleteAsync(role), Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldThrowNullRolesExceptionOnRemoveRoleAsyncIfRoleNotFound()
    {
        // Given
        string roleName = GetRandomString();
        var expectedException = new NullRolesException($"Role '{roleName}' was not found.");

        this.roleManagerBrokerMock.Setup(broker =>
            broker.FindByNameAsync(roleName))
                .ReturnsAsync((IdentityRole?)null);

        // When
        Func<Task> action = async () => await this.rolesService.RemoveRoleAsync(roleName);

        // Then
        NullRolesException actualException = await Assert.ThrowsAsync<NullRolesException>(action);
        Assert.Equal(expectedException.Message, actualException.Message);

        this.roleManagerBrokerMock.Verify(broker =>
            broker.FindByNameAsync(roleName), Times.Once);

        this.roleManagerBrokerMock.Verify(broker =>
            broker.DeleteAsync(It.IsAny<IdentityRole>()), Times.Never);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldThrowFailedRolesOperationExceptionOnRemoveRoleAsyncIfIdentityResultFails()
    {
        // Given
        string roleName = GetRandomString();
        IdentityRole role = CreateRole(roleName);
        IdentityResult failedResult = IdentityResult.Failed(CreateIdentityError("error"));
        var expectedException = new FailedRolesOperationException("Role identity operation failed: error");

        this.roleManagerBrokerMock.Setup(broker =>
            broker.FindByNameAsync(roleName))
                .ReturnsAsync(role);

        this.roleManagerBrokerMock.Setup(broker =>
            broker.DeleteAsync(role))
                .ReturnsAsync(failedResult);

        // When
        Func<Task> action = async () => await this.rolesService.RemoveRoleAsync(roleName);

        // Then
        FailedRolesOperationException actualException =
            await Assert.ThrowsAsync<FailedRolesOperationException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);

        this.roleManagerBrokerMock.Verify(broker =>
            broker.FindByNameAsync(roleName), Times.Once);

        this.roleManagerBrokerMock.Verify(broker =>
            broker.DeleteAsync(role), Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldRetrieveRoleAsync()
    {
        // Given
        string roleName = GetRandomString();
        IdentityRole role = CreateRole(roleName);

        this.roleManagerBrokerMock.Setup(broker =>
            broker.FindByNameAsync(roleName))
                .ReturnsAsync(role);

        this.roleManagerBrokerMock.Setup(broker =>
            broker.GetRoleNameAsync(role))
                .ReturnsAsync(roleName);

        // When
        string? actualRoleName = await this.rolesService.RetrieveRoleAsync(roleName);

        // Then
        Assert.Equal(roleName, actualRoleName);

        this.roleManagerBrokerMock.Verify(broker =>
            broker.FindByNameAsync(roleName), Times.Once);

        this.roleManagerBrokerMock.Verify(broker =>
            broker.GetRoleNameAsync(role), Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldReturnNullOnRetrieveRoleAsyncWhenRoleNotFound()
    {
        // Given
        string roleName = GetRandomString();

        this.roleManagerBrokerMock.Setup(broker =>
            broker.FindByNameAsync(roleName))
                .ReturnsAsync((IdentityRole?)null);

        // When
        string? actualRoleName = await this.rolesService.RetrieveRoleAsync(roleName);

        // Then
        Assert.Null(actualRoleName);

        this.roleManagerBrokerMock.Verify(broker =>
            broker.FindByNameAsync(roleName), Times.Once);

        this.roleManagerBrokerMock.Verify(broker =>
            broker.GetRoleNameAsync(It.IsAny<IdentityRole>()), Times.Never);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldRetrieveRolesAsync()
    {
        // Given
        IdentityRole first = CreateRole("Admin");
        IdentityRole second = CreateRole("Manager");
        IdentityRole unnamed = CreateRole(string.Empty);

        this.roleManagerBrokerMock.SetupGet(broker => broker.Roles)
            .Returns(CreateAsyncQueryableRoles(first, second, unnamed));

        // When
        ImmutableList<string> actualRoleNames = await this.rolesService.RetrieveRolesAsync();

        // Then
        Assert.Contains("Admin", actualRoleNames);
        Assert.Contains("Manager", actualRoleNames);
        Assert.DoesNotContain(string.Empty, actualRoleNames);
        Assert.Equal(2, actualRoleNames.Count);

        this.roleManagerBrokerMock.VerifyGet(broker => broker.Roles, Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldUpdateRoleAsync()
    {
        // Given
        string roleName = "Admin";
        string newRoleName = "SuperAdmin";
        IdentityRole role = CreateRole(roleName);

        this.roleManagerBrokerMock.Setup(broker =>
            broker.FindByNameAsync(roleName))
                .ReturnsAsync(role);

        this.roleManagerBrokerMock.Setup(broker =>
            broker.RoleExistsAsync(newRoleName))
                .ReturnsAsync(false);

        this.roleManagerBrokerMock.Setup(broker =>
            broker.SetRoleNameAsync(role, newRoleName))
                .ReturnsAsync(IdentityResult.Success);

        this.roleManagerBrokerMock.Setup(broker =>
            broker.UpdateAsync(role))
                .ReturnsAsync(IdentityResult.Success);

        // When
        string actualRoleName = await this.rolesService.UpdateRoleAsync(roleName, newRoleName);

        // Then
        Assert.Equal(newRoleName, actualRoleName);

        this.roleManagerBrokerMock.Verify(broker =>
            broker.FindByNameAsync(roleName), Times.Once);

        this.roleManagerBrokerMock.Verify(broker =>
            broker.RoleExistsAsync(newRoleName), Times.Once);

        this.roleManagerBrokerMock.Verify(broker =>
            broker.SetRoleNameAsync(role, newRoleName), Times.Once);

        this.roleManagerBrokerMock.Verify(broker =>
            broker.UpdateAsync(role), Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldThrowNullRolesExceptionOnUpdateRoleAsyncIfRoleNotFound()
    {
        // Given
        string roleName = GetRandomString();
        string newRoleName = GetRandomString();
        var expectedException = new NullRolesException($"Role '{roleName}' was not found.");

        this.roleManagerBrokerMock.Setup(broker =>
            broker.FindByNameAsync(roleName))
                .ReturnsAsync((IdentityRole?)null);

        // When
        Func<Task> action = async () => await this.rolesService.UpdateRoleAsync(roleName, newRoleName);

        // Then
        NullRolesException actualException = await Assert.ThrowsAsync<NullRolesException>(action);
        Assert.Equal(expectedException.Message, actualException.Message);

        this.roleManagerBrokerMock.Verify(broker =>
            broker.FindByNameAsync(roleName), Times.Once);

        this.roleManagerBrokerMock.Verify(broker =>
            broker.RoleExistsAsync(It.IsAny<string>()), Times.Never);

        this.roleManagerBrokerMock.Verify(broker =>
            broker.SetRoleNameAsync(It.IsAny<IdentityRole>(), It.IsAny<string>()), Times.Never);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldThrowInvalidRolesExceptionOnUpdateRoleAsyncIfNewRoleNameExists()
    {
        // Given
        string roleName = "Admin";
        string newRoleName = "Manager";
        IdentityRole role = CreateRole(roleName);
        var expectedException = new InvalidRolesException($"Role '{newRoleName}' already exists.");

        this.roleManagerBrokerMock.Setup(broker =>
            broker.FindByNameAsync(roleName))
                .ReturnsAsync(role);

        this.roleManagerBrokerMock.Setup(broker =>
            broker.RoleExistsAsync(newRoleName))
                .ReturnsAsync(true);

        // When
        Func<Task> action = async () => await this.rolesService.UpdateRoleAsync(roleName, newRoleName);

        // Then
        InvalidRolesException actualException = await Assert.ThrowsAsync<InvalidRolesException>(action);
        Assert.Equal(expectedException.Message, actualException.Message);

        this.roleManagerBrokerMock.Verify(broker =>
            broker.FindByNameAsync(roleName), Times.Once);

        this.roleManagerBrokerMock.Verify(broker =>
            broker.RoleExistsAsync(newRoleName), Times.Once);

        this.roleManagerBrokerMock.Verify(broker =>
            broker.SetRoleNameAsync(It.IsAny<IdentityRole>(), It.IsAny<string>()), Times.Never);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldThrowFailedRolesOperationExceptionOnUpdateRoleAsyncIfRenameFails()
    {
        // Given
        string roleName = "Admin";
        string newRoleName = "SuperAdmin";
        IdentityRole role = CreateRole(roleName);
        IdentityResult failedResult = IdentityResult.Failed(CreateIdentityError("rename-error"));
        var expectedException = new FailedRolesOperationException("Role identity operation failed: rename-error");

        this.roleManagerBrokerMock.Setup(broker =>
            broker.FindByNameAsync(roleName))
                .ReturnsAsync(role);

        this.roleManagerBrokerMock.Setup(broker =>
            broker.RoleExistsAsync(newRoleName))
                .ReturnsAsync(false);

        this.roleManagerBrokerMock.Setup(broker =>
            broker.SetRoleNameAsync(role, newRoleName))
                .ReturnsAsync(failedResult);

        // When
        Func<Task> action = async () => await this.rolesService.UpdateRoleAsync(roleName, newRoleName);

        // Then
        FailedRolesOperationException actualException =
            await Assert.ThrowsAsync<FailedRolesOperationException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);

        this.roleManagerBrokerMock.Verify(broker =>
            broker.FindByNameAsync(roleName), Times.Once);

        this.roleManagerBrokerMock.Verify(broker =>
            broker.RoleExistsAsync(newRoleName), Times.Once);

        this.roleManagerBrokerMock.Verify(broker =>
            broker.SetRoleNameAsync(role, newRoleName), Times.Once);

        this.roleManagerBrokerMock.Verify(broker =>
            broker.UpdateAsync(It.IsAny<IdentityRole>()), Times.Never);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldThrowFailedRolesOperationExceptionOnUpdateRoleAsyncIfUpdateFails()
    {
        // Given
        string roleName = "Admin";
        string newRoleName = "SuperAdmin";
        IdentityRole role = CreateRole(roleName);
        IdentityResult failedResult = IdentityResult.Failed(CreateIdentityError("update-error"));
        var expectedException = new FailedRolesOperationException("Role identity operation failed: update-error");

        this.roleManagerBrokerMock.Setup(broker =>
            broker.FindByNameAsync(roleName))
                .ReturnsAsync(role);

        this.roleManagerBrokerMock.Setup(broker =>
            broker.RoleExistsAsync(newRoleName))
                .ReturnsAsync(false);

        this.roleManagerBrokerMock.Setup(broker =>
            broker.SetRoleNameAsync(role, newRoleName))
                .ReturnsAsync(IdentityResult.Success);

        this.roleManagerBrokerMock.Setup(broker =>
            broker.UpdateAsync(role))
                .ReturnsAsync(failedResult);

        // When
        Func<Task> action = async () => await this.rolesService.UpdateRoleAsync(roleName, newRoleName);

        // Then
        FailedRolesOperationException actualException =
            await Assert.ThrowsAsync<FailedRolesOperationException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);

        this.roleManagerBrokerMock.Verify(broker =>
            broker.FindByNameAsync(roleName), Times.Once);

        this.roleManagerBrokerMock.Verify(broker =>
            broker.RoleExistsAsync(newRoleName), Times.Once);

        this.roleManagerBrokerMock.Verify(broker =>
            broker.SetRoleNameAsync(role, newRoleName), Times.Once);

        this.roleManagerBrokerMock.Verify(broker =>
            broker.UpdateAsync(role), Times.Once);

        VerifyNoOtherBrokerCalls();
    }
}