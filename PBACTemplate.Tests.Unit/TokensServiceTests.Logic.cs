// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// TokensServiceTests.Logic.cs See LICENSE.txt in the root folder of the solution.

using PBACTemplate.Data;

namespace PBACTemplate.Tests.Unit;

public partial class TokensServiceTests
{
    [Fact]
    public async Task ShouldGenerateUserTokenAsync()
    {
        // Given
        ApplicationUser inputUser = CreateUser();
        string inputTokenProvider = GetRandomString();
        string inputPurpose = GetRandomString();
        string expectedToken = GetRandomString();

        this.userManagerBrokerMock.Setup(broker =>
            broker.GenerateUserTokenAsync(inputUser, inputTokenProvider, inputPurpose))
                .ReturnsAsync(expectedToken);

        // When
        string actualToken = await this.tokensService
            .GenerateUserTokenAsync(inputUser, inputTokenProvider, inputPurpose);

        // Then
        Assert.Equal(expectedToken, actualToken);

        this.userManagerBrokerMock.Verify(broker =>
            broker.GenerateUserTokenAsync(inputUser, inputTokenProvider, inputPurpose),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldVerifyUserTokenAsync()
    {
        // Given
        ApplicationUser inputUser = CreateUser();
        string inputTokenProvider = GetRandomString();
        string inputPurpose = GetRandomString();
        string inputToken = GetRandomString();
        bool expectedResult = GetRandomBoolean();

        this.userManagerBrokerMock.Setup(broker =>
            broker.VerifyUserTokenAsync(
                inputUser,
                inputTokenProvider,
                inputPurpose,
                inputToken))
                    .ReturnsAsync(expectedResult);

        // When
        bool actualResult = await this.tokensService
            .VerifyUserTokenAsync(inputUser, inputTokenProvider, inputPurpose, inputToken);

        // Then
        Assert.Equal(expectedResult, actualResult);

        this.userManagerBrokerMock.Verify(broker =>
            broker.VerifyUserTokenAsync(
                inputUser,
                inputTokenProvider,
                inputPurpose,
                inputToken),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }
}