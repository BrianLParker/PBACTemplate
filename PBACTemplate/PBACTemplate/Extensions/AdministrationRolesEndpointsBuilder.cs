// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// AdministrationRolesEndpointsBuilder.cs See LICENSE.txt in the root folder of the solution.

using Microsoft.AspNetCore.Mvc;
using PBACTemplate.Services.Foundations.Roles;
using PBACTemplate.Services.Foundations.Roles.Exceptions;

namespace PBACTemplate.Extensions;

internal static class AdministrationRolesEndpointsBuilder
{
    public static RouteGroupBuilder MapAdministrationRoleNamesEndpoints(this IEndpointRouteBuilder endpoints)
    {
        ArgumentNullException.ThrowIfNull(endpoints);

        RouteGroupBuilder roleNamesGroup = endpoints.MapGroup("/Api/Administration/Roles")
            .RequireAuthorization();

        roleNamesGroup.AddEndpointFilter(new RolesExceptionsFilter());

        roleNamesGroup.MapGet(
            pattern: "/",
            handler: async ([FromServices] IRolesService rolesService) =>
            {
                IReadOnlyList<string> roles = await rolesService.RetrieveRolesAsync();
                return TypedResults.Ok(roles);
            });

        roleNamesGroup.MapGet(
            pattern: "/{roleName}",
            handler: async ([FromServices] IRolesService rolesService, string roleName) =>
            {
                string? role = await rolesService.RetrieveRoleAsync(roleName);

                return role is null
                    ? Results.NotFound()
                    : TypedResults.Ok(role);
            });

        roleNamesGroup.MapPost(
            pattern: "/",
            handler: async ([FromServices] IRolesService rolesService, [FromBody] RoleNameRequest request) =>
            {
                if (string.IsNullOrWhiteSpace(request?.Name))
                {
                    return Results.BadRequest("Role name is required.");
                }

                string created = await rolesService.CreateRoleAsync(request.Name);
                return TypedResults.Created($"/Api/Administration/Roles/{created}", created);
            });

        roleNamesGroup.MapPut(
            pattern: "/{roleName}",
            handler: async ([FromServices] IRolesService rolesService, string roleName, [FromBody] RoleNameRequest request) =>
            {
                if (string.IsNullOrWhiteSpace(request?.Name))
                {
                    return Results.BadRequest("New role name is required.");
                }

                string updated = await rolesService.UpdateRoleAsync(roleName, request.Name);
                return TypedResults.Ok(updated);
            });

        roleNamesGroup.MapDelete(
            pattern: "/{roleName}",
            handler: async ([FromServices] IRolesService rolesService, string roleName) =>
            {
                await rolesService.RemoveRoleAsync(roleName);
                return TypedResults.NoContent();
            });

        return roleNamesGroup;
    }

    private sealed record RoleNameRequest(string Name);

    private sealed class RolesExceptionsFilter : IEndpointFilter
    {
        public async ValueTask<object?> InvokeAsync(
            EndpointFilterInvocationContext context,
            EndpointFilterDelegate next)
        {
            try
            {
                return await next(context);
            }
            catch (NullRolesException ex)
            {
                return Results.NotFound(ex.Message);
            }
            catch (InvalidRolesException ex)
            {
                return Results.BadRequest(ex.Message);
            }
            catch (RolesServiceException ex)
            {
                return Results.Problem(ex.Message, statusCode: StatusCodes.Status500InternalServerError);
            }
        }
    }
}
