// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// IAdministrationOrchestrationService.cs See LICENSE.txt in the root folder of the solution.

using PBACTemplate.Client.Models.Users;
using System.Collections.Immutable;

namespace PBACTemplate.Services.Orchestrations.Administration;

public interface IAdministrationOrchestrationService
{
    ValueTask<ImmutableList<string>> RetrieveRolesAsync();
    IQueryable<User> Users { get; }
}
