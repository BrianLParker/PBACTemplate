// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// RolesServiceTests.cs See LICENSE.txt in the root folder of the solution.

using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Moq;
using PBACTemplate.Brokers.Roles;
using PBACTemplate.Services.Foundations.Roles;

namespace PBACTemplate.Tests.Unit;

public partial class RolesServiceTests
{
    private readonly Mock<IRoleManagerBroker> roleManagerBrokerMock;
    private readonly Mock<ILogger<RolesService>> loggerMock;
    private readonly IRolesService rolesService;

    public RolesServiceTests()
    {
        this.roleManagerBrokerMock = new Mock<IRoleManagerBroker>();
        this.loggerMock = new Mock<ILogger<RolesService>>();

        this.loggerMock.Setup(logger =>
            logger.IsEnabled(It.IsAny<LogLevel>()))
                .Returns(true);

        this.rolesService = new RolesService(
            this.roleManagerBrokerMock.Object,
            this.loggerMock.Object);
    }

    private static IdentityRole CreateRole()
    {
        string name = GetRandomString();

        return new IdentityRole(name)
        {
            Id = Guid.NewGuid().ToString()
        };
    }

    private static string GetRandomString() => Guid.NewGuid().ToString();

    private void VerifyNoOtherBrokerCalls() =>
        this.roleManagerBrokerMock.VerifyNoOtherCalls();
}