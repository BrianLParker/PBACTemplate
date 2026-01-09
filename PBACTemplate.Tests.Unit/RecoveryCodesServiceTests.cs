// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// RecoveryCodesServiceTests.cs See LICENSE.txt in the root folder of the solution.

using Microsoft.Extensions.Logging;
using PBACTemplate.Brokers.User;
using PBACTemplate.Models.User;
using PBACTemplate.Services.Foundations.RecoveryCodes;

namespace PBACTemplate.Tests.Unit;

public partial class RecoveryCodesServiceTests
{
    private readonly Mock<IUserManagerBroker> userManagerBrokerMock;
    private readonly Mock<ILogger<RecoveryCodesService>> loggerMock;
    private readonly IRecoveryCodesService recoveryCodesService;

    public RecoveryCodesServiceTests()
    {
        this.userManagerBrokerMock = new Mock<IUserManagerBroker>();
        this.loggerMock = new Mock<ILogger<RecoveryCodesService>>();

        this.loggerMock.Setup(logger =>
            logger.IsEnabled(It.IsAny<LogLevel>()))
                .Returns(true);

        this.recoveryCodesService = new RecoveryCodesService(
            this.userManagerBrokerMock.Object,
            this.loggerMock.Object);
    }

    private static ApplicationUser CreateUser() => new() { Id = Guid.NewGuid().ToString() };
    private static string GetRandomString() => Guid.NewGuid().ToString();
    private static int GetRandomInt() => Random.Shared.Next(1, 10);

    private void VerifyNoOtherBrokerCalls() =>
        this.userManagerBrokerMock.VerifyNoOtherCalls();
}