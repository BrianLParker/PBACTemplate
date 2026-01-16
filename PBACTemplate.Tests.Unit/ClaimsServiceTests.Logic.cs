// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// ClaimsServiceTests.Logic.cs See LICENSE.txt in the root folder of the solution.

using Microsoft.AspNetCore.Identity;
using PBACTemplate.Models.Users;
using System.Security.Claims;

namespace PBACTemplate.Tests.Unit;

public partial class ClaimsServiceTests
{
    [Fact]
    public async Task ShouldAddClaimAsync()
    {
        // Given
        ApplicationUser inputUser = CreateUser();
        Claim inputClaim = CreateClaim();

        this.userManagerBrokerMock.Setup(broker =>
            broker.AddClaimAsync(inputUser, inputClaim))
                .ReturnsAsync(IdentityResult.Success);

        // When
        ApplicationUser actualUser =
            await this.claimsService.AddClaimAsync(inputUser, inputClaim);

        // Then
        Assert.Equal(inputUser, actualUser);

        this.userManagerBrokerMock.Verify(broker =>
            broker.AddClaimAsync(inputUser, inputClaim),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldAddClaimsAsync()
    {
        // Given
        ApplicationUser inputUser = CreateUser();
        IEnumerable<Claim> inputClaims = CreateClaims();

        this.userManagerBrokerMock.Setup(broker =>
            broker.AddClaimsAsync(inputUser, inputClaims))
                .ReturnsAsync(IdentityResult.Success);

        // When
        ApplicationUser actualUser =
            await this.claimsService.AddClaimsAsync(inputUser, inputClaims);

        // Then
        Assert.Equal(inputUser, actualUser);

        this.userManagerBrokerMock.Verify(broker =>
            broker.AddClaimsAsync(inputUser, inputClaims),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldReplaceClaimAsync()
    {
        // Given
        ApplicationUser inputUser = CreateUser();
        Claim inputClaim = CreateClaim();
        Claim inputNewClaim = CreateClaim();

        this.userManagerBrokerMock.Setup(broker =>
            broker.ReplaceClaimAsync(inputUser, inputClaim, inputNewClaim))
                .ReturnsAsync(IdentityResult.Success);

        // When
        ApplicationUser actualUser =
            await this.claimsService.ReplaceClaimAsync(inputUser, inputClaim, inputNewClaim);

        // Then
        Assert.Equal(inputUser, actualUser);

        this.userManagerBrokerMock.Verify(broker =>
            broker.ReplaceClaimAsync(inputUser, inputClaim, inputNewClaim),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldRemoveClaimAsync()
    {
        // Given
        ApplicationUser inputUser = CreateUser();
        Claim inputClaim = CreateClaim();

        this.userManagerBrokerMock.Setup(broker =>
            broker.RemoveClaimAsync(inputUser, inputClaim))
                .ReturnsAsync(IdentityResult.Success);

        // When
        ApplicationUser actualUser =
            await this.claimsService.RemoveClaimAsync(inputUser, inputClaim);

        // Then
        Assert.Equal(inputUser, actualUser);

        this.userManagerBrokerMock.Verify(broker =>
            broker.RemoveClaimAsync(inputUser, inputClaim),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldRemoveClaimsAsync()
    {
        // Given
        ApplicationUser inputUser = CreateUser();
        IEnumerable<Claim> inputClaims = CreateClaims();

        this.userManagerBrokerMock.Setup(broker =>
            broker.RemoveClaimsAsync(inputUser, inputClaims))
                .ReturnsAsync(IdentityResult.Success);

        // When
        ApplicationUser actualUser =
            await this.claimsService.RemoveClaimsAsync(inputUser, inputClaims);

        // Then
        Assert.Equal(inputUser, actualUser);

        this.userManagerBrokerMock.Verify(broker =>
            broker.RemoveClaimsAsync(inputUser, inputClaims),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldRetrieveClaimsAsync()
    {
        // Given
        ApplicationUser inputUser = CreateUser();
        IList<Claim> expectedClaims = CreateClaims().ToList();

        this.userManagerBrokerMock.Setup(broker =>
            broker.GetClaimsAsync(inputUser))
                .ReturnsAsync(expectedClaims);

        // When
        IList<Claim> actualClaims =
            await this.claimsService.RetrieveClaimsAsync(inputUser);

        // Then
        Assert.Equal(expectedClaims, actualClaims);

        this.userManagerBrokerMock.Verify(broker =>
            broker.GetClaimsAsync(inputUser),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldRetrieveUsersForClaimAsync()
    {
        // Given
        Claim inputClaim = CreateClaim();
        IList<ApplicationUser> expectedUsers = new List<ApplicationUser>
        {
            CreateUser(),
            CreateUser()
        };

        this.userManagerBrokerMock.Setup(broker =>
            broker.GetUsersForClaimAsync(inputClaim))
                .ReturnsAsync(expectedUsers);

        // When
        IList<ApplicationUser> actualUsers =
            await this.claimsService.RetrieveUsersForClaimAsync(inputClaim);

        // Then
        Assert.Equal(expectedUsers, actualUsers);

        this.userManagerBrokerMock.Verify(broker =>
            broker.GetUsersForClaimAsync(inputClaim),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }
}