// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// HttpClientBroker.Roles.cs See LICENSE.txt in the root folder of the solution.

namespace PBACTemplate.Client.Brokers.HttpClients;

public partial class HttpClientBroker
{
    private const string RolesEndpoint = "Api/Administration/Roles";
    public ValueTask<string> CreateRoleAsync(string roleName) => throw new NotImplementedException();
    public ValueTask<bool> RemoveRoleAsync(string roleName) => throw new NotImplementedException();
    public ValueTask<string?> RetrieveRoleAsync(string roleName) => throw new NotImplementedException();
    public ValueTask<IReadOnlyList<string>> RetrieveRolesAsync() => throw new NotImplementedException();
    public ValueTask<string> UpdateRoleAsync(string roleName, string newRoleName) => throw new NotImplementedException();
}
