// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// UserCrudServiceTests.Validations.cs See LICENSE.txt in the root folder of the solution.

using Microsoft.AspNetCore.Identity;
using PBACTemplate.Data;
using PBACTemplate.Services.Foundations.UserCrud.Exceptions;

namespace PBACTemplate.Tests.Unit;

public partial class UserCrudServiceTests
{
    [Fact]
    public async Task ShouldThrowNullUserCrudExceptionOnCreateUserAsyncIfUserIsNull()
    {
        // Given
        ApplicationUser? nullUser = null;
        var expectedException = new NullUserCrudException("User cannot be null.");

        // When
        Func<Task> action = async () => await this.userCrudService.CreateUserAsync(nullUser!);

        // Then
        NullUserCrudException actualException =
            await Assert.ThrowsAsync<NullUserCrudException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);

        this.userManagerBrokerMock.Verify(broker =>
            broker.CreateAsync(It.IsAny<ApplicationUser>()),
            Times.Never);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldThrowNullUserCrudExceptionOnCreateUserWithPasswordAsyncIfUserIsNull()
    {
        // Given
        ApplicationUser? nullUser = null;
        string password = GetRandomString();
        var expectedException = new NullUserCrudException("User cannot be null.");

        // When
        Func<Task> action = async () => await this.userCrudService
            .CreateUserWithPasswordAsync(nullUser!, password);

        // Then
        NullUserCrudException actualException =
            await Assert.ThrowsAsync<NullUserCrudException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);

        this.userManagerBrokerMock.Verify(broker =>
            broker.CreateAsync(
                It.IsAny<ApplicationUser>(),
                It.IsAny<string>()),
            Times.Never);

        VerifyNoOtherBrokerCalls();
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("   ")]
    public async Task ShouldThrowInvalidUserCrudExceptionOnCreateUserWithPasswordAsyncIfPasswordIsInvalid(
        string? invalidPassword)
    {
        // Given
        ApplicationUser user = CreateUser();
        var expectedException = new InvalidUserCrudException(
            "Password cannot be null or whitespace.");

        // When
        Func<Task> action = async () => await this.userCrudService
            .CreateUserWithPasswordAsync(user, invalidPassword!);

        // Then
        InvalidUserCrudException actualException =
            await Assert.ThrowsAsync<InvalidUserCrudException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);

        this.userManagerBrokerMock.Verify(broker =>
            broker.CreateAsync(
                It.IsAny<ApplicationUser>(),
                It.IsAny<string>()),
            Times.Never);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldThrowNullUserCrudExceptionOnUpdateUserAsyncIfUserIsNull()
    {
        // Given
        ApplicationUser? nullUser = null;
        var expectedException = new NullUserCrudException("User cannot be null.");

        // When
        Func<Task> action = async () => await this.userCrudService.UpdateUserAsync(nullUser!);

        // Then
        NullUserCrudException actualException =
            await Assert.ThrowsAsync<NullUserCrudException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);

        this.userManagerBrokerMock.Verify(broker =>
            broker.UpdateAsync(It.IsAny<ApplicationUser>()),
            Times.Never);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldThrowNullUserCrudExceptionOnDeleteUserAsyncIfUserIsNull()
    {
        // Given
        ApplicationUser? nullUser = null;
        var expectedException = new NullUserCrudException("User cannot be null.");

        // When
        Func<Task> action = async () => await this.userCrudService.DeleteUserAsync(nullUser!);

        // Then
        NullUserCrudException actualException =
            await Assert.ThrowsAsync<NullUserCrudException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);

        this.userManagerBrokerMock.Verify(broker =>
            broker.DeleteAsync(It.IsAny<ApplicationUser>()),
            Times.Never);

        VerifyNoOtherBrokerCalls();
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("   ")]
    public async Task ShouldThrowInvalidUserCrudExceptionOnRetrieveUserByIdAsyncIfUserIdIsInvalid(
        string? invalidUserId)
    {
        // Given
        var expectedException = new InvalidUserCrudException(
            "User ID cannot be null or whitespace.");

        // When
        Func<Task> action = async () => await this.userCrudService
            .RetrieveUserByIdAsync(invalidUserId!);

        // Then
        InvalidUserCrudException actualException =
            await Assert.ThrowsAsync<InvalidUserCrudException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);

        this.userManagerBrokerMock.Verify(broker =>
            broker.FindByIdAsync(It.IsAny<string>()),
            Times.Never);

        VerifyNoOtherBrokerCalls();
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("   ")]
    public async Task ShouldThrowInvalidUserCrudExceptionOnRetrieveUserByNameAsyncIfUserNameIsInvalid(
        string? invalidUserName)
    {
        // Given
        var expectedException = new InvalidUserCrudException(
            "User name cannot be null or whitespace.");

        // When
        Func<Task> action = async () => await this.userCrudService
            .RetrieveUserByNameAsync(invalidUserName!);

        // Then
        InvalidUserCrudException actualException =
            await Assert.ThrowsAsync<InvalidUserCrudException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);

        this.userManagerBrokerMock.Verify(broker =>
            broker.FindByNameAsync(It.IsAny<string>()),
            Times.Never);

        VerifyNoOtherBrokerCalls();
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("   ")]
    public async Task ShouldThrowInvalidUserCrudExceptionOnRetrieveUserByEmailAsyncIfEmailIsInvalid(
        string? invalidEmail)
    {
        // Given
        var expectedException = new InvalidUserCrudException(
            "Email cannot be null or whitespace.");

        // When
        Func<Task> action = async () => await this.userCrudService
            .RetrieveUserByEmailAsync(invalidEmail!);

        // Then
        InvalidUserCrudException actualException =
            await Assert.ThrowsAsync<InvalidUserCrudException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);

        this.userManagerBrokerMock.Verify(broker =>
            broker.FindByEmailAsync(It.IsAny<string>()),
            Times.Never);

        VerifyNoOtherBrokerCalls();
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("   ")]
    public async Task ShouldThrowInvalidUserCrudExceptionOnRetrieveUserByLoginAsyncIfLoginProviderIsInvalid(
        string? invalidLoginProvider)
    {
        // Given
        string providerKey = GetRandomString();
        var expectedException = new InvalidUserCrudException(
            "Login provider cannot be null or whitespace.");

        // When
        Func<Task> action = async () => await this.userCrudService
            .RetrieveUserByLoginAsync(invalidLoginProvider!, providerKey);

        // Then
        InvalidUserCrudException actualException =
            await Assert.ThrowsAsync<InvalidUserCrudException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);

        this.userManagerBrokerMock.Verify(broker =>
            broker.FindByLoginAsync(
                It.IsAny<string>(),
                It.IsAny<string>()),
            Times.Never);

        VerifyNoOtherBrokerCalls();
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("   ")]
    public async Task ShouldThrowInvalidUserCrudExceptionOnRetrieveUserByLoginAsyncIfProviderKeyIsInvalid(
        string? invalidProviderKey)
    {
        // Given
        string loginProvider = GetRandomString();
        var expectedException = new InvalidUserCrudException(
            "Provider key cannot be null or whitespace.");

        // When
        Func<Task> action = async () => await this.userCrudService
            .RetrieveUserByLoginAsync(loginProvider, invalidProviderKey!);

        // Then
        InvalidUserCrudException actualException =
            await Assert.ThrowsAsync<InvalidUserCrudException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);

        this.userManagerBrokerMock.Verify(broker =>
            broker.FindByLoginAsync(
                It.IsAny<string>(),
                It.IsAny<string>()),
            Times.Never);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldThrowFailedUserCrudOperationExceptionOnCreateUserAsyncIfIdentityResultFailed()
    {
        // Given
        ApplicationUser user = CreateUser();
        var identityError = new IdentityError { Description = GetRandomString() };
        IdentityResult failedResult = IdentityResult.Failed(identityError);

        this.userManagerBrokerMock.Setup(broker =>
            broker.CreateAsync(user))
                .ReturnsAsync(failedResult);

        var expectedException = new FailedUserCrudOperationException(
            $"Identity operation failed: {identityError.Description}");

        // When
        Func<Task> action = async () => await this.userCrudService.CreateUserAsync(user);

        // Then
        FailedUserCrudOperationException actualException =
            await Assert.ThrowsAsync<FailedUserCrudOperationException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);

        this.userManagerBrokerMock.Verify(broker =>
            broker.CreateAsync(user),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldThrowFailedUserCrudOperationExceptionOnCreateUserWithPasswordAsyncIfIdentityResultFailed()
    {
        // Given
        ApplicationUser user = CreateUser();
        string password = GetRandomString();
        var identityError = new IdentityError { Description = GetRandomString() };
        IdentityResult failedResult = IdentityResult.Failed(identityError);

        this.userManagerBrokerMock.Setup(broker =>
            broker.CreateAsync(user, password))
                .ReturnsAsync(failedResult);

        var expectedException = new FailedUserCrudOperationException(
            $"Identity operation failed: {identityError.Description}");

        // When
        Func<Task> action = async () => await this.userCrudService
            .CreateUserWithPasswordAsync(user, password);

        // Then
        FailedUserCrudOperationException actualException =
            await Assert.ThrowsAsync<FailedUserCrudOperationException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);

        this.userManagerBrokerMock.Verify(broker =>
            broker.CreateAsync(user, password),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldThrowFailedUserCrudOperationExceptionOnUpdateUserAsyncIfIdentityResultFailed()
    {
        // Given
        ApplicationUser user = CreateUser();
        var identityError = new IdentityError { Description = GetRandomString() };
        IdentityResult failedResult = IdentityResult.Failed(identityError);

        this.userManagerBrokerMock.Setup(broker =>
            broker.UpdateAsync(user))
                .ReturnsAsync(failedResult);

        var expectedException = new FailedUserCrudOperationException(
            $"Identity operation failed: {identityError.Description}");

        // When
        Func<Task> action = async () => await this.userCrudService.UpdateUserAsync(user);

        // Then
        FailedUserCrudOperationException actualException =
            await Assert.ThrowsAsync<FailedUserCrudOperationException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);

        this.userManagerBrokerMock.Verify(broker =>
            broker.UpdateAsync(user),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldThrowFailedUserCrudOperationExceptionOnDeleteUserAsyncIfIdentityResultFailed()
    {
        // Given
        ApplicationUser user = CreateUser();
        var identityError = new IdentityError { Description = GetRandomString() };
        IdentityResult failedResult = IdentityResult.Failed(identityError);

        this.userManagerBrokerMock.Setup(broker =>
            broker.DeleteAsync(user))
                .ReturnsAsync(failedResult);

        var expectedException = new FailedUserCrudOperationException(
            $"Identity operation failed: {identityError.Description}");

        // When
        Func<Task> action = async () => await this.userCrudService.DeleteUserAsync(user);

        // Then
        FailedUserCrudOperationException actualException =
            await Assert.ThrowsAsync<FailedUserCrudOperationException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);

        this.userManagerBrokerMock.Verify(broker =>
            broker.DeleteAsync(user),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }
}