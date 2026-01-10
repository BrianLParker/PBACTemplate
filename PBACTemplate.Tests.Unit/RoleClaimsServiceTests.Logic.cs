// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// RoleClaimsServiceTests.Logic.cs See LICENSE.txt in the root folder of the solution.

using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace PBACTemplate.Tests.Unit;

public partial class RoleClaimsServiceTests
{
    [Fact]
    public async Task ShouldRetrieveClaimsAsync()
    {
        // Given
        IdentityRole role = CreateRole();
        IList<Claim> expectedClaims = new List<Claim> { CreateClaim(), CreateClaim() };

        this.roleManagerBrokerMock.Setup(broker =>
            broker.GetClaimsAsync(role))
                .ReturnsAsync(expectedClaims);

        // When
        IList<Claim> actualClaims =
            await this.roleClaimsService.RetrieveClaimsAsync(role);

        // Then
        Assert.Equal(expectedClaims, actualClaims);

        this.roleManagerBrokerMock.Verify(broker =>
            broker.GetClaimsAsync(role),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldAddClaimAsync()
    {
        // Given
        IdentityRole role = CreateRole();
        Claim claim = CreateClaim();

        this.roleManagerBrokerMock.Setup(broker =>
            broker.AddClaimAsync(role, claim))
                .ReturnsAsync(IdentityResult.Success);

        // When
        IdentityRole actualRole =
            await this.roleClaimsService.AddClaimAsync(role, claim);

        // Then
        Assert.Equal(role, actualRole);

        this.roleManagerBrokerMock.Verify(broker =>
            broker.AddClaimAsync(role, claim),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldRemoveClaimAsync()
    {
        // Given
        IdentityRole role = CreateRole();
        Claim claim = CreateClaim();

        this.roleManagerBrokerMock.Setup(broker =>
            broker.RemoveClaimAsync(role, claim))
                .ReturnsAsync(IdentityResult.Success);

        // When
        IdentityRole actualRole =
            await this.roleClaimsService.RemoveClaimAsync(role, claim);

        // Then
        Assert.Equal(role, actualRole);

        this.roleManagerBrokerMock.Verify(broker =>
            broker.RemoveClaimAsync(role, claim),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }
}