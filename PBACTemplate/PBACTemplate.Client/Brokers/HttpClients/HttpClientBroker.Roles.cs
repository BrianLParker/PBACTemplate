// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// HttpClientBroker.Roles.cs See LICENSE.txt in the root folder of the solution.

using System.Collections.Immutable;
using System.Net.Http.Json;

namespace PBACTemplate.Client.Brokers.HttpClients;

public partial class HttpClientBroker
{
    private const string RolesEndpoint = "/Api/Administration/Roles";

    public async ValueTask<string> CreateRoleAsync(string roleName)
    {
        using HttpResponseMessage response = await this.httpClient.PostAsJsonAsync(
            $"{RolesEndpoint}/",
            new { Name = roleName });

        if (!response.IsSuccessStatusCode)
        {
            return string.Empty;
        }

        return await response.Content.ReadFromJsonAsync<string>() ?? string.Empty;
    }

    public async ValueTask<bool> RemoveRoleAsync(string roleName)
    {
        using HttpResponseMessage response = await this.httpClient.DeleteAsync(
            $"{RolesEndpoint}/{roleName}");

        return response.IsSuccessStatusCode;
    }

    public async ValueTask<string?> RetrieveRoleAsync(string roleName)
    {
        using HttpResponseMessage response = await this.httpClient.GetAsync(
            $"{RolesEndpoint}/{roleName}");

        if (!response.IsSuccessStatusCode)
        {
            return null;
        }

        return await response.Content.ReadFromJsonAsync<string>();
    }

    public async ValueTask<ImmutableList<string>> RetrieveRolesAsync()
    {
        using HttpResponseMessage response = await this.httpClient.GetAsync($"{RolesEndpoint}/");

        if (!response.IsSuccessStatusCode)
        {
            return [];
        }

        return (await response.Content.ReadFromJsonAsync<List<string>>() ?? []).ToImmutableList();
    }

    public async ValueTask<string> UpdateRoleAsync(string roleName, string newRoleName)
    {
        using HttpResponseMessage response = await this.httpClient.PutAsJsonAsync(
            $"{RolesEndpoint}/{roleName}",
            new { Name = newRoleName });

        if (!response.IsSuccessStatusCode)
        {
            return string.Empty;
        }

        return await response.Content.ReadFromJsonAsync<string>() ?? string.Empty;
    }
}
