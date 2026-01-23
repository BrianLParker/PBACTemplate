// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// UserServiceTests.cs See LICENSE.txt in the root folder of the solution.

using Microsoft.Extensions.Logging;
using PBACTemplate.Brokers.User;
using PBACTemplate.Client.Models.Users;
using PBACTemplate.Models.Users;
using PBACTemplate.Services.Foundations.Users;

namespace PBACTemplate.Tests.Unit;

public partial class UserServiceTests
{
    private readonly Mock<IUserManagerBroker> userManagerBrokerMock;
    private readonly Mock<ILogger<UserService>> loggerMock;
    private readonly IUserService userService;

    public UserServiceTests()
    {
        this.userManagerBrokerMock = new Mock<IUserManagerBroker>();
        this.loggerMock = new Mock<ILogger<UserService>>();

        this.loggerMock.Setup(logger =>
            logger.IsEnabled(It.IsAny<LogLevel>()))
                .Returns(true);

        this.userService = new UserService(
            this.userManagerBrokerMock.Object,
            this.loggerMock.Object);
    }

    private static string GetRandomString() => Guid.NewGuid().ToString();

    private static bool GetRandomBoolean() => Random.Shared.Next(0, 2) == 1;

    private static User CreateClientUser(string? id = null) => new()
    {
        Id = id ?? Guid.NewGuid().ToString(),
        UserName = $"user-{GetRandomString()}",
        Email = $"{GetRandomString()}@example.com",
        EmailConfirmed = GetRandomBoolean(),
        FirstName = "First",
        LastName = "Last",
        PhoneNumber = "1234567890",
        PhoneNumberConfirmed = GetRandomBoolean(),
        LockoutEnd = null,
        AccessFailedCount = 0,
        ConcurrencyStamp = GetRandomString(),
        AvatarUrl = null,
        Roles = []
    };

    private static ApplicationUser CreateApplicationUser(string? id = null) => new()
    {
        Id = id ?? Guid.NewGuid().ToString(),
        UserName = $"user-{GetRandomString()}",
        Email = $"{GetRandomString()}@example.com",
        EmailConfirmed = GetRandomBoolean(),
        FirstName = "First",
        LastName = "Last",
        PhoneNumber = "1234567890",
        PhoneNumberConfirmed = GetRandomBoolean(),
        LockoutEnd = null,
        AccessFailedCount = 0,
        ConcurrencyStamp = GetRandomString()
    };

    private void VerifyNoOtherBrokerCalls() =>
        this.userManagerBrokerMock.VerifyNoOtherCalls();
}