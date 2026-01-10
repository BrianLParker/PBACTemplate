// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// RolesServiceTests.Logic.cs See LICENSE.txt in the root folder of the solution.

using Microsoft.AspNetCore.Identity;

namespace PBACTemplate.Tests.Unit;

public partial class RolesServiceTests
{
    [Fact]
    public async Task ShouldCreateRoleAsync()
    {
        // Given
        string roleName = GetRandomString();

        this.roleManagerBrokerMock.Setup(broker =>
            broker.CreateAsync(It.Is<IdentityRole>(role => role.Name == roleName)))
                .ReturnsAsync(IdentityResult.Success);

        // When
        IdentityRole actualRole =
            await this.rolesService.CreateRoleAsync(roleName);

        // Then
        Assert.Equal(roleName, actualRole.Name);

        this.roleManagerBrokerMock.Verify(broker =>
            broker.CreateAsync(It.Is<IdentityRole>(role => role.Name == roleName)),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldUpdateRoleNameAsync()
    {
        // Given
        IdentityRole role = CreateRole();
        string newName = GetRandomString();

        this.roleManagerBrokerMock.Setup(broker =>
            broker.SetRoleNameAsync(role, newName))
                .ReturnsAsync(IdentityResult.Success)
                .Callback(() => role.Name = newName);

        this.roleManagerBrokerMock.Setup(broker =>
            broker.UpdateAsync(role))
                .ReturnsAsync(IdentityResult.Success);

        // When
        IdentityRole actualRole =
            await this.rolesService.UpdateRoleNameAsync(role, newName);

        // Then
        Assert.Equal(role, actualRole);
        Assert.Equal(newName, role.Name);

        this.roleManagerBrokerMock.Verify(broker =>
            broker.SetRoleNameAsync(role, newName),
            Times.Once);

        this.roleManagerBrokerMock.Verify(broker =>
            broker.UpdateAsync(role),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldDeleteRoleAsync()
    {
        // Given
        IdentityRole role = CreateRole();

        this.roleManagerBrokerMock.Setup(broker =>
            broker.DeleteAsync(role))
                .ReturnsAsync(IdentityResult.Success);

        // When
        IdentityRole actualRole =
            await this.rolesService.DeleteRoleAsync(role);

        // Then
        Assert.Equal(role, actualRole);

        this.roleManagerBrokerMock.Verify(broker =>
            broker.DeleteAsync(role),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldCheckRoleExistsAsync()
    {
        // Given
        string roleName = GetRandomString();
        const bool expectedExists = true;

        this.roleManagerBrokerMock.Setup(broker =>
            broker.RoleExistsAsync(roleName))
                .ReturnsAsync(expectedExists);

        // When
        bool actualExists =
            await this.rolesService.RoleExistsAsync(roleName);

        // Then
        Assert.Equal(expectedExists, actualExists);

        this.roleManagerBrokerMock.Verify(broker =>
            broker.RoleExistsAsync(roleName),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldRetrieveRoleByIdAsync()
    {
        // Given
        IdentityRole expectedRole = CreateRole();

        this.roleManagerBrokerMock.Setup(broker =>
            broker.FindByIdAsync(expectedRole.Id))
                .ReturnsAsync(expectedRole);

        // When
        IdentityRole? actualRole =
            await this.rolesService.RetrieveRoleByIdAsync(expectedRole.Id);

        // Then
        Assert.Equal(expectedRole, actualRole);

        this.roleManagerBrokerMock.Verify(broker =>
            broker.FindByIdAsync(expectedRole.Id),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldRetrieveRoleByNameAsync()
    {
        // Given
        IdentityRole expectedRole = CreateRole();

        this.roleManagerBrokerMock.Setup(broker =>
            broker.FindByNameAsync(expectedRole.Name!))
                .ReturnsAsync(expectedRole);

        // When
        IdentityRole? actualRole =
            await this.rolesService.RetrieveRoleByNameAsync(expectedRole.Name!);

        // Then
        Assert.Equal(expectedRole, actualRole);

        this.roleManagerBrokerMock.Verify(broker =>
            broker.FindByNameAsync(expectedRole.Name!),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }
}