// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// PasswordServiceTests.Validations.cs See LICENSE.txt in the root folder of the solution.

using Microsoft.AspNetCore.Identity;
using PBACTemplate.Models.Users;
using PBACTemplate.Services.Foundations.Password.Exceptions;

namespace PBACTemplate.Tests.Unit;

public partial class PasswordServiceTests
{
    [Fact]
    public async Task ShouldThrowNullPasswordExceptionOnCheckPasswordAsyncIfUserIsNull()
    {
        // Given
        ApplicationUser? nullUser = null;
        string password = GetRandomString();

        var expectedException = new NullPasswordException("User cannot be null.");

        // When
        Func<Task> action = async () => await this.passwordService.CheckPasswordAsync(nullUser!, password);

        // Then
        NullPasswordException actualException =
            await Assert.ThrowsAsync<NullPasswordException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);

        this.userManagerBrokerMock.Verify(broker =>
            broker.CheckPasswordAsync(It.IsAny<ApplicationUser>(), It.IsAny<string>()),
            Times.Never);

        VerifyNoOtherBrokerCalls();
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("   ")]
    public async Task ShouldThrowInvalidPasswordExceptionOnCheckPasswordAsyncIfPasswordIsInvalid(string? invalidPassword)
    {
        // Given
        ApplicationUser user = CreateUser();

        var expectedException = new InvalidPasswordException("password cannot be null or whitespace.");

        // When
        Func<Task> action = async () => await this.passwordService.CheckPasswordAsync(user, invalidPassword!);

        // Then
        InvalidPasswordException actualException =
            await Assert.ThrowsAsync<InvalidPasswordException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);

        this.userManagerBrokerMock.Verify(broker =>
            broker.CheckPasswordAsync(It.IsAny<ApplicationUser>(), It.IsAny<string>()),
            Times.Never);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldThrowNullPasswordExceptionOnHasPasswordAsyncIfUserIsNull()
    {
        // Given
        ApplicationUser? nullUser = null;

        var expectedException = new NullPasswordException("User cannot be null.");

        // When
        Func<Task> action = async () => await this.passwordService.HasPasswordAsync(nullUser!);

        // Then
        NullPasswordException actualException =
            await Assert.ThrowsAsync<NullPasswordException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);

        this.userManagerBrokerMock.Verify(broker =>
            broker.HasPasswordAsync(It.IsAny<ApplicationUser>()),
            Times.Never);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldThrowNullPasswordExceptionOnAddPasswordAsyncIfUserIsNull()
    {
        // Given
        ApplicationUser? nullUser = null;
        string password = GetRandomString();

        var expectedException = new NullPasswordException("User cannot be null.");

        // When
        Func<Task> action = async () => await this.passwordService.AddPasswordAsync(nullUser!, password);

        // Then
        NullPasswordException actualException =
            await Assert.ThrowsAsync<NullPasswordException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);

        this.userManagerBrokerMock.Verify(broker =>
            broker.AddPasswordAsync(It.IsAny<ApplicationUser>(), It.IsAny<string>()),
            Times.Never);

        VerifyNoOtherBrokerCalls();
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("   ")]
    public async Task ShouldThrowInvalidPasswordExceptionOnAddPasswordAsyncIfPasswordIsInvalid(string? invalidPassword)
    {
        // Given
        ApplicationUser user = CreateUser();

        var expectedException = new InvalidPasswordException("password cannot be null or whitespace.");

        // When
        Func<Task> action = async () => await this.passwordService.AddPasswordAsync(user, invalidPassword!);

        // Then
        InvalidPasswordException actualException =
            await Assert.ThrowsAsync<InvalidPasswordException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);

        this.userManagerBrokerMock.Verify(broker =>
            broker.AddPasswordAsync(It.IsAny<ApplicationUser>(), It.IsAny<string>()),
            Times.Never);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldThrowFailedPasswordOperationExceptionOnAddPasswordAsyncIfIdentityResultFailed()
    {
        // Given
        ApplicationUser user = CreateUser();
        string password = GetRandomString();
        var identityError = new IdentityError { Description = GetRandomString() };
        IdentityResult failedResult = IdentityResult.Failed(identityError);

        this.userManagerBrokerMock.Setup(broker =>
            broker.AddPasswordAsync(user, password))
                .ReturnsAsync(failedResult);

        var expectedException = new FailedPasswordOperationException(
            $"Identity operation failed: {identityError.Description}");

        // When
        Func<Task> action = async () => await this.passwordService.AddPasswordAsync(user, password);

        // Then
        FailedPasswordOperationException actualException =
            await Assert.ThrowsAsync<FailedPasswordOperationException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);

        this.userManagerBrokerMock.Verify(broker =>
            broker.AddPasswordAsync(user, password),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldThrowNullPasswordExceptionOnChangePasswordAsyncIfUserIsNull()
    {
        // Given
        ApplicationUser? nullUser = null;
        string currentPassword = GetRandomString();
        string newPassword = GetRandomString();

        var expectedException = new NullPasswordException("User cannot be null.");

        // When
        Func<Task> action = async () => await this.passwordService.ChangePasswordAsync(nullUser!, currentPassword, newPassword);

        // Then
        NullPasswordException actualException =
            await Assert.ThrowsAsync<NullPasswordException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);

        this.userManagerBrokerMock.Verify(broker =>
            broker.ChangePasswordAsync(It.IsAny<ApplicationUser>(), It.IsAny<string>(), It.IsAny<string>()),
            Times.Never);

        VerifyNoOtherBrokerCalls();
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("   ")]
    public async Task ShouldThrowInvalidPasswordExceptionOnChangePasswordAsyncIfCurrentPasswordIsInvalid(string? invalidPassword)
    {
        // Given
        ApplicationUser user = CreateUser();
        string newPassword = GetRandomString();

        var expectedException = new InvalidPasswordException("currentPassword cannot be null or whitespace.");

        // When
        Func<Task> action = async () => await this.passwordService.ChangePasswordAsync(user, invalidPassword!, newPassword);

        // Then
        InvalidPasswordException actualException =
            await Assert.ThrowsAsync<InvalidPasswordException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);

        this.userManagerBrokerMock.Verify(broker =>
            broker.ChangePasswordAsync(It.IsAny<ApplicationUser>(), It.IsAny<string>(), It.IsAny<string>()),
            Times.Never);

        VerifyNoOtherBrokerCalls();
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("   ")]
    public async Task ShouldThrowInvalidPasswordExceptionOnChangePasswordAsyncIfNewPasswordIsInvalid(string? invalidPassword)
    {
        // Given
        ApplicationUser user = CreateUser();
        string currentPassword = GetRandomString();

        var expectedException = new InvalidPasswordException("newPassword cannot be null or whitespace.");

        // When
        Func<Task> action = async () => await this.passwordService.ChangePasswordAsync(user, currentPassword, invalidPassword!);

        // Then
        InvalidPasswordException actualException =
            await Assert.ThrowsAsync<InvalidPasswordException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);

        this.userManagerBrokerMock.Verify(broker =>
            broker.ChangePasswordAsync(It.IsAny<ApplicationUser>(), It.IsAny<string>(), It.IsAny<string>()),
            Times.Never);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldThrowFailedPasswordOperationExceptionOnChangePasswordAsyncIfIdentityResultFailed()
    {
        // Given
        ApplicationUser user = CreateUser();
        string currentPassword = GetRandomString();
        string newPassword = GetRandomString();
        var identityError = new IdentityError { Description = GetRandomString() };
        IdentityResult failedResult = IdentityResult.Failed(identityError);

        this.userManagerBrokerMock.Setup(broker =>
            broker.ChangePasswordAsync(user, currentPassword, newPassword))
                .ReturnsAsync(failedResult);

        var expectedException = new FailedPasswordOperationException(
            $"Identity operation failed: {identityError.Description}");

        // When
        Func<Task> action = async () => await this.passwordService.ChangePasswordAsync(user, currentPassword, newPassword);

        // Then
        FailedPasswordOperationException actualException =
            await Assert.ThrowsAsync<FailedPasswordOperationException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);

        this.userManagerBrokerMock.Verify(broker =>
            broker.ChangePasswordAsync(user, currentPassword, newPassword),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldThrowNullPasswordExceptionOnRemovePasswordAsyncIfUserIsNull()
    {
        // Given
        ApplicationUser? nullUser = null;

        var expectedException = new NullPasswordException("User cannot be null.");

        // When
        Func<Task> action = async () => await this.passwordService.RemovePasswordAsync(nullUser!);

        // Then
        NullPasswordException actualException =
            await Assert.ThrowsAsync<NullPasswordException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);

        this.userManagerBrokerMock.Verify(broker =>
            broker.RemovePasswordAsync(It.IsAny<ApplicationUser>()),
            Times.Never);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldThrowFailedPasswordOperationExceptionOnRemovePasswordAsyncIfIdentityResultFailed()
    {
        // Given
        ApplicationUser user = CreateUser();
        var identityError = new IdentityError { Description = GetRandomString() };
        IdentityResult failedResult = IdentityResult.Failed(identityError);

        this.userManagerBrokerMock.Setup(broker =>
            broker.RemovePasswordAsync(user))
                .ReturnsAsync(failedResult);

        var expectedException = new FailedPasswordOperationException(
            $"Identity operation failed: {identityError.Description}");

        // When
        Func<Task> action = async () => await this.passwordService.RemovePasswordAsync(user);

        // Then
        FailedPasswordOperationException actualException =
            await Assert.ThrowsAsync<FailedPasswordOperationException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);

        this.userManagerBrokerMock.Verify(broker =>
            broker.RemovePasswordAsync(user),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldThrowNullPasswordExceptionOnGeneratePasswordResetTokenAsyncIfUserIsNull()
    {
        // Given
        ApplicationUser? nullUser = null;

        var expectedException = new NullPasswordException("User cannot be null.");

        // When
        Func<Task> action = async () => await this.passwordService.GeneratePasswordResetTokenAsync(nullUser!);

        // Then
        NullPasswordException actualException =
            await Assert.ThrowsAsync<NullPasswordException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);

        this.userManagerBrokerMock.Verify(broker =>
            broker.GeneratePasswordResetTokenAsync(It.IsAny<ApplicationUser>()),
            Times.Never);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldThrowNullPasswordExceptionOnResetPasswordAsyncIfUserIsNull()
    {
        // Given
        ApplicationUser? nullUser = null;
        string token = GetRandomString();
        string newPassword = GetRandomString();

        var expectedException = new NullPasswordException("User cannot be null.");

        // When
        Func<Task> action = async () => await this.passwordService.ResetPasswordAsync(nullUser!, token, newPassword);

        // Then
        NullPasswordException actualException =
            await Assert.ThrowsAsync<NullPasswordException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);

        this.userManagerBrokerMock.Verify(broker =>
            broker.ResetPasswordAsync(It.IsAny<ApplicationUser>(), It.IsAny<string>(), It.IsAny<string>()),
            Times.Never);

        VerifyNoOtherBrokerCalls();
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("   ")]
    public async Task ShouldThrowInvalidPasswordExceptionOnResetPasswordAsyncIfTokenIsInvalid(string? invalidToken)
    {
        // Given
        ApplicationUser user = CreateUser();
        string newPassword = GetRandomString();

        var expectedException = new InvalidPasswordException("Token cannot be null or whitespace.");

        // When
        Func<Task> action = async () => await this.passwordService.ResetPasswordAsync(user, invalidToken!, newPassword);

        // Then
        InvalidPasswordException actualException =
            await Assert.ThrowsAsync<InvalidPasswordException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);

        this.userManagerBrokerMock.Verify(broker =>
            broker.ResetPasswordAsync(It.IsAny<ApplicationUser>(), It.IsAny<string>(), It.IsAny<string>()),
            Times.Never);

        VerifyNoOtherBrokerCalls();
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("   ")]
    public async Task ShouldThrowInvalidPasswordExceptionOnResetPasswordAsyncIfNewPasswordIsInvalid(string? invalidPassword)
    {
        // Given
        ApplicationUser user = CreateUser();
        string token = GetRandomString();

        var expectedException = new InvalidPasswordException("newPassword cannot be null or whitespace.");

        // When
        Func<Task> action = async () => await this.passwordService.ResetPasswordAsync(user, token, invalidPassword!);

        // Then
        InvalidPasswordException actualException =
            await Assert.ThrowsAsync<InvalidPasswordException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);

        this.userManagerBrokerMock.Verify(broker =>
            broker.ResetPasswordAsync(It.IsAny<ApplicationUser>(), It.IsAny<string>(), It.IsAny<string>()),
            Times.Never);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldThrowFailedPasswordOperationExceptionOnResetPasswordAsyncIfIdentityResultFailed()
    {
        // Given
        ApplicationUser user = CreateUser();
        string token = GetRandomString();
        string newPassword = GetRandomString();
        var identityError = new IdentityError { Description = GetRandomString() };
        IdentityResult failedResult = IdentityResult.Failed(identityError);

        this.userManagerBrokerMock.Setup(broker =>
            broker.ResetPasswordAsync(user, token, newPassword))
                .ReturnsAsync(failedResult);

        var expectedException = new FailedPasswordOperationException(
            $"Identity operation failed: {identityError.Description}");

        // When
        Func<Task> action = async () => await this.passwordService.ResetPasswordAsync(user, token, newPassword);

        // Then
        FailedPasswordOperationException actualException =
            await Assert.ThrowsAsync<FailedPasswordOperationException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);

        this.userManagerBrokerMock.Verify(broker =>
            broker.ResetPasswordAsync(user, token, newPassword),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }
}