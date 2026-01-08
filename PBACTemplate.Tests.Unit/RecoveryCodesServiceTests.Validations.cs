// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// RecoveryCodesServiceTests.Validations.cs See LICENSE.txt in the root folder of the solution.

using Microsoft.AspNetCore.Identity;
using PBACTemplate.Data;
using PBACTemplate.Services.Foundations.RecoveryCodes.Exceptions;

namespace PBACTemplate.Tests.Unit;

public partial class RecoveryCodesServiceTests
{
    [Fact]
    public async Task ShouldThrowNullRecoveryCodesExceptionOnGenerateWhenUserIsNullAsync()
    {
        // Given
        ApplicationUser? nullUser = null;

        // When
        Func<Task> action = async () =>
            await this.recoveryCodesService.GenerateNewTwoFactorRecoveryCodesAsync(
                nullUser!,
                GetRandomInt());

        // Then
        await Assert.ThrowsAsync<NullRecoveryCodesException>(action);

        VerifyNoOtherBrokerCalls();
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    public async Task ShouldThrowInvalidRecoveryCodesExceptionOnGenerateWhenCountIsNotPositiveAsync(int invalidCount)
    {
        // Given
        ApplicationUser inputUser = CreateUser();

        // When
        Func<Task> action = async () =>
            await this.recoveryCodesService.GenerateNewTwoFactorRecoveryCodesAsync(
                inputUser,
                invalidCount);

        // Then
        await Assert.ThrowsAsync<InvalidRecoveryCodesException>(action);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldThrowNullRecoveryCodesExceptionOnRedeemWhenUserIsNullAsync()
    {
        // Given
        ApplicationUser? nullUser = null;

        // When
        Func<Task> action = async () =>
            await this.recoveryCodesService.RedeemTwoFactorRecoveryCodeAsync(
                nullUser!,
                GetRandomString());

        // Then
        await Assert.ThrowsAsync<NullRecoveryCodesException>(action);

        VerifyNoOtherBrokerCalls();
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData(" ")]
    public async Task ShouldThrowInvalidRecoveryCodesExceptionOnRedeemWhenCodeIsInvalidAsync(string? invalidCode)
    {
        // Given
        ApplicationUser inputUser = CreateUser();

        // When
        Func<Task> action = async () =>
            await this.recoveryCodesService.RedeemTwoFactorRecoveryCodeAsync(
                inputUser,
                invalidCode!);

        // Then
        await Assert.ThrowsAsync<InvalidRecoveryCodesException>(action);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldThrowFailedRecoveryCodesOperationExceptionOnRedeemWhenIdentityFailsAsync()
    {
        // Given
        ApplicationUser inputUser = CreateUser();
        string inputCode = GetRandomString();
        IdentityResult identityFailure = IdentityResult.Failed(
            new IdentityError { Description = GetRandomString() });

        this.userManagerBrokerMock.Setup(broker =>
            broker.RedeemTwoFactorRecoveryCodeAsync(inputUser, inputCode))
                .ReturnsAsync(identityFailure);

        // When
        Func<Task> action = async () =>
            await this.recoveryCodesService.RedeemTwoFactorRecoveryCodeAsync(
                inputUser,
                inputCode);

        // Then
        await Assert.ThrowsAsync<FailedRecoveryCodesOperationException>(action);

        this.userManagerBrokerMock.Verify(broker =>
            broker.RedeemTwoFactorRecoveryCodeAsync(inputUser, inputCode),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldThrowNullRecoveryCodesExceptionOnCountWhenUserIsNullAsync()
    {
        // Given
        ApplicationUser? nullUser = null;

        // When
        Func<Task> action = async () =>
            await this.recoveryCodesService.CountRecoveryCodesAsync(nullUser!);

        // Then
        await Assert.ThrowsAsync<NullRecoveryCodesException>(action);

        VerifyNoOtherBrokerCalls();
    }
}