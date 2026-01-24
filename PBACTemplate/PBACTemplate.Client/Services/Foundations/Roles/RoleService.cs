// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// RoleService.cs See LICENSE.txt in the root folder of the solution.

using PBACTemplate.Client.Brokers.HttpClients;
using PBACTemplate.Client.Services.Foundations.Roles.Exceptions;
using System.Collections.Immutable;

namespace PBACTemplate.Client.Services.Foundations.Roles;

public sealed partial class RoleService(IHttpClientBroker httpClientBroker, ILogger<RoleService> logger) : IRoleService
{
    private readonly IHttpClientBroker httpClientBroker = httpClientBroker;
    private readonly ILogger<RoleService> logger = logger;

    public ValueTask<string> CreateRoleAsync(string roleName) =>
        TryCatch(async () =>
        {
            ValidateRoleName(roleName);

            LogCreatingRole(roleName);

            string createdRoleName = await this.httpClientBroker.CreateRoleAsync(roleName);

            if (string.IsNullOrWhiteSpace(createdRoleName))
            {
                throw new FailedRolesOperationException("Failed to create role.");
            }

            return createdRoleName;
        });

    public ValueTask<bool> RemoveRoleAsync(string roleName) =>
        TryCatch(async () =>
        {
            ValidateRoleName(roleName);

            LogRemovingRole(roleName);

            bool removed = await this.httpClientBroker.RemoveRoleAsync(roleName);

            if (!removed)
            {
                throw new FailedRolesOperationException($"Failed to remove role '{roleName}'.");
            }

            return true;
        });

    public ValueTask<string?> RetrieveRoleAsync(string roleName) =>
        TryCatch(async () =>
        {
            ValidateRoleName(roleName);

            LogRetrievingRole(roleName);

            return await this.httpClientBroker.RetrieveRoleAsync(roleName);
        });

    public ValueTask<ImmutableList<string>> RetrieveRolesAsync() =>
        TryCatch(async () =>
        {
            LogRetrievingRoles();

            return await this.httpClientBroker.RetrieveRolesAsync();
        });

    public ValueTask<string> UpdateRoleAsync(string roleName, string newRoleName) =>
        TryCatch(async () =>
        {
            ValidateRoleName(roleName);
            ValidateRoleName(newRoleName);

            LogUpdatingRole(roleName, newRoleName);

            string updatedRoleName = await this.httpClientBroker.UpdateRoleAsync(roleName, newRoleName);

            if (string.IsNullOrWhiteSpace(updatedRoleName))
            {
                throw new FailedRolesOperationException($"Failed to update role '{roleName}'.");
            }

            return updatedRoleName;
        });
}
