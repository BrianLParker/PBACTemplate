// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// PhoneServiceTests.Logic.cs See LICENSE.txt in the root folder of the solution.

using Microsoft.AspNetCore.Identity;
using PBACTemplate.Models.Users;

namespace PBACTemplate.Tests.Unit;

public partial class PhoneServiceTests
{
    [Fact]
    public async Task ShouldRetrievePhoneNumberAsync()
    {
        // Given
        ApplicationUser inputUser = CreateUser();
        string? expectedPhone = GetRandomString();

        this.userManagerBrokerMock.Setup(broker =>
            broker.GetPhoneNumberAsync(inputUser))
                .ReturnsAsync(expectedPhone);

        // When
        string? actualPhone =
            await this.phoneService.RetrievePhoneNumberAsync(inputUser);

        // Then
        Assert.Equal(expectedPhone, actualPhone);

        this.userManagerBrokerMock.Verify(broker =>
            broker.GetPhoneNumberAsync(inputUser),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldSetPhoneNumberAsync()
    {
        // Given
        ApplicationUser inputUser = CreateUser();
        string? inputPhone = GetRandomString();

        this.userManagerBrokerMock.Setup(broker =>
            broker.SetPhoneNumberAsync(inputUser, inputPhone))
                .ReturnsAsync(IdentityResult.Success);

        // When
        ApplicationUser actualUser =
            await this.phoneService.SetPhoneNumberAsync(inputUser, inputPhone);

        // Then
        Assert.Equal(inputUser, actualUser);

        this.userManagerBrokerMock.Verify(broker =>
            broker.SetPhoneNumberAsync(inputUser, inputPhone),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldCheckPhoneNumberConfirmedAsync()
    {
        // Given
        ApplicationUser inputUser = CreateUser();
        bool expectedConfirmed = GetRandomBoolean();

        this.userManagerBrokerMock.Setup(broker =>
            broker.IsPhoneNumberConfirmedAsync(inputUser))
                .ReturnsAsync(expectedConfirmed);

        // When
        bool actualConfirmed =
            await this.phoneService.IsPhoneNumberConfirmedAsync(inputUser);

        // Then
        Assert.Equal(expectedConfirmed, actualConfirmed);

        this.userManagerBrokerMock.Verify(broker =>
            broker.IsPhoneNumberConfirmedAsync(inputUser),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldGenerateChangePhoneNumberTokenAsync()
    {
        // Given
        ApplicationUser inputUser = CreateUser();
        string inputPhone = GetRandomString();
        string expectedToken = GetRandomString();

        this.userManagerBrokerMock.Setup(broker =>
            broker.GenerateChangePhoneNumberTokenAsync(inputUser, inputPhone))
                .ReturnsAsync(expectedToken);

        // When
        string actualToken =
            await this.phoneService.GenerateChangePhoneNumberTokenAsync(inputUser, inputPhone);

        // Then
        Assert.Equal(expectedToken, actualToken);

        this.userManagerBrokerMock.Verify(broker =>
            broker.GenerateChangePhoneNumberTokenAsync(inputUser, inputPhone),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldVerifyChangePhoneNumberTokenAsync()
    {
        // Given
        ApplicationUser inputUser = CreateUser();
        string inputToken = GetRandomString();
        string inputPhone = GetRandomString();
        bool expectedResult = GetRandomBoolean();

        this.userManagerBrokerMock.Setup(broker =>
            broker.VerifyChangePhoneNumberTokenAsync(inputUser, inputToken, inputPhone))
                .ReturnsAsync(expectedResult);

        // When
        bool actualResult =
            await this.phoneService.VerifyChangePhoneNumberTokenAsync(inputUser, inputToken, inputPhone);

        // Then
        Assert.Equal(expectedResult, actualResult);

        this.userManagerBrokerMock.Verify(broker =>
            broker.VerifyChangePhoneNumberTokenAsync(inputUser, inputToken, inputPhone),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldChangePhoneNumberAsync()
    {
        // Given
        ApplicationUser inputUser = CreateUser();
        string inputPhone = GetRandomString();
        string inputToken = GetRandomString();

        this.userManagerBrokerMock.Setup(broker =>
            broker.ChangePhoneNumberAsync(inputUser, inputPhone, inputToken))
                .ReturnsAsync(IdentityResult.Success);

        // When
        ApplicationUser actualUser =
            await this.phoneService.ChangePhoneNumberAsync(inputUser, inputPhone, inputToken);

        // Then
        Assert.Equal(inputUser, actualUser);

        this.userManagerBrokerMock.Verify(broker =>
            broker.ChangePhoneNumberAsync(inputUser, inputPhone, inputToken),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }
}