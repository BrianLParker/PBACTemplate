// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// RoleServiceTests.Logic.cs See LICENSE.txt in the root folder of the solution.

using System.Collections.Immutable;

namespace PBACTemplate.Client.Tests.Unit;

public partial class RoleServiceTests
{
    [Fact]
    public async Task ShouldCreateRoleAsync()
    {
        // Given
        string roleName = GetRandomString();

        this.httpClientBrokerMock.Setup(broker =>
            broker.CreateRoleAsync(roleName))
            .ReturnsAsync(roleName);

        // When
        string actualRoleName = await this.roleService.CreateRoleAsync(roleName);

        // Then
        Assert.Equal(roleName, actualRoleName);

        this.httpClientBrokerMock.Verify(broker =>
            broker.CreateRoleAsync(roleName),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldRemoveRoleAsync()
    {
        // Given
        string roleName = GetRandomString();

        this.httpClientBrokerMock.Setup(broker =>
            broker.RemoveRoleAsync(roleName))
            .ReturnsAsync(true);

        // When
        bool result = await this.roleService.RemoveRoleAsync(roleName);

        // Then
        Assert.True(result);

        this.httpClientBrokerMock.Verify(broker =>
            broker.RemoveRoleAsync(roleName),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldRetrieveRoleAsync()
    {
        // Given
        string roleName = GetRandomString();

        this.httpClientBrokerMock.Setup(broker =>
            broker.RetrieveRoleAsync(roleName))
            .ReturnsAsync(roleName);

        // When
        string? actualRoleName = await this.roleService.RetrieveRoleAsync(roleName);

        // Then
        Assert.Equal(roleName, actualRoleName);

        this.httpClientBrokerMock.Verify(broker =>
            broker.RetrieveRoleAsync(roleName),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldRetrieveRolesAsync()
    {
        // Given
        ImmutableList<string> roles = ["Admin", "Manager"];

        this.httpClientBrokerMock.Setup(broker =>
            broker.RetrieveRolesAsync())
            .ReturnsAsync(roles);

        // When
        IReadOnlyList<string> actualRoles = await this.roleService.RetrieveRolesAsync();

        // Then
        Assert.Equivalent(roles, actualRoles, strict: true);

        this.httpClientBrokerMock.Verify(broker =>
            broker.RetrieveRolesAsync(),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldUpdateRoleAsync()
    {
        // Given
        string roleName = "Admin";
        string newRoleName = "SuperAdmin";

        this.httpClientBrokerMock.Setup(broker =>
            broker.UpdateRoleAsync(roleName, newRoleName))
            .ReturnsAsync(newRoleName);

        // When
        string actualRoleName = await this.roleService.UpdateRoleAsync(roleName, newRoleName);

        // Then
        Assert.Equal(newRoleName, actualRoleName);

        this.httpClientBrokerMock.Verify(broker =>
            broker.UpdateRoleAsync(roleName, newRoleName),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }
}
