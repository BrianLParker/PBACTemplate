// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// TokensServiceTests.Exceptions.cs See LICENSE.txt in the root folder of the solution.

using PBACTemplate.Data;
using PBACTemplate.Services.Foundations.Tokens.Exceptions;

namespace PBACTemplate.Tests.Unit;

public partial class TokensServiceTests
{
    [Fact]
    public async Task ShouldThrowTokensServiceExceptionOnGenerateUserTokenAsyncIfExceptionOccurs()
    {
        // Given
        ApplicationUser inputUser = CreateUser();
        string tokenProvider = GetRandomString();
        string purpose = GetRandomString();
        var someException = new Exception(GetRandomString());

        this.userManagerBrokerMock.Setup(broker =>
            broker.GenerateUserTokenAsync(inputUser, tokenProvider, purpose))
                .ThrowsAsync(someException);

        var expectedException = new TokensServiceException(
            "Tokens service error occurred, contact support.",
            new FailedTokensServiceException(
                "Failed tokens service error occurred, contact support.",
                someException));

        // When
        Func<Task> action = async () => await this.tokensService
            .GenerateUserTokenAsync(inputUser, tokenProvider, purpose);

        // Then
        TokensServiceException actualException =
            await Assert.ThrowsAsync<TokensServiceException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);
        Assert.IsType<FailedTokensServiceException>(actualException.InnerException);

        this.userManagerBrokerMock.Verify(broker =>
            broker.GenerateUserTokenAsync(inputUser, tokenProvider, purpose),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldThrowTokensServiceExceptionOnVerifyUserTokenAsyncIfExceptionOccurs()
    {
        // Given
        ApplicationUser inputUser = CreateUser();
        string tokenProvider = GetRandomString();
        string purpose = GetRandomString();
        string token = GetRandomString();
        var someException = new Exception(GetRandomString());

        this.userManagerBrokerMock.Setup(broker =>
            broker.VerifyUserTokenAsync(inputUser, tokenProvider, purpose, token))
                .ThrowsAsync(someException);

        var expectedException = new TokensServiceException(
            "Tokens service error occurred, contact support.",
            new FailedTokensServiceException(
                "Failed tokens service error occurred, contact support.",
                someException));

        // When
        Func<Task> action = async () => await this.tokensService
            .VerifyUserTokenAsync(inputUser, tokenProvider, purpose, token);

        // Then
        TokensServiceException actualException =
            await Assert.ThrowsAsync<TokensServiceException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);
        Assert.IsType<FailedTokensServiceException>(actualException.InnerException);

        this.userManagerBrokerMock.Verify(broker =>
            broker.VerifyUserTokenAsync(inputUser, tokenProvider, purpose, token),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }
}