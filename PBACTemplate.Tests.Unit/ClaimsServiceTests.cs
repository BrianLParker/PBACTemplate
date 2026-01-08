// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// ClaimsServiceTests.cs See LICENSE.txt in the root folder of the solution.

using Microsoft.Extensions.Logging;
using PBACTemplate.Brokers.User;
using PBACTemplate.Data;
using PBACTemplate.Services.Foundations.Claims;
using System.Security.Claims;

namespace PBACTemplate.Tests.Unit;

public partial class ClaimsServiceTests
{
    private readonly Mock<IUserManagerBroker> userManagerBrokerMock;
    private readonly Mock<ILogger<ClaimsService>> loggerMock;
    private readonly IClaimsService claimsService;

    public ClaimsServiceTests()
    {
        this.userManagerBrokerMock = new Mock<IUserManagerBroker>();
        this.loggerMock = new Mock<ILogger<ClaimsService>>();

        this.loggerMock.Setup(logger =>
            logger.IsEnabled(It.IsAny<LogLevel>()))
                .Returns(true);

        this.claimsService = new ClaimsService(
            this.userManagerBrokerMock.Object,
            this.loggerMock.Object);
    }

    private static ApplicationUser CreateUser() => new() { Id = Guid.NewGuid().ToString() };
    private static Claim CreateClaim() => new("type", "value");
    private static IEnumerable<Claim> CreateClaims(int count = 2) =>
        Enumerable.Range(0, count).Select(_ => CreateClaim()).ToList();
    private static string GetRandomString() => Guid.NewGuid().ToString();
    private static int GetRandomNumber() => Random.Shared.Next(1, 1000);

    private void VerifyNoOtherBrokerCalls() =>
        this.userManagerBrokerMock.VerifyNoOtherCalls();
}