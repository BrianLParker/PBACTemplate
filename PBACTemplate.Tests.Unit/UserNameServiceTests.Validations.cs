// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// UserNameServiceTests.Validations.cs See LICENSE.txt in the root folder of the solution.

using Microsoft.AspNetCore.Identity;
using PBACTemplate.Models.Users;
using PBACTemplate.Services.Foundations.UserName.Exceptions;
using System.Security.Claims;

namespace PBACTemplate.Tests.Unit;

public partial class UserNameServiceTests
{
    [Fact]
    public void ShouldThrowNullUserNameExceptionOnRetrieveUserNameIfPrincipalIsNull()
    {
        // Given
        ClaimsPrincipal? nullPrincipal = null;
        var expectedException = new NullUserNameException("Claims principal cannot be null.");

        // When
        Action action = () => this.userNameService.RetrieveUserName(nullPrincipal!);

        // Then
        NullUserNameException actualException =
            Assert.Throws<NullUserNameException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);

        this.userManagerBrokerMock.Verify(broker =>
            broker.GetUserName(It.IsAny<ClaimsPrincipal>()),
            Times.Never);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldThrowNullUserNameExceptionOnRetrieveUserNameAsyncIfUserIsNull()
    {
        // Given
        ApplicationUser? nullUser = null;
        var expectedException = new NullUserNameException("User cannot be null.");

        // When
        Func<Task> action = async () => await this.userNameService
            .RetrieveUserNameAsync(nullUser!);

        // Then
        NullUserNameException actualException =
            await Assert.ThrowsAsync<NullUserNameException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);

        this.userManagerBrokerMock.Verify(broker =>
            broker.GetUserNameAsync(It.IsAny<ApplicationUser>()),
            Times.Never);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldThrowNullUserNameExceptionOnSetUserNameAsyncIfUserIsNull()
    {
        // Given
        ApplicationUser? nullUser = null;
        string? userName = GetRandomString();
        var expectedException = new NullUserNameException("User cannot be null.");

        // When
        Func<Task> action = async () => await this.userNameService
            .SetUserNameAsync(nullUser!, userName);

        // Then
        NullUserNameException actualException =
            await Assert.ThrowsAsync<NullUserNameException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);

        this.userManagerBrokerMock.Verify(broker =>
            broker.SetUserNameAsync(
                It.IsAny<ApplicationUser>(),
                It.IsAny<string?>()),
            Times.Never);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldThrowFailedUserNameOperationExceptionOnSetUserNameAsyncIfIdentityResultFailed()
    {
        // Given
        ApplicationUser user = CreateUser();
        string? userName = GetRandomString();
        var identityError = new IdentityError { Description = GetRandomString() };
        IdentityResult failedResult = IdentityResult.Failed(identityError);

        this.userManagerBrokerMock.Setup(broker =>
            broker.SetUserNameAsync(user, userName))
                .ReturnsAsync(failedResult);

        var expectedException = new FailedUserNameOperationException(
            $"Identity operation failed: {identityError.Description}");

        // When
        Func<Task> action = async () => await this.userNameService
            .SetUserNameAsync(user, userName);

        // Then
        FailedUserNameOperationException actualException =
            await Assert.ThrowsAsync<FailedUserNameOperationException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);

        this.userManagerBrokerMock.Verify(broker =>
            broker.SetUserNameAsync(user, userName),
            Times.Once);

        this.userManagerBrokerMock.Verify(broker =>
            broker.UpdateNormalizedUserNameAsync(It.IsAny<ApplicationUser>()),
            Times.Never);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public void ShouldThrowNullUserNameExceptionOnRetrieveUserIdIfPrincipalIsNull()
    {
        // Given
        ClaimsPrincipal? nullPrincipal = null;
        var expectedException = new NullUserNameException("Claims principal cannot be null.");

        // When
        Action action = () => this.userNameService.RetrieveUserId(nullPrincipal!);

        // Then
        NullUserNameException actualException =
            Assert.Throws<NullUserNameException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);

        this.userManagerBrokerMock.Verify(broker =>
            broker.GetUserId(It.IsAny<ClaimsPrincipal>()),
            Times.Never);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldThrowNullUserNameExceptionOnRetrieveUserIdAsyncIfUserIsNull()
    {
        // Given
        ApplicationUser? nullUser = null;
        var expectedException = new NullUserNameException("User cannot be null.");

        // When
        Func<Task> action = async () => await this.userNameService
            .RetrieveUserIdAsync(nullUser!);

        // Then
        NullUserNameException actualException =
            await Assert.ThrowsAsync<NullUserNameException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);

        this.userManagerBrokerMock.Verify(broker =>
            broker.GetUserIdAsync(It.IsAny<ApplicationUser>()),
            Times.Never);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldThrowNullUserNameExceptionOnRetrieveUserAsyncIfPrincipalIsNull()
    {
        // Given
        ClaimsPrincipal? nullPrincipal = null;
        var expectedException = new NullUserNameException("Claims principal cannot be null.");

        // When
        Func<Task> action = async () =>
            await this.userNameService.RetrieveUserAsync(nullPrincipal!);

        // Then
        NullUserNameException actualException =
            await Assert.ThrowsAsync<NullUserNameException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);

        this.userManagerBrokerMock.Verify(broker =>
            broker.GetUserAsync(It.IsAny<ClaimsPrincipal>()),
            Times.Never);

        VerifyNoOtherBrokerCalls();
    }
}