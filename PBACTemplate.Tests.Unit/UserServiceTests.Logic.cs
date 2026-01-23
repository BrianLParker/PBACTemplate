// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// UserServiceTests.Logic.cs See LICENSE.txt in the root folder of the solution.

using Microsoft.AspNetCore.Identity;
using PBACTemplate.Client.Models.Users;
using PBACTemplate.Models.Users;
using PBACTemplate.Services.Foundations.Users.Exceptions;
using System.Collections.Immutable;

namespace PBACTemplate.Tests.Unit;

public partial class UserServiceTests
{
    [Fact]
    public async Task ShouldCreateUserAsync()
    {
        // Given
        User inputUser = CreateClientUser();
        ApplicationUser mappedUser = null!;

        this.userManagerBrokerMock.Setup(broker =>
            broker.CreateAsync(It.IsAny<ApplicationUser>()))
            .Callback<ApplicationUser>(u => mappedUser = u)
            .ReturnsAsync(IdentityResult.Success);

        // When
        User actualUser = await this.userService.CreateUserAsync(inputUser);

        // Then
        Assert.Equal(inputUser.Id, mappedUser.Id);
        Assert.Equal(inputUser.UserName, mappedUser.UserName);
        Assert.Equal(inputUser.Email, mappedUser.Email);
        Assert.Equal(inputUser.UserName, actualUser.UserName);
        Assert.Equal(inputUser.Email, actualUser.Email);
        Assert.Equal(inputUser.Id, actualUser.Id);

        this.userManagerBrokerMock.Verify(broker =>
            broker.CreateAsync(It.Is<ApplicationUser>(u =>
                u.Id == inputUser.Id &&
                u.UserName == inputUser.UserName &&
                u.Email == inputUser.Email &&
                u.FirstName == inputUser.FirstName &&
                u.LastName == inputUser.LastName &&
                u.PhoneNumber == inputUser.PhoneNumber &&
                u.EmailConfirmed == inputUser.EmailConfirmed &&
                u.PhoneNumberConfirmed == inputUser.PhoneNumberConfirmed &&
                u.AccessFailedCount == inputUser.AccessFailedCount &&
                u.ConcurrencyStamp == inputUser.ConcurrencyStamp)),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldThrowFailedUsersOperationExceptionOnCreateUserAsyncIfIdentityResultFails()
    {
        // Given
        User inputUser = CreateClientUser();
        IdentityResult failedResult = IdentityResult.Failed(new IdentityError { Description = "error" });
        var expectedException = new FailedUsersOperationException("User identity operation failed: error");

        this.userManagerBrokerMock.Setup(broker =>
            broker.CreateAsync(It.IsAny<ApplicationUser>()))
                .ReturnsAsync(failedResult);

        // When
        Func<Task> action = async () => await this.userService.CreateUserAsync(inputUser);

        // Then
        FailedUsersOperationException actualException =
            await Assert.ThrowsAsync<FailedUsersOperationException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);

        this.userManagerBrokerMock.Verify(broker =>
            broker.CreateAsync(It.IsAny<ApplicationUser>()), Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldRemoveUserAsync()
    {
        // Given
        string userId = GetRandomString();
        ApplicationUser existingUser = CreateApplicationUser(userId);

        this.userManagerBrokerMock.Setup(broker =>
            broker.FindByIdAsync(userId))
                .ReturnsAsync(existingUser);

        this.userManagerBrokerMock.Setup(broker =>
            broker.DeleteAsync(existingUser))
                .ReturnsAsync(IdentityResult.Success);

        // When
        bool result = await this.userService.RemoveUserAsync(userId);

        // Then
        Assert.True(result);

        this.userManagerBrokerMock.Verify(broker =>
            broker.FindByIdAsync(userId), Times.Once);

        this.userManagerBrokerMock.Verify(broker =>
            broker.DeleteAsync(existingUser), Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldReturnFalseOnRemoveUserAsyncWhenUserNotFound()
    {
        // Given
        string userId = GetRandomString();

        this.userManagerBrokerMock.Setup(broker =>
            broker.FindByIdAsync(userId))
                .ReturnsAsync((ApplicationUser?)null);

        // When
        bool result = await this.userService.RemoveUserAsync(userId);

        // Then
        Assert.False(result);

        this.userManagerBrokerMock.Verify(broker =>
            broker.FindByIdAsync(userId), Times.Once);

        this.userManagerBrokerMock.Verify(broker =>
            broker.DeleteAsync(It.IsAny<ApplicationUser>()), Times.Never);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldThrowFailedUsersOperationExceptionOnRemoveUserAsyncIfDeleteFails()
    {
        // Given
        string userId = GetRandomString();
        ApplicationUser existingUser = CreateApplicationUser(userId);
        IdentityResult failedResult = IdentityResult.Failed(new IdentityError { Description = "error" });
        var expectedException = new FailedUsersOperationException("User identity operation failed: error");

        this.userManagerBrokerMock.Setup(broker =>
            broker.FindByIdAsync(userId))
                .ReturnsAsync(existingUser);

        this.userManagerBrokerMock.Setup(broker =>
            broker.DeleteAsync(existingUser))
                .ReturnsAsync(failedResult);

        // When
        Func<Task> action = async () => await this.userService.RemoveUserAsync(userId);

        // Then
        FailedUsersOperationException actualException =
            await Assert.ThrowsAsync<FailedUsersOperationException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);

        this.userManagerBrokerMock.Verify(broker =>
            broker.FindByIdAsync(userId), Times.Once);

        this.userManagerBrokerMock.Verify(broker =>
            broker.DeleteAsync(existingUser), Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldRetrieveUserByIdAsync()
    {
        // Given
        string userId = GetRandomString();
        ApplicationUser appUser = CreateApplicationUser(userId);

        this.userManagerBrokerMock.Setup(broker =>
            broker.FindByIdAsync(userId))
                .ReturnsAsync(appUser);

        // When
        User? actualUser = await this.userService.RetrieveUserByIdAsync(userId);

        // Then
        Assert.NotNull(actualUser);
        Assert.Equal(appUser.Id, actualUser!.Id);
        Assert.Equal(appUser.UserName, actualUser.UserName);
        Assert.Equal(appUser.Email, actualUser.Email);

        this.userManagerBrokerMock.Verify(broker =>
            broker.FindByIdAsync(userId), Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldReturnNullOnRetrieveUserByIdAsyncWhenNotFound()
    {
        // Given
        string userId = GetRandomString();

        this.userManagerBrokerMock.Setup(broker =>
            broker.FindByIdAsync(userId))
                .ReturnsAsync((ApplicationUser?)null);

        // When
        User? actualUser = await this.userService.RetrieveUserByIdAsync(userId);

        // Then
        Assert.Null(actualUser);

        this.userManagerBrokerMock.Verify(broker =>
            broker.FindByIdAsync(userId), Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldRetrieveUsersAsync()
    {
        // Given
        ApplicationUser first = CreateApplicationUser();
        ApplicationUser second = CreateApplicationUser();

        this.userManagerBrokerMock.SetupGet(broker => broker.Users)
            .Returns(new[] { first, second }.AsQueryable());

        ImmutableList<User> expectedUsers = ImmutableList.Create(
            Map(first),
            Map(second));

        static User Map(ApplicationUser u) => new()
        {
            Id = u.Id ?? string.Empty,
            UserName = u.UserName ?? string.Empty,
            Email = u.Email ?? string.Empty,
            EmailConfirmed = u.EmailConfirmed,
            FirstName = u.FirstName,
            LastName = u.LastName,
            PhoneNumber = u.PhoneNumber ?? string.Empty,
            PhoneNumberConfirmed = u.PhoneNumberConfirmed,
            LockoutEnd = u.LockoutEnd,
            CreatedAt = default,
            UpdatedAt = default,
            LastSignInAt = null,
            AccessFailedCount = u.AccessFailedCount,
            ConcurrencyStamp = u.ConcurrencyStamp,
            AvatarUrl = null,
            Roles = []
        };

        // When
        ImmutableList<User> actualUsers = await this.userService.RetrieveUsersAsync();

        // Then
        Assert.Equivalent(expectedUsers, actualUsers, strict: true);

        this.userManagerBrokerMock.VerifyGet(broker => broker.Users, Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldUpdateUserAsync()
    {
        // Given
        string userId = GetRandomString();
        User inputUser = CreateClientUser();
        IdentityResult success = IdentityResult.Success;

        ApplicationUser? captured = null;

        this.userManagerBrokerMock.Setup(broker =>
            broker.UpdateAsync(It.IsAny<ApplicationUser>()))
            .Callback<ApplicationUser>(u => captured = u)
            .ReturnsAsync(success);

        // When
        User actualUser = await this.userService.UpdateUserAsync(userId, inputUser);

        // Then
        Assert.NotNull(captured);
        Assert.Equal(userId, captured!.Id);
        Assert.Equal(inputUser.UserName, captured.UserName);
        Assert.Equal(inputUser.Email, captured.Email);

        Assert.Equal(userId, actualUser.Id);
        Assert.Equal(inputUser.UserName, actualUser.UserName);
        Assert.Equal(inputUser.Email, actualUser.Email);

        this.userManagerBrokerMock.Verify(broker =>
            broker.UpdateAsync(It.Is<ApplicationUser>(u =>
                u.Id == userId &&
                u.UserName == inputUser.UserName &&
                u.Email == inputUser.Email &&
                u.FirstName == inputUser.FirstName &&
                u.LastName == inputUser.LastName &&
                u.PhoneNumber == inputUser.PhoneNumber &&
                u.EmailConfirmed == inputUser.EmailConfirmed &&
                u.PhoneNumberConfirmed == inputUser.PhoneNumberConfirmed &&
                u.AccessFailedCount == inputUser.AccessFailedCount &&
                u.ConcurrencyStamp == inputUser.ConcurrencyStamp)),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldThrowFailedUsersOperationExceptionOnUpdateUserAsyncIfIdentityResultFails()
    {
        // Given
        string userId = GetRandomString();
        User inputUser = CreateClientUser();
        IdentityResult failedResult = IdentityResult.Failed(new IdentityError { Description = "error" });
        var expectedException = new FailedUsersOperationException("User identity operation failed: error");

        this.userManagerBrokerMock.Setup(broker =>
            broker.UpdateAsync(It.IsAny<ApplicationUser>()))
                .ReturnsAsync(failedResult);

        // When
        Func<Task> action = async () => await this.userService.UpdateUserAsync(userId, inputUser);

        // Then
        FailedUsersOperationException actualException =
            await Assert.ThrowsAsync<FailedUsersOperationException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);

        this.userManagerBrokerMock.Verify(broker =>
            broker.UpdateAsync(It.IsAny<ApplicationUser>()), Times.Once);

        VerifyNoOtherBrokerCalls();
    }
}