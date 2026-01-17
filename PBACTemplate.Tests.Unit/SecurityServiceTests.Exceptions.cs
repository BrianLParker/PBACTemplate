// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// SecurityServiceTests.Exceptions.cs See LICENSE.txt in the root folder of the solution.

using PBACTemplate.Models.Users;
using PBACTemplate.Services.Foundations.Security.Exceptions;

namespace PBACTemplate.Tests.Unit;

public partial class SecurityServiceTests
{
    [Fact]
    public async Task ShouldThrowSecurityServiceExceptionOnRetrieveWhenExceptionOccursAsync()
    {
        // Given
        ApplicationUser inputUser = CreateUser();
        var serviceException = new Exception(GetRandomString());

        this.userManagerBrokerMock.Setup(broker =>
            broker.GetSecurityStampAsync(inputUser))
                .ThrowsAsync(serviceException);

        // When
        Func<Task> action = async () =>
            await this.securityService.RetrieveSecurityStampAsync(inputUser);

        // Then
        await Assert.ThrowsAsync<SecurityServiceException>(action);

        this.userManagerBrokerMock.Verify(broker =>
            broker.GetSecurityStampAsync(inputUser),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldThrowSecurityServiceExceptionOnUpdateWhenExceptionOccursAsync()
    {
        // Given
        ApplicationUser inputUser = CreateUser();
        var serviceException = new Exception(GetRandomString());

        this.userManagerBrokerMock.Setup(broker =>
            broker.UpdateSecurityStampAsync(inputUser))
                .ThrowsAsync(serviceException);

        // When
        Func<Task> action = async () =>
            await this.securityService.UpdateSecurityStampAsync(inputUser);

        // Then
        await Assert.ThrowsAsync<SecurityServiceException>(action);

        this.userManagerBrokerMock.Verify(broker =>
            broker.UpdateSecurityStampAsync(inputUser),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldThrowSecurityServiceExceptionOnCreateTokenWhenExceptionOccursAsync()
    {
        // Given
        ApplicationUser inputUser = CreateUser();
        var serviceException = new Exception(GetRandomString());

        this.userManagerBrokerMock.Setup(broker =>
            broker.CreateSecurityTokenAsync(inputUser))
                .ThrowsAsync(serviceException);

        // When
        Func<Task> action = async () =>
            await this.securityService.CreateSecurityTokenAsync(inputUser);

        // Then
        await Assert.ThrowsAsync<SecurityServiceException>(action);

        this.userManagerBrokerMock.Verify(broker =>
            broker.CreateSecurityTokenAsync(inputUser),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldThrowSecurityServiceExceptionOnGenerateConcurrencyStampWhenExceptionOccursAsync()
    {
        // Given
        ApplicationUser inputUser = CreateUser();
        var serviceException = new Exception(GetRandomString());

        this.userManagerBrokerMock.Setup(broker =>
            broker.GenerateConcurrencyStampAsync(inputUser))
                .ThrowsAsync(serviceException);

        // When
        Func<Task> action = async () =>
            await this.securityService.GenerateConcurrencyStampAsync(inputUser);

        // Then
        await Assert.ThrowsAsync<SecurityServiceException>(action);

        this.userManagerBrokerMock.Verify(broker =>
            broker.GenerateConcurrencyStampAsync(inputUser),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }
}