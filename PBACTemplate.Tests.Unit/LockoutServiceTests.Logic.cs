// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// LockoutServiceTests.Logic.cs See LICENSE.txt in the root folder of the solution.

using Microsoft.AspNetCore.Identity;
using Moq;
using PBACTemplate.Data;

namespace PBACTemplate.Tests.Unit;

public partial class LockoutServiceTests
{
    [Fact]
    public async Task ShouldCheckIsLockedOutAsync()
    {
        // Given
        ApplicationUser inputUser = CreateUser();
        bool expectedLockedOut = GetRandomBoolean();

        this.userManagerBrokerMock.Setup(broker =>
            broker.IsLockedOutAsync(inputUser))
                .ReturnsAsync(expectedLockedOut);

        // When
        bool actualLockedOut =
            await this.lockoutService.IsLockedOutAsync(inputUser);

        // Then
        Assert.Equal(expectedLockedOut, actualLockedOut);

        this.userManagerBrokerMock.Verify(broker =>
            broker.IsLockedOutAsync(inputUser),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldSetLockoutEnabledAsync()
    {
        // Given
        ApplicationUser inputUser = CreateUser();
        bool inputEnabled = GetRandomBoolean();

        this.userManagerBrokerMock.Setup(broker =>
            broker.SetLockoutEnabledAsync(inputUser, inputEnabled))
                .ReturnsAsync(IdentityResult.Success);

        // When
        ApplicationUser actualUser =
            await this.lockoutService.SetLockoutEnabledAsync(inputUser, inputEnabled);

        // Then
        Assert.Equal(inputUser, actualUser);

        this.userManagerBrokerMock.Verify(broker =>
            broker.SetLockoutEnabledAsync(inputUser, inputEnabled),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldGetLockoutEnabledAsync()
    {
        // Given
        ApplicationUser inputUser = CreateUser();
        bool expectedEnabled = GetRandomBoolean();

        this.userManagerBrokerMock.Setup(broker =>
            broker.GetLockoutEnabledAsync(inputUser))
                .ReturnsAsync(expectedEnabled);

        // When
        bool actualEnabled =
            await this.lockoutService.GetLockoutEnabledAsync(inputUser);

        // Then
        Assert.Equal(expectedEnabled, actualEnabled);

        this.userManagerBrokerMock.Verify(broker =>
            broker.GetLockoutEnabledAsync(inputUser),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldRetrieveLockoutEndDateAsync()
    {
        // Given
        ApplicationUser inputUser = CreateUser();
        DateTimeOffset? expectedEnd = GetRandomDateTimeOffset();

        this.userManagerBrokerMock.Setup(broker =>
            broker.GetLockoutEndDateAsync(inputUser))
                .ReturnsAsync(expectedEnd);

        // When
        DateTimeOffset? actualEnd =
            await this.lockoutService.RetrieveLockoutEndDateAsync(inputUser);

        // Then
        Assert.Equal(expectedEnd, actualEnd);

        this.userManagerBrokerMock.Verify(broker =>
            broker.GetLockoutEndDateAsync(inputUser),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldSetLockoutEndDateAsync()
    {
        // Given
        ApplicationUser inputUser = CreateUser();
        DateTimeOffset? inputEnd = GetRandomDateTimeOffset();

        this.userManagerBrokerMock.Setup(broker =>
            broker.SetLockoutEndDateAsync(inputUser, inputEnd))
                .ReturnsAsync(IdentityResult.Success);

        // When
        ApplicationUser actualUser =
            await this.lockoutService.SetLockoutEndDateAsync(inputUser, inputEnd);

        // Then
        Assert.Equal(inputUser, actualUser);

        this.userManagerBrokerMock.Verify(broker =>
            broker.SetLockoutEndDateAsync(inputUser, inputEnd),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldRecordAccessFailedAsync()
    {
        // Given
        ApplicationUser inputUser = CreateUser();

        this.userManagerBrokerMock.Setup(broker =>
            broker.AccessFailedAsync(inputUser))
                .ReturnsAsync(IdentityResult.Success);

        // When
        ApplicationUser actualUser =
            await this.lockoutService.RecordAccessFailedAsync(inputUser);

        // Then
        Assert.Equal(inputUser, actualUser);

        this.userManagerBrokerMock.Verify(broker =>
            broker.AccessFailedAsync(inputUser),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldResetAccessFailedCountAsync()
    {
        // Given
        ApplicationUser inputUser = CreateUser();

        this.userManagerBrokerMock.Setup(broker =>
            broker.ResetAccessFailedCountAsync(inputUser))
                .ReturnsAsync(IdentityResult.Success);

        // When
        ApplicationUser actualUser =
            await this.lockoutService.ResetAccessFailedCountAsync(inputUser);

        // Then
        Assert.Equal(inputUser, actualUser);

        this.userManagerBrokerMock.Verify(broker =>
            broker.ResetAccessFailedCountAsync(inputUser),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldRetrieveAccessFailedCountAsync()
    {
        // Given
        ApplicationUser inputUser = CreateUser();
        int expectedCount = Random.Shared.Next(0, 10);

        this.userManagerBrokerMock.Setup(broker =>
            broker.GetAccessFailedCountAsync(inputUser))
                .ReturnsAsync(expectedCount);

        // When
        int actualCount =
            await this.lockoutService.RetrieveAccessFailedCountAsync(inputUser);

        // Then
        Assert.Equal(expectedCount, actualCount);

        this.userManagerBrokerMock.Verify(broker =>
            broker.GetAccessFailedCountAsync(inputUser),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }
}