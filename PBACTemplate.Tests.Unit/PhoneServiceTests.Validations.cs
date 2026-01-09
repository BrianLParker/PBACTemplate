// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// PhoneServiceTests.Validations.cs See LICENSE.txt in the root folder of the solution.

using Microsoft.AspNetCore.Identity;
using PBACTemplate.Models.User;
using PBACTemplate.Services.Foundations.Phone.Exceptions;

namespace PBACTemplate.Tests.Unit;

public partial class PhoneServiceTests
{
    [Fact]
    public async Task ShouldThrowNullPhoneExceptionOnRetrievePhoneNumberAsyncIfUserIsNull()
    {
        // Given
        ApplicationUser? nullUser = null;

        var expectedException = new NullPhoneException("User cannot be null.");

        // When
        Func<Task> action = async () => await this.phoneService.RetrievePhoneNumberAsync(nullUser!);

        // Then
        NullPhoneException actualException =
            await Assert.ThrowsAsync<NullPhoneException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);

        this.userManagerBrokerMock.Verify(broker =>
            broker.GetPhoneNumberAsync(It.IsAny<ApplicationUser>()),
            Times.Never);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldThrowNullPhoneExceptionOnSetPhoneNumberAsyncIfUserIsNull()
    {
        // Given
        ApplicationUser? nullUser = null;
        string? phone = GetRandomString();

        var expectedException = new NullPhoneException("User cannot be null.");

        // When
        Func<Task> action = async () => await this.phoneService.SetPhoneNumberAsync(nullUser!, phone);

        // Then
        NullPhoneException actualException =
            await Assert.ThrowsAsync<NullPhoneException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);

        this.userManagerBrokerMock.Verify(broker =>
            broker.SetPhoneNumberAsync(It.IsAny<ApplicationUser>(), It.IsAny<string?>()),
            Times.Never);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldThrowFailedPhoneOperationExceptionOnSetPhoneNumberAsyncIfIdentityResultFailed()
    {
        // Given
        ApplicationUser user = CreateUser();
        string? phone = GetRandomString();
        var identityError = new IdentityError { Description = GetRandomString() };
        IdentityResult failedResult = IdentityResult.Failed(identityError);

        this.userManagerBrokerMock.Setup(broker =>
            broker.SetPhoneNumberAsync(user, phone))
                .ReturnsAsync(failedResult);

        var expectedException = new FailedPhoneOperationException(
            $"Identity operation failed: {identityError.Description}");

        // When
        Func<Task> action = async () => await this.phoneService.SetPhoneNumberAsync(user, phone);

        // Then
        FailedPhoneOperationException actualException =
            await Assert.ThrowsAsync<FailedPhoneOperationException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);

        this.userManagerBrokerMock.Verify(broker =>
            broker.SetPhoneNumberAsync(user, phone),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldThrowNullPhoneExceptionOnIsPhoneNumberConfirmedAsyncIfUserIsNull()
    {
        // Given
        ApplicationUser? nullUser = null;

        var expectedException = new NullPhoneException("User cannot be null.");

        // When
        Func<Task> action = async () => await this.phoneService.IsPhoneNumberConfirmedAsync(nullUser!);

        // Then
        NullPhoneException actualException =
            await Assert.ThrowsAsync<NullPhoneException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);

        this.userManagerBrokerMock.Verify(broker =>
            broker.IsPhoneNumberConfirmedAsync(It.IsAny<ApplicationUser>()),
            Times.Never);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldThrowNullPhoneExceptionOnGenerateChangePhoneNumberTokenAsyncIfUserIsNull()
    {
        // Given
        ApplicationUser? nullUser = null;
        string phoneNumber = GetRandomString();

        var expectedException = new NullPhoneException("User cannot be null.");

        // When
        Func<Task> action = async () => await this.phoneService.GenerateChangePhoneNumberTokenAsync(nullUser!, phoneNumber);

        // Then
        NullPhoneException actualException =
            await Assert.ThrowsAsync<NullPhoneException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);

        this.userManagerBrokerMock.Verify(broker =>
            broker.GenerateChangePhoneNumberTokenAsync(It.IsAny<ApplicationUser>(), It.IsAny<string>()),
            Times.Never);

        VerifyNoOtherBrokerCalls();
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("   ")]
    public async Task ShouldThrowInvalidPhoneExceptionOnGenerateChangePhoneNumberTokenAsyncIfPhoneIsInvalid(string? invalidPhone)
    {
        // Given
        ApplicationUser user = CreateUser();

        var expectedException = new InvalidPhoneException("Phone number cannot be null or whitespace.");

        // When
        Func<Task> action = async () => await this.phoneService.GenerateChangePhoneNumberTokenAsync(user, invalidPhone!);

        // Then
        InvalidPhoneException actualException =
            await Assert.ThrowsAsync<InvalidPhoneException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);

        this.userManagerBrokerMock.Verify(broker =>
            broker.GenerateChangePhoneNumberTokenAsync(It.IsAny<ApplicationUser>(), It.IsAny<string>()),
            Times.Never);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldThrowNullPhoneExceptionOnVerifyChangePhoneNumberTokenAsyncIfUserIsNull()
    {
        // Given
        ApplicationUser? nullUser = null;
        string token = GetRandomString();
        string phone = GetRandomString();

        var expectedException = new NullPhoneException("User cannot be null.");

        // When
        Func<Task> action = async () => await this.phoneService.VerifyChangePhoneNumberTokenAsync(nullUser!, token, phone);

        // Then
        NullPhoneException actualException =
            await Assert.ThrowsAsync<NullPhoneException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);

        this.userManagerBrokerMock.Verify(broker =>
            broker.VerifyChangePhoneNumberTokenAsync(It.IsAny<ApplicationUser>(), It.IsAny<string>(), It.IsAny<string>()),
            Times.Never);

        VerifyNoOtherBrokerCalls();
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("   ")]
    public async Task ShouldThrowInvalidPhoneExceptionOnVerifyChangePhoneNumberTokenAsyncIfTokenIsInvalid(string? invalidToken)
    {
        // Given
        ApplicationUser user = CreateUser();
        string phone = GetRandomString();

        var expectedException = new InvalidPhoneException("Token cannot be null or whitespace.");

        // When
        Func<Task> action = async () => await this.phoneService.VerifyChangePhoneNumberTokenAsync(user, invalidToken!, phone);

        // Then
        InvalidPhoneException actualException =
            await Assert.ThrowsAsync<InvalidPhoneException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);

        this.userManagerBrokerMock.Verify(broker =>
            broker.VerifyChangePhoneNumberTokenAsync(It.IsAny<ApplicationUser>(), It.IsAny<string>(), It.IsAny<string>()),
            Times.Never);

        VerifyNoOtherBrokerCalls();
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("   ")]
    public async Task ShouldThrowInvalidPhoneExceptionOnVerifyChangePhoneNumberTokenAsyncIfPhoneIsInvalid(string? invalidPhone)
    {
        // Given
        ApplicationUser user = CreateUser();
        string token = GetRandomString();

        var expectedException = new InvalidPhoneException("Phone number cannot be null or whitespace.");

        // When
        Func<Task> action = async () => await this.phoneService.VerifyChangePhoneNumberTokenAsync(user, token, invalidPhone!);

        // Then
        InvalidPhoneException actualException =
            await Assert.ThrowsAsync<InvalidPhoneException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);

        this.userManagerBrokerMock.Verify(broker =>
            broker.VerifyChangePhoneNumberTokenAsync(It.IsAny<ApplicationUser>(), It.IsAny<string>(), It.IsAny<string>()),
            Times.Never);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldThrowNullPhoneExceptionOnChangePhoneNumberAsyncIfUserIsNull()
    {
        // Given
        ApplicationUser? nullUser = null;
        string phone = GetRandomString();
        string token = GetRandomString();

        var expectedException = new NullPhoneException("User cannot be null.");

        // When
        Func<Task> action = async () => await this.phoneService.ChangePhoneNumberAsync(nullUser!, phone, token);

        // Then
        NullPhoneException actualException =
            await Assert.ThrowsAsync<NullPhoneException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);

        this.userManagerBrokerMock.Verify(broker =>
            broker.ChangePhoneNumberAsync(It.IsAny<ApplicationUser>(), It.IsAny<string>(), It.IsAny<string>()),
            Times.Never);

        VerifyNoOtherBrokerCalls();
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("   ")]
    public async Task ShouldThrowInvalidPhoneExceptionOnChangePhoneNumberAsyncIfPhoneIsInvalid(string? invalidPhone)
    {
        // Given
        ApplicationUser user = CreateUser();
        string token = GetRandomString();

        var expectedException = new InvalidPhoneException("Phone number cannot be null or whitespace.");

        // When
        Func<Task> action = async () => await this.phoneService.ChangePhoneNumberAsync(user, invalidPhone!, token);

        // Then
        InvalidPhoneException actualException =
            await Assert.ThrowsAsync<InvalidPhoneException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);

        this.userManagerBrokerMock.Verify(broker =>
            broker.ChangePhoneNumberAsync(It.IsAny<ApplicationUser>(), It.IsAny<string>(), It.IsAny<string>()),
            Times.Never);

        VerifyNoOtherBrokerCalls();
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("   ")]
    public async Task ShouldThrowInvalidPhoneExceptionOnChangePhoneNumberAsyncIfTokenIsInvalid(string? invalidToken)
    {
        // Given
        ApplicationUser user = CreateUser();
        string phone = GetRandomString();

        var expectedException = new InvalidPhoneException("Token cannot be null or whitespace.");

        // When
        Func<Task> action = async () => await this.phoneService.ChangePhoneNumberAsync(user, phone, invalidToken!);

        // Then
        InvalidPhoneException actualException =
            await Assert.ThrowsAsync<InvalidPhoneException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);

        this.userManagerBrokerMock.Verify(broker =>
            broker.ChangePhoneNumberAsync(It.IsAny<ApplicationUser>(), It.IsAny<string>(), It.IsAny<string>()),
            Times.Never);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldThrowFailedPhoneOperationExceptionOnChangePhoneNumberAsyncIfIdentityResultFailed()
    {
        // Given
        ApplicationUser user = CreateUser();
        string phone = GetRandomString();
        string token = GetRandomString();
        var identityError = new IdentityError { Description = GetRandomString() };
        IdentityResult failedResult = IdentityResult.Failed(identityError);

        this.userManagerBrokerMock.Setup(broker =>
            broker.ChangePhoneNumberAsync(user, phone, token))
                .ReturnsAsync(failedResult);

        var expectedException = new FailedPhoneOperationException(
            $"Identity operation failed: {identityError.Description}");

        // When
        Func<Task> action = async () => await this.phoneService.ChangePhoneNumberAsync(user, phone, token);

        // Then
        FailedPhoneOperationException actualException =
            await Assert.ThrowsAsync<FailedPhoneOperationException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);

        this.userManagerBrokerMock.Verify(broker =>
            broker.ChangePhoneNumberAsync(user, phone, token),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }
}