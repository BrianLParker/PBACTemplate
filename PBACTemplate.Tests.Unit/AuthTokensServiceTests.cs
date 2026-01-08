// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// AuthTokensServiceTests.cs See LICENSE.txt in the root folder of the solution.

using Microsoft.Extensions.Logging;
using PBACTemplate.Brokers.User;
using PBACTemplate.Data;
using PBACTemplate.Services.Foundations.AuthTokens;

namespace PBACTemplate.Tests.Unit;

public partial class AuthTokensServiceTests
{
    private readonly Mock<IUserManagerBroker> userManagerBrokerMock;
    private readonly Mock<ILogger<AuthTokensService>> loggerMock;
    private readonly IAuthTokensService authTokensService;

    public AuthTokensServiceTests()
    {
        this.userManagerBrokerMock = new Mock<IUserManagerBroker>();
        this.loggerMock = new Mock<ILogger<AuthTokensService>>();

        this.loggerMock.Setup(logger =>
            logger.IsEnabled(It.IsAny<LogLevel>()))
                .Returns(true);

        this.authTokensService = new AuthTokensService(
            this.userManagerBrokerMock.Object,
            this.loggerMock.Object);
    }

    private static ApplicationUser CreateUser() => new() { Id = Guid.NewGuid().ToString() };
    private static string GetRandomString() => Guid.NewGuid().ToString();
    private static bool GetRandomBoolean() => Random.Shared.Next(0, 2) == 1;

    private void VerifyNoOtherBrokerCalls() =>
        this.userManagerBrokerMock.VerifyNoOtherCalls();
}