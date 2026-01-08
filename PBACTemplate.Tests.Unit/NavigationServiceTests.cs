// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// NavigationServiceTests.cs See LICENSE.txt in the root folder of the solution.

using Microsoft.Extensions.Logging;
using PBACTemplate.Client.Brokers.Navigation;
using PBACTemplate.Client.Services.Foundations.Navigation;

namespace PBACTemplate.Tests.Unit;

public partial class NavigationServiceTests
{
    private readonly Mock<INavigationBroker> navigationBrokerMock;
    private readonly Mock<ILogger<NavigationService>> loggerMock;
    private readonly INavigationService navigationService;

    public NavigationServiceTests()
    {
        this.navigationBrokerMock = new Mock<INavigationBroker>();
        this.loggerMock = new Mock<ILogger<NavigationService>>();

        this.loggerMock.Setup(logger =>
            logger.IsEnabled(It.IsAny<LogLevel>()))
                .Returns(true);

        this.navigationService = new NavigationService(
            this.navigationBrokerMock.Object,
            this.loggerMock.Object);
    }

    private static string GetRandomString() => Guid.NewGuid().ToString();
    private static int GetRandomNumber() => Random.Shared.Next(1, 1000);
    private static bool GetRandomBoolean() => Random.Shared.Next(0, 2) == 1;
}
