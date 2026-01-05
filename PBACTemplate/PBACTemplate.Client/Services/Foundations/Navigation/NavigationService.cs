// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// NavigationService.cs See LICENSE.txt in the root folder of the solution.

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;
using PBACTemplate.Client.Brokers.Navigation;

namespace PBACTemplate.Client.Services.Foundations.Navigation;

public sealed partial class NavigationService : INavigationService, IDisposable
{
    private readonly INavigationBroker navigationBroker;
    private readonly ILogger<NavigationService> logger;

    public NavigationService(
        INavigationBroker navigationBroker,
        ILogger<NavigationService> logger)
    {
        this.navigationBroker = navigationBroker;
        this.logger = logger;
        this.navigationBroker.LocationChanged += OnLocationChanged;
        this.navigationBroker.OnNotFound += OnNotFoundHandler;
    }

    public string BaseUri => this.navigationBroker.BaseUri;

    public string Uri => this.navigationBroker.Uri;

    public string? HistoryEntryState => this.navigationBroker.HistoryEntryState;

    public event EventHandler<LocationChangedEventArgs>? LocationChanged;
    public event EventHandler<NotFoundEventArgs>? OnNotFound;

    public void NavigateTo(string uri, bool forceLoad) =>
        TryCatch(() =>
        {
            ValidateUri(uri);

            LogNavigatingTo(uri, forceLoad);

            this.navigationBroker.NavigateTo(uri, forceLoad);
        });

    public void NavigateTo(string uri, bool forceLoad = false, bool replace = false) =>
        TryCatch(() =>
        {
            ValidateUri(uri);

            LogNavigatingToWithReplace(uri, forceLoad, replace);

            this.navigationBroker.NavigateTo(uri, forceLoad, replace);
        });

    public void NavigateTo(string uri, NavigationOptions options) =>
        TryCatch(() =>
        {
            ValidateUri(uri);

            LogNavigatingToWithOptions(uri);

            this.navigationBroker.NavigateTo(uri, options);
        });

    public void Refresh(bool forceReload = false) =>
        TryCatch(() =>
        {
            LogRefreshing(forceReload);

            this.navigationBroker.Refresh(forceReload);
        });

    public void NotFound() =>
        TryCatch(() =>
        {
            LogNotFound();

            this.navigationBroker.NotFound();
        });

    public Uri ToAbsoluteUri(string? relativeUri) =>
        TryCatch(() =>
        {
            LogConvertingToAbsoluteUri(relativeUri);

            return this.navigationBroker.ToAbsoluteUri(relativeUri);
        });

    public string ToBaseRelativePath(string uri) =>
        TryCatch(() =>
        {
            ValidateUri(uri);

            LogConvertingToBaseRelativePath(uri);

            return this.navigationBroker.ToBaseRelativePath(uri);
        });

    // Query parameter methods
    public string GetUriWithQueryParameter(string name, bool value) =>
        TryCatch(() =>
        {
            ValidateParameterName(name);
            return this.navigationBroker.GetUriWithQueryParameter(name, value);
        });

    public string GetUriWithQueryParameter(string name, DateOnly value) =>
        TryCatch(() =>
        {
            ValidateParameterName(name);
            return this.navigationBroker.GetUriWithQueryParameter(name, value);
        });

    public string GetUriWithQueryParameter(string name, DateTime value) =>
        TryCatch(() =>
        {
            ValidateParameterName(name);
            return this.navigationBroker.GetUriWithQueryParameter(name, value);
        });

    public string GetUriWithQueryParameter(string name, decimal value) =>
        TryCatch(() =>
        {
            ValidateParameterName(name);
            return this.navigationBroker.GetUriWithQueryParameter(name, value);
        });

    public string GetUriWithQueryParameter(string name, double value) =>
        TryCatch(() =>
        {
            ValidateParameterName(name);
            return this.navigationBroker.GetUriWithQueryParameter(name, value);
        });

    public string GetUriWithQueryParameter(string name, float value) =>
        TryCatch(() =>
        {
            ValidateParameterName(name);
            return this.navigationBroker.GetUriWithQueryParameter(name, value);
        });

    public string GetUriWithQueryParameter(string name, Guid value) =>
        TryCatch(() =>
        {
            ValidateParameterName(name);
            return this.navigationBroker.GetUriWithQueryParameter(name, value);
        });

    public string GetUriWithQueryParameter(string name, int value) =>
        TryCatch(() =>
        {
            ValidateParameterName(name);
            return this.navigationBroker.GetUriWithQueryParameter(name, value);
        });

    public string GetUriWithQueryParameter(string name, long value) =>
        TryCatch(() =>
        {
            ValidateParameterName(name);
            return this.navigationBroker.GetUriWithQueryParameter(name, value);
        });

    public string GetUriWithQueryParameter(string name, bool? value) =>
        TryCatch(() =>
        {
            ValidateParameterName(name);
            return this.navigationBroker.GetUriWithQueryParameter(name, value);
        });

    public string GetUriWithQueryParameter(string name, DateOnly? value) =>
        TryCatch(() =>
        {
            ValidateParameterName(name);
            return this.navigationBroker.GetUriWithQueryParameter(name, value);
        });

    public string GetUriWithQueryParameter(string name, DateTime? value) =>
        TryCatch(() =>
        {
            ValidateParameterName(name);
            return this.navigationBroker.GetUriWithQueryParameter(name, value);
        });

    public string GetUriWithQueryParameter(string name, decimal? value) =>
        TryCatch(() =>
        {
            ValidateParameterName(name);
            return this.navigationBroker.GetUriWithQueryParameter(name, value);
        });

    public string GetUriWithQueryParameter(string name, double? value) =>
        TryCatch(() =>
        {
            ValidateParameterName(name);
            return this.navigationBroker.GetUriWithQueryParameter(name, value);
        });

    public string GetUriWithQueryParameter(string name, float? value) =>
        TryCatch(() =>
        {
            ValidateParameterName(name);
            return this.navigationBroker.GetUriWithQueryParameter(name, value);
        });

    public string GetUriWithQueryParameter(string name, Guid? value) =>
        TryCatch(() =>
        {
            ValidateParameterName(name);
            return this.navigationBroker.GetUriWithQueryParameter(name, value);
        });

    public string GetUriWithQueryParameter(string name, int? value) =>
        TryCatch(() =>
        {
            ValidateParameterName(name);
            return this.navigationBroker.GetUriWithQueryParameter(name, value);
        });

    public string GetUriWithQueryParameter(string name, long? value) =>
        TryCatch(() =>
        {
            ValidateParameterName(name);
            return this.navigationBroker.GetUriWithQueryParameter(name, value);
        });

    public string GetUriWithQueryParameter(string name, string? value) =>
        TryCatch(() =>
        {
            ValidateParameterName(name);
            return this.navigationBroker.GetUriWithQueryParameter(name, value);
        });

    public string GetUriWithQueryParameter(string name, TimeOnly value) =>
        TryCatch(() =>
        {
            ValidateParameterName(name);
            return this.navigationBroker.GetUriWithQueryParameter(name, value);
        });

    public string GetUriWithQueryParameter(string name, TimeOnly? value) =>
        TryCatch(() =>
        {
            ValidateParameterName(name);
            return this.navigationBroker.GetUriWithQueryParameter(name, value);
        });

    public string GetUriWithQueryParameters(IReadOnlyDictionary<string, object?> parameters) =>
        TryCatch(() =>
        {
            ValidateParameters(parameters);
            return this.navigationBroker.GetUriWithQueryParameters(parameters);
        });

    public string GetUriWithQueryParameters(string uri, IReadOnlyDictionary<string, object?> parameters) =>
        TryCatch(() =>
        {
            ValidateUri(uri);
            ValidateParameters(parameters);
            return this.navigationBroker.GetUriWithQueryParameters(uri, parameters);
        });

    private void OnLocationChanged(object? sender, LocationChangedEventArgs e)
    {
        LogLocationChanged(e.Location);
        LocationChanged?.Invoke(this, e);
    }

    private void OnNotFoundHandler(object? sender, NotFoundEventArgs e)
    {
        LogNotFoundEvent();
        OnNotFound?.Invoke(this, e);
    }

    public void Dispose()
    {
        this.navigationBroker.LocationChanged -= OnLocationChanged;
        this.navigationBroker.OnNotFound -= OnNotFoundHandler;
    }
}
