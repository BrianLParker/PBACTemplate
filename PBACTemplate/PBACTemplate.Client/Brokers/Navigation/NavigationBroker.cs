// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// NavigationBroker.cs See LICENSE.txt in the root folder of the solution.

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;

namespace PBACTemplate.Client.Brokers.Navigation;

public sealed class NavigationBroker : INavigationBroker, IDisposable
{
    private readonly NavigationManager navigationManager;

    public NavigationBroker(NavigationManager navigationManager)
    {
        this.navigationManager = navigationManager;
        this.navigationManager.LocationChanged += OnLocationChanged;
        this.navigationManager.OnNotFound += OnNotFoundHandler;
    }

    public string BaseUri => this.navigationManager.BaseUri;

    public string Uri => this.navigationManager.Uri;

    public string? HistoryEntryState => this.navigationManager.HistoryEntryState;

    public event EventHandler<LocationChangedEventArgs>? LocationChanged;
    public event EventHandler<NotFoundEventArgs>? OnNotFound;

    public void NavigateTo(string uri, bool forceLoad) =>
        this.navigationManager.NavigateTo(uri, forceLoad);

    public void NavigateTo(string uri, bool forceLoad = false, bool replace = false) =>
        this.navigationManager.NavigateTo(uri, forceLoad, replace);

    public void NavigateTo(string uri, NavigationOptions options) =>
        this.navigationManager.NavigateTo(uri, options);

    public void Refresh(bool forceReload = false) =>
        this.navigationManager.Refresh(forceReload);

    public void NotFound() =>
        this.navigationManager.NotFound();

    public Uri ToAbsoluteUri(string? relativeUri) =>
        this.navigationManager.ToAbsoluteUri(relativeUri);

    public string ToBaseRelativePath(string uri) =>
        this.navigationManager.ToBaseRelativePath(uri);

    // Query parameter methods - delegate to NavigationManager extension methods
    public string GetUriWithQueryParameter(string name, bool value) =>
        this.navigationManager.GetUriWithQueryParameter(name, value);

    public string GetUriWithQueryParameter(string name, DateOnly value) =>
        this.navigationManager.GetUriWithQueryParameter(name, value);

    public string GetUriWithQueryParameter(string name, DateTime value) =>
        this.navigationManager.GetUriWithQueryParameter(name, value);

    public string GetUriWithQueryParameter(string name, decimal value) =>
        this.navigationManager.GetUriWithQueryParameter(name, value);

    public string GetUriWithQueryParameter(string name, double value) =>
        this.navigationManager.GetUriWithQueryParameter(name, value);

    public string GetUriWithQueryParameter(string name, float value) =>
        this.navigationManager.GetUriWithQueryParameter(name, value);

    public string GetUriWithQueryParameter(string name, Guid value) =>
        this.navigationManager.GetUriWithQueryParameter(name, value);

    public string GetUriWithQueryParameter(string name, int value) =>
        this.navigationManager.GetUriWithQueryParameter(name, value);

    public string GetUriWithQueryParameter(string name, long value) =>
        this.navigationManager.GetUriWithQueryParameter(name, value);

    public string GetUriWithQueryParameter(string name, bool? value) =>
        this.navigationManager.GetUriWithQueryParameter(name, value);

    public string GetUriWithQueryParameter(string name, DateOnly? value) =>
        this.navigationManager.GetUriWithQueryParameter(name, value);

    public string GetUriWithQueryParameter(string name, DateTime? value) =>
        this.navigationManager.GetUriWithQueryParameter(name, value);

    public string GetUriWithQueryParameter(string name, decimal? value) =>
        this.navigationManager.GetUriWithQueryParameter(name, value);

    public string GetUriWithQueryParameter(string name, double? value) =>
        this.navigationManager.GetUriWithQueryParameter(name, value);

    public string GetUriWithQueryParameter(string name, float? value) =>
        this.navigationManager.GetUriWithQueryParameter(name, value);

    public string GetUriWithQueryParameter(string name, Guid? value) =>
        this.navigationManager.GetUriWithQueryParameter(name, value);

    public string GetUriWithQueryParameter(string name, int? value) =>
        this.navigationManager.GetUriWithQueryParameter(name, value);

    public string GetUriWithQueryParameter(string name, long? value) =>
        this.navigationManager.GetUriWithQueryParameter(name, value);

    public string GetUriWithQueryParameter(string name, string? value) =>
        this.navigationManager.GetUriWithQueryParameter(name, value);

    public string GetUriWithQueryParameter(string name, TimeOnly value) =>
        this.navigationManager.GetUriWithQueryParameter(name, value);

    public string GetUriWithQueryParameter(string name, TimeOnly? value) =>
        this.navigationManager.GetUriWithQueryParameter(name, value);

    public string GetUriWithQueryParameters(IReadOnlyDictionary<string, object?> parameters) =>
        this.navigationManager.GetUriWithQueryParameters(parameters);

    public string GetUriWithQueryParameters(string uri, IReadOnlyDictionary<string, object?> parameters) =>
        this.navigationManager.GetUriWithQueryParameters(uri, parameters);

    private void OnLocationChanged(object? sender, LocationChangedEventArgs e) =>
        LocationChanged?.Invoke(this, e);

    private void OnNotFoundHandler(object? sender, NotFoundEventArgs e) =>
        OnNotFound?.Invoke(this, e);

    public void Dispose()
    {
        this.navigationManager.LocationChanged -= OnLocationChanged;
        this.navigationManager.OnNotFound -= OnNotFoundHandler;
    }
}
