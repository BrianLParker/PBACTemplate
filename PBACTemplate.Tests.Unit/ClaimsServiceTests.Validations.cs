// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// ClaimsServiceTests.Validations.cs See LICENSE.txt in the root folder of the solution.

using Microsoft.AspNetCore.Identity;
using Moq;
using PBACTemplate.Data;
using PBACTemplate.Services.Foundations.Claims.Exceptions;
using System.Security.Claims;

namespace PBACTemplate.Tests.Unit;

public partial class ClaimsServiceTests
{
    [Fact]
    public async Task ShouldThrowNullClaimsExceptionOnAddClaimAsyncIfUserIsNull()
    {
        // Given
        ApplicationUser? nullUser = null;
        Claim inputClaim = CreateClaim();

        var expectedException = new NullClaimsException("User cannot be null.");

        // When
        Func<Task> action = async () => await this.claimsService.AddClaimAsync(nullUser!, inputClaim);

        // Then
        NullClaimsException actualException =
            await Assert.ThrowsAsync<NullClaimsException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);

        this.userManagerBrokerMock.Verify(broker =>
            broker.AddClaimAsync(It.IsAny<ApplicationUser>(), It.IsAny<Claim>()),
            Times.Never);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldThrowNullClaimsExceptionOnAddClaimAsyncIfClaimIsNull()
    {
        // Given
        ApplicationUser inputUser = CreateUser();
        Claim? nullClaim = null;

        var expectedException = new NullClaimsException("claim cannot be null.");

        // When
        Func<Task> action = async () => await this.claimsService.AddClaimAsync(inputUser, nullClaim!);

        // Then
        NullClaimsException actualException =
            await Assert.ThrowsAsync<NullClaimsException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);

        this.userManagerBrokerMock.Verify(broker =>
            broker.AddClaimAsync(It.IsAny<ApplicationUser>(), It.IsAny<Claim>()),
            Times.Never);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldThrowNullClaimsExceptionOnAddClaimsAsyncIfUserIsNull()
    {
        // Given
        ApplicationUser? nullUser = null;
        IEnumerable<Claim> inputClaims = CreateClaims();

        var expectedException = new NullClaimsException("User cannot be null.");

        // When
        Func<Task> action = async () => await this.claimsService.AddClaimsAsync(nullUser!, inputClaims);

        // Then
        NullClaimsException actualException =
            await Assert.ThrowsAsync<NullClaimsException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);

        this.userManagerBrokerMock.Verify(broker =>
            broker.AddClaimsAsync(It.IsAny<ApplicationUser>(), It.IsAny<IEnumerable<Claim>>()),
            Times.Never);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldThrowNullClaimsExceptionOnAddClaimsAsyncIfClaimsIsNull()
    {
        // Given
        ApplicationUser inputUser = CreateUser();
        IEnumerable<Claim>? nullClaims = null;

        var expectedException = new NullClaimsException("Claims cannot be null.");

        // When
        Func<Task> action = async () => await this.claimsService.AddClaimsAsync(inputUser, nullClaims!);

        // Then
        NullClaimsException actualException =
            await Assert.ThrowsAsync<NullClaimsException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);

        this.userManagerBrokerMock.Verify(broker =>
            broker.AddClaimsAsync(It.IsAny<ApplicationUser>(), It.IsAny<IEnumerable<Claim>>()),
            Times.Never);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldThrowInvalidClaimsExceptionOnAddClaimsAsyncIfClaimsIsEmpty()
    {
        // Given
        ApplicationUser inputUser = CreateUser();
        IEnumerable<Claim> emptyClaims = Enumerable.Empty<Claim>();

        var expectedException = new InvalidClaimsException("Claims cannot be empty.");

        // When
        Func<Task> action = async () => await this.claimsService.AddClaimsAsync(inputUser, emptyClaims);

        // Then
        InvalidClaimsException actualException =
            await Assert.ThrowsAsync<InvalidClaimsException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);

        this.userManagerBrokerMock.Verify(broker =>
            broker.AddClaimsAsync(It.IsAny<ApplicationUser>(), It.IsAny<IEnumerable<Claim>>()),
            Times.Never);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldThrowNullClaimsExceptionOnReplaceClaimAsyncIfUserIsNull()
    {
        // Given
        ApplicationUser? nullUser = null;
        Claim claim = CreateClaim();
        Claim newClaim = CreateClaim();

        var expectedException = new NullClaimsException("User cannot be null.");

        // When
        Func<Task> action = async () => await this.claimsService.ReplaceClaimAsync(nullUser!, claim, newClaim);

        // Then
        NullClaimsException actualException =
            await Assert.ThrowsAsync<NullClaimsException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);

        this.userManagerBrokerMock.Verify(broker =>
            broker.ReplaceClaimAsync(It.IsAny<ApplicationUser>(), It.IsAny<Claim>(), It.IsAny<Claim>()),
            Times.Never);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldThrowNullClaimsExceptionOnReplaceClaimAsyncIfOldClaimIsNull()
    {
        // Given
        ApplicationUser user = CreateUser();
        Claim? nullClaim = null;
        Claim newClaim = CreateClaim();

        var expectedException = new NullClaimsException("claim cannot be null.");

        // When
        Func<Task> action = async () => await this.claimsService.ReplaceClaimAsync(user, nullClaim!, newClaim);

        // Then
        NullClaimsException actualException =
            await Assert.ThrowsAsync<NullClaimsException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);

        this.userManagerBrokerMock.Verify(broker =>
            broker.ReplaceClaimAsync(It.IsAny<ApplicationUser>(), It.IsAny<Claim>(), It.IsAny<Claim>()),
            Times.Never);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldThrowNullClaimsExceptionOnReplaceClaimAsyncIfNewClaimIsNull()
    {
        // Given
        ApplicationUser user = CreateUser();
        Claim claim = CreateClaim();
        Claim? nullNewClaim = null;

        var expectedException = new NullClaimsException("newClaim cannot be null.");

        // When
        Func<Task> action = async () => await this.claimsService.ReplaceClaimAsync(user, claim, nullNewClaim!);

        // Then
        NullClaimsException actualException =
            await Assert.ThrowsAsync<NullClaimsException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);

        this.userManagerBrokerMock.Verify(broker =>
            broker.ReplaceClaimAsync(It.IsAny<ApplicationUser>(), It.IsAny<Claim>(), It.IsAny<Claim>()),
            Times.Never);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldThrowNullClaimsExceptionOnRemoveClaimAsyncIfUserIsNull()
    {
        // Given
        ApplicationUser? nullUser = null;
        Claim claim = CreateClaim();

        var expectedException = new NullClaimsException("User cannot be null.");

        // When
        Func<Task> action = async () => await this.claimsService.RemoveClaimAsync(nullUser!, claim);

        // Then
        NullClaimsException actualException =
            await Assert.ThrowsAsync<NullClaimsException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);

        this.userManagerBrokerMock.Verify(broker =>
            broker.RemoveClaimAsync(It.IsAny<ApplicationUser>(), It.IsAny<Claim>()),
            Times.Never);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldThrowNullClaimsExceptionOnRemoveClaimAsyncIfClaimIsNull()
    {
        // Given
        ApplicationUser user = CreateUser();
        Claim? nullClaim = null;

        var expectedException = new NullClaimsException("claim cannot be null.");

        // When
        Func<Task> action = async () => await this.claimsService.RemoveClaimAsync(user, nullClaim!);

        // Then
        NullClaimsException actualException =
            await Assert.ThrowsAsync<NullClaimsException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);

        this.userManagerBrokerMock.Verify(broker =>
            broker.RemoveClaimAsync(It.IsAny<ApplicationUser>(), It.IsAny<Claim>()),
            Times.Never);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldThrowNullClaimsExceptionOnRemoveClaimsAsyncIfUserIsNull()
    {
        // Given
        ApplicationUser? nullUser = null;
        IEnumerable<Claim> claims = CreateClaims();

        var expectedException = new NullClaimsException("User cannot be null.");

        // When
        Func<Task> action = async () => await this.claimsService.RemoveClaimsAsync(nullUser!, claims);

        // Then
        NullClaimsException actualException =
            await Assert.ThrowsAsync<NullClaimsException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);

        this.userManagerBrokerMock.Verify(broker =>
            broker.RemoveClaimsAsync(It.IsAny<ApplicationUser>(), It.IsAny<IEnumerable<Claim>>()),
            Times.Never);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldThrowNullClaimsExceptionOnRemoveClaimsAsyncIfClaimsIsNull()
    {
        // Given
        ApplicationUser user = CreateUser();
        IEnumerable<Claim>? nullClaims = null;

        var expectedException = new NullClaimsException("Claims cannot be null.");

        // When
        Func<Task> action = async () => await this.claimsService.RemoveClaimsAsync(user, nullClaims!);

        // Then
        NullClaimsException actualException =
            await Assert.ThrowsAsync<NullClaimsException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);

        this.userManagerBrokerMock.Verify(broker =>
            broker.RemoveClaimsAsync(It.IsAny<ApplicationUser>(), It.IsAny<IEnumerable<Claim>>()),
            Times.Never);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldThrowInvalidClaimsExceptionOnRemoveClaimsAsyncIfClaimsIsEmpty()
    {
        // Given
        ApplicationUser user = CreateUser();
        IEnumerable<Claim> emptyClaims = Enumerable.Empty<Claim>();

        var expectedException = new InvalidClaimsException("Claims cannot be empty.");

        // When
        Func<Task> action = async () => await this.claimsService.RemoveClaimsAsync(user, emptyClaims);

        // Then
        InvalidClaimsException actualException =
            await Assert.ThrowsAsync<InvalidClaimsException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);

        this.userManagerBrokerMock.Verify(broker =>
            broker.RemoveClaimsAsync(It.IsAny<ApplicationUser>(), It.IsAny<IEnumerable<Claim>>()),
            Times.Never);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldThrowNullClaimsExceptionOnRetrieveClaimsAsyncIfUserIsNull()
    {
        // Given
        ApplicationUser? nullUser = null;

        var expectedException = new NullClaimsException("User cannot be null.");

        // When
        Func<Task> action = async () => await this.claimsService.RetrieveClaimsAsync(nullUser!);

        // Then
        NullClaimsException actualException =
            await Assert.ThrowsAsync<NullClaimsException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);

        this.userManagerBrokerMock.Verify(broker =>
            broker.GetClaimsAsync(It.IsAny<ApplicationUser>()),
            Times.Never);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldThrowNullClaimsExceptionOnRetrieveUsersForClaimAsyncIfClaimIsNull()
    {
        // Given
        Claim? nullClaim = null;

        var expectedException = new NullClaimsException("claim cannot be null.");

        // When
        Func<Task> action = async () => await this.claimsService.RetrieveUsersForClaimAsync(nullClaim!);

        // Then
        NullClaimsException actualException =
            await Assert.ThrowsAsync<NullClaimsException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);

        this.userManagerBrokerMock.Verify(broker =>
            broker.GetUsersForClaimAsync(It.IsAny<Claim>()),
            Times.Never);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldThrowFailedClaimsOperationExceptionOnAddClaimAsyncIfIdentityResultFailed()
    {
        // Given
        ApplicationUser user = CreateUser();
        Claim claim = CreateClaim();
        var identityError = new IdentityError { Description = GetRandomString() };
        IdentityResult failedResult = IdentityResult.Failed(identityError);

        this.userManagerBrokerMock.Setup(broker =>
            broker.AddClaimAsync(user, claim))
                .ReturnsAsync(failedResult);

        var expectedException = new FailedClaimsOperationException(
            $"Identity operation failed: {identityError.Description}");

        // When
        Func<Task> action = async () => await this.claimsService.AddClaimAsync(user, claim);

        // Then
        FailedClaimsOperationException actualException =
            await Assert.ThrowsAsync<FailedClaimsOperationException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);

        this.userManagerBrokerMock.Verify(broker =>
            broker.AddClaimAsync(user, claim),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldThrowFailedClaimsOperationExceptionOnAddClaimsAsyncIfIdentityResultFailed()
    {
        // Given
        ApplicationUser user = CreateUser();
        IEnumerable<Claim> claims = CreateClaims();
        var identityError = new IdentityError { Description = GetRandomString() };
        IdentityResult failedResult = IdentityResult.Failed(identityError);

        this.userManagerBrokerMock.Setup(broker =>
            broker.AddClaimsAsync(user, claims))
                .ReturnsAsync(failedResult);

        var expectedException = new FailedClaimsOperationException(
            $"Identity operation failed: {identityError.Description}");

        // When
        Func<Task> action = async () => await this.claimsService.AddClaimsAsync(user, claims);

        // Then
        FailedClaimsOperationException actualException =
            await Assert.ThrowsAsync<FailedClaimsOperationException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);

        this.userManagerBrokerMock.Verify(broker =>
            broker.AddClaimsAsync(user, claims),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldThrowFailedClaimsOperationExceptionOnReplaceClaimAsyncIfIdentityResultFailed()
    {
        // Given
        ApplicationUser user = CreateUser();
        Claim claim = CreateClaim();
        Claim newClaim = CreateClaim();
        var identityError = new IdentityError { Description = GetRandomString() };
        IdentityResult failedResult = IdentityResult.Failed(identityError);

        this.userManagerBrokerMock.Setup(broker =>
            broker.ReplaceClaimAsync(user, claim, newClaim))
                .ReturnsAsync(failedResult);

        var expectedException = new FailedClaimsOperationException(
            $"Identity operation failed: {identityError.Description}");

        // When
        Func<Task> action = async () => await this.claimsService.ReplaceClaimAsync(user, claim, newClaim);

        // Then
        FailedClaimsOperationException actualException =
            await Assert.ThrowsAsync<FailedClaimsOperationException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);

        this.userManagerBrokerMock.Verify(broker =>
            broker.ReplaceClaimAsync(user, claim, newClaim),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldThrowFailedClaimsOperationExceptionOnRemoveClaimAsyncIfIdentityResultFailed()
    {
        // Given
        ApplicationUser user = CreateUser();
        Claim claim = CreateClaim();
        var identityError = new IdentityError { Description = GetRandomString() };
        IdentityResult failedResult = IdentityResult.Failed(identityError);

        this.userManagerBrokerMock.Setup(broker =>
            broker.RemoveClaimAsync(user, claim))
                .ReturnsAsync(failedResult);

        var expectedException = new FailedClaimsOperationException(
            $"Identity operation failed: {identityError.Description}");

        // When
        Func<Task> action = async () => await this.claimsService.RemoveClaimAsync(user, claim);

        // Then
        FailedClaimsOperationException actualException =
            await Assert.ThrowsAsync<FailedClaimsOperationException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);

        this.userManagerBrokerMock.Verify(broker =>
            broker.RemoveClaimAsync(user, claim),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldThrowFailedClaimsOperationExceptionOnRemoveClaimsAsyncIfIdentityResultFailed()
    {
        // Given
        ApplicationUser user = CreateUser();
        IEnumerable<Claim> claims = CreateClaims();
        var identityError = new IdentityError { Description = GetRandomString() };
        IdentityResult failedResult = IdentityResult.Failed(identityError);

        this.userManagerBrokerMock.Setup(broker =>
            broker.RemoveClaimsAsync(user, claims))
                .ReturnsAsync(failedResult);

        var expectedException = new FailedClaimsOperationException(
            $"Identity operation failed: {identityError.Description}");

        // When
        Func<Task> action = async () => await this.claimsService.RemoveClaimsAsync(user, claims);

        // Then
        FailedClaimsOperationException actualException =
            await Assert.ThrowsAsync<FailedClaimsOperationException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);

        this.userManagerBrokerMock.Verify(broker =>
            broker.RemoveClaimsAsync(user, claims),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }
}