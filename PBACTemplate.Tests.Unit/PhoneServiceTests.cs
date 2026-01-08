// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// PhoneServiceTests.cs See LICENSE.txt in the root folder of the solution.

using Microsoft.Extensions.Logging;
using PBACTemplate.Brokers.User;
using PBACTemplate.Data;
using PBACTemplate.Services.Foundations.Phone;

namespace PBACTemplate.Tests.Unit;

public partial class PhoneServiceTests
{
    private readonly Mock<IUserManagerBroker> userManagerBrokerMock;
    private readonly Mock<ILogger<PhoneService>> loggerMock;
    private readonly IPhoneService phoneService;

    public PhoneServiceTests()
    {
        this.userManagerBrokerMock = new Mock<IUserManagerBroker>();
        this.loggerMock = new Mock<ILogger<PhoneService>>();

        this.loggerMock.Setup(logger =>
            logger.IsEnabled(It.IsAny<LogLevel>()))
                .Returns(true);

        this.phoneService = new PhoneService(
            this.userManagerBrokerMock.Object,
            this.loggerMock.Object);
    }

    private static ApplicationUser CreateUser() => new() { Id = Guid.NewGuid().ToString() };
    private static string GetRandomString() => Guid.NewGuid().ToString();
    private static bool GetRandomBoolean() => Random.Shared.Next(0, 2) == 1;

    private void VerifyNoOtherBrokerCalls() =>
        this.userManagerBrokerMock.VerifyNoOtherCalls();
}