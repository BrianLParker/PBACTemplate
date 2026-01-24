// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// ApiAdministrationRolesEndpointsTests.Logic.cs See LICENSE.txt in the root folder of the solution.

using FluentAssertions;
using System.Net;
using System.Net.Http.Json;

namespace PBACTemplate.Tests.Integration;

public partial class ApiAdministrationRolesEndpointsTests
{
    [Fact]
    public async Task GetRoleNames_ShouldReturnOkWithNames()
    {
        // Given
        HttpClient client = this.factory.CreateClient();

        // When
        HttpResponseMessage response = await client.GetAsync("/Api/Administration/Roles/");

        // Then
        response.StatusCode.Should().Be(HttpStatusCode.OK);
        var payload = await response.Content.ReadFromJsonAsync<List<string>>();
        payload.Should().BeEquivalentTo(new[] { "Admin", "Manager" });
    }

    [Fact]
    public async Task GetRoleName_WhenMissing_ShouldReturnNotFoundFromFilter()
    {
        // Given
        HttpClient client = this.factory.CreateClient();

        // When
        HttpResponseMessage response = await client.GetAsync("/Api/Administration/Roles/Missing");

        // Then
        response.StatusCode.Should().Be(HttpStatusCode.NotFound);
    }

    [Fact]
    public async Task PostRoleName_WithMissingBodyName_ShouldReturnBadRequest()
    {
        // Given
        HttpClient client = this.factory.CreateClient();

        // When
        HttpResponseMessage response = await client.PostAsJsonAsync("/Api/Administration/Roles/", new { Name = "" });

        // Then
        response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
    }

    [Fact]
    public async Task PostRoleName_ShouldReturnCreated()
    {
        // Given
        HttpClient client = this.factory.CreateClient();

        // When
        HttpResponseMessage response = await client.PostAsJsonAsync("/Api/Administration/Roles/", new { Name = "NewRole" });

        // Then
        response.StatusCode.Should().Be(HttpStatusCode.Created);
        string body = await response.Content.ReadAsStringAsync();
        body.Should().Contain("NewRole");
    }

    [Fact]
    public async Task PutRoleName_ShouldReturnOk()
    {
        // Given
        HttpClient client = this.factory.CreateClient();

        // When
        HttpResponseMessage response = await client.PutAsJsonAsync("/Api/Administration/Roles/Old", new { Name = "New" });

        // Then
        response.StatusCode.Should().Be(HttpStatusCode.OK);
    }

    [Fact]
    public async Task DeleteRoleName_ShouldReturnNoContent()
    {
        // Given
        HttpClient client = this.factory.CreateClient();

        // When
        HttpResponseMessage response = await client.DeleteAsync("/Api/Administration/Roles/Gone");

        // Then
        response.StatusCode.Should().Be(HttpStatusCode.NoContent);
    }
}