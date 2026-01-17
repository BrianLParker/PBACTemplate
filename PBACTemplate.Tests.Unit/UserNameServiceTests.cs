// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// UserNameServiceTests.cs See LICENSE.txt in the root folder of the solution.

using Microsoft.Extensions.Logging;
using PBACTemplate.Brokers.User;
using PBACTemplate.Models.Users;
using PBACTemplate.Services.Foundations.UserName;
using System.Security.Claims;

namespace PBACTemplate.Tests.Unit;

public partial class UserNameServiceTests
{
    private readonly Mock<IUserManagerBroker> userManagerBrokerMock;
    private readonly Mock<ILogger<UserNameService>> loggerMock;
    private readonly IUserNameService userNameService;

    public UserNameServiceTests()
    {
        this.userManagerBrokerMock = new Mock<IUserManagerBroker>();
        this.loggerMock = new Mock<ILogger<UserNameService>>();

        this.loggerMock.Setup(logger =>
            logger.IsEnabled(It.IsAny<LogLevel>()))
                .Returns(true);

        this.userNameService = new UserNameService(
            this.userManagerBrokerMock.Object,
            this.loggerMock.Object);
    }

    private static ApplicationUser CreateUser() => new() { Id = Guid.NewGuid().ToString() };
    private static string GetRandomString() => Guid.NewGuid().ToString();
    private static Claim CreateClaim() => new(ClaimTypes.Name, GetRandomString());
    private static ClaimsPrincipal CreatePrincipal() => new(new ClaimsIdentity(new[] { CreateClaim() }, "TestAuth"));

    private void VerifyNoOtherBrokerCalls() =>
        this.userManagerBrokerMock.VerifyNoOtherCalls();
}