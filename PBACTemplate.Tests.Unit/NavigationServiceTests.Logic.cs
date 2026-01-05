// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// NavigationServiceTests.Logic.cs See LICENSE.txt in the root folder of the solution.

using Microsoft.AspNetCore.Components;
using Moq;

namespace PBACTemplate.Tests.Unit;

public partial class NavigationServiceTests
{
    [Fact]
    public void ShouldNavigateToUri()
    {
        // Given
        string inputUri = GetRandomString();
        bool inputForceLoad = GetRandomBoolean();

        // When
        this.navigationService.NavigateTo(inputUri, inputForceLoad);

        // Then
        this.navigationBrokerMock.Verify(broker =>
            broker.NavigateTo(inputUri, inputForceLoad),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public void ShouldNavigateToUriWithReplace()
    {
        // Given
        string inputUri = GetRandomString();
        bool inputForceLoad = GetRandomBoolean();
        bool inputReplace = GetRandomBoolean();

        // When
        this.navigationService.NavigateTo(inputUri, inputForceLoad, inputReplace);

        // Then
        this.navigationBrokerMock.Verify(broker =>
            broker.NavigateTo(inputUri, inputForceLoad, inputReplace),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public void ShouldNavigateToUriWithOptions()
    {
        // Given
        string inputUri = GetRandomString();
        var inputOptions = new NavigationOptions { ForceLoad = GetRandomBoolean() };

        // When
        this.navigationService.NavigateTo(inputUri, inputOptions);

        // Then
        this.navigationBrokerMock.Verify(broker =>
            broker.NavigateTo(inputUri, inputOptions),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public void ShouldRefresh()
    {
        // Given
        bool inputForceReload = GetRandomBoolean();

        // When
        this.navigationService.Refresh(inputForceReload);

        // Then
        this.navigationBrokerMock.Verify(broker =>
            broker.Refresh(inputForceReload),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public void ShouldTriggerNotFound()
    {
        // Given / When
        this.navigationService.NotFound();

        // Then
        this.navigationBrokerMock.Verify(broker =>
            broker.NotFound(),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public void ShouldConvertToAbsoluteUri()
    {
        // Given
        string inputRelativeUri = GetRandomString();
        Uri expectedUri = new Uri($"https://example.com/{inputRelativeUri}");

        this.navigationBrokerMock.Setup(broker =>
            broker.ToAbsoluteUri(inputRelativeUri))
                .Returns(expectedUri);

        // When
        Uri actualUri = this.navigationService.ToAbsoluteUri(inputRelativeUri);

        // Then
        Assert.Equal(expectedUri, actualUri);

        this.navigationBrokerMock.Verify(broker =>
            broker.ToAbsoluteUri(inputRelativeUri),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public void ShouldConvertToBaseRelativePath()
    {
        // Given
        string inputUri = "https://example.com/some/path";
        string expectedPath = "some/path";

        this.navigationBrokerMock.Setup(broker =>
            broker.ToBaseRelativePath(inputUri))
                .Returns(expectedPath);

        // When
        string actualPath = this.navigationService.ToBaseRelativePath(inputUri);

        // Then
        Assert.Equal(expectedPath, actualPath);

        this.navigationBrokerMock.Verify(broker =>
            broker.ToBaseRelativePath(inputUri),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public void ShouldGetUriWithQueryParameterString()
    {
        // Given
        string inputName = GetRandomString();
        string inputValue = GetRandomString();
        string expectedUri = $"https://example.com?{inputName}={inputValue}";

        this.navigationBrokerMock.Setup(broker =>
            broker.GetUriWithQueryParameter(inputName, inputValue))
                .Returns(expectedUri);

        // When
        string actualUri = this.navigationService.GetUriWithQueryParameter(inputName, inputValue);

        // Then
        Assert.Equal(expectedUri, actualUri);

        this.navigationBrokerMock.Verify(broker =>
            broker.GetUriWithQueryParameter(inputName, inputValue),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public void ShouldGetUriWithQueryParameterInt()
    {
        // Given
        string inputName = GetRandomString();
        int inputValue = GetRandomNumber();
        string expectedUri = $"https://example.com?{inputName}={inputValue}";

        this.navigationBrokerMock.Setup(broker =>
            broker.GetUriWithQueryParameter(inputName, inputValue))
                .Returns(expectedUri);

        // When
        string actualUri = this.navigationService.GetUriWithQueryParameter(inputName, inputValue);

        // Then
        Assert.Equal(expectedUri, actualUri);

        this.navigationBrokerMock.Verify(broker =>
            broker.GetUriWithQueryParameter(inputName, inputValue),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public void ShouldGetUriWithQueryParameterBool()
    {
        // Given
        string inputName = GetRandomString();
        bool inputValue = GetRandomBoolean();
        string expectedUri = $"https://example.com?{inputName}={inputValue}";

        this.navigationBrokerMock.Setup(broker =>
            broker.GetUriWithQueryParameter(inputName, inputValue))
                .Returns(expectedUri);

        // When
        string actualUri = this.navigationService.GetUriWithQueryParameter(inputName, inputValue);

        // Then
        Assert.Equal(expectedUri, actualUri);

        this.navigationBrokerMock.Verify(broker =>
            broker.GetUriWithQueryParameter(inputName, inputValue),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public void ShouldGetUriWithQueryParameterGuid()
    {
        // Given
        string inputName = GetRandomString();
        Guid inputValue = Guid.NewGuid();
        string expectedUri = $"https://example.com?{inputName}={inputValue}";

        this.navigationBrokerMock.Setup(broker =>
            broker.GetUriWithQueryParameter(inputName, inputValue))
                .Returns(expectedUri);

        // When
        string actualUri = this.navigationService.GetUriWithQueryParameter(inputName, inputValue);

        // Then
        Assert.Equal(expectedUri, actualUri);

        this.navigationBrokerMock.Verify(broker =>
            broker.GetUriWithQueryParameter(inputName, inputValue),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public void ShouldGetUriWithQueryParameters()
    {
        // Given
        var inputParameters = new Dictionary<string, object?>
        {
            ["param1"] = "value1",
            ["param2"] = 123
        };
        string expectedUri = "https://example.com?param1=value1&param2=123";

        this.navigationBrokerMock.Setup(broker =>
            broker.GetUriWithQueryParameters(inputParameters))
                .Returns(expectedUri);

        // When
        string actualUri = this.navigationService.GetUriWithQueryParameters(inputParameters);

        // Then
        Assert.Equal(expectedUri, actualUri);

        this.navigationBrokerMock.Verify(broker =>
            broker.GetUriWithQueryParameters(inputParameters),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public void ShouldGetUriWithQueryParametersAndUri()
    {
        // Given
        string inputUri = "https://example.com/path";
        var inputParameters = new Dictionary<string, object?>
        {
            ["param1"] = "value1"
        };
        string expectedUri = "https://example.com/path?param1=value1";

        this.navigationBrokerMock.Setup(broker =>
            broker.GetUriWithQueryParameters(inputUri, inputParameters))
                .Returns(expectedUri);

        // When
        string actualUri = this.navigationService.GetUriWithQueryParameters(inputUri, inputParameters);

        // Then
        Assert.Equal(expectedUri, actualUri);

        this.navigationBrokerMock.Verify(broker =>
            broker.GetUriWithQueryParameters(inputUri, inputParameters),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public void ShouldReturnBaseUri()
    {
        // Given
        string expectedBaseUri = "https://example.com/";

        this.navigationBrokerMock.Setup(broker =>
            broker.BaseUri)
                .Returns(expectedBaseUri);

        // When
        string actualBaseUri = this.navigationService.BaseUri;

        // Then
        Assert.Equal(expectedBaseUri, actualBaseUri);
    }

    [Fact]
    public void ShouldReturnUri()
    {
        // Given
        string expectedUri = "https://example.com/current/page";

        this.navigationBrokerMock.Setup(broker =>
            broker.Uri)
                .Returns(expectedUri);

        // When
        string actualUri = this.navigationService.Uri;

        // Then
        Assert.Equal(expectedUri, actualUri);
    }

    [Fact]
    public void ShouldReturnHistoryEntryState()
    {
        // Given
        string expectedState = GetRandomString();

        this.navigationBrokerMock.Setup(broker =>
            broker.HistoryEntryState)
                .Returns(expectedState);

        // When
        string? actualState = this.navigationService.HistoryEntryState;

        // Then
        Assert.Equal(expectedState, actualState);
    }
}