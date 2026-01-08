// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// LoginServiceTests.cs See LICENSE.txt in the root folder of the solution.

using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Moq;
using PBACTemplate.Brokers.User;
using PBACTemplate.Data;
using PBACTemplate.Services.Foundations.Login;

namespace PBACTemplate.Tests.Unit;

public partial class LoginServiceTests
{
    private readonly Mock<IUserManagerBroker> userManagerBrokerMock;
    private readonly Mock<ILogger<LoginService>> loggerMock;
    private readonly ILoginService loginService;

    public LoginServiceTests()
    {
        this.userManagerBrokerMock = new Mock<IUserManagerBroker>();
        this.loggerMock = new Mock<ILogger<LoginService>>();

        this.loggerMock.Setup(logger =>
            logger.IsEnabled(It.IsAny<LogLevel>()))
                .Returns(true);

        this.loginService = new LoginService(
            this.userManagerBrokerMock.Object,
            this.loggerMock.Object);
    }

    private static ApplicationUser CreateUser() => new() { Id = Guid.NewGuid().ToString() };
    private static UserLoginInfo CreateLogin() => new("provider", Guid.NewGuid().ToString(), "display");
    private static string GetRandomString() => Guid.NewGuid().ToString();

    private void VerifyNoOtherBrokerCalls() =>
        this.userManagerBrokerMock.VerifyNoOtherCalls();
}