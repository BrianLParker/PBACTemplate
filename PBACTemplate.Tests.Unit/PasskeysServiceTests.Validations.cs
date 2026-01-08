// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// PasskeysServiceTests.Validations.cs See LICENSE.txt in the root folder of the solution.

using Microsoft.AspNetCore.Identity;
using Moq;
using PBACTemplate.Data;
using PBACTemplate.Services.Foundations.Passkeys.Exceptions;

namespace PBACTemplate.Tests.Unit;

public partial class PasskeysServiceTests
{
    [Fact]
    public async Task ShouldThrowNullPasskeysExceptionOnAddOrUpdatePasskeyAsyncIfUserIsNull()
    {
        // Given
        ApplicationUser? nullUser = null;
        UserPasskeyInfo passkey = CreatePasskey();

        var expectedException = new NullPasskeysException("User cannot be null.");

        // When
        Func<Task> action = async () => await this.passkeysService.AddOrUpdatePasskeyAsync(nullUser!, passkey);

        // Then
        NullPasskeysException actualException =
            await Assert.ThrowsAsync<NullPasskeysException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);

        this.userManagerBrokerMock.Verify(broker =>
            broker.AddOrUpdatePasskeyAsync(It.IsAny<ApplicationUser>(), It.IsAny<UserPasskeyInfo>()),
            Times.Never);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldThrowNullPasskeysExceptionOnAddOrUpdatePasskeyAsyncIfPasskeyIsNull()
    {
        // Given
        ApplicationUser user = CreateUser();
        UserPasskeyInfo? nullPasskey = null;

        var expectedException = new NullPasskeysException("Passkey cannot be null.");

        // When
        Func<Task> action = async () => await this.passkeysService.AddOrUpdatePasskeyAsync(user, nullPasskey!);

        // Then
        NullPasskeysException actualException =
            await Assert.ThrowsAsync<NullPasskeysException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);

        this.userManagerBrokerMock.Verify(broker =>
            broker.AddOrUpdatePasskeyAsync(It.IsAny<ApplicationUser>(), It.IsAny<UserPasskeyInfo>()),
            Times.Never);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldThrowFailedPasskeysOperationExceptionOnAddOrUpdatePasskeyAsyncIfIdentityResultFailed()
    {
        // Given
        ApplicationUser user = CreateUser();
        UserPasskeyInfo passkey = CreatePasskey();
        var identityError = new IdentityError { Description = GetRandomString() };
        IdentityResult failedResult = IdentityResult.Failed(identityError);

        this.userManagerBrokerMock.Setup(broker =>
            broker.AddOrUpdatePasskeyAsync(user, passkey))
                .ReturnsAsync(failedResult);

        var expectedException = new FailedPasskeysOperationException(
            $"Identity operation failed: {identityError.Description}");

        // When
        Func<Task> action = async () => await this.passkeysService.AddOrUpdatePasskeyAsync(user, passkey);

        // Then
        FailedPasskeysOperationException actualException =
            await Assert.ThrowsAsync<FailedPasskeysOperationException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);

        this.userManagerBrokerMock.Verify(broker =>
            broker.AddOrUpdatePasskeyAsync(user, passkey),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldThrowNullPasskeysExceptionOnRetrievePasskeysAsyncIfUserIsNull()
    {
        // Given
        ApplicationUser? nullUser = null;

        var expectedException = new NullPasskeysException("User cannot be null.");

        // When
        Func<Task> action = async () => await this.passkeysService.RetrievePasskeysAsync(nullUser!);

        // Then
        NullPasskeysException actualException =
            await Assert.ThrowsAsync<NullPasskeysException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);

        this.userManagerBrokerMock.Verify(broker =>
            broker.GetPasskeysAsync(It.IsAny<ApplicationUser>()),
            Times.Never);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldThrowNullPasskeysExceptionOnRetrievePasskeyAsyncIfUserIsNull()
    {
        // Given
        ApplicationUser? nullUser = null;
        byte[] credentialId = CreateCredentialId();

        var expectedException = new NullPasskeysException("User cannot be null.");

        // When
        Func<Task> action = async () => await this.passkeysService.RetrievePasskeyAsync(nullUser!, credentialId);

        // Then
        NullPasskeysException actualException =
            await Assert.ThrowsAsync<NullPasskeysException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);

        this.userManagerBrokerMock.Verify(broker =>
            broker.GetPasskeyAsync(It.IsAny<ApplicationUser>(), It.IsAny<byte[]>()),
            Times.Never);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldThrowInvalidPasskeysExceptionOnRetrievePasskeyAsyncIfCredentialIdIsInvalid()
    {
        // Given
        ApplicationUser user = CreateUser();
        byte[] invalidCredentialId = Array.Empty<byte>();

        var expectedException = new InvalidPasskeysException("Credential ID cannot be null or empty.");

        // When
        Func<Task> action = async () => await this.passkeysService.RetrievePasskeyAsync(user, invalidCredentialId);

        // Then
        InvalidPasskeysException actualException =
            await Assert.ThrowsAsync<InvalidPasskeysException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);

        this.userManagerBrokerMock.Verify(broker =>
            broker.GetPasskeyAsync(It.IsAny<ApplicationUser>(), It.IsAny<byte[]>()),
            Times.Never);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldThrowInvalidPasskeysExceptionOnRetrieveUserByPasskeyIdAsyncIfCredentialIdIsInvalid()
    {
        // Given
        byte[] invalidCredentialId = Array.Empty<byte>();

        var expectedException = new InvalidPasskeysException("Credential ID cannot be null or empty.");

        // When
        Func<Task> action = async () => await this.passkeysService.RetrieveUserByPasskeyIdAsync(invalidCredentialId);

        // Then
        InvalidPasskeysException actualException =
            await Assert.ThrowsAsync<InvalidPasskeysException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);

        this.userManagerBrokerMock.Verify(broker =>
            broker.FindByPasskeyIdAsync(It.IsAny<byte[]>()),
            Times.Never);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldThrowNullPasskeysExceptionOnRemovePasskeyAsyncIfUserIsNull()
    {
        // Given
        ApplicationUser? nullUser = null;
        byte[] credentialId = CreateCredentialId();

        var expectedException = new NullPasskeysException("User cannot be null.");

        // When
        Func<Task> action = async () => await this.passkeysService.RemovePasskeyAsync(nullUser!, credentialId);

        // Then
        NullPasskeysException actualException =
            await Assert.ThrowsAsync<NullPasskeysException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);

        this.userManagerBrokerMock.Verify(broker =>
            broker.RemovePasskeyAsync(It.IsAny<ApplicationUser>(), It.IsAny<byte[]>()),
            Times.Never);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldThrowInvalidPasskeysExceptionOnRemovePasskeyAsyncIfCredentialIdIsInvalid()
    {
        // Given
        ApplicationUser user = CreateUser();
        byte[] invalidCredentialId = Array.Empty<byte>();

        var expectedException = new InvalidPasskeysException("Credential ID cannot be null or empty.");

        // When
        Func<Task> action = async () => await this.passkeysService.RemovePasskeyAsync(user, invalidCredentialId);

        // Then
        InvalidPasskeysException actualException =
            await Assert.ThrowsAsync<InvalidPasskeysException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);

        this.userManagerBrokerMock.Verify(broker =>
            broker.RemovePasskeyAsync(It.IsAny<ApplicationUser>(), It.IsAny<byte[]>()),
            Times.Never);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldThrowFailedPasskeysOperationExceptionOnRemovePasskeyAsyncIfIdentityResultFailed()
    {
        // Given
        ApplicationUser user = CreateUser();
        byte[] credentialId = CreateCredentialId();
        var identityError = new IdentityError { Description = GetRandomString() };
        IdentityResult failedResult = IdentityResult.Failed(identityError);

        this.userManagerBrokerMock.Setup(broker =>
            broker.RemovePasskeyAsync(user, credentialId))
                .ReturnsAsync(failedResult);

        var expectedException = new FailedPasskeysOperationException(
            $"Identity operation failed: {identityError.Description}");

        // When
        Func<Task> action = async () => await this.passkeysService.RemovePasskeyAsync(user, credentialId);

        // Then
        FailedPasskeysOperationException actualException =
            await Assert.ThrowsAsync<FailedPasskeysOperationException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);

        this.userManagerBrokerMock.Verify(broker =>
            broker.RemovePasskeyAsync(user, credentialId),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }
}