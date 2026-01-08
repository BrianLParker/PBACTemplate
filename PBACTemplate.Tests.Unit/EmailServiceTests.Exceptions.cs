// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// EmailServiceTests.Exceptions.cs See LICENSE.txt in the root folder of the solution.

using PBACTemplate.Data;
using PBACTemplate.Services.Foundations.Email.Exceptions;

namespace PBACTemplate.Tests.Unit;

public partial class EmailServiceTests
{
    [Fact]
    public async Task ShouldThrowEmailServiceExceptionOnRetrieveEmailAsyncIfExceptionOccurs()
    {
        // Given
        ApplicationUser user = CreateUser();
        var someException = new Exception(GetRandomString());

        this.userManagerBrokerMock.Setup(broker =>
            broker.GetEmailAsync(user))
                .ThrowsAsync(someException);

        var expectedException = new EmailServiceException(
            "Email service error occurred, contact support.",
            new FailedEmailServiceException(
                "Failed email service error occurred, contact support.",
                someException));

        // When
        Func<Task> action = async () => await this.emailService.RetrieveEmailAsync(user);

        // Then
        EmailServiceException actualException =
            await Assert.ThrowsAsync<EmailServiceException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);
        Assert.IsType<FailedEmailServiceException>(actualException.InnerException);

        this.userManagerBrokerMock.Verify(broker =>
            broker.GetEmailAsync(user),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldThrowEmailServiceExceptionOnSetEmailAsyncIfExceptionOccurs()
    {
        // Given
        ApplicationUser user = CreateUser();
        string? email = GetRandomString();
        var someException = new Exception(GetRandomString());

        this.userManagerBrokerMock.Setup(broker =>
            broker.SetEmailAsync(user, email))
                .ThrowsAsync(someException);

        var expectedException = new EmailServiceException(
            "Email service error occurred, contact support.",
            new FailedEmailServiceException(
                "Failed email service error occurred, contact support.",
                someException));

        // When
        Func<Task> action = async () => await this.emailService.SetEmailAsync(user, email);

        // Then
        EmailServiceException actualException =
            await Assert.ThrowsAsync<EmailServiceException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);
        Assert.IsType<FailedEmailServiceException>(actualException.InnerException);

        this.userManagerBrokerMock.Verify(broker =>
            broker.SetEmailAsync(user, email),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public void ShouldThrowEmailServiceExceptionOnNormalizeEmailIfExceptionOccurs()
    {
        // Given
        string? email = GetRandomString();
        var someException = new Exception(GetRandomString());

        this.userManagerBrokerMock.Setup(broker =>
            broker.NormalizeEmail(email))
                .Throws(someException);

        var expectedException = new EmailServiceException(
            "Email service error occurred, contact support.",
            new FailedEmailServiceException(
                "Failed email service error occurred, contact support.",
                someException));

        // When
        Action action = () => this.emailService.NormalizeEmail(email);

        // Then
        EmailServiceException actualException =
            Assert.Throws<EmailServiceException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);
        Assert.IsType<FailedEmailServiceException>(actualException.InnerException);

        this.userManagerBrokerMock.Verify(broker =>
            broker.NormalizeEmail(email),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldThrowEmailServiceExceptionOnIsEmailConfirmedAsyncIfExceptionOccurs()
    {
        // Given
        ApplicationUser user = CreateUser();
        var someException = new Exception(GetRandomString());

        this.userManagerBrokerMock.Setup(broker =>
            broker.IsEmailConfirmedAsync(user))
                .ThrowsAsync(someException);

        var expectedException = new EmailServiceException(
            "Email service error occurred, contact support.",
            new FailedEmailServiceException(
                "Failed email service error occurred, contact support.",
                someException));

        // When
        Func<Task> action = async () => await this.emailService.IsEmailConfirmedAsync(user);

        // Then
        EmailServiceException actualException =
            await Assert.ThrowsAsync<EmailServiceException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);
        Assert.IsType<FailedEmailServiceException>(actualException.InnerException);

        this.userManagerBrokerMock.Verify(broker =>
            broker.IsEmailConfirmedAsync(user),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldThrowEmailServiceExceptionOnGenerateEmailConfirmationTokenAsyncIfExceptionOccurs()
    {
        // Given
        ApplicationUser user = CreateUser();
        var someException = new Exception(GetRandomString());

        this.userManagerBrokerMock.Setup(broker =>
            broker.GenerateEmailConfirmationTokenAsync(user))
                .ThrowsAsync(someException);

        var expectedException = new EmailServiceException(
            "Email service error occurred, contact support.",
            new FailedEmailServiceException(
                "Failed email service error occurred, contact support.",
                someException));

        // When
        Func<Task> action = async () => await this.emailService.GenerateEmailConfirmationTokenAsync(user);

        // Then
        EmailServiceException actualException =
            await Assert.ThrowsAsync<EmailServiceException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);
        Assert.IsType<FailedEmailServiceException>(actualException.InnerException);

        this.userManagerBrokerMock.Verify(broker =>
            broker.GenerateEmailConfirmationTokenAsync(user),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldThrowEmailServiceExceptionOnConfirmEmailAsyncIfExceptionOccurs()
    {
        // Given
        ApplicationUser user = CreateUser();
        string token = GetRandomString();
        var someException = new Exception(GetRandomString());

        this.userManagerBrokerMock.Setup(broker =>
            broker.ConfirmEmailAsync(user, token))
                .ThrowsAsync(someException);

        var expectedException = new EmailServiceException(
            "Email service error occurred, contact support.",
            new FailedEmailServiceException(
                "Failed email service error occurred, contact support.",
                someException));

        // When
        Func<Task> action = async () => await this.emailService.ConfirmEmailAsync(user, token);

        // Then
        EmailServiceException actualException =
            await Assert.ThrowsAsync<EmailServiceException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);
        Assert.IsType<FailedEmailServiceException>(actualException.InnerException);

        this.userManagerBrokerMock.Verify(broker =>
            broker.ConfirmEmailAsync(user, token),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldThrowEmailServiceExceptionOnGenerateChangeEmailTokenAsyncIfExceptionOccurs()
    {
        // Given
        ApplicationUser user = CreateUser();
        string newEmail = GetRandomString();
        var someException = new Exception(GetRandomString());

        this.userManagerBrokerMock.Setup(broker =>
            broker.GenerateChangeEmailTokenAsync(user, newEmail))
                .ThrowsAsync(someException);

        var expectedException = new EmailServiceException(
            "Email service error occurred, contact support.",
            new FailedEmailServiceException(
                "Failed email service error occurred, contact support.",
                someException));

        // When
        Func<Task> action = async () => await this.emailService.GenerateChangeEmailTokenAsync(user, newEmail);

        // Then
        EmailServiceException actualException =
            await Assert.ThrowsAsync<EmailServiceException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);
        Assert.IsType<FailedEmailServiceException>(actualException.InnerException);

        this.userManagerBrokerMock.Verify(broker =>
            broker.GenerateChangeEmailTokenAsync(user, newEmail),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldThrowEmailServiceExceptionOnChangeEmailAsyncIfExceptionOccurs()
    {
        // Given
        ApplicationUser user = CreateUser();
        string newEmail = GetRandomString();
        string token = GetRandomString();
        var someException = new Exception(GetRandomString());

        this.userManagerBrokerMock.Setup(broker =>
            broker.ChangeEmailAsync(user, newEmail, token))
                .ThrowsAsync(someException);

        var expectedException = new EmailServiceException(
            "Email service error occurred, contact support.",
            new FailedEmailServiceException(
                "Failed email service error occurred, contact support.",
                someException));

        // When
        Func<Task> action = async () => await this.emailService.ChangeEmailAsync(user, newEmail, token);

        // Then
        EmailServiceException actualException =
            await Assert.ThrowsAsync<EmailServiceException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);
        Assert.IsType<FailedEmailServiceException>(actualException.InnerException);

        this.userManagerBrokerMock.Verify(broker =>
            broker.ChangeEmailAsync(user, newEmail, token),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }
}