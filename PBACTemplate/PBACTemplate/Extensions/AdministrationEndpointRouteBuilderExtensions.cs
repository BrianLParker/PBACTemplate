// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// AdministrationEndpointRouteBuilderExtensions.cs See LICENSE.txt in the root folder of the solution.

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PBACTemplate.Client.Models.Roles;
using PBACTemplate.Services.Orchestrations.Administration;

namespace PBACTemplate.Extensions;

internal static class AdministrationEndpointRouteBuilderExtensions
{
    public static IEndpointConventionBuilder MapAdministrationRoleEndpoints(this IEndpointRouteBuilder endpoints)
    {
        ArgumentNullException.ThrowIfNull(endpoints);

        RouteGroupBuilder rolesGroup = 
            endpoints.MapGroup("/Api/Administration/Roles")
                .RequireAuthorization();

        rolesGroup.MapGet(
            pattern: "/",
            handler: ([FromServices] IAdministrationOrchestrationService admin) =>
            {
                List<Role> roles = admin.Roles
                    .Select(r => new Role { Id = r.Id, Name = r.Name! })
                    .ToList();

                return TypedResults.Ok(roles);
            });

        rolesGroup.MapGet(
            pattern: "/{id}",
            handler: async ([FromServices] IAdministrationOrchestrationService admin, string id) =>
            {
                IdentityRole? role = await admin.RetrieveRoleByIdAsync(id);
                return role is null
                    ? Results.NotFound()
                    : TypedResults.Ok(new Role { Id = role.Id, Name = role.Name! });
            });

        rolesGroup.MapPost(
            pattern: "/",
            handler: async ([FromServices] IAdministrationOrchestrationService admin, [FromBody] Role role) =>
            {
                if (string.IsNullOrWhiteSpace(role?.Name))
                {
                    return Results.BadRequest("Role name is required.");
                }

                var created = await admin.CreateRoleAsync(role.Name);
                var dto = new Role { Id = created.Id, Name = created.Name! };

                return TypedResults.Created($"/Api/Administration/Roles/{dto.Id}", dto);
            });

        rolesGroup.MapPut(
            pattern: "/{id}",
            handler: async ([FromServices] IAdministrationOrchestrationService admin, string id, [FromBody] Role role) =>
            {
                if (string.IsNullOrWhiteSpace(role?.Name))
                {
                    return Results.BadRequest("Role name is required.");
                }

                var existing = await admin.RetrieveRoleByIdAsync(id);
                if (existing is null)
                {
                    return Results.NotFound();
                }

                var updated = await admin.UpdateRoleNameAsync(existing, role.Name);
                return TypedResults.Ok(new Role { Id = updated.Id, Name = updated.Name! });
            });

        rolesGroup.MapDelete(
            pattern: "/{id}",
            handler: async ([FromServices] IAdministrationOrchestrationService admin, string id) =>
            {
                var existing = await admin.RetrieveRoleByIdAsync(id);
                if (existing is null)
                {
                    return Results.NotFound();
            }

            await admin.DeleteRoleAsync(existing);
            return TypedResults.NoContent();
        });

        return rolesGroup;
    }
}