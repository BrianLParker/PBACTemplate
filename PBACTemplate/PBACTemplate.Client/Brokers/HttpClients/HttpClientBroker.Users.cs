// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// HttpClientBroker.Users.cs See LICENSE.txt in the root folder of the solution.

using PBACTemplate.Client.Models.Users;
using System.Collections.Immutable;
using System.Net.Http.Json;

namespace PBACTemplate.Client.Brokers.HttpClients;

public partial class HttpClientBroker
{
    private const string AdministrationUsersBasePath = "/Api/Administration/Users";

    public async ValueTask<ImmutableList<User>> GetUsersAsync(CancellationToken cancellationToken = default)
    {
        using HttpResponseMessage response = await this.httpClient.GetAsync(
            $"{AdministrationUsersBasePath}/",
            cancellationToken);

        if (!response.IsSuccessStatusCode)
        {
            return [];
        }

        return (await response.Content.ReadFromJsonAsync<List<User>>(cancellationToken)
               ?? []).ToImmutableList();
    }

    public async ValueTask<User?> GetUserAsync(string userId, CancellationToken cancellationToken = default)
    {
        using HttpResponseMessage response = await this.httpClient.GetAsync(
            $"{AdministrationUsersBasePath}/{userId}",
            cancellationToken);

        if (!response.IsSuccessStatusCode)
        {
            return null;
        }

        return await response.Content.ReadFromJsonAsync<User>(cancellationToken);
    }

    public async ValueTask<User?> CreateUserAsync(User user, CancellationToken cancellationToken = default)
    {
        using HttpResponseMessage response = await this.httpClient.PostAsJsonAsync(
            $"{AdministrationUsersBasePath}/",
            user,
            cancellationToken);

        if (!response.IsSuccessStatusCode)
        {
            return null;
        }

        return await response.Content.ReadFromJsonAsync<User>(cancellationToken);
    }

    public async ValueTask<User?> UpdateUserAsync(string userId, User user, CancellationToken cancellationToken = default)
    {
        using HttpResponseMessage response = await this.httpClient.PutAsJsonAsync(
            $"{AdministrationUsersBasePath}/{userId}",
            user,
            cancellationToken);

        if (!response.IsSuccessStatusCode)
        {
            return null;
        }

        return await response.Content.ReadFromJsonAsync<User>(cancellationToken);
    }

    public async ValueTask<bool> DeleteUserAsync(string userId, CancellationToken cancellationToken = default)
    {
        using HttpResponseMessage response = await this.httpClient.DeleteAsync(
            $"{AdministrationUsersBasePath}/{userId}",
            cancellationToken);

        return response.IsSuccessStatusCode;
    }
}
