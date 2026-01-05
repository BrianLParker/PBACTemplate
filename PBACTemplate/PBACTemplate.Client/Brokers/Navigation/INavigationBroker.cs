// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// INavigationBroker.cs See LICENSE.txt in the root folder of the solution.

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;

namespace PBACTemplate.Client.Brokers.Navigation;

public interface INavigationBroker
{
    event EventHandler<LocationChangedEventArgs> LocationChanged;
    event EventHandler<NotFoundEventArgs> OnNotFound;
    string BaseUri { get; }
    string Uri { get; }
    string? HistoryEntryState { get; }
    void NavigateTo(string uri, bool forceLoad);
    void NavigateTo(string uri, bool forceLoad = false, bool replace = false);
    void NavigateTo(string uri, NavigationOptions options);
    void Refresh(bool forceReload = false);
    void NotFound();
    Uri ToAbsoluteUri(string? relativeUri);
    string ToBaseRelativePath(string uri);

    // Query parameter methods
    string GetUriWithQueryParameter(string name, bool value);
    string GetUriWithQueryParameter(string name, DateOnly value);
    string GetUriWithQueryParameter(string name, DateTime value);
    string GetUriWithQueryParameter(string name, decimal value);
    string GetUriWithQueryParameter(string name, double value);
    string GetUriWithQueryParameter(string name, float value);
    string GetUriWithQueryParameter(string name, Guid value);
    string GetUriWithQueryParameter(string name, int value);
    string GetUriWithQueryParameter(string name, long value);
    string GetUriWithQueryParameter(string name, bool? value);
    string GetUriWithQueryParameter(string name, DateOnly? value);
    string GetUriWithQueryParameter(string name, DateTime? value);
    string GetUriWithQueryParameter(string name, decimal? value);
    string GetUriWithQueryParameter(string name, double? value);
    string GetUriWithQueryParameter(string name, float? value);
    string GetUriWithQueryParameter(string name, Guid? value);
    string GetUriWithQueryParameter(string name, int? value);
    string GetUriWithQueryParameter(string name, long? value);
    string GetUriWithQueryParameter(string name, string? value);
    string GetUriWithQueryParameter(string name, TimeOnly value);
    string GetUriWithQueryParameter(string name, TimeOnly? value);
    string GetUriWithQueryParameters(IReadOnlyDictionary<string, object?> parameters);
    string GetUriWithQueryParameters(string uri, IReadOnlyDictionary<string, object?> parameters);
}
