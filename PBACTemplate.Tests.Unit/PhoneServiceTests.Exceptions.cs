// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// PhoneServiceTests.Exceptions.cs See LICENSE.txt in the root folder of the solution.

using PBACTemplate.Models.User;
using PBACTemplate.Services.Foundations.Phone.Exceptions;

namespace PBACTemplate.Tests.Unit;

public partial class PhoneServiceTests
{
    [Fact]
    public async Task ShouldThrowPhoneServiceExceptionOnRetrievePhoneNumberAsyncIfExceptionOccurs()
    {
        // Given
        ApplicationUser user = CreateUser();
        var someException = new Exception(GetRandomString());

        this.userManagerBrokerMock.Setup(broker =>
            broker.GetPhoneNumberAsync(user))
                .ThrowsAsync(someException);

        var expectedException = new PhoneServiceException(
            "Phone service error occurred, contact support.",
            new FailedPhoneServiceException(
                "Failed phone service error occurred, contact support.",
                someException));

        // When
        Func<Task> action = async () => await this.phoneService.RetrievePhoneNumberAsync(user);

        // Then
        PhoneServiceException actualException =
            await Assert.ThrowsAsync<PhoneServiceException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);
        Assert.IsType<FailedPhoneServiceException>(actualException.InnerException);

        this.userManagerBrokerMock.Verify(broker =>
            broker.GetPhoneNumberAsync(user),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldThrowPhoneServiceExceptionOnSetPhoneNumberAsyncIfExceptionOccurs()
    {
        // Given
        ApplicationUser user = CreateUser();
        string? phone = GetRandomString();
        var someException = new Exception(GetRandomString());

        this.userManagerBrokerMock.Setup(broker =>
            broker.SetPhoneNumberAsync(user, phone))
                .ThrowsAsync(someException);

        var expectedException = new PhoneServiceException(
            "Phone service error occurred, contact support.",
            new FailedPhoneServiceException(
                "Failed phone service error occurred, contact support.",
                someException));

        // When
        Func<Task> action = async () => await this.phoneService.SetPhoneNumberAsync(user, phone);

        // Then
        PhoneServiceException actualException =
            await Assert.ThrowsAsync<PhoneServiceException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);
        Assert.IsType<FailedPhoneServiceException>(actualException.InnerException);

        this.userManagerBrokerMock.Verify(broker =>
            broker.SetPhoneNumberAsync(user, phone),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldThrowPhoneServiceExceptionOnIsPhoneNumberConfirmedAsyncIfExceptionOccurs()
    {
        // Given
        ApplicationUser user = CreateUser();
        var someException = new Exception(GetRandomString());

        this.userManagerBrokerMock.Setup(broker =>
            broker.IsPhoneNumberConfirmedAsync(user))
                .ThrowsAsync(someException);

        var expectedException = new PhoneServiceException(
            "Phone service error occurred, contact support.",
            new FailedPhoneServiceException(
                "Failed phone service error occurred, contact support.",
                someException));

        // When
        Func<Task> action = async () => await this.phoneService.IsPhoneNumberConfirmedAsync(user);

        // Then
        PhoneServiceException actualException =
            await Assert.ThrowsAsync<PhoneServiceException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);
        Assert.IsType<FailedPhoneServiceException>(actualException.InnerException);

        this.userManagerBrokerMock.Verify(broker =>
            broker.IsPhoneNumberConfirmedAsync(user),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldThrowPhoneServiceExceptionOnGenerateChangePhoneNumberTokenAsyncIfExceptionOccurs()
    {
        // Given
        ApplicationUser user = CreateUser();
        string phone = GetRandomString();
        var someException = new Exception(GetRandomString());

        this.userManagerBrokerMock.Setup(broker =>
            broker.GenerateChangePhoneNumberTokenAsync(user, phone))
                .ThrowsAsync(someException);

        var expectedException = new PhoneServiceException(
            "Phone service error occurred, contact support.",
            new FailedPhoneServiceException(
                "Failed phone service error occurred, contact support.",
                someException));

        // When
        Func<Task> action = async () => await this.phoneService.GenerateChangePhoneNumberTokenAsync(user, phone);

        // Then
        PhoneServiceException actualException =
            await Assert.ThrowsAsync<PhoneServiceException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);
        Assert.IsType<FailedPhoneServiceException>(actualException.InnerException);

        this.userManagerBrokerMock.Verify(broker =>
            broker.GenerateChangePhoneNumberTokenAsync(user, phone),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldThrowPhoneServiceExceptionOnVerifyChangePhoneNumberTokenAsyncIfExceptionOccurs()
    {
        // Given
        ApplicationUser user = CreateUser();
        string token = GetRandomString();
        string phone = GetRandomString();
        var someException = new Exception(GetRandomString());

        this.userManagerBrokerMock.Setup(broker =>
            broker.VerifyChangePhoneNumberTokenAsync(user, token, phone))
                .ThrowsAsync(someException);

        var expectedException = new PhoneServiceException(
            "Phone service error occurred, contact support.",
            new FailedPhoneServiceException(
                "Failed phone service error occurred, contact support.",
                someException));

        // When
        Func<Task> action = async () => await this.phoneService.VerifyChangePhoneNumberTokenAsync(user, token, phone);

        // Then
        PhoneServiceException actualException =
            await Assert.ThrowsAsync<PhoneServiceException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);
        Assert.IsType<FailedPhoneServiceException>(actualException.InnerException);

        this.userManagerBrokerMock.Verify(broker =>
            broker.VerifyChangePhoneNumberTokenAsync(user, token, phone),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldThrowPhoneServiceExceptionOnChangePhoneNumberAsyncIfExceptionOccurs()
    {
        // Given
        ApplicationUser user = CreateUser();
        string phone = GetRandomString();
        string token = GetRandomString();
        var someException = new Exception(GetRandomString());

        this.userManagerBrokerMock.Setup(broker =>
            broker.ChangePhoneNumberAsync(user, phone, token))
                .ThrowsAsync(someException);

        var expectedException = new PhoneServiceException(
            "Phone service error occurred, contact support.",
            new FailedPhoneServiceException(
                "Failed phone service error occurred, contact support.",
                someException));

        // When
        Func<Task> action = async () => await this.phoneService.ChangePhoneNumberAsync(user, phone, token);

        // Then
        PhoneServiceException actualException =
            await Assert.ThrowsAsync<PhoneServiceException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);
        Assert.IsType<FailedPhoneServiceException>(actualException.InnerException);

        this.userManagerBrokerMock.Verify(broker =>
            broker.ChangePhoneNumberAsync(user, phone, token),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }
}