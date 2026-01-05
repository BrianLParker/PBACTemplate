// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// NavigationServiceTests.Exceptions.cs See LICENSE.txt in the root folder of the solution.

using Microsoft.AspNetCore.Components.Routing;
using Microsoft.Extensions.Logging;
using Moq;
using PBACTemplate.Client.Services.Foundations.Navigation.Exceptions;

namespace PBACTemplate.Tests.Unit;

public partial class NavigationServiceTests
{
    [Fact]
    public void ShouldThrowNavigationServiceExceptionOnNavigateToIfExceptionOccurs()
    {
        // Given
        string inputUri = GetRandomString();
        bool inputForceLoad = GetRandomBoolean();
        var someException = new Exception("Some error occurred");

        this.navigationBrokerMock.Setup(broker =>
            broker.NavigateTo(inputUri, inputForceLoad))
                .Throws(someException);

        var expectedFailedNavigationServiceException =
            new FailedNavigationServiceException(
                "Failed navigation service error occurred, contact support.",
                someException);

        var expectedNavigationServiceException =
            new NavigationServiceException(
                "Navigation service error occurred, contact support.",
                expectedFailedNavigationServiceException);

        // When
        Action navigateToAction = () =>
            this.navigationService.NavigateTo(inputUri, inputForceLoad);

        // Then
        NavigationServiceException actualException =
            Assert.Throws<NavigationServiceException>(navigateToAction);

        Assert.Equal(expectedNavigationServiceException.Message, actualException.Message);
        Assert.IsType<FailedNavigationServiceException>(actualException.InnerException);

        this.navigationBrokerMock.Verify(broker =>
            broker.NavigateTo(inputUri, inputForceLoad),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public void ShouldThrowNavigationServiceExceptionOnNavigateToWithReplaceIfExceptionOccurs()
    {
        // Given
        string inputUri = GetRandomString();
        bool inputForceLoad = GetRandomBoolean();
        bool inputReplace = GetRandomBoolean();
        var someException = new Exception("Some error occurred");

        this.navigationBrokerMock.Setup(broker =>
            broker.NavigateTo(inputUri, inputForceLoad, inputReplace))
                .Throws(someException);

        var expectedNavigationServiceException =
            new NavigationServiceException(
                "Navigation service error occurred, contact support.",
                new FailedNavigationServiceException(
                    "Failed navigation service error occurred, contact support.",
                    someException));

        // When
        Action navigateToAction = () =>
            this.navigationService.NavigateTo(inputUri, inputForceLoad, inputReplace);

        // Then
        NavigationServiceException actualException =
            Assert.Throws<NavigationServiceException>(navigateToAction);

        Assert.Equal(expectedNavigationServiceException.Message, actualException.Message);
        Assert.IsType<FailedNavigationServiceException>(actualException.InnerException);

        this.navigationBrokerMock.Verify(broker =>
            broker.NavigateTo(inputUri, inputForceLoad, inputReplace),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public void ShouldThrowNavigationServiceExceptionOnRefreshIfExceptionOccurs()
    {
        // Given
        bool inputForceReload = GetRandomBoolean();
        var someException = new Exception("Some error occurred");

        this.navigationBrokerMock.Setup(broker =>
            broker.Refresh(inputForceReload))
                .Throws(someException);

        var expectedNavigationServiceException =
            new NavigationServiceException(
                "Navigation service error occurred, contact support.",
                new FailedNavigationServiceException(
                    "Failed navigation service error occurred, contact support.",
                    someException));

        // When
        Action refreshAction = () =>
            this.navigationService.Refresh(inputForceReload);

        // Then
        NavigationServiceException actualException =
            Assert.Throws<NavigationServiceException>(refreshAction);

        Assert.Equal(expectedNavigationServiceException.Message, actualException.Message);
        Assert.IsType<FailedNavigationServiceException>(actualException.InnerException);

        this.navigationBrokerMock.Verify(broker =>
            broker.Refresh(inputForceReload),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public void ShouldThrowNavigationServiceExceptionOnNotFoundIfExceptionOccurs()
    {
        // Given
        var someException = new Exception("Some error occurred");

        this.navigationBrokerMock.Setup(broker =>
            broker.NotFound())
                .Throws(someException);

        var expectedNavigationServiceException =
            new NavigationServiceException(
                "Navigation service error occurred, contact support.",
                new FailedNavigationServiceException(
                    "Failed navigation service error occurred, contact support.",
                    someException));

        // When
        Action notFoundAction = () =>
            this.navigationService.NotFound();

        // Then
        NavigationServiceException actualException =
            Assert.Throws<NavigationServiceException>(notFoundAction);

        Assert.Equal(expectedNavigationServiceException.Message, actualException.Message);
        Assert.IsType<FailedNavigationServiceException>(actualException.InnerException);

        this.navigationBrokerMock.Verify(broker =>
            broker.NotFound(),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public void ShouldThrowNavigationServiceExceptionOnToAbsoluteUriIfExceptionOccurs()
    {
        // Given
        string inputRelativeUri = GetRandomString();
        var someException = new Exception("Some error occurred");

        this.navigationBrokerMock.Setup(broker =>
            broker.ToAbsoluteUri(inputRelativeUri))
                .Throws(someException);

        var expectedNavigationServiceException =
            new NavigationServiceException(
                "Navigation service error occurred, contact support.",
                new FailedNavigationServiceException(
                    "Failed navigation service error occurred, contact support.",
                    someException));

        // When
        Func<Uri> toAbsoluteUriFunction = () =>
            this.navigationService.ToAbsoluteUri(inputRelativeUri);

        // Then
        NavigationServiceException actualException =
            Assert.Throws<NavigationServiceException>(toAbsoluteUriFunction);

        Assert.Equal(expectedNavigationServiceException.Message, actualException.Message);
        Assert.IsType<FailedNavigationServiceException>(actualException.InnerException);

        this.navigationBrokerMock.Verify(broker =>
            broker.ToAbsoluteUri(inputRelativeUri),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public void ShouldThrowNavigationServiceExceptionOnToBaseRelativePathIfExceptionOccurs()
    {
        // Given
        string inputUri = GetRandomString();
        var someException = new Exception("Some error occurred");

        this.navigationBrokerMock.Setup(broker =>
            broker.ToBaseRelativePath(inputUri))
                .Throws(someException);

        var expectedNavigationServiceException =
            new NavigationServiceException(
                "Navigation service error occurred, contact support.",
                new FailedNavigationServiceException(
                    "Failed navigation service error occurred, contact support.",
                    someException));

        // When
        Func<string> toBaseRelativePathFunction = () =>
            this.navigationService.ToBaseRelativePath(inputUri);

        // Then
        NavigationServiceException actualException =
            Assert.Throws<NavigationServiceException>(toBaseRelativePathFunction);

        Assert.Equal(expectedNavigationServiceException.Message, actualException.Message);
        Assert.IsType<FailedNavigationServiceException>(actualException.InnerException);

        this.navigationBrokerMock.Verify(broker =>
            broker.ToBaseRelativePath(inputUri),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public void ShouldThrowNavigationServiceExceptionOnGetUriWithQueryParametersIfExceptionOccurs()
    {
        // Given
        var inputParameters = new Dictionary<string, object?> { ["key"] = "value" };
        var someException = new Exception("Some error occurred");

        this.navigationBrokerMock.Setup(broker =>
            broker.GetUriWithQueryParameters(inputParameters))
                .Throws(someException);

        var expectedNavigationServiceException =
            new NavigationServiceException(
                "Navigation service error occurred, contact support.",
                new FailedNavigationServiceException(
                    "Failed navigation service error occurred, contact support.",
                    someException));

        // When
        Func<string> getUriWithQueryParametersFunction = () =>
            this.navigationService.GetUriWithQueryParameters(inputParameters);

        // Then
        NavigationServiceException actualException =
            Assert.Throws<NavigationServiceException>(getUriWithQueryParametersFunction);

        Assert.Equal(expectedNavigationServiceException.Message, actualException.Message);
        Assert.IsType<FailedNavigationServiceException>(actualException.InnerException);

        this.navigationBrokerMock.Verify(broker =>
            broker.GetUriWithQueryParameters(inputParameters),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    private void VerifyNoOtherBrokerCalls()
    {
        this.navigationBrokerMock.VerifyAdd(broker =>
            broker.LocationChanged += It.IsAny<EventHandler<LocationChangedEventArgs>>(),
            Times.Once);

        this.navigationBrokerMock.VerifyAdd(broker =>
            broker.OnNotFound += It.IsAny<EventHandler<NotFoundEventArgs>>(),
            Times.Once);

        this.navigationBrokerMock.VerifyNoOtherCalls();
    }
}