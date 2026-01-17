// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// SignInServiceTests.Validations.cs See LICENSE.txt in the root folder of the solution.

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using PBACTemplate.Models.Users;
using PBACTemplate.Services.Foundations.SignIn.Exceptions;
using System.Security.Claims;

namespace PBACTemplate.Tests.Unit;

public partial class SignInServiceTests
{
    [Fact]
    public void ShouldThrowNullSignInExceptionOnIsSignedInWhenPrincipalIsNull()
    {
        // Given
        ClaimsPrincipal? nullPrincipal = null;

        // When
        Action action = () => this.signInService.IsSignedIn(nullPrincipal!);

        // Then
        Assert.Throws<NullSignInException>(action);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldThrowNullSignInExceptionOnCanSignInWhenUserIsNullAsync()
    {
        // Given
        ApplicationUser? nullUser = null;

        // When
        Func<Task> action = async () =>
            await this.signInService.CanSignInAsync(nullUser!);

        // Then
        await Assert.ThrowsAsync<NullSignInException>(action);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldThrowNullSignInExceptionOnSignInWithPropertiesWhenAuthPropertiesNullAsync()
    {
        // Given
        ApplicationUser user = CreateUser();
        AuthenticationProperties? nullProps = null;

        // When
        Func<Task> action = async () =>
            await this.signInService.SignInAsync(user, nullProps!, GetRandomString());

        // Then
        await Assert.ThrowsAsync<NullSignInException>(action);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldThrowNullSignInExceptionOnSignInWithClaimsWhenClaimsNullAsync()
    {
        // Given
        ApplicationUser user = CreateUser();
        IEnumerable<Claim>? nullClaims = null;

        // When
        Func<Task> action = async () =>
            await this.signInService.SignInWithClaimsAsync(user, true, nullClaims!);

        // Then
        await Assert.ThrowsAsync<NullSignInException>(action);

        VerifyNoOtherBrokerCalls();
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData(" ")]
    public async Task ShouldThrowInvalidSignInExceptionOnPasswordSignInWhenPasswordInvalidAsync(string? invalidPassword)
    {
        // Given
        ApplicationUser user = CreateUser();

        // When
        Func<Task> action = async () =>
            await this.signInService.PasswordSignInAsync(user, invalidPassword!, true, false);

        // Then
        await Assert.ThrowsAsync<InvalidSignInException>(action);

        VerifyNoOtherBrokerCalls();
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData(" ")]
    public async Task ShouldThrowInvalidSignInExceptionOnPasswordSignInByUserNameWhenUserNameInvalidAsync(string? invalidUserName)
    {
        // Given
        string password = GetRandomString();

        // When
        Func<Task> action = async () =>
            await this.signInService.PasswordSignInAsync(invalidUserName!, password, true, false);

        // Then
        await Assert.ThrowsAsync<InvalidSignInException>(action);

        VerifyNoOtherBrokerCalls();
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData(" ")]
    public async Task ShouldThrowInvalidSignInExceptionOnTwoFactorRecoveryCodeWhenCodeInvalidAsync(string? invalidCode)
    {
        // Given
        // When
        Func<Task> action = async () =>
            await this.signInService.TwoFactorRecoveryCodeSignInAsync(invalidCode!);

        // Then
        await Assert.ThrowsAsync<InvalidSignInException>(action);

        VerifyNoOtherBrokerCalls();
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData(" ")]
    public async Task ShouldThrowInvalidSignInExceptionOnExternalLoginWhenProviderInvalidAsync(string? invalidProvider)
    {
        // Given
        string providerKey = GetRandomString();

        // When
        Func<Task> action = async () =>
            await this.signInService.ExternalLoginSignInAsync(invalidProvider!, providerKey, true);

        // Then
        await Assert.ThrowsAsync<InvalidSignInException>(action);

        VerifyNoOtherBrokerCalls();
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData(" ")]
    public async Task ShouldThrowInvalidSignInExceptionOnExternalLoginWhenProviderKeyInvalidAsync(string? invalidProviderKey)
    {
        // Given
        string provider = GetRandomString();

        // When
        Func<Task> action = async () =>
            await this.signInService.ExternalLoginSignInAsync(provider, invalidProviderKey!, true);

        // Then
        await Assert.ThrowsAsync<InvalidSignInException>(action);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldThrowNullSignInExceptionOnUpdateExternalAuthenticationTokensWhenInfoNullAsync()
    {
        // Given
        ExternalLoginInfo? nullInfo = null;

        // When
        Func<Task> action = async () =>
            await this.signInService.UpdateExternalAuthenticationTokensAsync(nullInfo!);

        // Then
        await Assert.ThrowsAsync<NullSignInException>(action);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldThrowNullSignInExceptionOnMakePasskeyCreationOptionsWhenUserEntityNullAsync()
    {
        // Given
        PasskeyUserEntity? nullEntity = null;

        // When
        Func<Task> action = async () =>
            await this.signInService.MakePasskeyCreationOptionsAsync(nullEntity!);

        // Then
        await Assert.ThrowsAsync<NullSignInException>(action);

        VerifyNoOtherBrokerCalls();
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData(" ")]
    public async Task ShouldThrowInvalidSignInExceptionOnPasskeySignInWhenCredentialJsonInvalidAsync(string? invalidJson)
    {
        // Given
        // When
        Func<Task> action = async () =>
            await this.signInService.PasskeySignInAsync(invalidJson!);

        // Then
        await Assert.ThrowsAsync<InvalidSignInException>(action);

        VerifyNoOtherBrokerCalls();
    }
}