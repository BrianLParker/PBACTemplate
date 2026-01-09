// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// LoginServiceTests.Logic.cs See LICENSE.txt in the root folder of the solution.

using Microsoft.AspNetCore.Identity;
using PBACTemplate.Models.User;

namespace PBACTemplate.Tests.Unit;

public partial class LoginServiceTests
{
    [Fact]
    public async Task ShouldAddLoginAsync()
    {
        // Given
        ApplicationUser inputUser = CreateUser();
        UserLoginInfo inputLogin = CreateLogin();

        this.userManagerBrokerMock.Setup(broker =>
            broker.AddLoginAsync(inputUser, inputLogin))
                .ReturnsAsync(IdentityResult.Success);

        // When
        ApplicationUser actualUser =
            await this.loginService.AddLoginAsync(inputUser, inputLogin);

        // Then
        Assert.Equal(inputUser, actualUser);

        this.userManagerBrokerMock.Verify(broker =>
            broker.AddLoginAsync(inputUser, inputLogin),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldRemoveLoginAsync()
    {
        // Given
        ApplicationUser inputUser = CreateUser();
        string inputProvider = GetRandomString();
        string inputProviderKey = GetRandomString();

        this.userManagerBrokerMock.Setup(broker =>
            broker.RemoveLoginAsync(inputUser, inputProvider, inputProviderKey))
                .ReturnsAsync(IdentityResult.Success);

        // When
        ApplicationUser actualUser =
            await this.loginService.RemoveLoginAsync(inputUser, inputProvider, inputProviderKey);

        // Then
        Assert.Equal(inputUser, actualUser);

        this.userManagerBrokerMock.Verify(broker =>
            broker.RemoveLoginAsync(inputUser, inputProvider, inputProviderKey),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldRetrieveLoginsAsync()
    {
        // Given
        ApplicationUser inputUser = CreateUser();
        IList<UserLoginInfo> expectedLogins = new List<UserLoginInfo>
        {
            CreateLogin(),
            CreateLogin()
        };

        this.userManagerBrokerMock.Setup(broker =>
            broker.GetLoginsAsync(inputUser))
                .ReturnsAsync(expectedLogins);

        // When
        IList<UserLoginInfo> actualLogins =
            await this.loginService.RetrieveLoginsAsync(inputUser);

        // Then
        Assert.Equal(expectedLogins, actualLogins);

        this.userManagerBrokerMock.Verify(broker =>
            broker.GetLoginsAsync(inputUser),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }
}