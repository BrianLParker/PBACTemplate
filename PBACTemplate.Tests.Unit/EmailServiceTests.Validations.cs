// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// EmailServiceTests.Validations.cs See LICENSE.txt in the root folder of the solution.

using Microsoft.AspNetCore.Identity;
using PBACTemplate.Data;
using PBACTemplate.Services.Foundations.Email.Exceptions;

namespace PBACTemplate.Tests.Unit;

public partial class EmailServiceTests
{
    [Fact]
    public async Task ShouldThrowNullEmailExceptionOnRetrieveEmailAsyncIfUserIsNull()
    {
        // Given
        ApplicationUser? nullUser = null;

        var expectedException = new NullEmailException("User cannot be null.");

        // When
        Func<Task> action = async () => await this.emailService.RetrieveEmailAsync(nullUser!);

        // Then
        NullEmailException actualException =
            await Assert.ThrowsAsync<NullEmailException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);

        this.userManagerBrokerMock.Verify(broker =>
            broker.GetEmailAsync(It.IsAny<ApplicationUser>()),
            Times.Never);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldThrowNullEmailExceptionOnSetEmailAsyncIfUserIsNull()
    {
        // Given
        ApplicationUser? nullUser = null;
        string? email = GetRandomString();

        var expectedException = new NullEmailException("User cannot be null.");

        // When
        Func<Task> action = async () => await this.emailService.SetEmailAsync(nullUser!, email);

        // Then
        NullEmailException actualException =
            await Assert.ThrowsAsync<NullEmailException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);

        this.userManagerBrokerMock.Verify(broker =>
            broker.SetEmailAsync(It.IsAny<ApplicationUser>(), It.IsAny<string?>()),
            Times.Never);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public void ShouldThrowInvalidEmailExceptionOnNormalizeEmailIfEmailIsInvalid()
    {
        // Given
        string? invalidEmail = "   ";

        var expectedException = new InvalidEmailException("Email cannot be null or whitespace.");

        // When
        Action action = () => this.emailService.NormalizeEmail(invalidEmail);

        // Then
        InvalidEmailException actualException =
            Assert.Throws<InvalidEmailException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);

        this.userManagerBrokerMock.Verify(broker =>
            broker.NormalizeEmail(It.IsAny<string?>()),
            Times.Never);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldThrowNullEmailExceptionOnIsEmailConfirmedAsyncIfUserIsNull()
    {
        // Given
        ApplicationUser? nullUser = null;

        var expectedException = new NullEmailException("User cannot be null.");

        // When
        Func<Task> action = async () => await this.emailService.IsEmailConfirmedAsync(nullUser!);

        // Then
        NullEmailException actualException =
            await Assert.ThrowsAsync<NullEmailException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);

        this.userManagerBrokerMock.Verify(broker =>
            broker.IsEmailConfirmedAsync(It.IsAny<ApplicationUser>()),
            Times.Never);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldThrowNullEmailExceptionOnGenerateEmailConfirmationTokenAsyncIfUserIsNull()
    {
        // Given
        ApplicationUser? nullUser = null;

        var expectedException = new NullEmailException("User cannot be null.");

        // When
        Func<Task> action = async () => await this.emailService.GenerateEmailConfirmationTokenAsync(nullUser!);

        // Then
        NullEmailException actualException =
            await Assert.ThrowsAsync<NullEmailException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);

        this.userManagerBrokerMock.Verify(broker =>
            broker.GenerateEmailConfirmationTokenAsync(It.IsAny<ApplicationUser>()),
            Times.Never);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldThrowNullEmailExceptionOnConfirmEmailAsyncIfUserIsNull()
    {
        // Given
        ApplicationUser? nullUser = null;
        string token = GetRandomString();

        var expectedException = new NullEmailException("User cannot be null.");

        // When
        Func<Task> action = async () => await this.emailService.ConfirmEmailAsync(nullUser!, token);

        // Then
        NullEmailException actualException =
            await Assert.ThrowsAsync<NullEmailException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);

        this.userManagerBrokerMock.Verify(broker =>
            broker.ConfirmEmailAsync(It.IsAny<ApplicationUser>(), It.IsAny<string>()),
            Times.Never);

        VerifyNoOtherBrokerCalls();
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("   ")]
    public async Task ShouldThrowInvalidEmailExceptionOnConfirmEmailAsyncIfTokenIsInvalid(string? invalidToken)
    {
        // Given
        ApplicationUser user = CreateUser();

        var expectedException = new InvalidEmailException("Token cannot be null or whitespace.");

        // When
        Func<Task> action = async () => await this.emailService.ConfirmEmailAsync(user, invalidToken!);

        // Then
        InvalidEmailException actualException =
            await Assert.ThrowsAsync<InvalidEmailException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);

        this.userManagerBrokerMock.Verify(broker =>
            broker.ConfirmEmailAsync(It.IsAny<ApplicationUser>(), It.IsAny<string>()),
            Times.Never);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldThrowNullEmailExceptionOnGenerateChangeEmailTokenAsyncIfUserIsNull()
    {
        // Given
        ApplicationUser? nullUser = null;
        string newEmail = GetRandomString();

        var expectedException = new NullEmailException("User cannot be null.");

        // When
        Func<Task> action = async () => await this.emailService.GenerateChangeEmailTokenAsync(nullUser!, newEmail);

        // Then
        NullEmailException actualException =
            await Assert.ThrowsAsync<NullEmailException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);

        this.userManagerBrokerMock.Verify(broker =>
            broker.GenerateChangeEmailTokenAsync(It.IsAny<ApplicationUser>(), It.IsAny<string>()),
            Times.Never);

        VerifyNoOtherBrokerCalls();
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("   ")]
    public async Task ShouldThrowInvalidEmailExceptionOnGenerateChangeEmailTokenAsyncIfEmailIsInvalid(string? invalidEmail)
    {
        // Given
        ApplicationUser user = CreateUser();

        var expectedException = new InvalidEmailException("Email cannot be null or whitespace.");

        // When
        Func<Task> action = async () => await this.emailService.GenerateChangeEmailTokenAsync(user, invalidEmail!);

        // Then
        InvalidEmailException actualException =
            await Assert.ThrowsAsync<InvalidEmailException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);

        this.userManagerBrokerMock.Verify(broker =>
            broker.GenerateChangeEmailTokenAsync(It.IsAny<ApplicationUser>(), It.IsAny<string>()),
            Times.Never);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldThrowNullEmailExceptionOnChangeEmailAsyncIfUserIsNull()
    {
        // Given
        ApplicationUser? nullUser = null;
        string newEmail = GetRandomString();
        string token = GetRandomString();

        var expectedException = new NullEmailException("User cannot be null.");

        // When
        Func<Task> action = async () => await this.emailService.ChangeEmailAsync(nullUser!, newEmail, token);

        // Then
        NullEmailException actualException =
            await Assert.ThrowsAsync<NullEmailException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);

        this.userManagerBrokerMock.Verify(broker =>
            broker.ChangeEmailAsync(It.IsAny<ApplicationUser>(), It.IsAny<string>(), It.IsAny<string>()),
            Times.Never);

        VerifyNoOtherBrokerCalls();
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("   ")]
    public async Task ShouldThrowInvalidEmailExceptionOnChangeEmailAsyncIfEmailIsInvalid(string? invalidEmail)
    {
        // Given
        ApplicationUser user = CreateUser();
        string token = GetRandomString();

        var expectedException = new InvalidEmailException("Email cannot be null or whitespace.");

        // When
        Func<Task> action = async () => await this.emailService.ChangeEmailAsync(user, invalidEmail!, token);

        // Then
        InvalidEmailException actualException =
            await Assert.ThrowsAsync<InvalidEmailException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);

        this.userManagerBrokerMock.Verify(broker =>
            broker.ChangeEmailAsync(It.IsAny<ApplicationUser>(), It.IsAny<string>(), It.IsAny<string>()),
            Times.Never);

        VerifyNoOtherBrokerCalls();
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("   ")]
    public async Task ShouldThrowInvalidEmailExceptionOnChangeEmailAsyncIfTokenIsInvalid(string? invalidToken)
    {
        // Given
        ApplicationUser user = CreateUser();
        string newEmail = GetRandomString();

        var expectedException = new InvalidEmailException("Token cannot be null or whitespace.");

        // When
        Func<Task> action = async () => await this.emailService.ChangeEmailAsync(user, newEmail, invalidToken!);

        // Then
        InvalidEmailException actualException =
            await Assert.ThrowsAsync<InvalidEmailException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);

        this.userManagerBrokerMock.Verify(broker =>
            broker.ChangeEmailAsync(It.IsAny<ApplicationUser>(), It.IsAny<string>(), It.IsAny<string>()),
            Times.Never);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldThrowFailedEmailOperationExceptionOnSetEmailAsyncIfIdentityResultFailed()
    {
        // Given
        ApplicationUser user = CreateUser();
        string? email = GetRandomString();
        var identityError = new IdentityError { Description = GetRandomString() };
        IdentityResult failedResult = IdentityResult.Failed(identityError);

        this.userManagerBrokerMock.Setup(broker =>
            broker.SetEmailAsync(user, email))
                .ReturnsAsync(failedResult);

        var expectedException = new FailedEmailOperationException(
            $"Identity operation failed: {identityError.Description}");

        // When
        Func<Task> action = async () => await this.emailService.SetEmailAsync(user, email);

        // Then
        FailedEmailOperationException actualException =
            await Assert.ThrowsAsync<FailedEmailOperationException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);

        this.userManagerBrokerMock.Verify(broker =>
            broker.SetEmailAsync(user, email),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldThrowFailedEmailOperationExceptionOnConfirmEmailAsyncIfIdentityResultFailed()
    {
        // Given
        ApplicationUser user = CreateUser();
        string token = GetRandomString();
        var identityError = new IdentityError { Description = GetRandomString() };
        IdentityResult failedResult = IdentityResult.Failed(identityError);

        this.userManagerBrokerMock.Setup(broker =>
            broker.ConfirmEmailAsync(user, token))
                .ReturnsAsync(failedResult);

        var expectedException = new FailedEmailOperationException(
            $"Identity operation failed: {identityError.Description}");

        // When
        Func<Task> action = async () => await this.emailService.ConfirmEmailAsync(user, token);

        // Then
        FailedEmailOperationException actualException =
            await Assert.ThrowsAsync<FailedEmailOperationException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);

        this.userManagerBrokerMock.Verify(broker =>
            broker.ConfirmEmailAsync(user, token),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldThrowFailedEmailOperationExceptionOnChangeEmailAsyncIfIdentityResultFailed()
    {
        // Given
        ApplicationUser user = CreateUser();
        string newEmail = GetRandomString();
        string token = GetRandomString();
        var identityError = new IdentityError { Description = GetRandomString() };
        IdentityResult failedResult = IdentityResult.Failed(identityError);

        this.userManagerBrokerMock.Setup(broker =>
            broker.ChangeEmailAsync(user, newEmail, token))
                .ReturnsAsync(failedResult);

        var expectedException = new FailedEmailOperationException(
            $"Identity operation failed: {identityError.Description}");

        // When
        Func<Task> action = async () => await this.emailService.ChangeEmailAsync(user, newEmail, token);

        // Then
        FailedEmailOperationException actualException =
            await Assert.ThrowsAsync<FailedEmailOperationException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);

        this.userManagerBrokerMock.Verify(broker =>
            broker.ChangeEmailAsync(user, newEmail, token),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }
}