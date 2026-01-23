// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// RoleServiceTests.Exceptions.cs See LICENSE.txt in the root folder of the solution.

using PBACTemplate.Client.Services.Foundations.Roles.Exceptions;

namespace PBACTemplate.Client.Tests.Unit;

public partial class RoleServiceTests
{
    [Fact]
    public async Task ShouldThrowRolesServiceExceptionOnCreateIfBrokerThrows()
    {
        // Given
        string roleName = GetRandomString();
        var someException = new Exception("boom");

        this.httpClientBrokerMock.Setup(broker =>
            broker.CreateRoleAsync(roleName))
            .ThrowsAsync(someException);

        var expectedException = new RolesServiceException(
            "Roles service error occurred, contact support.",
            new FailedRolesServiceException(
                "Failed roles service error occurred, contact support.",
                someException));

        // When
        Func<Task> action = async () =>
            await this.roleService.CreateRoleAsync(roleName);

        // Then
        RolesServiceException actualException =
            await Assert.ThrowsAsync<RolesServiceException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);
        Assert.IsType<FailedRolesServiceException>(actualException.InnerException);

        this.httpClientBrokerMock.Verify(broker =>
            broker.CreateRoleAsync(roleName),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldThrowRolesServiceExceptionOnRemoveIfBrokerThrows()
    {
        // Given
        string roleName = GetRandomString();
        var someException = new Exception("boom");

        this.httpClientBrokerMock.Setup(broker =>
            broker.RemoveRoleAsync(roleName))
            .ThrowsAsync(someException);

        var expectedException = new RolesServiceException(
            "Roles service error occurred, contact support.",
            new FailedRolesServiceException(
                "Failed roles service error occurred, contact support.",
                someException));

        // When
        Func<Task> action = async () =>
            await this.roleService.RemoveRoleAsync(roleName);

        // Then
        RolesServiceException actualException =
            await Assert.ThrowsAsync<RolesServiceException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);
        Assert.IsType<FailedRolesServiceException>(actualException.InnerException);

        this.httpClientBrokerMock.Verify(broker =>
            broker.RemoveRoleAsync(roleName),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldThrowRolesServiceExceptionOnRetrieveIfBrokerThrows()
    {
        // Given
        string roleName = GetRandomString();
        var someException = new Exception("boom");

        this.httpClientBrokerMock.Setup(broker =>
            broker.RetrieveRoleAsync(roleName))
            .ThrowsAsync(someException);

        var expectedException = new RolesServiceException(
            "Roles service error occurred, contact support.",
            new FailedRolesServiceException(
                "Failed roles service error occurred, contact support.",
                someException));

        // When
        Func<Task> action = async () =>
            await this.roleService.RetrieveRoleAsync(roleName);

        // Then
        RolesServiceException actualException =
            await Assert.ThrowsAsync<RolesServiceException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);
        Assert.IsType<FailedRolesServiceException>(actualException.InnerException);

        this.httpClientBrokerMock.Verify(broker =>
            broker.RetrieveRoleAsync(roleName),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldThrowRolesServiceExceptionOnRetrieveAllIfBrokerThrows()
    {
        // Given
        var someException = new Exception("boom");

        this.httpClientBrokerMock.Setup(broker =>
            broker.RetrieveRolesAsync())
            .ThrowsAsync(someException);

        var expectedException = new RolesServiceException(
            "Roles service error occurred, contact support.",
            new FailedRolesServiceException(
                "Failed roles service error occurred, contact support.",
                someException));

        // When
        Func<Task> action = async () =>
            await this.roleService.RetrieveRolesAsync();

        // Then
        RolesServiceException actualException =
            await Assert.ThrowsAsync<RolesServiceException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);
        Assert.IsType<FailedRolesServiceException>(actualException.InnerException);

        this.httpClientBrokerMock.Verify(broker =>
            broker.RetrieveRolesAsync(),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldThrowRolesServiceExceptionOnUpdateIfBrokerThrows()
    {
        // Given
        string roleName = "Admin";
        string newRoleName = "Manager";
        var someException = new Exception("boom");

        this.httpClientBrokerMock.Setup(broker =>
            broker.UpdateRoleAsync(roleName, newRoleName))
            .ThrowsAsync(someException);

        var expectedException = new RolesServiceException(
            "Roles service error occurred, contact support.",
            new FailedRolesServiceException(
                "Failed roles service error occurred, contact support.",
                someException));

        // When
        Func<Task> action = async () =>
            await this.roleService.UpdateRoleAsync(roleName, newRoleName);

        // Then
        RolesServiceException actualException =
            await Assert.ThrowsAsync<RolesServiceException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);
        Assert.IsType<FailedRolesServiceException>(actualException.InnerException);

        this.httpClientBrokerMock.Verify(broker =>
            broker.UpdateRoleAsync(roleName, newRoleName),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldThrowFailedRolesOperationExceptionOnCreateIfBrokerReturnsNull()
    {
        // Given
        string roleName = GetRandomString();
        var expectedException = new FailedRolesOperationException("Failed to create role.");

        this.httpClientBrokerMock.Setup(broker =>
            broker.CreateRoleAsync(roleName))
            .ReturnsAsync((string?)null);

        // When
        Func<Task> action = async () =>
            await this.roleService.CreateRoleAsync(roleName);

        // Then
        FailedRolesOperationException actualException =
            await Assert.ThrowsAsync<FailedRolesOperationException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);

        this.httpClientBrokerMock.Verify(broker =>
            broker.CreateRoleAsync(roleName),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldThrowFailedRolesOperationExceptionOnCreateIfBrokerReturnsWhitespace()
    {
        // Given
        string roleName = GetRandomString();
        var expectedException = new FailedRolesOperationException("Failed to create role.");

        this.httpClientBrokerMock.Setup(broker =>
            broker.CreateRoleAsync(roleName))
            .ReturnsAsync(" ");

        // When
        Func<Task> action = async () =>
            await this.roleService.CreateRoleAsync(roleName);

        // Then
        FailedRolesOperationException actualException =
            await Assert.ThrowsAsync<FailedRolesOperationException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);

        this.httpClientBrokerMock.Verify(broker =>
            broker.CreateRoleAsync(roleName),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldThrowFailedRolesOperationExceptionOnRemoveIfBrokerReturnsFalse()
    {
        // Given
        string roleName = GetRandomString();
        var expectedException = new FailedRolesOperationException($"Failed to remove role '{roleName}'.");

        this.httpClientBrokerMock.Setup(broker =>
            broker.RemoveRoleAsync(roleName))
            .ReturnsAsync(false);

        // When
        Func<Task> action = async () =>
            await this.roleService.RemoveRoleAsync(roleName);

        // Then
        FailedRolesOperationException actualException =
            await Assert.ThrowsAsync<FailedRolesOperationException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);

        this.httpClientBrokerMock.Verify(broker =>
            broker.RemoveRoleAsync(roleName),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldThrowFailedRolesOperationExceptionOnUpdateIfBrokerReturnsNull()
    {
        // Given
        string roleName = "Admin";
        string newRoleName = "Manager";
        var expectedException = new FailedRolesOperationException($"Failed to update role '{roleName}'.");

        this.httpClientBrokerMock.Setup(broker =>
            broker.UpdateRoleAsync(roleName, newRoleName))
            .ReturnsAsync((string?)null);

        // When
        Func<Task> action = async () =>
            await this.roleService.UpdateRoleAsync(roleName, newRoleName);

        // Then
        FailedRolesOperationException actualException =
            await Assert.ThrowsAsync<FailedRolesOperationException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);

        this.httpClientBrokerMock.Verify(broker =>
            broker.UpdateRoleAsync(roleName, newRoleName),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldThrowFailedRolesOperationExceptionOnUpdateIfBrokerReturnsWhitespace()
    {
        // Given
        string roleName = "Admin";
        string newRoleName = "Manager";
        var expectedException = new FailedRolesOperationException($"Failed to update role '{roleName}'.");

        this.httpClientBrokerMock.Setup(broker =>
            broker.UpdateRoleAsync(roleName, newRoleName))
            .ReturnsAsync("  ");

        // When
        Func<Task> action = async () =>
            await this.roleService.UpdateRoleAsync(roleName, newRoleName);

        // Then
        FailedRolesOperationException actualException =
            await Assert.ThrowsAsync<FailedRolesOperationException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);

        this.httpClientBrokerMock.Verify(broker =>
            broker.UpdateRoleAsync(roleName, newRoleName),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldThrowNullRolesExceptionOnCreateIfRoleNameIsNull()
    {
        // Given
        string? roleName = null;

        // When
        Func<Task> action = async () =>
            await this.roleService.CreateRoleAsync(roleName!);

        // Then
        NullRolesException exception = await Assert.ThrowsAsync<NullRolesException>(action);
        Assert.Equal("Role name cannot be null.", exception.Message);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldThrowInvalidRolesExceptionOnCreateIfRoleNameIsWhitespace()
    {
        // Given
        string roleName = "  ";

        // When
        Func<Task> action = async () =>
            await this.roleService.CreateRoleAsync(roleName);

        // Then
        InvalidRolesException exception = await Assert.ThrowsAsync<InvalidRolesException>(action);
        Assert.Equal("Role name cannot be empty or whitespace.", exception.Message);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldThrowNullRolesExceptionOnRemoveIfRoleNameIsNull()
    {
        // Given
        string? roleName = null;

        // When
        Func<Task> action = async () =>
            await this.roleService.RemoveRoleAsync(roleName!);

        // Then
        NullRolesException exception = await Assert.ThrowsAsync<NullRolesException>(action);
        Assert.Equal("Role name cannot be null.", exception.Message);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldThrowInvalidRolesExceptionOnRemoveIfRoleNameIsWhitespace()
    {
        // Given
        string roleName = " ";

        // When
        Func<Task> action = async () =>
            await this.roleService.RemoveRoleAsync(roleName);

        // Then
        InvalidRolesException exception = await Assert.ThrowsAsync<InvalidRolesException>(action);
        Assert.Equal("Role name cannot be empty or whitespace.", exception.Message);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldThrowNullRolesExceptionOnRetrieveIfRoleNameIsNull()
    {
        // Given
        string? roleName = null;

        // When
        Func<Task> action = async () =>
            await this.roleService.RetrieveRoleAsync(roleName!);

        // Then
        NullRolesException exception = await Assert.ThrowsAsync<NullRolesException>(action);
        Assert.Equal("Role name cannot be null.", exception.Message);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldThrowInvalidRolesExceptionOnRetrieveIfRoleNameIsWhitespace()
    {
        // Given
        string roleName = "\t";

        // When
        Func<Task> action = async () =>
            await this.roleService.RetrieveRoleAsync(roleName);

        // Then
        InvalidRolesException exception = await Assert.ThrowsAsync<InvalidRolesException>(action);
        Assert.Equal("Role name cannot be empty or whitespace.", exception.Message);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldThrowNullRolesExceptionOnUpdateIfRoleNameIsNull()
    {
        // Given
        string? roleName = null;
        string newRoleName = "Admin";

        // When
        Func<Task> action = async () =>
            await this.roleService.UpdateRoleAsync(roleName!, newRoleName);

        // Then
        NullRolesException exception = await Assert.ThrowsAsync<NullRolesException>(action);
        Assert.Equal("Role name cannot be null.", exception.Message);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldThrowInvalidRolesExceptionOnUpdateIfRoleNameIsWhitespace()
    {
        // Given
        string roleName = " ";
        string newRoleName = "Admin";

        // When
        Func<Task> action = async () =>
            await this.roleService.UpdateRoleAsync(roleName, newRoleName);

        // Then
        InvalidRolesException exception = await Assert.ThrowsAsync<InvalidRolesException>(action);
        Assert.Equal("Role name cannot be empty or whitespace.", exception.Message);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldThrowNullRolesExceptionOnUpdateIfNewRoleNameIsNull()
    {
        // Given
        string roleName = "Admin";
        string? newRoleName = null;

        // When
        Func<Task> action = async () =>
            await this.roleService.UpdateRoleAsync(roleName, newRoleName!);

        // Then
        NullRolesException exception = await Assert.ThrowsAsync<NullRolesException>(action);
        Assert.Equal("Role name cannot be null.", exception.Message);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldThrowInvalidRolesExceptionOnUpdateIfNewRoleNameIsWhitespace()
    {
        // Given
        string roleName = "Admin";
        string newRoleName = "   ";

        // When
        Func<Task> action = async () =>
            await this.roleService.UpdateRoleAsync(roleName, newRoleName);

        // Then
        InvalidRolesException exception = await Assert.ThrowsAsync<InvalidRolesException>(action);
        Assert.Equal("Role name cannot be empty or whitespace.", exception.Message);

        VerifyNoOtherBrokerCalls();
    }
}
