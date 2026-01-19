// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// IAdministrationOrchestrationService.cs See LICENSE.txt in the root folder of the solution.

using Microsoft.AspNetCore.Identity;
using PBACTemplate.Client.Models.Users;
using System.Collections.Immutable;
using System.Security.Claims;

namespace PBACTemplate.Services.Orchestrations.Administration;

public interface IAdministrationOrchestrationService
{
    ValueTask<ImmutableList<string>> RetrieveRolesAsync();
    IQueryable<User> Users { get; }
}
