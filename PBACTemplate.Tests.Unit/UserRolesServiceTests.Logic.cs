// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// UserRolesServiceTests.Logic.cs See LICENSE.txt in the root folder of the solution.

using Microsoft.AspNetCore.Identity;
using PBACTemplate.Data;

namespace PBACTemplate.Tests.Unit;

public partial class UserRolesServiceTests
{
    [Fact]
    public async Task ShouldAddToRoleAsync()
    {
        // Given
        ApplicationUser user = CreateUser();
        string role = GetRandomString();

        this.userManagerBrokerMock.Setup(broker =>
            broker.AddToRoleAsync(user, role))
                .ReturnsAsync(IdentityResult.Success);

        // When
        ApplicationUser actualUser = await this.userRolesService
            .AddToRoleAsync(user, role);

        // Then
        Assert.Equal(user, actualUser);

        this.userManagerBrokerMock.Verify(broker =>
            broker.AddToRoleAsync(user, role),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldAddToRolesAsync()
    {
        // Given
        ApplicationUser user = CreateUser();
        IEnumerable<string> roles = CreateRoles(GetRandomString(), GetRandomString());

        this.userManagerBrokerMock.Setup(broker =>
            broker.AddToRolesAsync(user, roles))
                .ReturnsAsync(IdentityResult.Success);

        // When
        ApplicationUser actualUser = await this.userRolesService
            .AddToRolesAsync(user, roles);

        // Then
        Assert.Equal(user, actualUser);

        this.userManagerBrokerMock.Verify(broker =>
            broker.AddToRolesAsync(user, roles),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldRemoveFromRoleAsync()
    {
        // Given
        ApplicationUser user = CreateUser();
        string role = GetRandomString();

        this.userManagerBrokerMock.Setup(broker =>
            broker.RemoveFromRoleAsync(user, role))
                .ReturnsAsync(IdentityResult.Success);

        // When
        ApplicationUser actualUser = await this.userRolesService
            .RemoveFromRoleAsync(user, role);

        // Then
        Assert.Equal(user, actualUser);

        this.userManagerBrokerMock.Verify(broker =>
            broker.RemoveFromRoleAsync(user, role),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldRemoveFromRolesAsync()
    {
        // Given
        ApplicationUser user = CreateUser();
        IEnumerable<string> roles = CreateRoles(GetRandomString());

        this.userManagerBrokerMock.Setup(broker =>
            broker.RemoveFromRolesAsync(user, roles))
                .ReturnsAsync(IdentityResult.Success);

        // When
        ApplicationUser actualUser = await this.userRolesService
            .RemoveFromRolesAsync(user, roles);

        // Then
        Assert.Equal(user, actualUser);

        this.userManagerBrokerMock.Verify(broker =>
            broker.RemoveFromRolesAsync(user, roles),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldRetrieveRolesAsync()
    {
        // Given
        ApplicationUser user = CreateUser();
        IList<string> expectedRoles = new List<string> { GetRandomString(), GetRandomString() };

        this.userManagerBrokerMock.Setup(broker =>
            broker.GetRolesAsync(user))
                .ReturnsAsync(expectedRoles);

        // When
        IList<string> actualRoles = await this.userRolesService
            .RetrieveRolesAsync(user);

        // Then
        Assert.Equal(expectedRoles, actualRoles);

        this.userManagerBrokerMock.Verify(broker =>
            broker.GetRolesAsync(user),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldCheckIsInRoleAsync()
    {
        // Given
        ApplicationUser user = CreateUser();
        string role = GetRandomString();
        const bool expectedResult = true;

        this.userManagerBrokerMock.Setup(broker =>
            broker.IsInRoleAsync(user, role))
                .ReturnsAsync(expectedResult);

        // When
        bool actualResult = await this.userRolesService
            .IsInRoleAsync(user, role);

        // Then
        Assert.Equal(expectedResult, actualResult);

        this.userManagerBrokerMock.Verify(broker =>
            broker.IsInRoleAsync(user, role),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldRetrieveUsersInRoleAsync()
    {
        // Given
        string roleName = GetRandomString();
        IList<ApplicationUser> expectedUsers = new List<ApplicationUser> { CreateUser(), CreateUser() };

        this.userManagerBrokerMock.Setup(broker =>
            broker.GetUsersInRoleAsync(roleName))
                .ReturnsAsync(expectedUsers);

        // When
        IList<ApplicationUser> actualUsers = await this.userRolesService
            .RetrieveUsersInRoleAsync(roleName);

        // Then
        Assert.Equal(expectedUsers, actualUsers);

        this.userManagerBrokerMock.Verify(broker =>
            broker.GetUsersInRoleAsync(roleName),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }
}