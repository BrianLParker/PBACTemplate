// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// PasswordServiceTests.cs See LICENSE.txt in the root folder of the solution.

using Microsoft.Extensions.Logging;
using Moq;
using PBACTemplate.Brokers.User;
using PBACTemplate.Data;
using PBACTemplate.Services.Foundations.Password;

namespace PBACTemplate.Tests.Unit;

public partial class PasswordServiceTests
{
    private readonly Mock<IUserManagerBroker> userManagerBrokerMock;
    private readonly Mock<ILogger<PasswordService>> loggerMock;
    private readonly IPasswordService passwordService;

    public PasswordServiceTests()
    {
        this.userManagerBrokerMock = new Mock<IUserManagerBroker>();
        this.loggerMock = new Mock<ILogger<PasswordService>>();

        this.loggerMock.Setup(logger =>
            logger.IsEnabled(It.IsAny<LogLevel>()))
                .Returns(true);

        this.passwordService = new PasswordService(
            this.userManagerBrokerMock.Object,
            this.loggerMock.Object);
    }

    private static ApplicationUser CreateUser() => new() { Id = Guid.NewGuid().ToString() };
    private static string GetRandomString() => Guid.NewGuid().ToString();
    private static bool GetRandomBoolean() => Random.Shared.Next(0, 2) == 1;

    private void VerifyNoOtherBrokerCalls() =>
        this.userManagerBrokerMock.VerifyNoOtherCalls();
}