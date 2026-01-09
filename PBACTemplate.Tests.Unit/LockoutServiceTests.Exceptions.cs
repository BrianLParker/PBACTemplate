// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// LockoutServiceTests.Exceptions.cs See LICENSE.txt in the root folder of the solution.

using PBACTemplate.Models.User;
using PBACTemplate.Services.Foundations.Lockout.Exceptions;

namespace PBACTemplate.Tests.Unit;

public partial class LockoutServiceTests
{
    [Fact]
    public async Task ShouldThrowLockoutServiceExceptionOnIsLockedOutAsyncIfExceptionOccurs()
    {
        // Given
        ApplicationUser user = CreateUser();
        var someException = new Exception(GetRandomString());

        this.userManagerBrokerMock.Setup(broker =>
            broker.IsLockedOutAsync(user))
                .ThrowsAsync(someException);

        var expectedException = new LockoutServiceException(
            "Lockout service error occurred, contact support.",
            new FailedLockoutServiceException(
                "Failed lockout service error occurred, contact support.",
                someException));

        // When
        Func<Task> action = async () => await this.lockoutService.IsLockedOutAsync(user);

        // Then
        LockoutServiceException actualException =
            await Assert.ThrowsAsync<LockoutServiceException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);
        Assert.IsType<FailedLockoutServiceException>(actualException.InnerException);

        this.userManagerBrokerMock.Verify(broker =>
            broker.IsLockedOutAsync(user),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldThrowLockoutServiceExceptionOnSetLockoutEnabledAsyncIfExceptionOccurs()
    {
        // Given
        ApplicationUser user = CreateUser();
        bool enabled = GetRandomBoolean();
        var someException = new Exception(GetRandomString());

        this.userManagerBrokerMock.Setup(broker =>
            broker.SetLockoutEnabledAsync(user, enabled))
                .ThrowsAsync(someException);

        var expectedException = new LockoutServiceException(
            "Lockout service error occurred, contact support.",
            new FailedLockoutServiceException(
                "Failed lockout service error occurred, contact support.",
                someException));

        // When
        Func<Task> action = async () => await this.lockoutService.SetLockoutEnabledAsync(user, enabled);

        // Then
        LockoutServiceException actualException =
            await Assert.ThrowsAsync<LockoutServiceException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);
        Assert.IsType<FailedLockoutServiceException>(actualException.InnerException);

        this.userManagerBrokerMock.Verify(broker =>
            broker.SetLockoutEnabledAsync(user, enabled),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldThrowLockoutServiceExceptionOnGetLockoutEnabledAsyncIfExceptionOccurs()
    {
        // Given
        ApplicationUser user = CreateUser();
        var someException = new Exception(GetRandomString());

        this.userManagerBrokerMock.Setup(broker =>
            broker.GetLockoutEnabledAsync(user))
                .ThrowsAsync(someException);

        var expectedException = new LockoutServiceException(
            "Lockout service error occurred, contact support.",
            new FailedLockoutServiceException(
                "Failed lockout service error occurred, contact support.",
                someException));

        // When
        Func<Task> action = async () => await this.lockoutService.GetLockoutEnabledAsync(user);

        // Then
        LockoutServiceException actualException =
            await Assert.ThrowsAsync<LockoutServiceException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);
        Assert.IsType<FailedLockoutServiceException>(actualException.InnerException);

        this.userManagerBrokerMock.Verify(broker =>
            broker.GetLockoutEnabledAsync(user),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldThrowLockoutServiceExceptionOnRetrieveLockoutEndDateAsyncIfExceptionOccurs()
    {
        // Given
        ApplicationUser user = CreateUser();
        var someException = new Exception(GetRandomString());

        this.userManagerBrokerMock.Setup(broker =>
            broker.GetLockoutEndDateAsync(user))
                .ThrowsAsync(someException);

        var expectedException = new LockoutServiceException(
            "Lockout service error occurred, contact support.",
            new FailedLockoutServiceException(
                "Failed lockout service error occurred, contact support.",
                someException));

        // When
        Func<Task> action = async () => await this.lockoutService.RetrieveLockoutEndDateAsync(user);

        // Then
        LockoutServiceException actualException =
            await Assert.ThrowsAsync<LockoutServiceException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);
        Assert.IsType<FailedLockoutServiceException>(actualException.InnerException);

        this.userManagerBrokerMock.Verify(broker =>
            broker.GetLockoutEndDateAsync(user),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldThrowLockoutServiceExceptionOnSetLockoutEndDateAsyncIfExceptionOccurs()
    {
        // Given
        ApplicationUser user = CreateUser();
        DateTimeOffset? lockoutEnd = GetRandomDateTimeOffset();
        var someException = new Exception(GetRandomString());

        this.userManagerBrokerMock.Setup(broker =>
            broker.SetLockoutEndDateAsync(user, lockoutEnd))
                .ThrowsAsync(someException);

        var expectedException = new LockoutServiceException(
            "Lockout service error occurred, contact support.",
            new FailedLockoutServiceException(
                "Failed lockout service error occurred, contact support.",
                someException));

        // When
        Func<Task> action = async () => await this.lockoutService.SetLockoutEndDateAsync(user, lockoutEnd);

        // Then
        LockoutServiceException actualException =
            await Assert.ThrowsAsync<LockoutServiceException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);
        Assert.IsType<FailedLockoutServiceException>(actualException.InnerException);

        this.userManagerBrokerMock.Verify(broker =>
            broker.SetLockoutEndDateAsync(user, lockoutEnd),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldThrowLockoutServiceExceptionOnRecordAccessFailedAsyncIfExceptionOccurs()
    {
        // Given
        ApplicationUser user = CreateUser();
        var someException = new Exception(GetRandomString());

        this.userManagerBrokerMock.Setup(broker =>
            broker.AccessFailedAsync(user))
                .ThrowsAsync(someException);

        var expectedException = new LockoutServiceException(
            "Lockout service error occurred, contact support.",
            new FailedLockoutServiceException(
                "Failed lockout service error occurred, contact support.",
                someException));

        // When
        Func<Task> action = async () => await this.lockoutService.RecordAccessFailedAsync(user);

        // Then
        LockoutServiceException actualException =
            await Assert.ThrowsAsync<LockoutServiceException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);
        Assert.IsType<FailedLockoutServiceException>(actualException.InnerException);

        this.userManagerBrokerMock.Verify(broker =>
            broker.AccessFailedAsync(user),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldThrowLockoutServiceExceptionOnResetAccessFailedCountAsyncIfExceptionOccurs()
    {
        // Given
        ApplicationUser user = CreateUser();
        var someException = new Exception(GetRandomString());

        this.userManagerBrokerMock.Setup(broker =>
            broker.ResetAccessFailedCountAsync(user))
                .ThrowsAsync(someException);

        var expectedException = new LockoutServiceException(
            "Lockout service error occurred, contact support.",
            new FailedLockoutServiceException(
                "Failed lockout service error occurred, contact support.",
                someException));

        // When
        Func<Task> action = async () => await this.lockoutService.ResetAccessFailedCountAsync(user);

        // Then
        LockoutServiceException actualException =
            await Assert.ThrowsAsync<LockoutServiceException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);
        Assert.IsType<FailedLockoutServiceException>(actualException.InnerException);

        this.userManagerBrokerMock.Verify(broker =>
            broker.ResetAccessFailedCountAsync(user),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldThrowLockoutServiceExceptionOnRetrieveAccessFailedCountAsyncIfExceptionOccurs()
    {
        // Given
        ApplicationUser user = CreateUser();
        var someException = new Exception(GetRandomString());

        this.userManagerBrokerMock.Setup(broker =>
            broker.GetAccessFailedCountAsync(user))
                .ThrowsAsync(someException);

        var expectedException = new LockoutServiceException(
            "Lockout service error occurred, contact support.",
            new FailedLockoutServiceException(
                "Failed lockout service error occurred, contact support.",
                someException));

        // When
        Func<Task> action = async () => await this.lockoutService.RetrieveAccessFailedCountAsync(user);

        // Then
        LockoutServiceException actualException =
            await Assert.ThrowsAsync<LockoutServiceException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);
        Assert.IsType<FailedLockoutServiceException>(actualException.InnerException);

        this.userManagerBrokerMock.Verify(broker =>
            broker.GetAccessFailedCountAsync(user),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }
}