// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// RolesServiceTests.Validations.cs See LICENSE.txt in the root folder of the solution.

using Microsoft.AspNetCore.Identity;
using PBACTemplate.Services.Foundations.Roles.Exceptions;

namespace PBACTemplate.Tests.Unit;

public partial class RolesServiceTests
{
    [Fact]
    public async Task ShouldThrowNullRolesExceptionOnCreateRoleAsyncIfRoleNameIsNull()
    {
        // Given
        string? nullRoleName = null;
        var expectedException = new NullRolesException("Role name cannot be null.");

        // When
        Func<Task> action = async () => await this.rolesService.CreateRoleAsync(nullRoleName!);

        // Then
        NullRolesException actualException = await Assert.ThrowsAsync<NullRolesException>(action);
        Assert.Equal(expectedException.Message, actualException.Message);

        this.roleManagerBrokerMock.Verify(broker =>
            broker.RoleExistsAsync(It.IsAny<string>()), Times.Never);

        this.roleManagerBrokerMock.Verify(broker =>
            broker.CreateAsync(It.IsAny<IdentityRole>()), Times.Never);

        VerifyNoOtherBrokerCalls();
    }

    [Theory]
    [InlineData("")]
    [InlineData("   ")]
    public async Task ShouldThrowInvalidRolesExceptionOnCreateRoleAsyncIfRoleNameIsInvalid(string invalidRoleName)
    {
        // Given
        var expectedException = new InvalidRolesException("Role name cannot be empty or whitespace.");

        // When
        Func<Task> action = async () => await this.rolesService.CreateRoleAsync(invalidRoleName);

        // Then
        InvalidRolesException actualException = await Assert.ThrowsAsync<InvalidRolesException>(action);
        Assert.Equal(expectedException.Message, actualException.Message);

        this.roleManagerBrokerMock.Verify(broker =>
            broker.RoleExistsAsync(It.IsAny<string>()), Times.Never);

        this.roleManagerBrokerMock.Verify(broker =>
            broker.CreateAsync(It.IsAny<IdentityRole>()), Times.Never);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldThrowNullRolesExceptionOnRemoveRoleAsyncIfRoleNameIsNull()
    {
        // Given
        string? nullRoleName = null;
        var expectedException = new NullRolesException("Role name cannot be null.");

        // When
        Func<Task> action = async () => await this.rolesService.RemoveRoleAsync(nullRoleName!);

        // Then
        NullRolesException actualException = await Assert.ThrowsAsync<NullRolesException>(action);
        Assert.Equal(expectedException.Message, actualException.Message);

        this.roleManagerBrokerMock.Verify(broker =>
            broker.FindByNameAsync(It.IsAny<string>()), Times.Never);

        this.roleManagerBrokerMock.Verify(broker =>
            broker.DeleteAsync(It.IsAny<IdentityRole>()), Times.Never);

        VerifyNoOtherBrokerCalls();
    }

    [Theory]
    [InlineData("")]
    [InlineData("   ")]
    public async Task ShouldThrowInvalidRolesExceptionOnRemoveRoleAsyncIfRoleNameIsInvalid(string invalidRoleName)
    {
        // Given
        var expectedException = new InvalidRolesException("Role name cannot be empty or whitespace.");

        // When
        Func<Task> action = async () => await this.rolesService.RemoveRoleAsync(invalidRoleName);

        // Then
        InvalidRolesException actualException = await Assert.ThrowsAsync<InvalidRolesException>(action);
        Assert.Equal(expectedException.Message, actualException.Message);

        this.roleManagerBrokerMock.Verify(broker =>
            broker.FindByNameAsync(It.IsAny<string>()), Times.Never);

        this.roleManagerBrokerMock.Verify(broker =>
            broker.DeleteAsync(It.IsAny<IdentityRole>()), Times.Never);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldThrowNullRolesExceptionOnRetrieveRoleAsyncIfRoleNameIsNull()
    {
        // Given
        string? nullRoleName = null;
        var expectedException = new NullRolesException("Role name cannot be null.");

        // When
        Func<Task> action = async () => await this.rolesService.RetrieveRoleAsync(nullRoleName!);

        // Then
        NullRolesException actualException = await Assert.ThrowsAsync<NullRolesException>(action);
        Assert.Equal(expectedException.Message, actualException.Message);

        this.roleManagerBrokerMock.Verify(broker =>
            broker.FindByNameAsync(It.IsAny<string>()), Times.Never);

        this.roleManagerBrokerMock.Verify(broker =>
            broker.GetRoleNameAsync(It.IsAny<IdentityRole>()), Times.Never);

        VerifyNoOtherBrokerCalls();
    }

    [Theory]
    [InlineData("")]
    [InlineData("   ")]
    public async Task ShouldThrowInvalidRolesExceptionOnRetrieveRoleAsyncIfRoleNameIsInvalid(string invalidRoleName)
    {
        // Given
        var expectedException = new InvalidRolesException("Role name cannot be empty or whitespace.");

        // When
        Func<Task> action = async () => await this.rolesService.RetrieveRoleAsync(invalidRoleName);

        // Then
        InvalidRolesException actualException = await Assert.ThrowsAsync<InvalidRolesException>(action);
        Assert.Equal(expectedException.Message, actualException.Message);

        this.roleManagerBrokerMock.Verify(broker =>
            broker.FindByNameAsync(It.IsAny<string>()), Times.Never);

        this.roleManagerBrokerMock.Verify(broker =>
            broker.GetRoleNameAsync(It.IsAny<IdentityRole>()), Times.Never);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldThrowNullRolesExceptionOnUpdateRoleAsyncIfRoleNameIsNull()
    {
        // Given
        string? nullRoleName = null;
        string newRoleName = GetRandomString();
        var expectedException = new NullRolesException("Role name cannot be null.");

        // When
        Func<Task> action = async () => await this.rolesService.UpdateRoleAsync(nullRoleName!, newRoleName);

        // Then
        NullRolesException actualException = await Assert.ThrowsAsync<NullRolesException>(action);
        Assert.Equal(expectedException.Message, actualException.Message);

        this.roleManagerBrokerMock.Verify(broker =>
            broker.FindByNameAsync(It.IsAny<string>()), Times.Never);

        this.roleManagerBrokerMock.Verify(broker =>
            broker.RoleExistsAsync(It.IsAny<string>()), Times.Never);

        this.roleManagerBrokerMock.Verify(broker =>
            broker.SetRoleNameAsync(It.IsAny<IdentityRole>(), It.IsAny<string>()), Times.Never);

        VerifyNoOtherBrokerCalls();
    }

    [Theory]
    [InlineData("")]
    [InlineData("   ")]
    public async Task ShouldThrowInvalidRolesExceptionOnUpdateRoleAsyncIfRoleNameIsInvalid(string invalidRoleName)
    {
        // Given
        string newRoleName = GetRandomString();
        var expectedException = new InvalidRolesException("Role name cannot be empty or whitespace.");

        // When
        Func<Task> action = async () => await this.rolesService.UpdateRoleAsync(invalidRoleName, newRoleName);

        // Then
        InvalidRolesException actualException = await Assert.ThrowsAsync<InvalidRolesException>(action);
        Assert.Equal(expectedException.Message, actualException.Message);

        this.roleManagerBrokerMock.Verify(broker =>
            broker.FindByNameAsync(It.IsAny<string>()), Times.Never);

        this.roleManagerBrokerMock.Verify(broker =>
            broker.SetRoleNameAsync(It.IsAny<IdentityRole>(), It.IsAny<string>()), Times.Never);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldThrowNullRolesExceptionOnUpdateRoleAsyncIfNewRoleNameIsNull()
    {
        // Given
        string roleName = GetRandomString();
        string? newRoleName = null;
        var expectedException = new NullRolesException("Role name cannot be null.");

        // When
        Func<Task> action = async () => await this.rolesService.UpdateRoleAsync(roleName, newRoleName!);

        // Then
        NullRolesException actualException = await Assert.ThrowsAsync<NullRolesException>(action);
        Assert.Equal(expectedException.Message, actualException.Message);

        this.roleManagerBrokerMock.Verify(broker =>
            broker.FindByNameAsync(It.IsAny<string>()), Times.Never);

        this.roleManagerBrokerMock.Verify(broker =>
            broker.SetRoleNameAsync(It.IsAny<IdentityRole>(), It.IsAny<string>()), Times.Never);

        VerifyNoOtherBrokerCalls();
    }

    [Theory]
    [InlineData("")]
    [InlineData("   ")]
    public async Task ShouldThrowInvalidRolesExceptionOnUpdateRoleAsyncIfNewRoleNameIsInvalid(string invalidRoleName)
    {
        // Given
        string roleName = GetRandomString();
        var expectedException = new InvalidRolesException("Role name cannot be empty or whitespace.");

        // When
        Func<Task> action = async () => await this.rolesService.UpdateRoleAsync(roleName, invalidRoleName);

        // Then
        InvalidRolesException actualException = await Assert.ThrowsAsync<InvalidRolesException>(action);
        Assert.Equal(expectedException.Message, actualException.Message);

        this.roleManagerBrokerMock.Verify(broker =>
            broker.FindByNameAsync(It.IsAny<string>()), Times.Never);

        this.roleManagerBrokerMock.Verify(broker =>
            broker.SetRoleNameAsync(It.IsAny<IdentityRole>(), It.IsAny<string>()), Times.Never);

        VerifyNoOtherBrokerCalls();
    }
}