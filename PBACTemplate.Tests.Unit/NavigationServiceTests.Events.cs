// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// NavigationServiceTests.Events.cs See LICENSE.txt in the root folder of the solution.

using Microsoft.AspNetCore.Components.Routing;
using Moq;

namespace PBACTemplate.Tests.Unit;

public partial class NavigationServiceTests
{
    [Fact]
    public void ShouldRaiseLocationChangedEventWhenBrokerRaisesEvent()
    {
        // Given
        string expectedLocation = "https://example.com/new/page";
        bool expectedIsNavigationIntercepted = true;
        LocationChangedEventArgs? receivedArgs = null;

        this.navigationService.LocationChanged += (sender, args) =>
        {
            receivedArgs = args;
        };

        // When
        this.navigationBrokerMock.Raise(broker =>
            broker.LocationChanged += null,
            this.navigationBrokerMock.Object,
            new LocationChangedEventArgs(expectedLocation, expectedIsNavigationIntercepted));

        // Then
        Assert.NotNull(receivedArgs);
        Assert.Equal(expectedLocation, receivedArgs.Location);
        Assert.Equal(expectedIsNavigationIntercepted, receivedArgs.IsNavigationIntercepted);
    }

    [Fact]
    public void ShouldRaiseOnNotFoundEventWhenBrokerRaisesEvent()
    {
        // Given
        NotFoundEventArgs? receivedArgs = null;

        this.navigationService.OnNotFound += (sender, args) =>
        {
            receivedArgs = args;
        };

        // When
        this.navigationBrokerMock.Raise(broker =>
            broker.OnNotFound += null,
            this.navigationBrokerMock.Object,
            new NotFoundEventArgs());

        // Then
        Assert.NotNull(receivedArgs);
    }
}