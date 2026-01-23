// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// UserServiceTests.cs See LICENSE.txt in the root folder of the solution.

using Microsoft.Extensions.Logging;
using PBACTemplate.Client.Brokers.HttpClients;
using PBACTemplate.Client.Models.Users;
using PBACTemplate.Client.Services.Foundations.Users;

namespace PBACTemplate.Client.Tests.Unit;

public partial class UserServiceTests
{
    private readonly Mock<IHttpClientBroker> httpClientBrokerMock;
    private readonly Mock<ILogger<UserService>> loggerMock;
    private readonly IUserService userService;

    public UserServiceTests()
    {
        this.httpClientBrokerMock = new Mock<IHttpClientBroker>();
        this.loggerMock = new Mock<ILogger<UserService>>();

        this.loggerMock.Setup(logger =>
            logger.IsEnabled(It.IsAny<LogLevel>()))
            .Returns(true);

        this.userService = new UserService(
            this.httpClientBrokerMock.Object,
            this.loggerMock.Object);
    }

    private static string GetRandomString() => Guid.NewGuid().ToString();

    private static User CreateUser(string? id = null) => new()
    {
        Id = id ?? GetRandomString(),
        UserName = $"user-{GetRandomString()}",
        Email = $"{GetRandomString()}@example.com",
        EmailConfirmed = true,
        FirstName = "First",
        LastName = "Last",
        PhoneNumber = "1234567890",
        PhoneNumberConfirmed = true,
        LockoutEnd = null,
        CreatedAt = DateTimeOffset.UtcNow,
        UpdatedAt = DateTimeOffset.UtcNow,
        LastSignInAt = null,
        AccessFailedCount = 0,
        ConcurrencyStamp = GetRandomString(),
        AvatarUrl = null,
        Roles = []
    };

    private void VerifyNoOtherBrokerCalls() =>
        this.httpClientBrokerMock.VerifyNoOtherCalls();
}
