// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// TokensServiceTests.Validations.cs See LICENSE.txt in the root folder of the solution.

using PBACTemplate.Data;
using PBACTemplate.Services.Foundations.Tokens.Exceptions;

namespace PBACTemplate.Tests.Unit;

public partial class TokensServiceTests
{
    [Fact]
    public async Task ShouldThrowNullTokensExceptionOnGenerateUserTokenAsyncIfUserIsNull()
    {
        // Given
        ApplicationUser? nullUser = null;
        string tokenProvider = GetRandomString();
        string purpose = GetRandomString();

        var expectedException = new NullTokensException("User cannot be null.");

        // When
        Func<Task> action = async () => await this.tokensService
            .GenerateUserTokenAsync(nullUser!, tokenProvider, purpose);

        // Then
        NullTokensException actualException =
            await Assert.ThrowsAsync<NullTokensException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);

        this.userManagerBrokerMock.Verify(broker =>
            broker.GenerateUserTokenAsync(
                It.IsAny<ApplicationUser>(),
                It.IsAny<string>(),
                It.IsAny<string>()),
            Times.Never);

        VerifyNoOtherBrokerCalls();
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("   ")]
    public async Task ShouldThrowInvalidTokensExceptionOnGenerateUserTokenAsyncIfTokenProviderIsInvalid(
        string? invalidTokenProvider)
    {
        // Given
        ApplicationUser user = CreateUser();
        string purpose = GetRandomString();

        var expectedException = new InvalidTokensException(
            "Token provider cannot be null or whitespace.");

        // When
        Func<Task> action = async () => await this.tokensService
            .GenerateUserTokenAsync(user, invalidTokenProvider!, purpose);

        // Then
        InvalidTokensException actualException =
            await Assert.ThrowsAsync<InvalidTokensException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);

        this.userManagerBrokerMock.Verify(broker =>
            broker.GenerateUserTokenAsync(
                It.IsAny<ApplicationUser>(),
                It.IsAny<string>(),
                It.IsAny<string>()),
            Times.Never);

        VerifyNoOtherBrokerCalls();
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("   ")]
    public async Task ShouldThrowInvalidTokensExceptionOnGenerateUserTokenAsyncIfPurposeIsInvalid(
        string? invalidPurpose)
    {
        // Given
        ApplicationUser user = CreateUser();
        string tokenProvider = GetRandomString();

        var expectedException = new InvalidTokensException(
            "Purpose cannot be null or whitespace.");

        // When
        Func<Task> action = async () => await this.tokensService
            .GenerateUserTokenAsync(user, tokenProvider, invalidPurpose!);

        // Then
        InvalidTokensException actualException =
            await Assert.ThrowsAsync<InvalidTokensException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);

        this.userManagerBrokerMock.Verify(broker =>
            broker.GenerateUserTokenAsync(
                It.IsAny<ApplicationUser>(),
                It.IsAny<string>(),
                It.IsAny<string>()),
            Times.Never);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldThrowNullTokensExceptionOnVerifyUserTokenAsyncIfUserIsNull()
    {
        // Given
        ApplicationUser? nullUser = null;
        string tokenProvider = GetRandomString();
        string purpose = GetRandomString();
        string token = GetRandomString();

        var expectedException = new NullTokensException("User cannot be null.");

        // When
        Func<Task> action = async () => await this.tokensService
            .VerifyUserTokenAsync(nullUser!, tokenProvider, purpose, token);

        // Then
        NullTokensException actualException =
            await Assert.ThrowsAsync<NullTokensException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);

        this.userManagerBrokerMock.Verify(broker =>
            broker.VerifyUserTokenAsync(
                It.IsAny<ApplicationUser>(),
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<string>()),
            Times.Never);

        VerifyNoOtherBrokerCalls();
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("   ")]
    public async Task ShouldThrowInvalidTokensExceptionOnVerifyUserTokenAsyncIfTokenProviderIsInvalid(
        string? invalidTokenProvider)
    {
        // Given
        ApplicationUser user = CreateUser();
        string purpose = GetRandomString();
        string token = GetRandomString();

        var expectedException = new InvalidTokensException(
            "Token provider cannot be null or whitespace.");

        // When
        Func<Task> action = async () => await this.tokensService
            .VerifyUserTokenAsync(user, invalidTokenProvider!, purpose, token);

        // Then
        InvalidTokensException actualException =
            await Assert.ThrowsAsync<InvalidTokensException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);

        this.userManagerBrokerMock.Verify(broker =>
            broker.VerifyUserTokenAsync(
                It.IsAny<ApplicationUser>(),
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<string>()),
            Times.Never);

        VerifyNoOtherBrokerCalls();
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("   ")]
    public async Task ShouldThrowInvalidTokensExceptionOnVerifyUserTokenAsyncIfPurposeIsInvalid(
        string? invalidPurpose)
    {
        // Given
        ApplicationUser user = CreateUser();
        string tokenProvider = GetRandomString();
        string token = GetRandomString();

        var expectedException = new InvalidTokensException(
            "Purpose cannot be null or whitespace.");

        // When
        Func<Task> action = async () => await this.tokensService
            .VerifyUserTokenAsync(user, tokenProvider, invalidPurpose!, token);

        // Then
        InvalidTokensException actualException =
            await Assert.ThrowsAsync<InvalidTokensException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);

        this.userManagerBrokerMock.Verify(broker =>
            broker.VerifyUserTokenAsync(
                It.IsAny<ApplicationUser>(),
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<string>()),
            Times.Never);

        VerifyNoOtherBrokerCalls();
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("   ")]
    public async Task ShouldThrowInvalidTokensExceptionOnVerifyUserTokenAsyncIfTokenIsInvalid(
        string? invalidToken)
    {
        // Given
        ApplicationUser user = CreateUser();
        string tokenProvider = GetRandomString();
        string purpose = GetRandomString();

        var expectedException = new InvalidTokensException(
            "Token cannot be null or whitespace.");

        // When
        Func<Task> action = async () => await this.tokensService
            .VerifyUserTokenAsync(user, tokenProvider, purpose, invalidToken!);

        // Then
        InvalidTokensException actualException =
            await Assert.ThrowsAsync<InvalidTokensException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);

        this.userManagerBrokerMock.Verify(broker =>
            broker.VerifyUserTokenAsync(
                It.IsAny<ApplicationUser>(),
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<string>()),
            Times.Never);

        VerifyNoOtherBrokerCalls();
    }
}