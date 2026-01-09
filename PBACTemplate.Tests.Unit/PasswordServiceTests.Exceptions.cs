// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// PasswordServiceTests.Exceptions.cs See LICENSE.txt in the root folder of the solution.

using PBACTemplate.Models.User;
using PBACTemplate.Services.Foundations.Password.Exceptions;

namespace PBACTemplate.Tests.Unit;

public partial class PasswordServiceTests
{
    [Fact]
    public async Task ShouldThrowPasswordServiceExceptionOnCheckPasswordAsyncIfExceptionOccurs()
    {
        // Given
        ApplicationUser user = CreateUser();
        string password = GetRandomString();
        var someException = new Exception(GetRandomString());

        this.userManagerBrokerMock.Setup(broker =>
            broker.CheckPasswordAsync(user, password))
                .ThrowsAsync(someException);

        var expectedException = new PasswordServiceException(
            "Password service error occurred, contact support.",
            new FailedPasswordServiceException(
                "Failed password service error occurred, contact support.",
                someException));

        // When
        Func<Task> action = async () => await this.passwordService.CheckPasswordAsync(user, password);

        // Then
        PasswordServiceException actualException =
            await Assert.ThrowsAsync<PasswordServiceException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);
        Assert.IsType<FailedPasswordServiceException>(actualException.InnerException);

        this.userManagerBrokerMock.Verify(broker =>
            broker.CheckPasswordAsync(user, password),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldThrowPasswordServiceExceptionOnHasPasswordAsyncIfExceptionOccurs()
    {
        // Given
        ApplicationUser user = CreateUser();
        var someException = new Exception(GetRandomString());

        this.userManagerBrokerMock.Setup(broker =>
            broker.HasPasswordAsync(user))
                .ThrowsAsync(someException);

        var expectedException = new PasswordServiceException(
            "Password service error occurred, contact support.",
            new FailedPasswordServiceException(
                "Failed password service error occurred, contact support.",
                someException));

        // When
        Func<Task> action = async () => await this.passwordService.HasPasswordAsync(user);

        // Then
        PasswordServiceException actualException =
            await Assert.ThrowsAsync<PasswordServiceException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);
        Assert.IsType<FailedPasswordServiceException>(actualException.InnerException);

        this.userManagerBrokerMock.Verify(broker =>
            broker.HasPasswordAsync(user),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldThrowPasswordServiceExceptionOnAddPasswordAsyncIfExceptionOccurs()
    {
        // Given
        ApplicationUser user = CreateUser();
        string password = GetRandomString();
        var someException = new Exception(GetRandomString());

        this.userManagerBrokerMock.Setup(broker =>
            broker.AddPasswordAsync(user, password))
                .ThrowsAsync(someException);

        var expectedException = new PasswordServiceException(
            "Password service error occurred, contact support.",
            new FailedPasswordServiceException(
                "Failed password service error occurred, contact support.",
                someException));

        // When
        Func<Task> action = async () => await this.passwordService.AddPasswordAsync(user, password);

        // Then
        PasswordServiceException actualException =
            await Assert.ThrowsAsync<PasswordServiceException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);
        Assert.IsType<FailedPasswordServiceException>(actualException.InnerException);

        this.userManagerBrokerMock.Verify(broker =>
            broker.AddPasswordAsync(user, password),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldThrowPasswordServiceExceptionOnChangePasswordAsyncIfExceptionOccurs()
    {
        // Given
        ApplicationUser user = CreateUser();
        string currentPassword = GetRandomString();
        string newPassword = GetRandomString();
        var someException = new Exception(GetRandomString());

        this.userManagerBrokerMock.Setup(broker =>
            broker.ChangePasswordAsync(user, currentPassword, newPassword))
                .ThrowsAsync(someException);

        var expectedException = new PasswordServiceException(
            "Password service error occurred, contact support.",
            new FailedPasswordServiceException(
                "Failed password service error occurred, contact support.",
                someException));

        // When
        Func<Task> action = async () => await this.passwordService.ChangePasswordAsync(user, currentPassword, newPassword);

        // Then
        PasswordServiceException actualException =
            await Assert.ThrowsAsync<PasswordServiceException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);
        Assert.IsType<FailedPasswordServiceException>(actualException.InnerException);

        this.userManagerBrokerMock.Verify(broker =>
            broker.ChangePasswordAsync(user, currentPassword, newPassword),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldThrowPasswordServiceExceptionOnRemovePasswordAsyncIfExceptionOccurs()
    {
        // Given
        ApplicationUser user = CreateUser();
        var someException = new Exception(GetRandomString());

        this.userManagerBrokerMock.Setup(broker =>
            broker.RemovePasswordAsync(user))
                .ThrowsAsync(someException);

        var expectedException = new PasswordServiceException(
            "Password service error occurred, contact support.",
            new FailedPasswordServiceException(
                "Failed password service error occurred, contact support.",
                someException));

        // When
        Func<Task> action = async () => await this.passwordService.RemovePasswordAsync(user);

        // Then
        PasswordServiceException actualException =
            await Assert.ThrowsAsync<PasswordServiceException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);
        Assert.IsType<FailedPasswordServiceException>(actualException.InnerException);

        this.userManagerBrokerMock.Verify(broker =>
            broker.RemovePasswordAsync(user),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldThrowPasswordServiceExceptionOnGeneratePasswordResetTokenAsyncIfExceptionOccurs()
    {
        // Given
        ApplicationUser user = CreateUser();
        var someException = new Exception(GetRandomString());

        this.userManagerBrokerMock.Setup(broker =>
            broker.GeneratePasswordResetTokenAsync(user))
                .ThrowsAsync(someException);

        var expectedException = new PasswordServiceException(
            "Password service error occurred, contact support.",
            new FailedPasswordServiceException(
                "Failed password service error occurred, contact support.",
                someException));

        // When
        Func<Task> action = async () => await this.passwordService.GeneratePasswordResetTokenAsync(user);

        // Then
        PasswordServiceException actualException =
            await Assert.ThrowsAsync<PasswordServiceException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);
        Assert.IsType<FailedPasswordServiceException>(actualException.InnerException);

        this.userManagerBrokerMock.Verify(broker =>
            broker.GeneratePasswordResetTokenAsync(user),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldThrowPasswordServiceExceptionOnResetPasswordAsyncIfExceptionOccurs()
    {
        // Given
        ApplicationUser user = CreateUser();
        string token = GetRandomString();
        string newPassword = GetRandomString();
        var someException = new Exception(GetRandomString());

        this.userManagerBrokerMock.Setup(broker =>
            broker.ResetPasswordAsync(user, token, newPassword))
                .ThrowsAsync(someException);

        var expectedException = new PasswordServiceException(
            "Password service error occurred, contact support.",
            new FailedPasswordServiceException(
                "Failed password service error occurred, contact support.",
                someException));

        // When
        Func<Task> action = async () => await this.passwordService.ResetPasswordAsync(user, token, newPassword);

        // Then
        PasswordServiceException actualException =
            await Assert.ThrowsAsync<PasswordServiceException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);
        Assert.IsType<FailedPasswordServiceException>(actualException.InnerException);

        this.userManagerBrokerMock.Verify(broker =>
            broker.ResetPasswordAsync(user, token, newPassword),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }
}