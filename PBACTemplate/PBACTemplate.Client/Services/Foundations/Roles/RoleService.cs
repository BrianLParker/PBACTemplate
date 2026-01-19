// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// RoleService.cs See LICENSE.txt in the root folder of the solution.

using PBACTemplate.Client.Brokers.HttpClients;

namespace PBACTemplate.Client.Services.Foundations.Roles;

public sealed partial class RoleService(IHttpClientBroker httpClientBroker, ILogger<RoleService> logger) : IRoleService
{
    private readonly IHttpClientBroker httpClientBroker = httpClientBroker;
    private readonly ILogger<RoleService> logger = logger;

    public ValueTask<string> CreateRoleAsync(string roleName) => throw new NotImplementedException();
    public ValueTask<bool> RemoveRoleAsync(string roleName) => throw new NotImplementedException();
    public ValueTask<string?> RetrieveRoleAsync(string roleName) => throw new NotImplementedException();
    public ValueTask<IReadOnlyList<string>> RetrieveRolesAsync() => throw new NotImplementedException();
    public ValueTask<string> UpdateRoleAsync(string roleName, string newRoleName) => throw new NotImplementedException();
}
