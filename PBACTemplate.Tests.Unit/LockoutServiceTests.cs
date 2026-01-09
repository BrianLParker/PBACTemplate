// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// LockoutServiceTests.cs See LICENSE.txt in the root folder of the solution.

using Microsoft.Extensions.Logging;
using PBACTemplate.Brokers.User;
using PBACTemplate.Models.User;
using PBACTemplate.Services.Foundations.Lockout;

namespace PBACTemplate.Tests.Unit;

public partial class LockoutServiceTests
{
    private readonly Mock<IUserManagerBroker> userManagerBrokerMock;
    private readonly Mock<ILogger<LockoutService>> loggerMock;
    private readonly ILockoutService lockoutService;

    public LockoutServiceTests()
    {
        this.userManagerBrokerMock = new Mock<IUserManagerBroker>();
        this.loggerMock = new Mock<ILogger<LockoutService>>();

        this.loggerMock.Setup(logger =>
            logger.IsEnabled(It.IsAny<LogLevel>()))
                .Returns(true);

        this.lockoutService = new LockoutService(
            this.userManagerBrokerMock.Object,
            this.loggerMock.Object);
    }

    private static ApplicationUser CreateUser() => new() { Id = Guid.NewGuid().ToString() };
    private static string GetRandomString() => Guid.NewGuid().ToString();
    private static bool GetRandomBoolean() => Random.Shared.Next(0, 2) == 1;
    private static DateTimeOffset GetRandomDateTimeOffset() => DateTimeOffset.UtcNow.AddMinutes(Random.Shared.Next(1, 60));

    private void VerifyNoOtherBrokerCalls() =>
        this.userManagerBrokerMock.VerifyNoOtherCalls();
}