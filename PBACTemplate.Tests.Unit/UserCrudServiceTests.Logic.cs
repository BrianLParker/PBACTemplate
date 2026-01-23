// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// UserCrudServiceTests.Logic.cs See LICENSE.txt in the root folder of the solution.

using Microsoft.AspNetCore.Identity;
using PBACTemplate.Models.Users;

namespace PBACTemplate.Tests.Unit;

public partial class UserCrudServiceTests
{
    [Fact]
    public void ShouldReturnUsers()
    {
        // Given
        IQueryable<ApplicationUser> brokerUsers =
            new[]
            {
                new ApplicationUser { Id = Guid.NewGuid().ToString(), UserName = GetRandomString() },
                new ApplicationUser { Id = Guid.NewGuid().ToString(), UserName = GetRandomString() }
            }.AsQueryable();

        IQueryable<ApplicationUser> expectedUsers = brokerUsers;

        this.userManagerBrokerMock.Setup(broker =>
            broker.Users)
                .Returns(brokerUsers);

        // When
        IQueryable<ApplicationUser> actualUsers = this.userCrudService.Users;

        // Then
        Assert.Equivalent(expectedUsers.ToList(), actualUsers.ToList());

        this.userManagerBrokerMock.VerifyGet(broker =>
            broker.Users,
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }


    [Fact]
    public async Task ShouldCreateUserAsync()
    {
        // Given
        ApplicationUser inputUser = CreateUser();

        this.userManagerBrokerMock.Setup(broker =>
            broker.CreateAsync(inputUser))
                .ReturnsAsync(IdentityResult.Success);

        // When
        ApplicationUser actualUser =
            await this.userCrudService.CreateUserAsync(inputUser);

        // Then
        Assert.Equal(inputUser, actualUser);

        this.userManagerBrokerMock.Verify(broker =>
            broker.CreateAsync(inputUser),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldCreateUserWithPasswordAsync()
    {
        // Given
        ApplicationUser inputUser = CreateUser();
        string inputPassword = GetRandomString();

        this.userManagerBrokerMock.Setup(broker =>
            broker.CreateAsync(inputUser, inputPassword))
                .ReturnsAsync(IdentityResult.Success);

        // When
        ApplicationUser actualUser =
            await this.userCrudService.CreateUserWithPasswordAsync(inputUser, inputPassword);

        // Then
        Assert.Equal(inputUser, actualUser);

        this.userManagerBrokerMock.Verify(broker =>
            broker.CreateAsync(inputUser, inputPassword),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldUpdateUserAsync()
    {
        // Given
        ApplicationUser inputUser = CreateUser();

        this.userManagerBrokerMock.Setup(broker =>
            broker.UpdateAsync(inputUser))
                .ReturnsAsync(IdentityResult.Success);

        // When
        ApplicationUser actualUser =
            await this.userCrudService.UpdateUserAsync(inputUser);

        // Then
        Assert.Equal(inputUser, actualUser);

        this.userManagerBrokerMock.Verify(broker =>
            broker.UpdateAsync(inputUser),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldDeleteUserAsync()
    {
        // Given
        ApplicationUser inputUser = CreateUser();

        this.userManagerBrokerMock.Setup(broker =>
            broker.DeleteAsync(inputUser))
                .ReturnsAsync(IdentityResult.Success);

        // When
        ApplicationUser actualUser =
            await this.userCrudService.DeleteUserAsync(inputUser);

        // Then
        Assert.Equal(inputUser, actualUser);

        this.userManagerBrokerMock.Verify(broker =>
            broker.DeleteAsync(inputUser),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldRetrieveUserByIdAsync()
    {
        // Given
        string userId = GetRandomString();
        ApplicationUser? expectedUser = CreateUser();

        this.userManagerBrokerMock.Setup(broker =>
            broker.FindByIdAsync(userId))
                .ReturnsAsync(expectedUser);

        // When
        ApplicationUser? actualUser =
            await this.userCrudService.RetrieveUserByIdAsync(userId);

        // Then
        Assert.Equal(expectedUser, actualUser);

        this.userManagerBrokerMock.Verify(broker =>
            broker.FindByIdAsync(userId),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldRetrieveUserByNameAsync()
    {
        // Given
        string userName = GetRandomString();
        ApplicationUser? expectedUser = CreateUser();

        this.userManagerBrokerMock.Setup(broker =>
            broker.FindByNameAsync(userName))
                .ReturnsAsync(expectedUser);

        // When
        ApplicationUser? actualUser =
            await this.userCrudService.RetrieveUserByNameAsync(userName);

        // Then
        Assert.Equal(expectedUser, actualUser);

        this.userManagerBrokerMock.Verify(broker =>
            broker.FindByNameAsync(userName),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldRetrieveUserByEmailAsync()
    {
        // Given
        string email = "user@example.com";
        ApplicationUser? expectedUser = CreateUser();

        this.userManagerBrokerMock.Setup(broker =>
            broker.FindByEmailAsync(email))
                .ReturnsAsync(expectedUser);

        // When
        ApplicationUser? actualUser =
            await this.userCrudService.RetrieveUserByEmailAsync(email);

        // Then
        Assert.Equal(expectedUser, actualUser);

        this.userManagerBrokerMock.Verify(broker =>
            broker.FindByEmailAsync(email),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldRetrieveUserByLoginAsync()
    {
        // Given
        string loginProvider = GetRandomString();
        string providerKey = GetRandomString();
        ApplicationUser? expectedUser = CreateUser();

        this.userManagerBrokerMock.Setup(broker =>
            broker.FindByLoginAsync(loginProvider, providerKey))
                .ReturnsAsync(expectedUser);

        // When
        ApplicationUser? actualUser =
            await this.userCrudService.RetrieveUserByLoginAsync(loginProvider, providerKey);

        // Then
        Assert.Equal(expectedUser, actualUser);

        this.userManagerBrokerMock.Verify(broker =>
            broker.FindByLoginAsync(loginProvider, providerKey),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }
}