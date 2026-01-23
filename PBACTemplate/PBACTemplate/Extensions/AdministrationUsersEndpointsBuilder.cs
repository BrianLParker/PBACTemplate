// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// AdministrationUsersEndpointsBuilder.cs See LICENSE.txt in the root folder of the solution.

using Microsoft.AspNetCore.Mvc;
using PBACTemplate.Client.Models.Users;
using PBACTemplate.Services.Foundations.UserCrud.Exceptions;
using PBACTemplate.Services.Foundations.Users;

namespace PBACTemplate.Extensions;

internal static class AdministrationUsersEndpointsBuilder
{
    public static RouteGroupBuilder MapAdministrationUsersEndpoints(this IEndpointRouteBuilder endpoints)
    {
        ArgumentNullException.ThrowIfNull(endpoints);

        RouteGroupBuilder usersGroup = endpoints.MapGroup("/Api/Administration/Users")
            .RequireAuthorization();

        usersGroup.AddEndpointFilter(new UsersExceptionsFilter());

        usersGroup.MapGet(
            pattern: "/",
            handler: async ([FromServices] IUserService userService) =>
            {
                var users = await userService.RetrieveUsersAsync();
                return TypedResults.Ok(users);
            });

        usersGroup.MapGet(
            pattern: "/{userId}",
            handler: async ([FromServices] IUserService userService, string userId) =>
            {
                User? user = await userService.RetrieveUserByIdAsync(userId);

                return user is null
                    ? Results.NotFound()
                    : TypedResults.Ok(user);
            });

        usersGroup.MapPost(
            pattern: "/",
            handler: async ([FromServices] IUserService userService, [FromBody] User request) =>
            {
                if (request is null)
                {
                    return Results.BadRequest("User payload is required.");
                }

                if (string.IsNullOrWhiteSpace(request.UserName))
                {
                    return Results.BadRequest("UserName is required.");
                }

                if (string.IsNullOrWhiteSpace(request.Email))
                {
                    return Results.BadRequest("Email is required.");
                }

                User created = await userService.CreateUserAsync(request);
                return TypedResults.Created($"/Api/Administration/Users/{created.Id}", created);
            });

        usersGroup.MapPut(
            pattern: "/{userId}",
            handler: async ([FromServices] IUserService userService, string userId, [FromBody] User request) =>
            {
                if (request is null)
                {
                    return Results.BadRequest("User payload is required.");
                }

                User updated = await userService.UpdateUserAsync(userId, request);
                return TypedResults.Ok(updated);
            });

        usersGroup.MapDelete(
            pattern: "/{userId}",
            handler: async ([FromServices] IUserService userService, string userId) =>
            {
                await userService.RemoveUserAsync(userId);
                return TypedResults.NoContent();
            });

        return usersGroup;
    }

    private sealed class UsersExceptionsFilter : IEndpointFilter
    {
        public async ValueTask<object?> InvokeAsync(
            EndpointFilterInvocationContext context,
            EndpointFilterDelegate next)
        {
            try
            {
                return await next(context);
            }
            catch (NullUserCrudException ex)
            {
                return Results.NotFound(ex.Message);
            }
            catch (InvalidUserCrudException ex)
            {
                return Results.BadRequest(ex.Message);
            }
            catch (FailedUserCrudOperationException ex)
            {
                return Results.BadRequest(ex.Message);
            }
            catch (UserCrudServiceException ex)
            {
                return Results.Problem(ex.Message, statusCode: StatusCodes.Status500InternalServerError);
            }
        }
    }
}
