// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// UserServiceTests.Logic.cs See LICENSE.txt in the root folder of the solution.

using PBACTemplate.Client.Models.Users;
using System.Collections.Immutable;

namespace PBACTemplate.Client.Tests.Unit;

public partial class UserServiceTests
{
    [Fact]
    public async Task ShouldCreateUserAsync()
    {
        // Given
        User inputUser = CreateUser();
        User returnedUser = CreateUser(inputUser.Id);

        this.httpClientBrokerMock.Setup(broker =>
            broker.CreateUserAsync(inputUser, It.IsAny<CancellationToken>()))
            .ReturnsAsync(returnedUser);

        // When
        User? actualUser = await this.userService.CreateUserAsync(inputUser);

        // Then
        Assert.NotNull(actualUser);
        Assert.Equal(returnedUser.Id, actualUser!.Id);
        Assert.Equal(returnedUser.UserName, actualUser.UserName);
        Assert.Equal(returnedUser.Email, actualUser.Email);

        this.httpClientBrokerMock.Verify(broker =>
            broker.CreateUserAsync(inputUser, It.IsAny<CancellationToken>()),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldUpdateUserAsync()
    {
        // Given
        string userId = GetRandomString();
        User inputUser = CreateUser(userId);
        User updatedUser = CreateUser(userId);

        this.httpClientBrokerMock.Setup(broker =>
            broker.UpdateUserAsync(userId, inputUser, It.IsAny<CancellationToken>()))
            .ReturnsAsync(updatedUser);

        // When
        User? actualUser = await this.userService.UpdateUserAsync(userId, inputUser);

        // Then
        Assert.NotNull(actualUser);
        Assert.Equal(updatedUser.Id, actualUser!.Id);
        Assert.Equal(updatedUser.UserName, actualUser.UserName);
        Assert.Equal(updatedUser.Email, actualUser.Email);

        this.httpClientBrokerMock.Verify(broker =>
            broker.UpdateUserAsync(userId, inputUser, It.IsAny<CancellationToken>()),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldDeleteUserAsync()
    {
        // Given
        string userId = GetRandomString();

        this.httpClientBrokerMock.Setup(broker =>
            broker.DeleteUserAsync(userId, It.IsAny<CancellationToken>()))
            .ReturnsAsync(true);

        // When
        bool result = await this.userService.DeleteUserAsync(userId);

        // Then
        Assert.True(result);

        this.httpClientBrokerMock.Verify(broker =>
            broker.DeleteUserAsync(userId, It.IsAny<CancellationToken>()),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldGetUserAsync()
    {
        // Given
        string userId = GetRandomString();
        User returnedUser = CreateUser(userId);

        this.httpClientBrokerMock.Setup(broker =>
            broker.GetUserAsync(userId, It.IsAny<CancellationToken>()))
            .ReturnsAsync(returnedUser);

        // When
        User? actualUser = await this.userService.GetUserAsync(userId);

        // Then
        Assert.NotNull(actualUser);
        Assert.Equal(returnedUser.Id, actualUser!.Id);
        Assert.Equal(returnedUser.UserName, actualUser.UserName);
        Assert.Equal(returnedUser.Email, actualUser.Email);

        this.httpClientBrokerMock.Verify(broker =>
            broker.GetUserAsync(userId, It.IsAny<CancellationToken>()),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldGetUsersAsync()
    {
        // Given
        ImmutableList<User> users = ImmutableList.Create(CreateUser(), CreateUser());

        this.httpClientBrokerMock.Setup(broker =>
            broker.GetUsersAsync(It.IsAny<CancellationToken>()))
            .ReturnsAsync(users);

        // When
        ImmutableList<User> actualUsers = await this.userService.GetUsersAsync();

        // Then
        Assert.Equivalent(users, actualUsers, strict: true);

        this.httpClientBrokerMock.Verify(broker =>
            broker.GetUsersAsync(It.IsAny<CancellationToken>()),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }
}