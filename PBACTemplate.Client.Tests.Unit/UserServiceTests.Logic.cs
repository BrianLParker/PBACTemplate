// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// UserServiceTests.Logic.cs See LICENSE.txt in the root folder of the solution.

using PBACTemplate.Client.Models.Users;
using System.Collections.Immutable;

namespace PBACTemplate.Client.Tests.Unit;

public partial class UserServiceTests
{
    [Fact]
    public async Task ShouldCreateAdministrationUserAsync()
    {
        // Given
        User inputUser = CreateUser();
        User returnedUser = CreateUser(inputUser.Id);

        this.httpClientBrokerMock.Setup(broker =>
            broker.CreateAdministrationUserAsync(inputUser, It.IsAny<CancellationToken>()))
            .ReturnsAsync(returnedUser);

        // When
        User? actualUser = await this.userService.CreateAdministrationUserAsync(inputUser);

        // Then
        Assert.NotNull(actualUser);
        Assert.Equal(returnedUser.Id, actualUser!.Id);
        Assert.Equal(returnedUser.UserName, actualUser.UserName);
        Assert.Equal(returnedUser.Email, actualUser.Email);

        this.httpClientBrokerMock.Verify(broker =>
            broker.CreateAdministrationUserAsync(inputUser, It.IsAny<CancellationToken>()),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldUpdateAdministrationUserAsync()
    {
        // Given
        string userId = GetRandomString();
        User inputUser = CreateUser(userId);
        User updatedUser = CreateUser(userId);

        this.httpClientBrokerMock.Setup(broker =>
            broker.UpdateAdministrationUserAsync(userId, inputUser, It.IsAny<CancellationToken>()))
            .ReturnsAsync(updatedUser);

        // When
        User? actualUser = await this.userService.UpdateAdministrationUserAsync(userId, inputUser);

        // Then
        Assert.NotNull(actualUser);
        Assert.Equal(updatedUser.Id, actualUser!.Id);
        Assert.Equal(updatedUser.UserName, actualUser.UserName);
        Assert.Equal(updatedUser.Email, actualUser.Email);

        this.httpClientBrokerMock.Verify(broker =>
            broker.UpdateAdministrationUserAsync(userId, inputUser, It.IsAny<CancellationToken>()),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldDeleteAdministrationUserAsync()
    {
        // Given
        string userId = GetRandomString();

        this.httpClientBrokerMock.Setup(broker =>
            broker.DeleteAdministrationUserAsync(userId, It.IsAny<CancellationToken>()))
            .ReturnsAsync(true);

        // When
        bool result = await this.userService.DeleteAdministrationUserAsync(userId);

        // Then
        Assert.True(result);

        this.httpClientBrokerMock.Verify(broker =>
            broker.DeleteAdministrationUserAsync(userId, It.IsAny<CancellationToken>()),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldGetAdministrationUserAsync()
    {
        // Given
        string userId = GetRandomString();
        User returnedUser = CreateUser(userId);

        this.httpClientBrokerMock.Setup(broker =>
            broker.GetAdministrationUserAsync(userId, It.IsAny<CancellationToken>()))
            .ReturnsAsync(returnedUser);

        // When
        User? actualUser = await this.userService.GetAdministrationUserAsync(userId);

        // Then
        Assert.NotNull(actualUser);
        Assert.Equal(returnedUser.Id, actualUser!.Id);
        Assert.Equal(returnedUser.UserName, actualUser.UserName);
        Assert.Equal(returnedUser.Email, actualUser.Email);

        this.httpClientBrokerMock.Verify(broker =>
            broker.GetAdministrationUserAsync(userId, It.IsAny<CancellationToken>()),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldGetAdministrationUsersAsync()
    {
        // Given
        ImmutableList<User> users = ImmutableList.Create(CreateUser(), CreateUser());

        this.httpClientBrokerMock.Setup(broker =>
            broker.GetAdministrationUsersAsync(It.IsAny<CancellationToken>()))
            .ReturnsAsync(users);

        // When
        ImmutableList<User> actualUsers = await this.userService.GetAdministrationUsersAsync();

        // Then
        Assert.Equivalent(users, actualUsers, strict: true);

        this.httpClientBrokerMock.Verify(broker =>
            broker.GetAdministrationUsersAsync(It.IsAny<CancellationToken>()),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }
}