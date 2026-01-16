// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// RecoveryCodesServiceTests.Logic.cs See LICENSE.txt in the root folder of the solution.

using Microsoft.AspNetCore.Identity;
using PBACTemplate.Models.Users;

namespace PBACTemplate.Tests.Unit;

public partial class RecoveryCodesServiceTests
{
    [Fact]
    public async Task ShouldGenerateNewTwoFactorRecoveryCodesAsync()
    {
        // Given
        ApplicationUser inputUser = CreateUser();
        int inputCount = GetRandomInt();
        IEnumerable<string> expectedCodes = new[] { GetRandomString(), GetRandomString() };

        this.userManagerBrokerMock.Setup(broker =>
            broker.GenerateNewTwoFactorRecoveryCodesAsync(inputUser, inputCount))
                .ReturnsAsync(expectedCodes);

        // When
        IEnumerable<string>? actualCodes =
            await this.recoveryCodesService.GenerateNewTwoFactorRecoveryCodesAsync(
                inputUser,
                inputCount);

        // Then
        Assert.Equal(expectedCodes, actualCodes);

        this.userManagerBrokerMock.Verify(broker =>
            broker.GenerateNewTwoFactorRecoveryCodesAsync(inputUser, inputCount),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldRedeemTwoFactorRecoveryCodeAsync()
    {
        // Given
        ApplicationUser inputUser = CreateUser();
        string inputCode = GetRandomString();

        this.userManagerBrokerMock.Setup(broker =>
            broker.RedeemTwoFactorRecoveryCodeAsync(inputUser, inputCode))
                .ReturnsAsync(IdentityResult.Success);

        // When
        ApplicationUser actualUser =
            await this.recoveryCodesService.RedeemTwoFactorRecoveryCodeAsync(
                inputUser,
                inputCode);

        // Then
        Assert.Equal(inputUser, actualUser);

        this.userManagerBrokerMock.Verify(broker =>
            broker.RedeemTwoFactorRecoveryCodeAsync(inputUser, inputCode),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldCountRecoveryCodesAsync()
    {
        // Given
        ApplicationUser inputUser = CreateUser();
        int expectedCount = GetRandomInt();

        this.userManagerBrokerMock.Setup(broker =>
            broker.CountRecoveryCodesAsync(inputUser))
                .ReturnsAsync(expectedCount);

        // When
        int actualCount =
            await this.recoveryCodesService.CountRecoveryCodesAsync(inputUser);

        // Then
        Assert.Equal(expectedCount, actualCount);

        this.userManagerBrokerMock.Verify(broker =>
            broker.CountRecoveryCodesAsync(inputUser),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }
}