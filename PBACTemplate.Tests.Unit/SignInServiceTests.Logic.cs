// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// SignInServiceTests.Logic.cs See LICENSE.txt in the root folder of the solution.

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using PBACTemplate.Models.Users;
using System.Security.Claims;

namespace PBACTemplate.Tests.Unit;

public partial class SignInServiceTests
{
    [Fact]
    public void ShouldCheckIsSignedIn()
    {
        // Given
        ClaimsPrincipal principal = CreatePrincipal();

        this.signInManagerBrokerMock.Setup(broker =>
            broker.IsSignedIn(principal))
                .Returns(true);

        // When
        bool result = this.signInService.IsSignedIn(principal);

        // Then
        Assert.True(result);

        this.signInManagerBrokerMock.Verify(broker =>
            broker.IsSignedIn(principal),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldCheckCanSignInAsync()
    {
        // Given
        ApplicationUser user = CreateUser();

        this.signInManagerBrokerMock.Setup(broker =>
            broker.CanSignInAsync(user))
                .ReturnsAsync(true);

        // When
        bool result = await this.signInService.CanSignInAsync(user);

        // Then
        Assert.True(result);

        this.signInManagerBrokerMock.Verify(broker =>
            broker.CanSignInAsync(user),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldSignInAsync_WithPersistence()
    {
        // Given
        ApplicationUser user = CreateUser();
        bool isPersistent = true;
        string? method = GetRandomString();

        this.signInManagerBrokerMock.Setup(broker =>
            broker.SignInAsync(user, isPersistent, method))
                .Returns(Task.CompletedTask);

        // When
        await this.signInService.SignInAsync(user, isPersistent, method);

        // Then
        this.signInManagerBrokerMock.Verify(broker =>
            broker.SignInAsync(user, isPersistent, method),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldSignInAsync_WithAuthProperties()
    {
        // Given
        ApplicationUser user = CreateUser();
        AuthenticationProperties props = CreateAuthProperties();
        string? method = GetRandomString();

        this.signInManagerBrokerMock.Setup(broker =>
            broker.SignInAsync(user, props, method))
                .Returns(Task.CompletedTask);

        // When
        await this.signInService.SignInAsync(user, props, method);

        // Then
        this.signInManagerBrokerMock.Verify(broker =>
            broker.SignInAsync(user, props, method),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldSignInWithClaimsAsync_WithPersistence()
    {
        // Given
        ApplicationUser user = CreateUser();
        bool isPersistent = GetRandomBytes()[0] % 2 == 0;
        IEnumerable<Claim> claims = new[] { CreateClaim() };

        this.signInManagerBrokerMock.Setup(broker =>
            broker.SignInWithClaimsAsync(user, isPersistent, claims))
                .Returns(Task.CompletedTask);

        // When
        await this.signInService.SignInWithClaimsAsync(user, isPersistent, claims);

        // Then
        this.signInManagerBrokerMock.Verify(broker =>
            broker.SignInWithClaimsAsync(user, isPersistent, claims),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldSignInWithClaimsAsync_WithAuthProperties()
    {
        // Given
        ApplicationUser user = CreateUser();
        AuthenticationProperties? props = CreateAuthProperties();
        IEnumerable<Claim> claims = new[] { CreateClaim() };

        this.signInManagerBrokerMock.Setup(broker =>
            broker.SignInWithClaimsAsync(user, props, claims))
                .Returns(Task.CompletedTask);

        // When
        await this.signInService.SignInWithClaimsAsync(user, props, claims);

        // Then
        this.signInManagerBrokerMock.Verify(broker =>
            broker.SignInWithClaimsAsync(user, props, claims),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldRefreshSignInAsync()
    {
        // Given
        ApplicationUser user = CreateUser();

        this.signInManagerBrokerMock.Setup(broker =>
            broker.RefreshSignInAsync(user))
                .Returns(Task.CompletedTask);

        // When
        await this.signInService.RefreshSignInAsync(user);

        // Then
        this.signInManagerBrokerMock.Verify(broker =>
            broker.RefreshSignInAsync(user),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldSignOutAsync()
    {
        // Given
        this.signInManagerBrokerMock.Setup(broker =>
            broker.SignOutAsync())
                .Returns(Task.CompletedTask);

        // When
        await this.signInService.SignOutAsync();

        // Then
        this.signInManagerBrokerMock.Verify(broker =>
            broker.SignOutAsync(),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldCreateUserPrincipalAsync()
    {
        // Given
        ApplicationUser user = CreateUser();
        ClaimsPrincipal expectedPrincipal = CreatePrincipal();

        this.signInManagerBrokerMock.Setup(broker =>
            broker.CreateUserPrincipalAsync(user))
                .ReturnsAsync(expectedPrincipal);

        // When
        ClaimsPrincipal actualPrincipal =
            await this.signInService.CreateUserPrincipalAsync(user);

        // Then
        Assert.Equal(expectedPrincipal, actualPrincipal);

        this.signInManagerBrokerMock.Verify(broker =>
            broker.CreateUserPrincipalAsync(user),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldPasswordSignInAsync_ByUser()
    {
        // Given
        ApplicationUser user = CreateUser();
        string password = GetRandomString();
        bool isPersistent = true;
        bool lockoutOnFailure = false;
        SignInResult expectedResult = SignInResult.Success;

        this.signInManagerBrokerMock.Setup(broker =>
            broker.PasswordSignInAsync(user, password, isPersistent, lockoutOnFailure))
                .ReturnsAsync(expectedResult);

        // When
        SignInResult actualResult =
            await this.signInService.PasswordSignInAsync(user, password, isPersistent, lockoutOnFailure);

        // Then
        Assert.Equal(expectedResult, actualResult);

        this.signInManagerBrokerMock.Verify(broker =>
            broker.PasswordSignInAsync(user, password, isPersistent, lockoutOnFailure),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldPasswordSignInAsync_ByUserName()
    {
        // Given
        string userName = GetRandomString();
        string password = GetRandomString();
        bool isPersistent = false;
        bool lockoutOnFailure = true;
        SignInResult expectedResult = SignInResult.Success;

        this.signInManagerBrokerMock.Setup(broker =>
            broker.PasswordSignInAsync(userName, password, isPersistent, lockoutOnFailure))
                .ReturnsAsync(expectedResult);

        // When
        SignInResult actualResult =
            await this.signInService.PasswordSignInAsync(userName, password, isPersistent, lockoutOnFailure);

        // Then
        Assert.Equal(expectedResult, actualResult);

        this.signInManagerBrokerMock.Verify(broker =>
            broker.PasswordSignInAsync(userName, password, isPersistent, lockoutOnFailure),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldCheckPasswordSignInAsync()
    {
        // Given
        ApplicationUser user = CreateUser();
        string password = GetRandomString();
        bool lockoutOnFailure = true;
        SignInResult expectedResult = SignInResult.Success;

        this.signInManagerBrokerMock.Setup(broker =>
            broker.CheckPasswordSignInAsync(user, password, lockoutOnFailure))
                .ReturnsAsync(expectedResult);

        // When
        SignInResult actualResult =
            await this.signInService.CheckPasswordSignInAsync(user, password, lockoutOnFailure);

        // Then
        Assert.Equal(expectedResult, actualResult);

        this.signInManagerBrokerMock.Verify(broker =>
            broker.CheckPasswordSignInAsync(user, password, lockoutOnFailure),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldCheckTwoFactorClientRememberedAsync()
    {
        // Given
        ApplicationUser user = CreateUser();

        this.signInManagerBrokerMock.Setup(broker =>
            broker.IsTwoFactorClientRememberedAsync(user))
                .ReturnsAsync(true);

        // When
        bool result = await this.signInService.IsTwoFactorClientRememberedAsync(user);

        // Then
        Assert.True(result);

        this.signInManagerBrokerMock.Verify(broker =>
            broker.IsTwoFactorClientRememberedAsync(user),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldRememberTwoFactorClientAsync()
    {
        // Given
        ApplicationUser user = CreateUser();

        this.signInManagerBrokerMock.Setup(broker =>
            broker.RememberTwoFactorClientAsync(user))
                .Returns(Task.CompletedTask);

        // When
        await this.signInService.RememberTwoFactorClientAsync(user);

        // Then
        this.signInManagerBrokerMock.Verify(broker =>
            broker.RememberTwoFactorClientAsync(user),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldForgetTwoFactorClientAsync()
    {
        // Given
        this.signInManagerBrokerMock.Setup(broker =>
            broker.ForgetTwoFactorClientAsync())
                .Returns(Task.CompletedTask);

        // When
        await this.signInService.ForgetTwoFactorClientAsync();

        // Then
        this.signInManagerBrokerMock.Verify(broker =>
            broker.ForgetTwoFactorClientAsync(),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldTwoFactorRecoveryCodeSignInAsync()
    {
        // Given
        string recoveryCode = GetRandomString();
        SignInResult expected = SignInResult.Success;

        this.signInManagerBrokerMock.Setup(broker =>
            broker.TwoFactorRecoveryCodeSignInAsync(recoveryCode))
                .ReturnsAsync(expected);

        // When
        SignInResult actual =
            await this.signInService.TwoFactorRecoveryCodeSignInAsync(recoveryCode);

        // Then
        Assert.Equal(expected, actual);

        this.signInManagerBrokerMock.Verify(broker =>
            broker.TwoFactorRecoveryCodeSignInAsync(recoveryCode),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldTwoFactorAuthenticatorSignInAsync()
    {
        // Given
        string code = GetRandomString();
        bool isPersistent = true;
        bool rememberClient = false;
        SignInResult expected = SignInResult.Success;

        this.signInManagerBrokerMock.Setup(broker =>
            broker.TwoFactorAuthenticatorSignInAsync(code, isPersistent, rememberClient))
                .ReturnsAsync(expected);

        // When
        SignInResult actual =
            await this.signInService.TwoFactorAuthenticatorSignInAsync(code, isPersistent, rememberClient);

        // Then
        Assert.Equal(expected, actual);

        this.signInManagerBrokerMock.Verify(broker =>
            broker.TwoFactorAuthenticatorSignInAsync(code, isPersistent, rememberClient),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldTwoFactorSignInAsync()
    {
        // Given
        string provider = GetRandomString();
        string code = GetRandomString();
        bool isPersistent = false;
        bool rememberClient = true;
        SignInResult expected = SignInResult.Success;

        this.signInManagerBrokerMock.Setup(broker =>
            broker.TwoFactorSignInAsync(provider, code, isPersistent, rememberClient))
                .ReturnsAsync(expected);

        // When
        SignInResult actual =
            await this.signInService.TwoFactorSignInAsync(provider, code, isPersistent, rememberClient);

        // Then
        Assert.Equal(expected, actual);

        this.signInManagerBrokerMock.Verify(broker =>
            broker.TwoFactorSignInAsync(provider, code, isPersistent, rememberClient),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldGetTwoFactorAuthenticationUserAsync()
    {
        // Given
        ApplicationUser expectedUser = CreateUser();

        this.signInManagerBrokerMock.Setup(broker =>
            broker.GetTwoFactorAuthenticationUserAsync())
                .ReturnsAsync(expectedUser);

        // When
        ApplicationUser? actualUser =
            await this.signInService.GetTwoFactorAuthenticationUserAsync();

        // Then
        Assert.Equal(expectedUser, actualUser);

        this.signInManagerBrokerMock.Verify(broker =>
            broker.GetTwoFactorAuthenticationUserAsync(),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldExternalLoginSignInAsync()
    {
        // Given
        string loginProvider = GetRandomString();
        string providerKey = GetRandomString();
        bool isPersistent = true;
        SignInResult expected = SignInResult.Success;

        this.signInManagerBrokerMock.Setup(broker =>
            broker.ExternalLoginSignInAsync(loginProvider, providerKey, isPersistent))
                .ReturnsAsync(expected);

        // When
        SignInResult actual =
            await this.signInService.ExternalLoginSignInAsync(loginProvider, providerKey, isPersistent);

        // Then
        Assert.Equal(expected, actual);

        this.signInManagerBrokerMock.Verify(broker =>
            broker.ExternalLoginSignInAsync(loginProvider, providerKey, isPersistent),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldExternalLoginSignInWithBypassAsync()
    {
        // Given
        string loginProvider = GetRandomString();
        string providerKey = GetRandomString();
        bool isPersistent = false;
        bool bypass = true;
        SignInResult expected = SignInResult.Success;

        this.signInManagerBrokerMock.Setup(broker =>
            broker.ExternalLoginSignInAsync(loginProvider, providerKey, isPersistent, bypass))
                .ReturnsAsync(expected);

        // When
        SignInResult actual =
            await this.signInService.ExternalLoginSignInAsync(loginProvider, providerKey, isPersistent, bypass);

        // Then
        Assert.Equal(expected, actual);

        this.signInManagerBrokerMock.Verify(broker =>
            broker.ExternalLoginSignInAsync(loginProvider, providerKey, isPersistent, bypass),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldGetExternalAuthenticationSchemesAsync()
    {
        // Given
        IEnumerable<AuthenticationScheme> expected = new[]
        {
            new AuthenticationScheme("a", "a", typeof(TestAuthenticationHandler))
        };

        this.signInManagerBrokerMock.Setup(broker =>
            broker.GetExternalAuthenticationSchemesAsync())
                .ReturnsAsync(expected);

        // When
        IEnumerable<AuthenticationScheme> actual =
            await this.signInService.GetExternalAuthenticationSchemesAsync();

        // Then
        Assert.Equal(expected, actual);

        this.signInManagerBrokerMock.Verify(broker =>
            broker.GetExternalAuthenticationSchemesAsync(),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    private sealed class TestAuthenticationHandler : IAuthenticationHandler
    {
        public Task InitializeAsync(AuthenticationScheme scheme, HttpContext context) =>
            Task.CompletedTask;

        public Task<AuthenticateResult> AuthenticateAsync() =>
            Task.FromResult(AuthenticateResult.NoResult());

        public Task ChallengeAsync(AuthenticationProperties? properties) =>
            Task.CompletedTask;

        public Task ForbidAsync(AuthenticationProperties? properties) =>
            Task.CompletedTask;
    }

    [Fact]
    public async Task ShouldGetExternalLoginInfoAsync()
    {
        // Given
        string? xsrf = GetRandomString();
        ExternalLoginInfo expected = CreateExternalLoginInfo();

        this.signInManagerBrokerMock.Setup(broker =>
            broker.GetExternalLoginInfoAsync(xsrf))
                .ReturnsAsync(expected);

        // When
        ExternalLoginInfo? actual =
            await this.signInService.GetExternalLoginInfoAsync(xsrf);

        // Then
        Assert.Equal(expected, actual);

        this.signInManagerBrokerMock.Verify(broker =>
            broker.GetExternalLoginInfoAsync(xsrf),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldUpdateExternalAuthenticationTokensAsync()
    {
        // Given
        ExternalLoginInfo info = CreateExternalLoginInfo();
        IdentityResult expected = IdentityResult.Success;

        this.signInManagerBrokerMock.Setup(broker =>
            broker.UpdateExternalAuthenticationTokensAsync(info))
                .ReturnsAsync(expected);

        // When
        IdentityResult actual =
            await this.signInService.UpdateExternalAuthenticationTokensAsync(info);

        // Then
        Assert.Equal(expected, actual);

        this.signInManagerBrokerMock.Verify(broker =>
            broker.UpdateExternalAuthenticationTokensAsync(info),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldMakePasskeyRequestOptionsAsync()
    {
        // Given
        ApplicationUser user = CreateUser();
        string expected = GetRandomString();

        this.signInManagerBrokerMock.Setup(broker =>
            broker.MakePasskeyRequestOptionsAsync(user))
                .ReturnsAsync(expected);

        // When
        string actual =
            await this.signInService.MakePasskeyRequestOptionsAsync(user);

        // Then
        Assert.Equal(expected, actual);

        this.signInManagerBrokerMock.Verify(broker =>
            broker.MakePasskeyRequestOptionsAsync(user),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldMakePasskeyCreationOptionsAsync()
    {
        // Given
        PasskeyUserEntity passkeyUser = CreatePasskeyUserEntity();
        string expected = GetRandomString();

        this.signInManagerBrokerMock.Setup(broker =>
            broker.MakePasskeyCreationOptionsAsync(passkeyUser))
                .ReturnsAsync(expected);

        // When
        string actual =
            await this.signInService.MakePasskeyCreationOptionsAsync(passkeyUser);

        // Then
        Assert.Equal(expected, actual);

        this.signInManagerBrokerMock.Verify(broker =>
            broker.MakePasskeyCreationOptionsAsync(passkeyUser),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldPasskeySignInAsync()
    {
        // Given
        string credentialJson = GetRandomString();
        SignInResult expected = SignInResult.Success;

        this.signInManagerBrokerMock.Setup(broker =>
            broker.PasskeySignInAsync(credentialJson))
                .ReturnsAsync(expected);

        // When
        SignInResult actual =
            await this.signInService.PasskeySignInAsync(credentialJson);

        // Then
        Assert.Equal(expected, actual);

        this.signInManagerBrokerMock.Verify(broker =>
            broker.PasskeySignInAsync(credentialJson),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldPerformPasskeyAttestationAsync()
    {
        // Given
        string credentialJson = GetRandomString();
        UserPasskeyInfo passkey = CreatePasskey();
        PasskeyUserEntity userEntity = CreatePasskeyUserEntity();
        PasskeyAttestationResult expected = PasskeyAttestationResult.Success(
            passkey: passkey,
            userEntity: userEntity);

        this.signInManagerBrokerMock.Setup(broker =>
            broker.PerformPasskeyAttestationAsync(credentialJson))
                .ReturnsAsync(expected);

        // When
        PasskeyAttestationResult actual =
            await this.signInService.PerformPasskeyAttestationAsync(credentialJson);

        // Then
        Assert.Equal(expected, actual);

        this.signInManagerBrokerMock.Verify(broker =>
            broker.PerformPasskeyAttestationAsync(credentialJson),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }
}