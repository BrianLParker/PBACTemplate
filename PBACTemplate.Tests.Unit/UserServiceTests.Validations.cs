// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// UserServiceTests.Validations.cs See LICENSE.txt in the root folder of the solution.

using PBACTemplate.Client.Models.Users;
using PBACTemplate.Models.Users;
using PBACTemplate.Services.Foundations.Users.Exceptions;

namespace PBACTemplate.Tests.Unit;

public partial class UserServiceTests
{
    [Fact]
    public async Task ShouldThrowNullUsersExceptionOnCreateUserAsyncIfUserIsNull()
    {
        // Given
        User? nullUser = null;
        var expectedException = new NullUsersException("User cannot be null.");

        // When
        Func<Task> action = async () => await this.userService.CreateUserAsync(nullUser!);

        // Then
        NullUsersException actualException = await Assert.ThrowsAsync<NullUsersException>(action);
        Assert.Equal(expectedException.Message, actualException.Message);

        this.userManagerBrokerMock.Verify(broker =>
            broker.CreateAsync(It.IsAny<ApplicationUser>()), Times.Never);

        VerifyNoOtherBrokerCalls();
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("   ")]
    public async Task ShouldThrowInvalidUsersExceptionOnCreateUserAsyncIfUserNameIsInvalid(string? invalidUserName)
    {
        // Given
        User user = CreateClientUser();
        user.UserName = invalidUserName!;
        var expectedException = new InvalidUsersException("User name cannot be null or whitespace.");

        // When
        Func<Task> action = async () => await this.userService.CreateUserAsync(user);

        // Then
        InvalidUsersException actualException = await Assert.ThrowsAsync<InvalidUsersException>(action);
        Assert.Equal(expectedException.Message, actualException.Message);

        this.userManagerBrokerMock.Verify(broker =>
            broker.CreateAsync(It.IsAny<ApplicationUser>()), Times.Never);

        VerifyNoOtherBrokerCalls();
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("   ")]
    public async Task ShouldThrowInvalidUsersExceptionOnCreateUserAsyncIfEmailIsInvalid(string? invalidEmail)
    {
        // Given
        User user = CreateClientUser();
        user.Email = invalidEmail!;
        var expectedException = new InvalidUsersException("Email cannot be null or whitespace.");

        // When
        Func<Task> action = async () => await this.userService.CreateUserAsync(user);

        // Then
        InvalidUsersException actualException = await Assert.ThrowsAsync<InvalidUsersException>(action);
        Assert.Equal(expectedException.Message, actualException.Message);

        this.userManagerBrokerMock.Verify(broker =>
            broker.CreateAsync(It.IsAny<ApplicationUser>()), Times.Never);

        VerifyNoOtherBrokerCalls();
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("   ")]
    public async Task ShouldThrowInvalidUsersExceptionOnRemoveUserAsyncIfUserIdIsInvalid(string? invalidUserId)
    {
        // Given
        var expectedException = new InvalidUsersException("User ID cannot be null or whitespace.");

        // When
        Func<Task> action = async () => await this.userService.RemoveUserAsync(invalidUserId!);

        // Then
        InvalidUsersException actualException = await Assert.ThrowsAsync<InvalidUsersException>(action);
        Assert.Equal(expectedException.Message, actualException.Message);

        this.userManagerBrokerMock.Verify(broker =>
            broker.FindByIdAsync(It.IsAny<string>()), Times.Never);

        VerifyNoOtherBrokerCalls();
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("   ")]
    public async Task ShouldThrowInvalidUsersExceptionOnRetrieveUserByIdAsyncIfUserIdIsInvalid(string? invalidUserId)
    {
        // Given
        var expectedException = new InvalidUsersException("User ID cannot be null or whitespace.");

        // When
        Func<Task> action = async () => await this.userService.RetrieveUserByIdAsync(invalidUserId!);

        // Then
        InvalidUsersException actualException = await Assert.ThrowsAsync<InvalidUsersException>(action);
        Assert.Equal(expectedException.Message, actualException.Message);

        this.userManagerBrokerMock.Verify(broker =>
            broker.FindByIdAsync(It.IsAny<string>()), Times.Never);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldThrowNullUsersExceptionOnUpdateUserAsyncIfUserIsNull()
    {
        // Given
        string userId = GetRandomString();
        User? nullUser = null;
        var expectedException = new NullUsersException("User cannot be null.");

        // When
        Func<Task> action = async () => await this.userService.UpdateUserAsync(userId, nullUser!);

        // Then
        NullUsersException actualException = await Assert.ThrowsAsync<NullUsersException>(action);
        Assert.Equal(expectedException.Message, actualException.Message);

        this.userManagerBrokerMock.Verify(broker =>
            broker.UpdateAsync(It.IsAny<ApplicationUser>()), Times.Never);

        VerifyNoOtherBrokerCalls();
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("   ")]
    public async Task ShouldThrowInvalidUsersExceptionOnUpdateUserAsyncIfUserIdIsInvalid(string? invalidUserId)
    {
        // Given
        User user = CreateClientUser();
        var expectedException = new InvalidUsersException("User ID cannot be null or whitespace.");

        // When
        Func<Task> action = async () => await this.userService.UpdateUserAsync(invalidUserId!, user);

        // Then
        InvalidUsersException actualException = await Assert.ThrowsAsync<InvalidUsersException>(action);
        Assert.Equal(expectedException.Message, actualException.Message);

        this.userManagerBrokerMock.Verify(broker =>
            broker.UpdateAsync(It.IsAny<ApplicationUser>()), Times.Never);

        VerifyNoOtherBrokerCalls();
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("   ")]
    public async Task ShouldThrowInvalidUsersExceptionOnUpdateUserAsyncIfUserNameIsInvalid(string? invalidUserName)
    {
        // Given
        string userId = GetRandomString();
        User user = CreateClientUser();
        user.UserName = invalidUserName!;
        var expectedException = new InvalidUsersException("User name cannot be null or whitespace.");

        // When
        Func<Task> action = async () => await this.userService.UpdateUserAsync(userId, user);

        // Then
        InvalidUsersException actualException = await Assert.ThrowsAsync<InvalidUsersException>(action);
        Assert.Equal(expectedException.Message, actualException.Message);

        this.userManagerBrokerMock.Verify(broker =>
            broker.UpdateAsync(It.IsAny<ApplicationUser>()), Times.Never);

        VerifyNoOtherBrokerCalls();
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("   ")]
    public async Task ShouldThrowInvalidUsersExceptionOnUpdateUserAsyncIfEmailIsInvalid(string? invalidEmail)
    {
        // Given
        string userId = GetRandomString();
        User user = CreateClientUser();
        user.Email = invalidEmail!;
        var expectedException = new InvalidUsersException("Email cannot be null or whitespace.");

        // When
        Func<Task> action = async () => await this.userService.UpdateUserAsync(userId, user);

        // Then
        InvalidUsersException actualException = await Assert.ThrowsAsync<InvalidUsersException>(action);
        Assert.Equal(expectedException.Message, actualException.Message);

        this.userManagerBrokerMock.Verify(broker =>
            broker.UpdateAsync(It.IsAny<ApplicationUser>()), Times.Never);

        VerifyNoOtherBrokerCalls();
    }
}