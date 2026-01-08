// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// ClaimsServiceTests.Exceptions.cs See LICENSE.txt in the root folder of the solution.

using Moq;
using PBACTemplate.Data;
using PBACTemplate.Services.Foundations.Claims.Exceptions;
using System.Security.Claims;

namespace PBACTemplate.Tests.Unit;

public partial class ClaimsServiceTests
{
    [Fact]
    public async Task ShouldThrowClaimsServiceExceptionOnAddClaimAsyncIfExceptionOccurs()
    {
        // Given
        ApplicationUser user = CreateUser();
        Claim claim = CreateClaim();
        var someException = new Exception(GetRandomString());

        this.userManagerBrokerMock.Setup(broker =>
            broker.AddClaimAsync(user, claim))
                .ThrowsAsync(someException);

        var expectedException = new ClaimsServiceException(
            "Claims service error occurred, contact support.",
            new FailedClaimsServiceException(
                "Failed claims service error occurred, contact support.",
                someException));

        // When
        Func<Task> action = async () => await this.claimsService.AddClaimAsync(user, claim);

        // Then
        ClaimsServiceException actualException =
            await Assert.ThrowsAsync<ClaimsServiceException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);
        Assert.IsType<FailedClaimsServiceException>(actualException.InnerException);

        this.userManagerBrokerMock.Verify(broker =>
            broker.AddClaimAsync(user, claim),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldThrowClaimsServiceExceptionOnAddClaimsAsyncIfExceptionOccurs()
    {
        // Given
        ApplicationUser user = CreateUser();
        IEnumerable<Claim> claims = CreateClaims();
        var someException = new Exception(GetRandomString());

        this.userManagerBrokerMock.Setup(broker =>
            broker.AddClaimsAsync(user, claims))
                .ThrowsAsync(someException);

        var expectedException = new ClaimsServiceException(
            "Claims service error occurred, contact support.",
            new FailedClaimsServiceException(
                "Failed claims service error occurred, contact support.",
                someException));

        // When
        Func<Task> action = async () => await this.claimsService.AddClaimsAsync(user, claims);

        // Then
        ClaimsServiceException actualException =
            await Assert.ThrowsAsync<ClaimsServiceException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);
        Assert.IsType<FailedClaimsServiceException>(actualException.InnerException);

        this.userManagerBrokerMock.Verify(broker =>
            broker.AddClaimsAsync(user, claims),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldThrowClaimsServiceExceptionOnReplaceClaimAsyncIfExceptionOccurs()
    {
        // Given
        ApplicationUser user = CreateUser();
        Claim claim = CreateClaim();
        Claim newClaim = CreateClaim();
        var someException = new Exception(GetRandomString());

        this.userManagerBrokerMock.Setup(broker =>
            broker.ReplaceClaimAsync(user, claim, newClaim))
                .ThrowsAsync(someException);

        var expectedException = new ClaimsServiceException(
            "Claims service error occurred, contact support.",
            new FailedClaimsServiceException(
                "Failed claims service error occurred, contact support.",
                someException));

        // When
        Func<Task> action = async () => await this.claimsService.ReplaceClaimAsync(user, claim, newClaim);

        // Then
        ClaimsServiceException actualException =
            await Assert.ThrowsAsync<ClaimsServiceException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);
        Assert.IsType<FailedClaimsServiceException>(actualException.InnerException);

        this.userManagerBrokerMock.Verify(broker =>
            broker.ReplaceClaimAsync(user, claim, newClaim),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldThrowClaimsServiceExceptionOnRemoveClaimAsyncIfExceptionOccurs()
    {
        // Given
        ApplicationUser user = CreateUser();
        Claim claim = CreateClaim();
        var someException = new Exception(GetRandomString());

        this.userManagerBrokerMock.Setup(broker =>
            broker.RemoveClaimAsync(user, claim))
                .ThrowsAsync(someException);

        var expectedException = new ClaimsServiceException(
            "Claims service error occurred, contact support.",
            new FailedClaimsServiceException(
                "Failed claims service error occurred, contact support.",
                someException));

        // When
        Func<Task> action = async () => await this.claimsService.RemoveClaimAsync(user, claim);

        // Then
        ClaimsServiceException actualException =
            await Assert.ThrowsAsync<ClaimsServiceException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);
        Assert.IsType<FailedClaimsServiceException>(actualException.InnerException);

        this.userManagerBrokerMock.Verify(broker =>
            broker.RemoveClaimAsync(user, claim),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldThrowClaimsServiceExceptionOnRemoveClaimsAsyncIfExceptionOccurs()
    {
        // Given
        ApplicationUser user = CreateUser();
        IEnumerable<Claim> claims = CreateClaims();
        var someException = new Exception(GetRandomString());

        this.userManagerBrokerMock.Setup(broker =>
            broker.RemoveClaimsAsync(user, claims))
                .ThrowsAsync(someException);

        var expectedException = new ClaimsServiceException(
            "Claims service error occurred, contact support.",
            new FailedClaimsServiceException(
                "Failed claims service error occurred, contact support.",
                someException));

        // When
        Func<Task> action = async () => await this.claimsService.RemoveClaimsAsync(user, claims);

        // Then
        ClaimsServiceException actualException =
            await Assert.ThrowsAsync<ClaimsServiceException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);
        Assert.IsType<FailedClaimsServiceException>(actualException.InnerException);

        this.userManagerBrokerMock.Verify(broker =>
            broker.RemoveClaimsAsync(user, claims),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldThrowClaimsServiceExceptionOnRetrieveClaimsAsyncIfExceptionOccurs()
    {
        // Given
        ApplicationUser user = CreateUser();
        var someException = new Exception(GetRandomString());

        this.userManagerBrokerMock.Setup(broker =>
            broker.GetClaimsAsync(user))
                .ThrowsAsync(someException);

        var expectedException = new ClaimsServiceException(
            "Claims service error occurred, contact support.",
            new FailedClaimsServiceException(
                "Failed claims service error occurred, contact support.",
                someException));

        // When
        Func<Task> action = async () => await this.claimsService.RetrieveClaimsAsync(user);

        // Then
        ClaimsServiceException actualException =
            await Assert.ThrowsAsync<ClaimsServiceException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);
        Assert.IsType<FailedClaimsServiceException>(actualException.InnerException);

        this.userManagerBrokerMock.Verify(broker =>
            broker.GetClaimsAsync(user),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldThrowClaimsServiceExceptionOnRetrieveUsersForClaimAsyncIfExceptionOccurs()
    {
        // Given
        Claim claim = CreateClaim();
        var someException = new Exception(GetRandomString());

        this.userManagerBrokerMock.Setup(broker =>
            broker.GetUsersForClaimAsync(claim))
                .ThrowsAsync(someException);

        var expectedException = new ClaimsServiceException(
            "Claims service error occurred, contact support.",
            new FailedClaimsServiceException(
                "Failed claims service error occurred, contact support.",
                someException));

        // When
        Func<Task> action = async () => await this.claimsService.RetrieveUsersForClaimAsync(claim);

        // Then
        ClaimsServiceException actualException =
            await Assert.ThrowsAsync<ClaimsServiceException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);
        Assert.IsType<FailedClaimsServiceException>(actualException.InnerException);

        this.userManagerBrokerMock.Verify(broker =>
            broker.GetUsersForClaimAsync(claim),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }
}