// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// EmailServiceTests.Logic.cs See LICENSE.txt in the root folder of the solution.

using Microsoft.AspNetCore.Identity;
using PBACTemplate.Models.User;

namespace PBACTemplate.Tests.Unit;

public partial class EmailServiceTests
{
    [Fact]
    public async Task ShouldRetrieveEmailAsync()
    {
        // Given
        ApplicationUser inputUser = CreateUser();
        string? expectedEmail = "user@example.com";

        this.userManagerBrokerMock.Setup(broker =>
            broker.GetEmailAsync(inputUser))
                .ReturnsAsync(expectedEmail);

        // When
        string? actualEmail =
            await this.emailService.RetrieveEmailAsync(inputUser);

        // Then
        Assert.Equal(expectedEmail, actualEmail);

        this.userManagerBrokerMock.Verify(broker =>
            broker.GetEmailAsync(inputUser),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldSetEmailAsync()
    {
        // Given
        ApplicationUser inputUser = CreateUser();
        string? inputEmail = "new@example.com";

        this.userManagerBrokerMock.Setup(broker =>
            broker.SetEmailAsync(inputUser, inputEmail))
                .ReturnsAsync(IdentityResult.Success);

        // When
        ApplicationUser actualUser =
            await this.emailService.SetEmailAsync(inputUser, inputEmail);

        // Then
        Assert.Equal(inputUser, actualUser);

        this.userManagerBrokerMock.Verify(broker =>
            broker.SetEmailAsync(inputUser, inputEmail),
            Times.Once);

        this.userManagerBrokerMock.Verify(broker =>
            broker.UpdateNormalizedEmailAsync(inputUser),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public void ShouldNormalizeEmail()
    {
        // Given
        string? inputEmail = "User@Example.com";
        string? expectedEmail = "user@example.com";

        this.userManagerBrokerMock.Setup(broker =>
            broker.NormalizeEmail(inputEmail))
                .Returns(expectedEmail);

        // When
        string? actualEmail = this.emailService.NormalizeEmail(inputEmail);

        // Then
        Assert.Equal(expectedEmail, actualEmail);

        this.userManagerBrokerMock.Verify(broker =>
            broker.NormalizeEmail(inputEmail),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldCheckEmailConfirmedAsync()
    {
        // Given
        ApplicationUser inputUser = CreateUser();
        bool expectedConfirmed = GetRandomBoolean();

        this.userManagerBrokerMock.Setup(broker =>
            broker.IsEmailConfirmedAsync(inputUser))
                .ReturnsAsync(expectedConfirmed);

        // When
        bool actualConfirmed =
            await this.emailService.IsEmailConfirmedAsync(inputUser);

        // Then
        Assert.Equal(expectedConfirmed, actualConfirmed);

        this.userManagerBrokerMock.Verify(broker =>
            broker.IsEmailConfirmedAsync(inputUser),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldGenerateEmailConfirmationTokenAsync()
    {
        // Given
        ApplicationUser inputUser = CreateUser();
        string expectedToken = GetRandomString();

        this.userManagerBrokerMock.Setup(broker =>
            broker.GenerateEmailConfirmationTokenAsync(inputUser))
                .ReturnsAsync(expectedToken);

        // When
        string actualToken =
            await this.emailService.GenerateEmailConfirmationTokenAsync(inputUser);

        // Then
        Assert.Equal(expectedToken, actualToken);

        this.userManagerBrokerMock.Verify(broker =>
            broker.GenerateEmailConfirmationTokenAsync(inputUser),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldConfirmEmailAsync()
    {
        // Given
        ApplicationUser inputUser = CreateUser();
        string inputToken = GetRandomString();

        this.userManagerBrokerMock.Setup(broker =>
            broker.ConfirmEmailAsync(inputUser, inputToken))
                .ReturnsAsync(IdentityResult.Success);

        // When
        ApplicationUser actualUser =
            await this.emailService.ConfirmEmailAsync(inputUser, inputToken);

        // Then
        Assert.Equal(inputUser, actualUser);

        this.userManagerBrokerMock.Verify(broker =>
            broker.ConfirmEmailAsync(inputUser, inputToken),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldGenerateChangeEmailTokenAsync()
    {
        // Given
        ApplicationUser inputUser = CreateUser();
        string inputNewEmail = "new@example.com";
        string expectedToken = GetRandomString();

        this.userManagerBrokerMock.Setup(broker =>
            broker.GenerateChangeEmailTokenAsync(inputUser, inputNewEmail))
                .ReturnsAsync(expectedToken);

        // When
        string actualToken =
            await this.emailService.GenerateChangeEmailTokenAsync(inputUser, inputNewEmail);

        // Then
        Assert.Equal(expectedToken, actualToken);

        this.userManagerBrokerMock.Verify(broker =>
            broker.GenerateChangeEmailTokenAsync(inputUser, inputNewEmail),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldChangeEmailAsync()
    {
        // Given
        ApplicationUser inputUser = CreateUser();
        string inputNewEmail = "new@example.com";
        string inputToken = GetRandomString();

        this.userManagerBrokerMock.Setup(broker =>
            broker.ChangeEmailAsync(inputUser, inputNewEmail, inputToken))
                .ReturnsAsync(IdentityResult.Success);

        // When
        ApplicationUser actualUser =
            await this.emailService.ChangeEmailAsync(inputUser, inputNewEmail, inputToken);

        // Then
        Assert.Equal(inputUser, actualUser);

        this.userManagerBrokerMock.Verify(broker =>
            broker.ChangeEmailAsync(inputUser, inputNewEmail, inputToken),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }
}