// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// PasskeysServiceTests.Logic.cs See LICENSE.txt in the root folder of the solution.

using Microsoft.AspNetCore.Identity;
using Moq;
using PBACTemplate.Data;

namespace PBACTemplate.Tests.Unit;

public partial class PasskeysServiceTests
{
    [Fact]
    public async Task ShouldAddOrUpdatePasskeyAsync()
    {
        // Given
        ApplicationUser inputUser = CreateUser();
        UserPasskeyInfo inputPasskey = CreatePasskey();

        this.userManagerBrokerMock.Setup(broker =>
            broker.AddOrUpdatePasskeyAsync(inputUser, inputPasskey))
                .ReturnsAsync(IdentityResult.Success);

        // When
        ApplicationUser actualUser =
            await this.passkeysService.AddOrUpdatePasskeyAsync(inputUser, inputPasskey);

        // Then
        Assert.Equal(inputUser, actualUser);

        this.userManagerBrokerMock.Verify(broker =>
            broker.AddOrUpdatePasskeyAsync(inputUser, inputPasskey),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldRetrievePasskeysAsync()
    {
        // Given
        ApplicationUser inputUser = CreateUser();
        IList<UserPasskeyInfo> expectedPasskeys = new List<UserPasskeyInfo>
        {
            CreatePasskey(),
            CreatePasskey()
        };

        this.userManagerBrokerMock.Setup(broker =>
            broker.GetPasskeysAsync(inputUser))
                .ReturnsAsync(expectedPasskeys);

        // When
        IList<UserPasskeyInfo> actualPasskeys =
            await this.passkeysService.RetrievePasskeysAsync(inputUser);

        // Then
        Assert.Equal(expectedPasskeys, actualPasskeys);

        this.userManagerBrokerMock.Verify(broker =>
            broker.GetPasskeysAsync(inputUser),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldRetrievePasskeyAsync()
    {
        // Given
        ApplicationUser inputUser = CreateUser();
        byte[] credentialId = CreateCredentialId();
        UserPasskeyInfo? expectedPasskey = CreatePasskey();

        this.userManagerBrokerMock.Setup(broker =>
            broker.GetPasskeyAsync(inputUser, credentialId))
                .ReturnsAsync(expectedPasskey);

        // When
        UserPasskeyInfo? actualPasskey =
            await this.passkeysService.RetrievePasskeyAsync(inputUser, credentialId);

        // Then
        Assert.Equal(expectedPasskey, actualPasskey);

        this.userManagerBrokerMock.Verify(broker =>
            broker.GetPasskeyAsync(inputUser, credentialId),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldRetrieveUserByPasskeyIdAsync()
    {
        // Given
        byte[] credentialId = CreateCredentialId();
        ApplicationUser? expectedUser = CreateUser();

        this.userManagerBrokerMock.Setup(broker =>
            broker.FindByPasskeyIdAsync(credentialId))
                .ReturnsAsync(expectedUser);

        // When
        ApplicationUser? actualUser =
            await this.passkeysService.RetrieveUserByPasskeyIdAsync(credentialId);

        // Then
        Assert.Equal(expectedUser, actualUser);

        this.userManagerBrokerMock.Verify(broker =>
            broker.FindByPasskeyIdAsync(credentialId),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldRemovePasskeyAsync()
    {
        // Given
        ApplicationUser inputUser = CreateUser();
        byte[] credentialId = CreateCredentialId();

        this.userManagerBrokerMock.Setup(broker =>
            broker.RemovePasskeyAsync(inputUser, credentialId))
                .ReturnsAsync(IdentityResult.Success);

        // When
        ApplicationUser actualUser =
            await this.passkeysService.RemovePasskeyAsync(inputUser, credentialId);

        // Then
        Assert.Equal(inputUser, actualUser);

        this.userManagerBrokerMock.Verify(broker =>
            broker.RemovePasskeyAsync(inputUser, credentialId),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }
}