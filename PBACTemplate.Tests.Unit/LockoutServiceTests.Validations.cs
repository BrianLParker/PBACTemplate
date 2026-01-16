// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// LockoutServiceTests.Validations.cs See LICENSE.txt in the root folder of the solution.

using Microsoft.AspNetCore.Identity;
using PBACTemplate.Models.Users;
using PBACTemplate.Services.Foundations.Lockout.Exceptions;

namespace PBACTemplate.Tests.Unit;

public partial class LockoutServiceTests
{
    [Fact]
    public async Task ShouldThrowNullLockoutExceptionOnIsLockedOutAsyncIfUserIsNull()
    {
        // Given
        ApplicationUser? nullUser = null;

        var expectedException = new NullLockoutException("User cannot be null.");

        // When
        Func<Task> action = async () => await this.lockoutService.IsLockedOutAsync(nullUser!);

        // Then
        NullLockoutException actualException =
            await Assert.ThrowsAsync<NullLockoutException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);

        this.userManagerBrokerMock.Verify(broker =>
            broker.IsLockedOutAsync(It.IsAny<ApplicationUser>()),
            Times.Never);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldThrowNullLockoutExceptionOnSetLockoutEnabledAsyncIfUserIsNull()
    {
        // Given
        ApplicationUser? nullUser = null;
        bool enabled = GetRandomBoolean();

        var expectedException = new NullLockoutException("User cannot be null.");

        // When
        Func<Task> action = async () => await this.lockoutService.SetLockoutEnabledAsync(nullUser!, enabled);

        // Then
        NullLockoutException actualException =
            await Assert.ThrowsAsync<NullLockoutException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);

        this.userManagerBrokerMock.Verify(broker =>
            broker.SetLockoutEnabledAsync(It.IsAny<ApplicationUser>(), It.IsAny<bool>()),
            Times.Never);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldThrowFailedLockoutOperationExceptionOnSetLockoutEnabledAsyncIfIdentityResultFailed()
    {
        // Given
        ApplicationUser user = CreateUser();
        bool enabled = GetRandomBoolean();
        var identityError = new IdentityError { Description = GetRandomString() };
        IdentityResult failedResult = IdentityResult.Failed(identityError);

        this.userManagerBrokerMock.Setup(broker =>
            broker.SetLockoutEnabledAsync(user, enabled))
                .ReturnsAsync(failedResult);

        var expectedException = new FailedLockoutOperationException(
            $"Identity operation failed: {identityError.Description}");

        // When
        Func<Task> action = async () => await this.lockoutService.SetLockoutEnabledAsync(user, enabled);

        // Then
        FailedLockoutOperationException actualException =
            await Assert.ThrowsAsync<FailedLockoutOperationException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);

        this.userManagerBrokerMock.Verify(broker =>
            broker.SetLockoutEnabledAsync(user, enabled),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldThrowNullLockoutExceptionOnGetLockoutEnabledAsyncIfUserIsNull()
    {
        // Given
        ApplicationUser? nullUser = null;

        var expectedException = new NullLockoutException("User cannot be null.");

        // When
        Func<Task> action = async () => await this.lockoutService.GetLockoutEnabledAsync(nullUser!);

        // Then
        NullLockoutException actualException =
            await Assert.ThrowsAsync<NullLockoutException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);

        this.userManagerBrokerMock.Verify(broker =>
            broker.GetLockoutEnabledAsync(It.IsAny<ApplicationUser>()),
            Times.Never);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldThrowNullLockoutExceptionOnRetrieveLockoutEndDateAsyncIfUserIsNull()
    {
        // Given
        ApplicationUser? nullUser = null;

        var expectedException = new NullLockoutException("User cannot be null.");

        // When
        Func<Task> action = async () => await this.lockoutService.RetrieveLockoutEndDateAsync(nullUser!);

        // Then
        NullLockoutException actualException =
            await Assert.ThrowsAsync<NullLockoutException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);

        this.userManagerBrokerMock.Verify(broker =>
            broker.GetLockoutEndDateAsync(It.IsAny<ApplicationUser>()),
            Times.Never);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldThrowNullLockoutExceptionOnSetLockoutEndDateAsyncIfUserIsNull()
    {
        // Given
        ApplicationUser? nullUser = null;
        DateTimeOffset? lockoutEnd = GetRandomDateTimeOffset();

        var expectedException = new NullLockoutException("User cannot be null.");

        // When
        Func<Task> action = async () => await this.lockoutService.SetLockoutEndDateAsync(nullUser!, lockoutEnd);

        // Then
        NullLockoutException actualException =
            await Assert.ThrowsAsync<NullLockoutException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);

        this.userManagerBrokerMock.Verify(broker =>
            broker.SetLockoutEndDateAsync(It.IsAny<ApplicationUser>(), It.IsAny<DateTimeOffset?>()),
            Times.Never);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldThrowFailedLockoutOperationExceptionOnSetLockoutEndDateAsyncIfIdentityResultFailed()
    {
        // Given
        ApplicationUser user = CreateUser();
        DateTimeOffset? lockoutEnd = GetRandomDateTimeOffset();
        var identityError = new IdentityError { Description = GetRandomString() };
        IdentityResult failedResult = IdentityResult.Failed(identityError);

        this.userManagerBrokerMock.Setup(broker =>
            broker.SetLockoutEndDateAsync(user, lockoutEnd))
                .ReturnsAsync(failedResult);

        var expectedException = new FailedLockoutOperationException(
            $"Identity operation failed: {identityError.Description}");

        // When
        Func<Task> action = async () => await this.lockoutService.SetLockoutEndDateAsync(user, lockoutEnd);

        // Then
        FailedLockoutOperationException actualException =
            await Assert.ThrowsAsync<FailedLockoutOperationException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);

        this.userManagerBrokerMock.Verify(broker =>
            broker.SetLockoutEndDateAsync(user, lockoutEnd),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldThrowNullLockoutExceptionOnRecordAccessFailedAsyncIfUserIsNull()
    {
        // Given
        ApplicationUser? nullUser = null;

        var expectedException = new NullLockoutException("User cannot be null.");

        // When
        Func<Task> action = async () => await this.lockoutService.RecordAccessFailedAsync(nullUser!);

        // Then
        NullLockoutException actualException =
            await Assert.ThrowsAsync<NullLockoutException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);

        this.userManagerBrokerMock.Verify(broker =>
            broker.AccessFailedAsync(It.IsAny<ApplicationUser>()),
            Times.Never);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldThrowFailedLockoutOperationExceptionOnRecordAccessFailedAsyncIfIdentityResultFailed()
    {
        // Given
        ApplicationUser user = CreateUser();
        var identityError = new IdentityError { Description = GetRandomString() };
        IdentityResult failedResult = IdentityResult.Failed(identityError);

        this.userManagerBrokerMock.Setup(broker =>
            broker.AccessFailedAsync(user))
                .ReturnsAsync(failedResult);

        var expectedException = new FailedLockoutOperationException(
            $"Identity operation failed: {identityError.Description}");

        // When
        Func<Task> action = async () => await this.lockoutService.RecordAccessFailedAsync(user);

        // Then
        FailedLockoutOperationException actualException =
            await Assert.ThrowsAsync<FailedLockoutOperationException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);

        this.userManagerBrokerMock.Verify(broker =>
            broker.AccessFailedAsync(user),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldThrowNullLockoutExceptionOnResetAccessFailedCountAsyncIfUserIsNull()
    {
        // Given
        ApplicationUser? nullUser = null;

        var expectedException = new NullLockoutException("User cannot be null.");

        // When
        Func<Task> action = async () => await this.lockoutService.ResetAccessFailedCountAsync(nullUser!);

        // Then
        NullLockoutException actualException =
            await Assert.ThrowsAsync<NullLockoutException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);

        this.userManagerBrokerMock.Verify(broker =>
            broker.ResetAccessFailedCountAsync(It.IsAny<ApplicationUser>()),
            Times.Never);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldThrowFailedLockoutOperationExceptionOnResetAccessFailedCountAsyncIfIdentityResultFailed()
    {
        // Given
        ApplicationUser user = CreateUser();
        var identityError = new IdentityError { Description = GetRandomString() };
        IdentityResult failedResult = IdentityResult.Failed(identityError);

        this.userManagerBrokerMock.Setup(broker =>
            broker.ResetAccessFailedCountAsync(user))
                .ReturnsAsync(failedResult);

        var expectedException = new FailedLockoutOperationException(
            $"Identity operation failed: {identityError.Description}");

        // When
        Func<Task> action = async () => await this.lockoutService.ResetAccessFailedCountAsync(user);

        // Then
        FailedLockoutOperationException actualException =
            await Assert.ThrowsAsync<FailedLockoutOperationException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);

        this.userManagerBrokerMock.Verify(broker =>
            broker.ResetAccessFailedCountAsync(user),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldThrowNullLockoutExceptionOnRetrieveAccessFailedCountAsyncIfUserIsNull()
    {
        // Given
        ApplicationUser? nullUser = null;

        var expectedException = new NullLockoutException("User cannot be null.");

        // When
        Func<Task> action = async () => await this.lockoutService.RetrieveAccessFailedCountAsync(nullUser!);

        // Then
        NullLockoutException actualException =
            await Assert.ThrowsAsync<NullLockoutException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);

        this.userManagerBrokerMock.Verify(broker =>
            broker.GetAccessFailedCountAsync(It.IsAny<ApplicationUser>()),
            Times.Never);

        VerifyNoOtherBrokerCalls();
    }
}