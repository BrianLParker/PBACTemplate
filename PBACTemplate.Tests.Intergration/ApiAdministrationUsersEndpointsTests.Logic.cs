// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// ApiAdministrationUsersEndpointsTests.Logic.cs See LICENSE.txt in the root folder of the solution.

using FluentAssertions;
using System.Net;
using System.Net.Http.Json;

namespace PBACTemplate.Tests.Integration;

public partial class ApiAdministrationUsersEndpointsTests
{
    [Fact]
    public async Task GetUsers_ShouldReturnOkWithUsers()
    {
        // Given
        HttpClient client = this.factory.CreateClient();

        // When
        HttpResponseMessage response = await client.GetAsync("/Api/Administration/Users/");

        // Then
        response.StatusCode.Should().Be(HttpStatusCode.OK);
        var payload = await response.Content.ReadFromJsonAsync<List<UserResponse>>();
        payload.Should().BeEquivalentTo(new[]
        {
            new UserResponse("1", "alice", "alice@example.com", "Alice", "Anderson"),
            new UserResponse("2", "bob", "bob@example.com", "Bob", "Baker")
        });
    }

    [Fact]
    public async Task GetUser_WhenMissing_ShouldReturnNotFoundFromFilter()
    {
        // Given
        HttpClient client = this.factory.CreateClient();

        // When
        HttpResponseMessage response = await client.GetAsync("/Api/Administration/Users/missing");

        // Then
        response.StatusCode.Should().Be(HttpStatusCode.NotFound);
    }

    [Fact]
    public async Task PostUser_WithMissingUserName_ShouldReturnBadRequest()
    {
        // Given
        HttpClient client = this.factory.CreateClient();

        // When
        HttpResponseMessage response = await client.PostAsJsonAsync("/Api/Administration/Users/", new
        {
            UserName = "",
            Email = "empty@example.com",
            FirstName = "Empty",
            LastName = "Name",
            Password = "P@ssword1"
        });

        // Then
        response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
    }

    [Fact]
    public async Task PostUser_ShouldReturnCreated()
    {
        // Given
        HttpClient client = this.factory.CreateClient();

        // When
        HttpResponseMessage response = await client.PostAsJsonAsync("/Api/Administration/Users/", new
        {
            UserName = "charlie",
            Email = "charlie@example.com",
            FirstName = "Charlie",
            LastName = "Chaplin",
            Password = "P@ssword1",
            EmailConfirmed = true
        });

        // Then
        response.StatusCode.Should().Be(HttpStatusCode.Created);
        string body = await response.Content.ReadAsStringAsync();
        body.Should().Contain("charlie");
    }

    [Fact]
    public async Task PutUser_ShouldReturnOk()
    {
        // Given
        HttpClient client = this.factory.CreateClient();

        // When
        HttpResponseMessage response = await client.PutAsJsonAsync("/Api/Administration/Users/1", new
        {
            Email = "alice+updated@example.com",
            FirstName = "Alice",
            LastName = "Anderson"
        });

        // Then
        response.StatusCode.Should().Be(HttpStatusCode.OK);
    }

    [Fact]
    public async Task DeleteUser_ShouldReturnNoContent()
    {
        // Given
        HttpClient client = this.factory.CreateClient();

        // When
        HttpResponseMessage response = await client.DeleteAsync("/Api/Administration/Users/1");

        // Then
        response.StatusCode.Should().Be(HttpStatusCode.NoContent);
    }

    private sealed record UserResponse(string Id, string UserName, string Email, string FirstName, string LastName);
}