// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// PasswordServiceTests.Logic.cs See LICENSE.txt in the root folder of the solution.

using Microsoft.AspNetCore.Identity;
using PBACTemplate.Models.Users;

namespace PBACTemplate.Tests.Unit;

public partial class PasswordServiceTests
{
    [Fact]
    public async Task ShouldCheckPasswordAsync()
    {
        // Given
        ApplicationUser inputUser = CreateUser();
        string inputPassword = GetRandomString();
        bool expectedResult = GetRandomBoolean();

        this.userManagerBrokerMock.Setup(broker =>
            broker.CheckPasswordAsync(inputUser, inputPassword))
                .ReturnsAsync(expectedResult);

        // When
        bool actualResult =
            await this.passwordService.CheckPasswordAsync(inputUser, inputPassword);

        // Then
        Assert.Equal(expectedResult, actualResult);

        this.userManagerBrokerMock.Verify(broker =>
            broker.CheckPasswordAsync(inputUser, inputPassword),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldCheckHasPasswordAsync()
    {
        // Given
        ApplicationUser inputUser = CreateUser();
        bool expectedResult = GetRandomBoolean();

        this.userManagerBrokerMock.Setup(broker =>
            broker.HasPasswordAsync(inputUser))
                .ReturnsAsync(expectedResult);

        // When
        bool actualResult =
            await this.passwordService.HasPasswordAsync(inputUser);

        // Then
        Assert.Equal(expectedResult, actualResult);

        this.userManagerBrokerMock.Verify(broker =>
            broker.HasPasswordAsync(inputUser),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldAddPasswordAsync()
    {
        // Given
        ApplicationUser inputUser = CreateUser();
        string inputPassword = GetRandomString();

        this.userManagerBrokerMock.Setup(broker =>
            broker.AddPasswordAsync(inputUser, inputPassword))
                .ReturnsAsync(IdentityResult.Success);

        // When
        ApplicationUser actualUser =
            await this.passwordService.AddPasswordAsync(inputUser, inputPassword);

        // Then
        Assert.Equal(inputUser, actualUser);

        this.userManagerBrokerMock.Verify(broker =>
            broker.AddPasswordAsync(inputUser, inputPassword),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldChangePasswordAsync()
    {
        // Given
        ApplicationUser inputUser = CreateUser();
        string currentPassword = GetRandomString();
        string newPassword = GetRandomString();

        this.userManagerBrokerMock.Setup(broker =>
            broker.ChangePasswordAsync(inputUser, currentPassword, newPassword))
                .ReturnsAsync(IdentityResult.Success);

        // When
        ApplicationUser actualUser =
            await this.passwordService.ChangePasswordAsync(inputUser, currentPassword, newPassword);

        // Then
        Assert.Equal(inputUser, actualUser);

        this.userManagerBrokerMock.Verify(broker =>
            broker.ChangePasswordAsync(inputUser, currentPassword, newPassword),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldRemovePasswordAsync()
    {
        // Given
        ApplicationUser inputUser = CreateUser();

        this.userManagerBrokerMock.Setup(broker =>
            broker.RemovePasswordAsync(inputUser))
                .ReturnsAsync(IdentityResult.Success);

        // When
        ApplicationUser actualUser =
            await this.passwordService.RemovePasswordAsync(inputUser);

        // Then
        Assert.Equal(inputUser, actualUser);

        this.userManagerBrokerMock.Verify(broker =>
            broker.RemovePasswordAsync(inputUser),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldGeneratePasswordResetTokenAsync()
    {
        // Given
        ApplicationUser inputUser = CreateUser();
        string expectedToken = GetRandomString();

        this.userManagerBrokerMock.Setup(broker =>
            broker.GeneratePasswordResetTokenAsync(inputUser))
                .ReturnsAsync(expectedToken);

        // When
        string actualToken =
            await this.passwordService.GeneratePasswordResetTokenAsync(inputUser);

        // Then
        Assert.Equal(expectedToken, actualToken);

        this.userManagerBrokerMock.Verify(broker =>
            broker.GeneratePasswordResetTokenAsync(inputUser),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldResetPasswordAsync()
    {
        // Given
        ApplicationUser inputUser = CreateUser();
        string token = GetRandomString();
        string newPassword = GetRandomString();

        this.userManagerBrokerMock.Setup(broker =>
            broker.ResetPasswordAsync(inputUser, token, newPassword))
                .ReturnsAsync(IdentityResult.Success);

        // When
        ApplicationUser actualUser =
            await this.passwordService.ResetPasswordAsync(inputUser, token, newPassword);

        // Then
        Assert.Equal(inputUser, actualUser);

        this.userManagerBrokerMock.Verify(broker =>
            broker.ResetPasswordAsync(inputUser, token, newPassword),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }
}