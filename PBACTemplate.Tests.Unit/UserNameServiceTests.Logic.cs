// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// UserNameServiceTests.Logic.cs See LICENSE.txt in the root folder of the solution.

using Microsoft.AspNetCore.Identity;
using PBACTemplate.Data;
using System.Security.Claims;

namespace PBACTemplate.Tests.Unit;

public partial class UserNameServiceTests
{
    [Fact]
    public void ShouldRetrieveUserName()
    {
        // Given
        ClaimsPrincipal principal = CreatePrincipal();
        string? expectedUserName = GetRandomString();

        this.userManagerBrokerMock.Setup(broker =>
            broker.GetUserName(principal))
                .Returns(expectedUserName);

        // When
        string? actualUserName = this.userNameService.RetrieveUserName(principal);

        // Then
        Assert.Equal(expectedUserName, actualUserName);

        this.userManagerBrokerMock.Verify(broker =>
            broker.GetUserName(principal),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldRetrieveUserNameAsync()
    {
        // Given
        ApplicationUser inputUser = CreateUser();
        string? expectedUserName = GetRandomString();

        this.userManagerBrokerMock.Setup(broker =>
            broker.GetUserNameAsync(inputUser))
                .ReturnsAsync(expectedUserName);

        // When
        string? actualUserName =
            await this.userNameService.RetrieveUserNameAsync(inputUser);

        // Then
        Assert.Equal(expectedUserName, actualUserName);

        this.userManagerBrokerMock.Verify(broker =>
            broker.GetUserNameAsync(inputUser),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldSetUserNameAsync()
    {
        // Given
        ApplicationUser inputUser = CreateUser();
        string? inputUserName = GetRandomString();

        this.userManagerBrokerMock.Setup(broker =>
            broker.SetUserNameAsync(inputUser, inputUserName))
                .ReturnsAsync(IdentityResult.Success);

        // When
        ApplicationUser actualUser =
            await this.userNameService.SetUserNameAsync(inputUser, inputUserName);

        // Then
        Assert.Equal(inputUser, actualUser);

        this.userManagerBrokerMock.Verify(broker =>
            broker.SetUserNameAsync(inputUser, inputUserName),
            Times.Once);

        this.userManagerBrokerMock.Verify(broker =>
            broker.UpdateNormalizedUserNameAsync(inputUser),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public void ShouldNormalizeName()
    {
        // Given
        string? inputName = GetRandomString();
        string? expectedName = inputName?.ToLowerInvariant();

        this.userManagerBrokerMock.Setup(broker =>
            broker.NormalizeName(inputName))
                .Returns(expectedName);

        // When
        string? actualName = this.userNameService.NormalizeName(inputName);

        // Then
        Assert.Equal(expectedName, actualName);

        this.userManagerBrokerMock.Verify(broker =>
            broker.NormalizeName(inputName),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public void ShouldRetrieveUserId()
    {
        // Given
        ClaimsPrincipal principal = CreatePrincipal();
        string expectedUserId = GetRandomString();

        this.userManagerBrokerMock.Setup(broker =>
            broker.GetUserId(principal))
                .Returns(expectedUserId);

        // When
        string? actualUserId = this.userNameService.RetrieveUserId(principal);

        // Then
        Assert.Equal(expectedUserId, actualUserId);

        this.userManagerBrokerMock.Verify(broker =>
            broker.GetUserId(principal),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldRetrieveUserIdAsync()
    {
        // Given
        ApplicationUser inputUser = CreateUser();
        string expectedUserId = GetRandomString();

        this.userManagerBrokerMock.Setup(broker =>
            broker.GetUserIdAsync(inputUser))
                .ReturnsAsync(expectedUserId);

        // When
        string actualUserId =
            await this.userNameService.RetrieveUserIdAsync(inputUser);

        // Then
        Assert.Equal(expectedUserId, actualUserId);

        this.userManagerBrokerMock.Verify(broker =>
            broker.GetUserIdAsync(inputUser),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldRetrieveUserAsync()
    {
        // Given
        ClaimsPrincipal principal = CreatePrincipal();
        ApplicationUser? expectedUser = CreateUser();

        this.userManagerBrokerMock.Setup(broker =>
            broker.GetUserAsync(principal))
                .ReturnsAsync(expectedUser);

        // When
        ApplicationUser? actualUser =
            await this.userNameService.RetrieveUserAsync(principal);

        // Then
        Assert.Equal(expectedUser, actualUser);

        this.userManagerBrokerMock.Verify(broker =>
            broker.GetUserAsync(principal),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }
}