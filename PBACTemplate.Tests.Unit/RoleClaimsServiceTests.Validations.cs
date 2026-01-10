// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// RoleClaimsServiceTests.Validations.cs See LICENSE.txt in the root folder of the solution.

using Microsoft.AspNetCore.Identity;
using PBACTemplate.Services.Foundations.RoleClaims.Exceptions;
using System.Security.Claims;

namespace PBACTemplate.Tests.Unit;

public partial class RoleClaimsServiceTests
{
    [Fact]
    public async Task ShouldThrowNullRoleClaimsExceptionOnRetrieveClaimsAsyncIfRoleIsNull()
    {
        // Given
        IdentityRole? nullRole = null;
        var expectedException = new NullRoleClaimsException("Role cannot be null.");

        // When
        Func<Task> action = async () => await this.roleClaimsService
            .RetrieveClaimsAsync(nullRole!);

        // Then
        NullRoleClaimsException actualException =
            await Assert.ThrowsAsync<NullRoleClaimsException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);

        this.roleManagerBrokerMock.Verify(broker =>
            broker.GetClaimsAsync(It.IsAny<IdentityRole>()),
            Times.Never);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldThrowNullRoleClaimsExceptionOnAddClaimAsyncIfRoleIsNull()
    {
        // Given
        IdentityRole? nullRole = null;
        Claim claim = CreateClaim();
        var expectedException = new NullRoleClaimsException("Role cannot be null.");

        // When
        Func<Task> action = async () => await this.roleClaimsService
            .AddClaimAsync(nullRole!, claim);

        // Then
        NullRoleClaimsException actualException =
            await Assert.ThrowsAsync<NullRoleClaimsException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);

        this.roleManagerBrokerMock.Verify(broker =>
            broker.AddClaimAsync(
                It.IsAny<IdentityRole>(),
                It.IsAny<Claim>()),
            Times.Never);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldThrowNullRoleClaimsExceptionOnAddClaimAsyncIfClaimIsNull()
    {
        // Given
        IdentityRole role = CreateRole();
        Claim? nullClaim = null;
        var expectedException = new NullRoleClaimsException("Claim cannot be null.");

        // When
        Func<Task> action = async () => await this.roleClaimsService
            .AddClaimAsync(role, nullClaim!);

        // Then
        NullRoleClaimsException actualException =
            await Assert.ThrowsAsync<NullRoleClaimsException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);

        this.roleManagerBrokerMock.Verify(broker =>
            broker.AddClaimAsync(
                It.IsAny<IdentityRole>(),
                It.IsAny<Claim>()),
            Times.Never);

        VerifyNoOtherBrokerCalls();
    }

    [Theory]
    [InlineData("")]
    [InlineData("   ")]
    public async Task ShouldThrowInvalidRoleClaimsExceptionOnAddClaimAsyncIfClaimTypeIsInvalid(
        string invalidType)
    {
        // Given
        IdentityRole role = CreateRole();
        Claim claim = new(invalidType!, "value");
        var expectedException = new InvalidRoleClaimsException(
            "Claim type cannot be null or whitespace.");

        // When
        Func<Task> action = async () => await this.roleClaimsService
            .AddClaimAsync(role, claim);

        // Then
        InvalidRoleClaimsException actualException =
            await Assert.ThrowsAsync<InvalidRoleClaimsException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);

        this.roleManagerBrokerMock.Verify(broker =>
            broker.AddClaimAsync(
                It.IsAny<IdentityRole>(),
                It.IsAny<Claim>()),
            Times.Never);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldThrowNullRoleClaimsExceptionOnRemoveClaimAsyncIfRoleIsNull()
    {
        // Given
        IdentityRole? nullRole = null;
        Claim claim = CreateClaim();
        var expectedException = new NullRoleClaimsException("Role cannot be null.");

        // When
        Func<Task> action = async () => await this.roleClaimsService
            .RemoveClaimAsync(nullRole!, claim);

        // Then
        NullRoleClaimsException actualException =
            await Assert.ThrowsAsync<NullRoleClaimsException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);

        this.roleManagerBrokerMock.Verify(broker =>
            broker.RemoveClaimAsync(
                It.IsAny<IdentityRole>(),
                It.IsAny<Claim>()),
            Times.Never);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldThrowNullRoleClaimsExceptionOnRemoveClaimAsyncIfClaimIsNull()
    {
        // Given
        IdentityRole role = CreateRole();
        Claim? nullClaim = null;
        var expectedException = new NullRoleClaimsException("Claim cannot be null.");

        // When
        Func<Task> action = async () => await this.roleClaimsService
            .RemoveClaimAsync(role, nullClaim!);

        // Then
        NullRoleClaimsException actualException =
            await Assert.ThrowsAsync<NullRoleClaimsException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);

        this.roleManagerBrokerMock.Verify(broker =>
            broker.RemoveClaimAsync(
                It.IsAny<IdentityRole>(),
                It.IsAny<Claim>()),
            Times.Never);

        VerifyNoOtherBrokerCalls();
    }

    [Theory]
    [InlineData("")]
    [InlineData("   ")]
    public async Task ShouldThrowInvalidRoleClaimsExceptionOnRemoveClaimAsyncIfClaimTypeIsInvalid(
        string invalidType)
    {
        // Given
        IdentityRole role = CreateRole();
        Claim claim = new(invalidType!, "value");
        var expectedException = new InvalidRoleClaimsException(
            "Claim type cannot be null or whitespace.");

        // When
        Func<Task> action = async () => await this.roleClaimsService
            .RemoveClaimAsync(role, claim);

        // Then
        InvalidRoleClaimsException actualException =
            await Assert.ThrowsAsync<InvalidRoleClaimsException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);

        this.roleManagerBrokerMock.Verify(broker =>
            broker.RemoveClaimAsync(
                It.IsAny<IdentityRole>(),
                It.IsAny<Claim>()),
            Times.Never);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldThrowFailedRoleClaimsOperationExceptionOnAddClaimAsyncIfIdentityResultFailed()
    {
        // Given
        IdentityRole role = CreateRole();
        Claim claim = CreateClaim();
        var identityError = new IdentityError { Description = GetRandomString() };
        IdentityResult failedResult = IdentityResult.Failed(identityError);

        this.roleManagerBrokerMock.Setup(broker =>
            broker.AddClaimAsync(role, claim))
                .ReturnsAsync(failedResult);

        var expectedException = new FailedRoleClaimsOperationException(
            $"Role claims identity operation failed: {identityError.Description}");

        // When
        Func<Task> action = async () => await this.roleClaimsService
            .AddClaimAsync(role, claim);

        // Then
        FailedRoleClaimsOperationException actualException =
            await Assert.ThrowsAsync<FailedRoleClaimsOperationException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);

        this.roleManagerBrokerMock.Verify(broker =>
            broker.AddClaimAsync(role, claim),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldThrowFailedRoleClaimsOperationExceptionOnRemoveClaimAsyncIfIdentityResultFailed()
    {
        // Given
        IdentityRole role = CreateRole();
        Claim claim = CreateClaim();
        var identityError = new IdentityError { Description = GetRandomString() };
        IdentityResult failedResult = IdentityResult.Failed(identityError);

        this.roleManagerBrokerMock.Setup(broker =>
            broker.RemoveClaimAsync(role, claim))
                .ReturnsAsync(failedResult);

        var expectedException = new FailedRoleClaimsOperationException(
            $"Role claims identity operation failed: {identityError.Description}");

        // When
        Func<Task> action = async () => await this.roleClaimsService
            .RemoveClaimAsync(role, claim);

        // Then
        FailedRoleClaimsOperationException actualException =
            await Assert.ThrowsAsync<FailedRoleClaimsOperationException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);

        this.roleManagerBrokerMock.Verify(broker =>
            broker.RemoveClaimAsync(role, claim),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }
}