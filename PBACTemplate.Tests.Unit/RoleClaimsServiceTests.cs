// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// RoleClaimsServiceTests.cs See LICENSE.txt in the root folder of the solution.

using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Moq;
using PBACTemplate.Brokers.Roles;
using PBACTemplate.Services.Foundations.RoleClaims;
using System.Security.Claims;

namespace PBACTemplate.Tests.Unit;

public partial class RoleClaimsServiceTests
{
    private readonly Mock<IRoleManagerBroker> roleManagerBrokerMock;
    private readonly Mock<ILogger<RoleClaimsService>> loggerMock;
    private readonly IRoleClaimsService roleClaimsService;

    public RoleClaimsServiceTests()
    {
        this.roleManagerBrokerMock = new Mock<IRoleManagerBroker>();
        this.loggerMock = new Mock<ILogger<RoleClaimsService>>();

        this.loggerMock.Setup(logger =>
            logger.IsEnabled(It.IsAny<LogLevel>()))
                .Returns(true);

        this.roleClaimsService = new RoleClaimsService(
            this.roleManagerBrokerMock.Object,
            this.loggerMock.Object);
    }

    private static IdentityRole CreateRole() => new(Guid.NewGuid().ToString());
    private static Claim CreateClaim() => new("type", "value");
    private static string GetRandomString() => Guid.NewGuid().ToString();

    private void VerifyNoOtherBrokerCalls() =>
        this.roleManagerBrokerMock.VerifyNoOtherCalls();
}