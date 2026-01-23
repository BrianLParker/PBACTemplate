// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// IAdministrationOrchestrationService.cs See LICENSE.txt in the root folder of the solution.

using PBACTemplate.Models.Users;
using System.Collections.Immutable;

namespace PBACTemplate.Services.Orchestrations.Administration;

public interface IAdministrationOrchestrationService
{
    ValueTask<ImmutableList<string>> RetrieveRolesAsync();
    IQueryable<ApplicationUser> Users { get; }
}
