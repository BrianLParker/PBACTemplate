// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// AdministrationRolesEndpointsBuilderTests.Logic.cs See LICENSE.txt in the root folder of the solution.

using FluentAssertions;
using System.Net;
using System.Net.Http.Json;

namespace PBACTemplate.Tests.Unit;

public partial class AdministrationRolesEndpointsBuilderTests
{
    [Fact]
    public async Task GetRoleNames_ShouldReturnOkWithNames()
    {
        HttpClient client = this.factory.CreateClient();
        HttpResponseMessage response = await client.GetAsync("/Api/Administration/RoleNames/");

        response.StatusCode.Should().Be(HttpStatusCode.OK);
        var payload = await response.Content.ReadFromJsonAsync<List<string>>();
        payload.Should().BeEquivalentTo(new[] { "Admin", "Manager" });
    }

    [Fact]
    public async Task GetRoleName_WhenMissing_ShouldReturnNotFoundFromFilter()
    {
        HttpClient client = this.factory.CreateClient();
        HttpResponseMessage response = await client.GetAsync("/Api/Administration/RoleNames/Missing");

        response.StatusCode.Should().Be(HttpStatusCode.NotFound);
    }

    [Fact]
    public async Task PostRoleName_WithMissingBodyName_ShouldReturnBadRequest()
    {
        HttpClient client = this.factory.CreateClient();
        HttpResponseMessage response = await client.PostAsJsonAsync("/Api/Administration/RoleNames/", new { Name = "" });

        response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
    }

    [Fact]
    public async Task PostRoleName_ShouldReturnCreated()
    {
        HttpClient client = this.factory.CreateClient();
        HttpResponseMessage response = await client.PostAsJsonAsync("/Api/Administration/RoleNames/", new { Name = "NewRole" });

        response.StatusCode.Should().Be(HttpStatusCode.Created);
        string body = await response.Content.ReadAsStringAsync();
        body.Should().Contain("NewRole");
    }

    [Fact]
    public async Task PutRoleName_ShouldReturnOk()
    {
        HttpClient client = this.factory.CreateClient();
        HttpResponseMessage response = await client.PutAsJsonAsync("/Api/Administration/RoleNames/Old", new { Name = "New" });

        response.StatusCode.Should().Be(HttpStatusCode.OK);
    }

    [Fact]
    public async Task DeleteRoleName_ShouldReturnNoContent()
    {
        HttpClient client = this.factory.CreateClient();
        HttpResponseMessage response = await client.DeleteAsync("/Api/Administration/RoleNames/Gone");

        response.StatusCode.Should().Be(HttpStatusCode.NoContent);
    }
}