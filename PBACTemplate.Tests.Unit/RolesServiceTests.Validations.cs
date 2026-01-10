// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// RolesServiceTests.Validations.cs See LICENSE.txt in the root folder of the solution.

using Microsoft.AspNetCore.Identity;
using PBACTemplate.Services.Foundations.Roles.Exceptions;

namespace PBACTemplate.Tests.Unit;

public partial class RolesServiceTests
{
    [Fact]
    public async Task ShouldThrowInvalidRolesExceptionOnCreateRoleAsyncIfNameIsNullOrWhitespace()
    {
        // Given
        string? invalidName = null;
        var expectedException = new InvalidRolesException("Role name cannot be null or whitespace.");

        // When
        Func<Task> action = async () => await this.rolesService
            .CreateRoleAsync(invalidName!);

        // Then
        InvalidRolesException actualException =
            await Assert.ThrowsAsync<InvalidRolesException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);

        this.roleManagerBrokerMock.Verify(broker =>
            broker.CreateAsync(It.IsAny<IdentityRole>()),
            Times.Never);

        VerifyNoOtherBrokerCalls();
    }

    [Theory]
    [InlineData("")]
    [InlineData("   ")]
    public async Task ShouldThrowInvalidRolesExceptionOnCreateRoleAsyncIfNameIsWhitespace(
        string invalidName)
    {
        // Given
        var expectedException = new InvalidRolesException("Role name cannot be null or whitespace.");

        // When
        Func<Task> action = async () => await this.rolesService
            .CreateRoleAsync(invalidName);

        // Then
        InvalidRolesException actualException =
            await Assert.ThrowsAsync<InvalidRolesException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);

        this.roleManagerBrokerMock.Verify(broker =>
            broker.CreateAsync(It.IsAny<IdentityRole>()),
            Times.Never);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldThrowNullRolesExceptionOnUpdateRoleNameAsyncIfRoleIsNull()
    {
        // Given
        IdentityRole? nullRole = null;
        string newName = GetRandomString();
        var expectedException = new NullRolesException("Role cannot be null.");

        // When
        Func<Task> action = async () => await this.rolesService
            .UpdateRoleNameAsync(nullRole!, newName);

        // Then
        NullRolesException actualException =
            await Assert.ThrowsAsync<NullRolesException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);

        this.roleManagerBrokerMock.Verify(broker =>
            broker.SetRoleNameAsync(
                It.IsAny<IdentityRole>(),
                It.IsAny<string>()),
            Times.Never);

        VerifyNoOtherBrokerCalls();
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("   ")]
    public async Task ShouldThrowInvalidRolesExceptionOnUpdateRoleNameAsyncIfNewNameIsInvalid(
        string? invalidName)
    {
        // Given
        IdentityRole role = CreateRole();
        var expectedException = new InvalidRolesException("Role name cannot be null or whitespace.");

        // When
        Func<Task> action = async () => await this.rolesService
            .UpdateRoleNameAsync(role, invalidName!);

        // Then
        InvalidRolesException actualException =
            await Assert.ThrowsAsync<InvalidRolesException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);

        this.roleManagerBrokerMock.Verify(broker =>
            broker.SetRoleNameAsync(
                It.IsAny<IdentityRole>(),
                It.IsAny<string>()),
            Times.Never);

        this.roleManagerBrokerMock.Verify(broker =>
            broker.UpdateAsync(It.IsAny<IdentityRole>()),
            Times.Never);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldThrowNullRolesExceptionOnDeleteRoleAsyncIfRoleIsNull()
    {
        // Given
        IdentityRole? nullRole = null;
        var expectedException = new NullRolesException("Role cannot be null.");

        // When
        Func<Task> action = async () => await this.rolesService
            .DeleteRoleAsync(nullRole!);

        // Then
        NullRolesException actualException =
            await Assert.ThrowsAsync<NullRolesException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);

        this.roleManagerBrokerMock.Verify(broker =>
            broker.DeleteAsync(It.IsAny<IdentityRole>()),
            Times.Never);

        VerifyNoOtherBrokerCalls();
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("   ")]
    public async Task ShouldThrowInvalidRolesExceptionOnRoleExistsAsyncIfNameIsInvalid(
        string? invalidName)
    {
        // Given
        var expectedException = new InvalidRolesException("Role name cannot be null or whitespace.");

        // When
        Func<Task> action = async () => await this.rolesService
            .RoleExistsAsync(invalidName!);

        // Then
        InvalidRolesException actualException =
            await Assert.ThrowsAsync<InvalidRolesException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);

        this.roleManagerBrokerMock.Verify(broker =>
            broker.RoleExistsAsync(It.IsAny<string>()),
            Times.Never);

        VerifyNoOtherBrokerCalls();
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("   ")]
    public async Task ShouldThrowInvalidRolesExceptionOnRetrieveRoleByIdAsyncIfIdIsInvalid(
        string? invalidRoleId)
    {
        // Given
        var expectedException = new InvalidRolesException("Role ID cannot be null or whitespace.");

        // When
        Func<Task> action = async () => await this.rolesService
            .RetrieveRoleByIdAsync(invalidRoleId!);

        // Then
        InvalidRolesException actualException =
            await Assert.ThrowsAsync<InvalidRolesException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);

        this.roleManagerBrokerMock.Verify(broker =>
            broker.FindByIdAsync(It.IsAny<string>()),
            Times.Never);

        VerifyNoOtherBrokerCalls();
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("   ")]
    public async Task ShouldThrowInvalidRolesExceptionOnRetrieveRoleByNameAsyncIfNameIsInvalid(
        string? invalidRoleName)
    {
        // Given
        var expectedException = new InvalidRolesException("Role name cannot be null or whitespace.");

        // When
        Func<Task> action = async () => await this.rolesService
            .RetrieveRoleByNameAsync(invalidRoleName!);

        // Then
        InvalidRolesException actualException =
            await Assert.ThrowsAsync<InvalidRolesException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);

        this.roleManagerBrokerMock.Verify(broker =>
            broker.FindByNameAsync(It.IsAny<string>()),
            Times.Never);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldThrowFailedRolesOperationExceptionOnCreateRoleAsyncIfIdentityResultFailed()
    {
        // Given
        string roleName = GetRandomString();
        var identityError = new IdentityError { Description = GetRandomString() };
        IdentityResult failedResult = IdentityResult.Failed(identityError);

        this.roleManagerBrokerMock.Setup(broker =>
            broker.CreateAsync(It.Is<IdentityRole>(role => role.Name == roleName)))
                .ReturnsAsync(failedResult);

        var expectedException = new FailedRolesOperationException(
            $"Role identity operation failed: {identityError.Description}");

        // When
        Func<Task> action = async () => await this.rolesService
            .CreateRoleAsync(roleName);

        // Then
        FailedRolesOperationException actualException =
            await Assert.ThrowsAsync<FailedRolesOperationException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);

        this.roleManagerBrokerMock.Verify(broker =>
            broker.CreateAsync(It.Is<IdentityRole>(role => role.Name == roleName)),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldThrowFailedRolesOperationExceptionOnUpdateRoleNameAsyncIfSetRoleNameFails()
    {
        // Given
        IdentityRole role = CreateRole();
        string newName = GetRandomString();
        var identityError = new IdentityError { Description = GetRandomString() };
        IdentityResult failedResult = IdentityResult.Failed(identityError);

        this.roleManagerBrokerMock.Setup(broker =>
            broker.SetRoleNameAsync(role, newName))
                .ReturnsAsync(failedResult);

        var expectedException = new FailedRolesOperationException(
            $"Role identity operation failed: {identityError.Description}");

        // When
        Func<Task> action = async () => await this.rolesService
            .UpdateRoleNameAsync(role, newName);

        // Then
        FailedRolesOperationException actualException =
            await Assert.ThrowsAsync<FailedRolesOperationException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);

        this.roleManagerBrokerMock.Verify(broker =>
            broker.SetRoleNameAsync(role, newName),
            Times.Once);

        this.roleManagerBrokerMock.Verify(broker =>
            broker.UpdateAsync(It.IsAny<IdentityRole>()),
            Times.Never);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldThrowFailedRolesOperationExceptionOnUpdateRoleNameAsyncIfUpdateFails()
    {
        // Given
        IdentityRole role = CreateRole();
        string newName = GetRandomString();

        this.roleManagerBrokerMock.Setup(broker =>
            broker.SetRoleNameAsync(role, newName))
                .ReturnsAsync(IdentityResult.Success);

        var identityError = new IdentityError { Description = GetRandomString() };
        IdentityResult failedResult = IdentityResult.Failed(identityError);

        this.roleManagerBrokerMock.Setup(broker =>
            broker.UpdateAsync(role))
                .ReturnsAsync(failedResult);

        var expectedException = new FailedRolesOperationException(
            $"Role identity operation failed: {identityError.Description}");

        // When
        Func<Task> action = async () => await this.rolesService
            .UpdateRoleNameAsync(role, newName);

        // Then
        FailedRolesOperationException actualException =
            await Assert.ThrowsAsync<FailedRolesOperationException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);

        this.roleManagerBrokerMock.Verify(broker =>
            broker.SetRoleNameAsync(role, newName),
            Times.Once);

        this.roleManagerBrokerMock.Verify(broker =>
            broker.UpdateAsync(role),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldThrowFailedRolesOperationExceptionOnDeleteRoleAsyncIfIdentityResultFailed()
    {
        // Given
        IdentityRole role = CreateRole();
        var identityError = new IdentityError { Description = GetRandomString() };
        IdentityResult failedResult = IdentityResult.Failed(identityError);

        this.roleManagerBrokerMock.Setup(broker =>
            broker.DeleteAsync(role))
                .ReturnsAsync(failedResult);

        var expectedException = new FailedRolesOperationException(
            $"Role identity operation failed: {identityError.Description}");

        // When
        Func<Task> action = async () => await this.rolesService
            .DeleteRoleAsync(role);

        // Then
        FailedRolesOperationException actualException =
            await Assert.ThrowsAsync<FailedRolesOperationException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);

        this.roleManagerBrokerMock.Verify(broker =>
            broker.DeleteAsync(role),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }
}