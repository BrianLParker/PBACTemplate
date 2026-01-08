// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// RecoveryCodesServiceTests.Exceptions.cs See LICENSE.txt in the root folder of the solution.

using PBACTemplate.Data;
using PBACTemplate.Services.Foundations.RecoveryCodes.Exceptions;

namespace PBACTemplate.Tests.Unit;

public partial class RecoveryCodesServiceTests
{
    [Fact]
    public async Task ShouldThrowRecoveryCodesServiceExceptionOnGenerateWhenExceptionOccursAsync()
    {
        // Given
        ApplicationUser inputUser = CreateUser();
        int inputCount = GetRandomInt();
        var serviceException = new Exception(GetRandomString());

        this.userManagerBrokerMock.Setup(broker =>
            broker.GenerateNewTwoFactorRecoveryCodesAsync(inputUser, inputCount))
                .ThrowsAsync(serviceException);

        // When
        Func<Task> action = async () =>
            await this.recoveryCodesService.GenerateNewTwoFactorRecoveryCodesAsync(
                inputUser,
                inputCount);

        // Then
        await Assert.ThrowsAsync<RecoveryCodesServiceException>(action);

        this.userManagerBrokerMock.Verify(broker =>
            broker.GenerateNewTwoFactorRecoveryCodesAsync(inputUser, inputCount),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldThrowRecoveryCodesServiceExceptionOnRedeemWhenExceptionOccursAsync()
    {
        // Given
        ApplicationUser inputUser = CreateUser();
        string inputCode = GetRandomString();
        var serviceException = new Exception(GetRandomString());

        this.userManagerBrokerMock.Setup(broker =>
            broker.RedeemTwoFactorRecoveryCodeAsync(inputUser, inputCode))
                .ThrowsAsync(serviceException);

        // When
        Func<Task> action = async () =>
            await this.recoveryCodesService.RedeemTwoFactorRecoveryCodeAsync(
                inputUser,
                inputCode);

        // Then
        await Assert.ThrowsAsync<RecoveryCodesServiceException>(action);

        this.userManagerBrokerMock.Verify(broker =>
            broker.RedeemTwoFactorRecoveryCodeAsync(inputUser, inputCode),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldThrowRecoveryCodesServiceExceptionOnCountWhenExceptionOccursAsync()
    {
        // Given
        ApplicationUser inputUser = CreateUser();
        var serviceException = new Exception(GetRandomString());

        this.userManagerBrokerMock.Setup(broker =>
            broker.CountRecoveryCodesAsync(inputUser))
                .ThrowsAsync(serviceException);

        // When
        Func<Task> action = async () =>
            await this.recoveryCodesService.CountRecoveryCodesAsync(inputUser);

        // Then
        await Assert.ThrowsAsync<RecoveryCodesServiceException>(action);

        this.userManagerBrokerMock.Verify(broker =>
            broker.CountRecoveryCodesAsync(inputUser),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }
}