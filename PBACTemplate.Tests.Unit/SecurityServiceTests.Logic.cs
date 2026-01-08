// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// SecurityServiceTests.Logic.cs See LICENSE.txt in the root folder of the solution.

using Microsoft.AspNetCore.Identity;
using PBACTemplate.Data;

namespace PBACTemplate.Tests.Unit;

public partial class SecurityServiceTests
{
    [Fact]
    public async Task ShouldRetrieveSecurityStampAsync()
    {
        // Given
        ApplicationUser inputUser = CreateUser();
        string expectedStamp = GetRandomString();

        this.userManagerBrokerMock.Setup(broker =>
            broker.GetSecurityStampAsync(inputUser))
                .ReturnsAsync(expectedStamp);

        // When
        string actualStamp =
            await this.securityService.RetrieveSecurityStampAsync(inputUser);

        // Then
        Assert.Equal(expectedStamp, actualStamp);

        this.userManagerBrokerMock.Verify(broker =>
            broker.GetSecurityStampAsync(inputUser),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldUpdateSecurityStampAsync()
    {
        // Given
        ApplicationUser inputUser = CreateUser();

        this.userManagerBrokerMock.Setup(broker =>
            broker.UpdateSecurityStampAsync(inputUser))
                .ReturnsAsync(IdentityResult.Success);

        // When
        ApplicationUser actualUser =
            await this.securityService.UpdateSecurityStampAsync(inputUser);

        // Then
        Assert.Equal(inputUser, actualUser);

        this.userManagerBrokerMock.Verify(broker =>
            broker.UpdateSecurityStampAsync(inputUser),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldCreateSecurityTokenAsync()
    {
        // Given
        ApplicationUser inputUser = CreateUser();
        byte[] expectedToken = GetRandomBytes();

        this.userManagerBrokerMock.Setup(broker =>
            broker.CreateSecurityTokenAsync(inputUser))
                .ReturnsAsync(expectedToken);

        // When
        byte[] actualToken =
            await this.securityService.CreateSecurityTokenAsync(inputUser);

        // Then
        Assert.Equal(expectedToken, actualToken);

        this.userManagerBrokerMock.Verify(broker =>
            broker.CreateSecurityTokenAsync(inputUser),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldGenerateConcurrencyStampAsync()
    {
        // Given
        ApplicationUser inputUser = CreateUser();
        string expectedStamp = GetRandomString();

        this.userManagerBrokerMock.Setup(broker =>
            broker.GenerateConcurrencyStampAsync(inputUser))
                .ReturnsAsync(expectedStamp);

        // When
        string actualStamp =
            await this.securityService.GenerateConcurrencyStampAsync(inputUser);

        // Then
        Assert.Equal(expectedStamp, actualStamp);

        this.userManagerBrokerMock.Verify(broker =>
            broker.GenerateConcurrencyStampAsync(inputUser),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }
}