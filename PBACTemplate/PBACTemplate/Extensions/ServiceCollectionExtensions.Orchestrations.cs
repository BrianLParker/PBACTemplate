// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// ServiceCollectionExtensions.Orchestrations.cs See LICENSE.txt in the root folder of the solution.

using PBACTemplate.Services.Orchestrations.Account;
using PBACTemplate.Services.Orchestrations.Administration;

namespace PBACTemplate.Extensions;

public static partial class ServiceCollectionExtensions
{
    extension(IServiceCollection services)
    {
        void AddOrchestrations()
        {
            services.AddScoped<IAccountOrchestrationService, AccountOrchestrationService>();
            services.AddScoped<IAdministrationOrchestrationService, AdministrationOrchestrationService>();
        }
    }
}
