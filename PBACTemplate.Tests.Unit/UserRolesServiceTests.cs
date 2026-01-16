// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// UserRolesServiceTests.cs See LICENSE.txt in the root folder of the solution.

using Microsoft.Extensions.Logging;
using PBACTemplate.Brokers.User;
using PBACTemplate.Models.Users;
using PBACTemplate.Services.Foundations.UserRoles;

namespace PBACTemplate.Tests.Unit;

public partial class UserRolesServiceTests
{
    private readonly Mock<IUserManagerBroker> userManagerBrokerMock;
    private readonly Mock<ILogger<UserRolesService>> loggerMock;
    private readonly IUserRolesService userRolesService;

    public UserRolesServiceTests()
    {
        this.userManagerBrokerMock = new Mock<IUserManagerBroker>();
        this.loggerMock = new Mock<ILogger<UserRolesService>>();

        this.loggerMock.Setup(logger =>
            logger.IsEnabled(It.IsAny<LogLevel>()))
                .Returns(true);

        this.userRolesService = new UserRolesService(
            this.userManagerBrokerMock.Object,
            this.loggerMock.Object);
    }

    private static ApplicationUser CreateUser() => new() { Id = Guid.NewGuid().ToString() };
    private static string GetRandomString() => Guid.NewGuid().ToString();
    private static IEnumerable<string> CreateRoles(params string[] roles) => roles;

    private void VerifyNoOtherBrokerCalls() =>
        this.userManagerBrokerMock.VerifyNoOtherCalls();
}