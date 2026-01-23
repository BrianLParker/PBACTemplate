// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// RoleServiceTests.cs See LICENSE.txt in the root folder of the solution.

using Microsoft.Extensions.Logging;
using PBACTemplate.Client.Brokers.HttpClients;
using PBACTemplate.Client.Services.Foundations.Roles;

namespace PBACTemplate.Client.Tests.Unit;

public partial class RoleServiceTests
{
    private readonly Mock<IHttpClientBroker> httpClientBrokerMock;
    private readonly Mock<ILogger<RoleService>> loggerMock;
    private readonly IRoleService roleService;

    public RoleServiceTests()
    {
        this.httpClientBrokerMock = new Mock<IHttpClientBroker>();
        this.loggerMock = new Mock<ILogger<RoleService>>();

        this.loggerMock.Setup(logger =>
            logger.IsEnabled(It.IsAny<LogLevel>()))
            .Returns(true);

        this.roleService = new RoleService(
            this.httpClientBrokerMock.Object,
            this.loggerMock.Object);
    }

    private static string GetRandomString() => Guid.NewGuid().ToString();

    private void VerifyNoOtherBrokerCalls() =>
        this.httpClientBrokerMock.VerifyNoOtherCalls();
}
