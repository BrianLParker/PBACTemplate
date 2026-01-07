// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// NavigationServiceTests.Validations.cs See LICENSE.txt in the root folder of the solution.

using Microsoft.AspNetCore.Components;
using Moq;
using PBACTemplate.Client.Services.Foundations.Navigation.Exceptions;

namespace PBACTemplate.Tests.Unit;

public partial class NavigationServiceTests
{
    [Fact]
    public void ShouldThrowNullNavigationExceptionOnNavigateToIfUriIsNull()
    {
        // Given
        string? nullUri = null;
        bool inputForceLoad = GetRandomBoolean();

        var expectedNullNavigationException =
            new NullNavigationException("URI cannot be null.");

        // When
        Action navigateToAction = () =>
            this.navigationService.NavigateTo(nullUri!, inputForceLoad);

        // Then
        NullNavigationException actualException =
            Assert.Throws<NullNavigationException>(navigateToAction);

        Assert.Equal(expectedNullNavigationException.Message, actualException.Message);

        this.navigationBrokerMock.Verify(broker =>
            broker.NavigateTo(It.IsAny<string>(), It.IsAny<bool>()),
            Times.Never);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public void ShouldThrowNullNavigationExceptionOnNavigateToWithReplaceIfUriIsNull()
    {
        // Given
        string? nullUri = null;
        bool inputForceLoad = GetRandomBoolean();
        bool inputReplace = GetRandomBoolean();

        var expectedNullNavigationException =
            new NullNavigationException("URI cannot be null.");

        // When
        Action navigateToAction = () =>
            this.navigationService.NavigateTo(nullUri!, inputForceLoad, inputReplace);

        // Then
        NullNavigationException actualException =
            Assert.Throws<NullNavigationException>(navigateToAction);

        Assert.Equal(expectedNullNavigationException.Message, actualException.Message);

        this.navigationBrokerMock.Verify(broker =>
            broker.NavigateTo(It.IsAny<string>(), It.IsAny<bool>(), It.IsAny<bool>()),
            Times.Never);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public void ShouldThrowNullNavigationExceptionOnNavigateToWithOptionsIfUriIsNull()
    {
        // Given
        string? nullUri = null;
        var inputOptions = new NavigationOptions();

        var expectedNullNavigationException =
            new NullNavigationException("URI cannot be null.");

        // When
        Action navigateToAction = () =>
            this.navigationService.NavigateTo(nullUri!, inputOptions);

        // Then
        NullNavigationException actualException =
            Assert.Throws<NullNavigationException>(navigateToAction);

        Assert.Equal(expectedNullNavigationException.Message, actualException.Message);

        this.navigationBrokerMock.Verify(broker =>
            broker.NavigateTo(It.IsAny<string>(), It.IsAny<NavigationOptions>()),
            Times.Never);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public void ShouldThrowNullNavigationExceptionOnToBaseRelativePathIfUriIsNull()
    {
        // Given
        string? nullUri = null;

        var expectedNullNavigationException =
            new NullNavigationException("URI cannot be null.");

        // When
        Action toBaseRelativePathAction = () =>
            this.navigationService.ToBaseRelativePath(nullUri!);

        // Then
        NullNavigationException actualException =
            Assert.Throws<NullNavigationException>(toBaseRelativePathAction);

        Assert.Equal(expectedNullNavigationException.Message, actualException.Message);

        this.navigationBrokerMock.Verify(broker =>
            broker.ToBaseRelativePath(It.IsAny<string>()),
            Times.Never);

        VerifyNoOtherBrokerCalls();
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("   ")]
    public void ShouldThrowInvalidNavigationExceptionOnGetUriWithQueryParameterIfNameIsInvalid(string? invalidName)
    {
        // Given
        string inputValue = GetRandomString();

        var expectedInvalidNavigationException =
            new InvalidNavigationException("Parameter name cannot be null or whitespace.");

        // When
        Action getUriWithQueryParameterAction = () =>
            this.navigationService.GetUriWithQueryParameter(invalidName!, inputValue);

        // Then
        InvalidNavigationException actualException =
            Assert.Throws<InvalidNavigationException>(getUriWithQueryParameterAction);

        Assert.Equal(expectedInvalidNavigationException.Message, actualException.Message);

        this.navigationBrokerMock.Verify(broker =>
            broker.GetUriWithQueryParameter(It.IsAny<string>(), It.IsAny<string>()),
            Times.Never);

        VerifyNoOtherBrokerCalls();
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("   ")]
    public void ShouldThrowInvalidNavigationExceptionOnGetUriWithQueryParameterIntIfNameIsInvalid(string? invalidName)
    {
        // Given
        int inputValue = GetRandomNumber();

        var expectedInvalidNavigationException =
            new InvalidNavigationException("Parameter name cannot be null or whitespace.");

        // When
        Action getUriWithQueryParameterAction = () =>
            this.navigationService.GetUriWithQueryParameter(invalidName!, inputValue);

        // Then
        InvalidNavigationException actualException =
            Assert.Throws<InvalidNavigationException>(getUriWithQueryParameterAction);

        Assert.Equal(expectedInvalidNavigationException.Message, actualException.Message);

        this.navigationBrokerMock.Verify(broker =>
            broker.GetUriWithQueryParameter(It.IsAny<string>(), It.IsAny<int>()),
            Times.Never);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public void ShouldThrowNullNavigationExceptionOnGetUriWithQueryParametersIfParametersIsNull()
    {
        // Given
        IReadOnlyDictionary<string, object?>? nullParameters = null;

        var expectedNullNavigationException =
            new NullNavigationException("Parameters dictionary cannot be null.");

        // When
        Action getUriWithQueryParametersAction = () =>
            this.navigationService.GetUriWithQueryParameters(nullParameters!);

        // Then
        NullNavigationException actualException =
            Assert.Throws<NullNavigationException>(getUriWithQueryParametersAction);

        Assert.Equal(expectedNullNavigationException.Message, actualException.Message);

        this.navigationBrokerMock.Verify(broker =>
            broker.GetUriWithQueryParameters(It.IsAny<IReadOnlyDictionary<string, object?>>()),
            Times.Never);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public void ShouldThrowNullNavigationExceptionOnGetUriWithQueryParametersWithUriIfUriIsNull()
    {
        // Given
        string? nullUri = null;
        var inputParameters = new Dictionary<string, object?> { ["key"] = "value" };

        var expectedNullNavigationException =
            new NullNavigationException("URI cannot be null.");

        // When
        Action getUriWithQueryParametersAction = () =>
            this.navigationService.GetUriWithQueryParameters(nullUri!, inputParameters);

        // Then
        NullNavigationException actualException =
            Assert.Throws<NullNavigationException>(getUriWithQueryParametersAction);

        Assert.Equal(expectedNullNavigationException.Message, actualException.Message);

        this.navigationBrokerMock.Verify(broker =>
            broker.GetUriWithQueryParameters(It.IsAny<string>(), It.IsAny<IReadOnlyDictionary<string, object?>>()),
            Times.Never);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public void ShouldThrowNullNavigationExceptionOnGetUriWithQueryParametersWithUriIfParametersIsNull()
    {
        // Given
        string inputUri = GetRandomString();
        IReadOnlyDictionary<string, object?>? nullParameters = null;

        var expectedNullNavigationException =
            new NullNavigationException("Parameters dictionary cannot be null.");

        // When
        Action getUriWithQueryParametersAction = () =>
            this.navigationService.GetUriWithQueryParameters(inputUri, nullParameters!);

        // Then
        NullNavigationException actualException =
            Assert.Throws<NullNavigationException>(getUriWithQueryParametersAction);

        Assert.Equal(expectedNullNavigationException.Message, actualException.Message);

        this.navigationBrokerMock.Verify(broker =>
            broker.GetUriWithQueryParameters(It.IsAny<string>(), It.IsAny<IReadOnlyDictionary<string, object?>>()),
            Times.Never);

        VerifyNoOtherBrokerCalls();
    }
}