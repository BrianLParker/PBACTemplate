// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// UserServiceTests.Validations.cs See LICENSE.txt in the root folder of the solution.

using PBACTemplate.Client.Models.Users;
using PBACTemplate.Client.Services.Foundations.Users.Exceptions;

namespace PBACTemplate.Client.Tests.Unit;

public partial class UserServiceTests
{
    [Fact]
    public async Task ShouldThrowNullUsersExceptionOnCreateIfUserIsNull()
    {
        // Given
        User? nullUser = null;
        var expectedException = new NullUsersException("User cannot be null.");

        // When
        Func<Task> action = async () =>
            await this.userService.CreateAdministrationUserAsync(nullUser!);

        // Then
        NullUsersException actualException = await Assert.ThrowsAsync<NullUsersException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);

        this.httpClientBrokerMock.Verify(broker =>
            broker.CreateAdministrationUserAsync(It.IsAny<User>(), It.IsAny<CancellationToken>()),
            Times.Never);

        VerifyNoOtherBrokerCalls();
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("   ")]
    public async Task ShouldThrowInvalidUsersExceptionOnCreateIfUserNameIsInvalid(string? invalid)
    {
        // Given
        User invalidUser = CreateUser();
        invalidUser.UserName = invalid!;

        var expectedException = new InvalidUsersException("User name cannot be null or whitespace.");

        // When
        Func<Task> action = async () =>
            await this.userService.CreateAdministrationUserAsync(invalidUser);

        // Then
        InvalidUsersException actualException = await Assert.ThrowsAsync<InvalidUsersException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);

        this.httpClientBrokerMock.Verify(broker =>
            broker.CreateAdministrationUserAsync(It.IsAny<User>(), It.IsAny<CancellationToken>()),
            Times.Never);

        VerifyNoOtherBrokerCalls();
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("   ")]
    public async Task ShouldThrowInvalidUsersExceptionOnCreateIfEmailIsInvalid(string? invalid)
    {
        // Given
        User invalidUser = CreateUser();
        invalidUser.Email = invalid!;

        var expectedException = new InvalidUsersException("Email cannot be null or whitespace.");

        // When
        Func<Task> action = async () =>
            await this.userService.CreateAdministrationUserAsync(invalidUser);

        // Then
        InvalidUsersException actualException = await Assert.ThrowsAsync<InvalidUsersException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);

        this.httpClientBrokerMock.Verify(broker =>
            broker.CreateAdministrationUserAsync(It.IsAny<User>(), It.IsAny<CancellationToken>()),
            Times.Never);

        VerifyNoOtherBrokerCalls();
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("   ")]
    public async Task ShouldThrowInvalidUsersExceptionOnUpdateIfUserIdInvalid(string? invalidUserId)
    {
        // Given
        User inputUser = CreateUser();

        var expectedException = new InvalidUsersException("User ID cannot be null or whitespace.");

        // When
        Func<Task> action = async () =>
            await this.userService.UpdateAdministrationUserAsync(invalidUserId!, inputUser);

        // Then
        InvalidUsersException actualException = await Assert.ThrowsAsync<InvalidUsersException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);

        this.httpClientBrokerMock.Verify(broker =>
            broker.UpdateAdministrationUserAsync(It.IsAny<string>(), It.IsAny<User>(), It.IsAny<CancellationToken>()),
            Times.Never);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldThrowNullUsersExceptionOnUpdateIfUserIsNull()
    {
        // Given
        string userId = GetRandomString();
        User? nullUser = null;

        var expectedException = new NullUsersException("User cannot be null.");

        // When
        Func<Task> action = async () =>
            await this.userService.UpdateAdministrationUserAsync(userId, nullUser!);

        // Then
        NullUsersException actualException = await Assert.ThrowsAsync<NullUsersException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);

        this.httpClientBrokerMock.Verify(broker =>
            broker.UpdateAdministrationUserAsync(It.IsAny<string>(), It.IsAny<User>(), It.IsAny<CancellationToken>()),
            Times.Never);

        VerifyNoOtherBrokerCalls();
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("   ")]
    public async Task ShouldThrowInvalidUsersExceptionOnDeleteIfUserIdInvalid(string? invalidUserId)
    {
        // Given
        var expectedException = new InvalidUsersException("User ID cannot be null or whitespace.");

        // When
        Func<Task> action = async () =>
            await this.userService.DeleteAdministrationUserAsync(invalidUserId!);

        // Then
        InvalidUsersException actualException = await Assert.ThrowsAsync<InvalidUsersException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);

        this.httpClientBrokerMock.Verify(broker =>
            broker.DeleteAdministrationUserAsync(It.IsAny<string>(), It.IsAny<CancellationToken>()),
            Times.Never);

        VerifyNoOtherBrokerCalls();
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("   ")]
    public async Task ShouldThrowInvalidUsersExceptionOnGetIfUserIdInvalid(string? invalidUserId)
    {
        // Given
        var expectedException = new InvalidUsersException("User ID cannot be null or whitespace.");

        // When
        Func<Task> action = async () =>
            await this.userService.GetAdministrationUserAsync(invalidUserId!);

        // Then
        InvalidUsersException actualException = await Assert.ThrowsAsync<InvalidUsersException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);

        this.httpClientBrokerMock.Verify(broker =>
            broker.GetAdministrationUserAsync(It.IsAny<string>(), It.IsAny<CancellationToken>()),
            Times.Never);

        VerifyNoOtherBrokerCalls();
    }
}