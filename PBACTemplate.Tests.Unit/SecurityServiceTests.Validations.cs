// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// SecurityServiceTests.Validations.cs See LICENSE.txt in the root folder of the solution.

using Microsoft.AspNetCore.Identity;
using PBACTemplate.Data;
using PBACTemplate.Services.Foundations.Security.Exceptions;

namespace PBACTemplate.Tests.Unit;

public partial class SecurityServiceTests
{
    [Fact]
    public async Task ShouldThrowNullSecurityExceptionOnRetrieveWhenUserIsNullAsync()
    {
        // Given
        ApplicationUser? nullUser = null;

        // When
        Func<Task> action = async () =>
            await this.securityService.RetrieveSecurityStampAsync(nullUser!);

        // Then
        await Assert.ThrowsAsync<NullSecurityException>(action);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldThrowNullSecurityExceptionOnUpdateWhenUserIsNullAsync()
    {
        // Given
        ApplicationUser? nullUser = null;

        // When
        Func<Task> action = async () =>
            await this.securityService.UpdateSecurityStampAsync(nullUser!);

        // Then
        await Assert.ThrowsAsync<NullSecurityException>(action);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldThrowFailedSecurityOperationExceptionOnUpdateWhenIdentityFailsAsync()
    {
        // Given
        ApplicationUser inputUser = CreateUser();
        IdentityResult failure = IdentityResult.Failed(
            new IdentityError { Description = GetRandomString() });

        this.userManagerBrokerMock.Setup(broker =>
            broker.UpdateSecurityStampAsync(inputUser))
                .ReturnsAsync(failure);

        // When
        Func<Task> action = async () =>
            await this.securityService.UpdateSecurityStampAsync(inputUser);

        // Then
        await Assert.ThrowsAsync<FailedSecurityOperationException>(action);

        this.userManagerBrokerMock.Verify(broker =>
            broker.UpdateSecurityStampAsync(inputUser),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldThrowNullSecurityExceptionOnCreateTokenWhenUserIsNullAsync()
    {
        // Given
        ApplicationUser? nullUser = null;

        // When
        Func<Task> action = async () =>
            await this.securityService.CreateSecurityTokenAsync(nullUser!);

        // Then
        await Assert.ThrowsAsync<NullSecurityException>(action);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldThrowNullSecurityExceptionOnGenerateConcurrencyStampWhenUserIsNullAsync()
    {
        // Given
        ApplicationUser? nullUser = null;

        // When
        Func<Task> action = async () =>
            await this.securityService.GenerateConcurrencyStampAsync(nullUser!);

        // Then
        await Assert.ThrowsAsync<NullSecurityException>(action);

        VerifyNoOtherBrokerCalls();
    }
}