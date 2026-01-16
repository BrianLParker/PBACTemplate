// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// UserCrudServiceTests.cs See LICENSE.txt in the root folder of the solution.

using Microsoft.Extensions.Logging;
using PBACTemplate.Brokers.User;
using PBACTemplate.Models.Users;
using PBACTemplate.Services.Foundations.UserCrud;

namespace PBACTemplate.Tests.Unit;

public partial class UserCrudServiceTests
{
    private readonly Mock<IUserManagerBroker> userManagerBrokerMock;
    private readonly Mock<ILogger<UserCrudService>> loggerMock;
    private readonly IUserCrudService userCrudService;

    public UserCrudServiceTests()
    {
        this.userManagerBrokerMock = new Mock<IUserManagerBroker>();
        this.loggerMock = new Mock<ILogger<UserCrudService>>();

        this.loggerMock.Setup(logger =>
            logger.IsEnabled(It.IsAny<LogLevel>()))
                .Returns(true);

        this.userCrudService = new UserCrudService(
            this.userManagerBrokerMock.Object,
            this.loggerMock.Object);
    }

    private static ApplicationUser CreateUser() => new() { Id = Guid.NewGuid().ToString() };
    private static string GetRandomString() => Guid.NewGuid().ToString();
    private static bool GetRandomBoolean() => Random.Shared.Next(0, 2) == 1;

    private void VerifyNoOtherBrokerCalls() =>
        this.userManagerBrokerMock.VerifyNoOtherCalls();
}