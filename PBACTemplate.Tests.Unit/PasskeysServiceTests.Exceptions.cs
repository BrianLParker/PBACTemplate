// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// PasskeysServiceTests.Exceptions.cs See LICENSE.txt in the root folder of the solution.

using Microsoft.AspNetCore.Identity;
using PBACTemplate.Models.Users;
using PBACTemplate.Services.Foundations.Passkeys.Exceptions;

namespace PBACTemplate.Tests.Unit;

public partial class PasskeysServiceTests
{
    [Fact]
    public async Task ShouldThrowPasskeysServiceExceptionOnAddOrUpdatePasskeyAsyncIfExceptionOccurs()
    {
        // Given
        ApplicationUser user = CreateUser();
        UserPasskeyInfo passkey = CreatePasskey();
        var someException = new Exception(GetRandomString());

        this.userManagerBrokerMock.Setup(broker =>
            broker.AddOrUpdatePasskeyAsync(user, passkey))
                .ThrowsAsync(someException);

        var expectedException = new PasskeysServiceException(
            "Passkeys service error occurred, contact support.",
            new FailedPasskeysServiceException(
                "Failed passkeys service error occurred, contact support.",
                someException));

        // When
        Func<Task> action = async () => await this.passkeysService.AddOrUpdatePasskeyAsync(user, passkey);

        // Then
        PasskeysServiceException actualException =
            await Assert.ThrowsAsync<PasskeysServiceException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);
        Assert.IsType<FailedPasskeysServiceException>(actualException.InnerException);

        this.userManagerBrokerMock.Verify(broker =>
            broker.AddOrUpdatePasskeyAsync(user, passkey),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldThrowPasskeysServiceExceptionOnRetrievePasskeysAsyncIfExceptionOccurs()
    {
        // Given
        ApplicationUser user = CreateUser();
        var someException = new Exception(GetRandomString());

        this.userManagerBrokerMock.Setup(broker =>
            broker.GetPasskeysAsync(user))
                .ThrowsAsync(someException);

        var expectedException = new PasskeysServiceException(
            "Passkeys service error occurred, contact support.",
            new FailedPasskeysServiceException(
                "Failed passkeys service error occurred, contact support.",
                someException));

        // When
        Func<Task> action = async () => await this.passkeysService.RetrievePasskeysAsync(user);

        // Then
        PasskeysServiceException actualException =
            await Assert.ThrowsAsync<PasskeysServiceException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);
        Assert.IsType<FailedPasskeysServiceException>(actualException.InnerException);

        this.userManagerBrokerMock.Verify(broker =>
            broker.GetPasskeysAsync(user),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldThrowPasskeysServiceExceptionOnRetrievePasskeyAsyncIfExceptionOccurs()
    {
        // Given
        ApplicationUser user = CreateUser();
        byte[] credentialId = CreateCredentialId();
        var someException = new Exception(GetRandomString());

        this.userManagerBrokerMock.Setup(broker =>
            broker.GetPasskeyAsync(user, credentialId))
                .ThrowsAsync(someException);

        var expectedException = new PasskeysServiceException(
            "Passkeys service error occurred, contact support.",
            new FailedPasskeysServiceException(
                "Failed passkeys service error occurred, contact support.",
                someException));

        // When
        Func<Task> action = async () => await this.passkeysService.RetrievePasskeyAsync(user, credentialId);

        // Then
        PasskeysServiceException actualException =
            await Assert.ThrowsAsync<PasskeysServiceException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);
        Assert.IsType<FailedPasskeysServiceException>(actualException.InnerException);

        this.userManagerBrokerMock.Verify(broker =>
            broker.GetPasskeyAsync(user, credentialId),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldThrowPasskeysServiceExceptionOnRetrieveUserByPasskeyIdAsyncIfExceptionOccurs()
    {
        // Given
        byte[] credentialId = CreateCredentialId();
        var someException = new Exception(GetRandomString());

        this.userManagerBrokerMock.Setup(broker =>
            broker.FindByPasskeyIdAsync(credentialId))
                .ThrowsAsync(someException);

        var expectedException = new PasskeysServiceException(
            "Passkeys service error occurred, contact support.",
            new FailedPasskeysServiceException(
                "Failed passkeys service error occurred, contact support.",
                someException));

        // When
        Func<Task> action = async () => await this.passkeysService.RetrieveUserByPasskeyIdAsync(credentialId);

        // Then
        PasskeysServiceException actualException =
            await Assert.ThrowsAsync<PasskeysServiceException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);
        Assert.IsType<FailedPasskeysServiceException>(actualException.InnerException);

        this.userManagerBrokerMock.Verify(broker =>
            broker.FindByPasskeyIdAsync(credentialId),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldThrowPasskeysServiceExceptionOnRemovePasskeyAsyncIfExceptionOccurs()
    {
        // Given
        ApplicationUser user = CreateUser();
        byte[] credentialId = CreateCredentialId();
        var someException = new Exception(GetRandomString());

        this.userManagerBrokerMock.Setup(broker =>
            broker.RemovePasskeyAsync(user, credentialId))
                .ThrowsAsync(someException);

        var expectedException = new PasskeysServiceException(
            "Passkeys service error occurred, contact support.",
            new FailedPasskeysServiceException(
                "Failed passkeys service error occurred, contact support.",
                someException));

        // When
        Func<Task> action = async () => await this.passkeysService.RemovePasskeyAsync(user, credentialId);

        // Then
        PasskeysServiceException actualException =
            await Assert.ThrowsAsync<PasskeysServiceException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);
        Assert.IsType<FailedPasskeysServiceException>(actualException.InnerException);

        this.userManagerBrokerMock.Verify(broker =>
            broker.RemovePasskeyAsync(user, credentialId),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }
}