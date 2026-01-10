// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// RoleClaimsServiceTests.Exceptions.cs See LICENSE.txt in the root folder of the solution.

using Microsoft.AspNetCore.Identity;
using PBACTemplate.Services.Foundations.RoleClaims.Exceptions;
using System.Security.Claims;

namespace PBACTemplate.Tests.Unit;

public partial class RoleClaimsServiceTests
{
    [Fact]
    public async Task ShouldThrowRoleClaimsServiceExceptionOnRetrieveClaimsAsyncIfExceptionOccurs()
    {
        // Given
        IdentityRole role = CreateRole();
        var someException = new Exception(GetRandomString());

        this.roleManagerBrokerMock.Setup(broker =>
            broker.GetClaimsAsync(role))
                .ThrowsAsync(someException);

        var expectedException = new RoleClaimsServiceException(
            "Role claims service error occurred, contact support.",
            new FailedRoleClaimsServiceException(
                "Failed role claims service error occurred, contact support.",
                someException));

        // When
        Func<Task> action = async () => await this.roleClaimsService
            .RetrieveClaimsAsync(role);

        // Then
        RoleClaimsServiceException actualException =
            await Assert.ThrowsAsync<RoleClaimsServiceException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);
        Assert.IsType<FailedRoleClaimsServiceException>(actualException.InnerException);

        this.roleManagerBrokerMock.Verify(broker =>
            broker.GetClaimsAsync(role),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldThrowRoleClaimsServiceExceptionOnAddClaimAsyncIfExceptionOccurs()
    {
        // Given
        IdentityRole role = CreateRole();
        Claim claim = CreateClaim();
        var someException = new Exception(GetRandomString());

        this.roleManagerBrokerMock.Setup(broker =>
            broker.AddClaimAsync(role, claim))
                .ThrowsAsync(someException);

        var expectedException = new RoleClaimsServiceException(
            "Role claims service error occurred, contact support.",
            new FailedRoleClaimsServiceException(
                "Failed role claims service error occurred, contact support.",
                someException));

        // When
        Func<Task> action = async () => await this.roleClaimsService
            .AddClaimAsync(role, claim);

        // Then
        RoleClaimsServiceException actualException =
            await Assert.ThrowsAsync<RoleClaimsServiceException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);
        Assert.IsType<FailedRoleClaimsServiceException>(actualException.InnerException);

        this.roleManagerBrokerMock.Verify(broker =>
            broker.AddClaimAsync(role, claim),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldThrowRoleClaimsServiceExceptionOnRemoveClaimAsyncIfExceptionOccurs()
    {
        // Given
        IdentityRole role = CreateRole();
        Claim claim = CreateClaim();
        var someException = new Exception(GetRandomString());

        this.roleManagerBrokerMock.Setup(broker =>
            broker.RemoveClaimAsync(role, claim))
                .ThrowsAsync(someException);

        var expectedException = new RoleClaimsServiceException(
            "Role claims service error occurred, contact support.",
            new FailedRoleClaimsServiceException(
                "Failed role claims service error occurred, contact support.",
                someException));

        // When
        Func<Task> action = async () => await this.roleClaimsService
            .RemoveClaimAsync(role, claim);

        // Then
        RoleClaimsServiceException actualException =
            await Assert.ThrowsAsync<RoleClaimsServiceException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);
        Assert.IsType<FailedRoleClaimsServiceException>(actualException.InnerException);

        this.roleManagerBrokerMock.Verify(broker =>
            broker.RemoveClaimAsync(role, claim),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }
}