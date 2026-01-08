// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// SignInServiceTests.Exceptions.cs See LICENSE.txt in the root folder of the solution.

using PBACTemplate.Data;
using PBACTemplate.Services.Foundations.SignIn.Exceptions;
using System.Security.Claims;

namespace PBACTemplate.Tests.Unit;

public partial class SignInServiceTests
{
    [Fact]
    public void ShouldThrowSignInServiceExceptionOnIsSignedInWhenBrokerThrows()
    {
        // Given
        ClaimsPrincipal principal = CreatePrincipal();
        var serviceException = new Exception(GetRandomString());

        this.signInManagerBrokerMock.Setup(broker =>
            broker.IsSignedIn(principal))
                .Throws(serviceException);

        // When
        Action action = () => this.signInService.IsSignedIn(principal);

        // Then
        Assert.Throws<SignInServiceException>(action);

        this.signInManagerBrokerMock.Verify(broker =>
            broker.IsSignedIn(principal),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldThrowSignInServiceExceptionOnSignInAsyncWhenBrokerThrowsAsync()
    {
        // Given
        ApplicationUser user = CreateUser();
        bool isPersistent = true;
        var serviceException = new Exception(GetRandomString());

        this.signInManagerBrokerMock.Setup(broker =>
            broker.SignInAsync(user, isPersistent, null))
                .ThrowsAsync(serviceException);

        // When
        Func<Task> action = async () =>
            await this.signInService.SignInAsync(user, isPersistent, null);

        // Then
        await Assert.ThrowsAsync<SignInServiceException>(action);

        this.signInManagerBrokerMock.Verify(broker =>
            broker.SignInAsync(user, isPersistent, null),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldThrowSignInServiceExceptionOnPasswordSignInAsyncWhenBrokerThrowsAsync()
    {
        // Given
        ApplicationUser user = CreateUser();
        string password = GetRandomString();
        bool isPersistent = false;
        bool lockoutOnFailure = true;
        var serviceException = new Exception(GetRandomString());

        this.signInManagerBrokerMock.Setup(broker =>
            broker.PasswordSignInAsync(user, password, isPersistent, lockoutOnFailure))
                .ThrowsAsync(serviceException);

        // When
        Func<Task> action = async () =>
            await this.signInService.PasswordSignInAsync(user, password, isPersistent, lockoutOnFailure);

        // Then
        await Assert.ThrowsAsync<SignInServiceException>(action);

        this.signInManagerBrokerMock.Verify(broker =>
            broker.PasswordSignInAsync(user, password, isPersistent, lockoutOnFailure),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }
}