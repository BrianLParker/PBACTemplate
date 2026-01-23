// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// ServiceCollectionExtensions.Orchestrations.cs See LICENSE.txt in the root folder of the solution.

using PBACTemplate.Client.Services.Orchestration.Navigation;

namespace PBACTemplate.Client.Extensions;

public static partial class ServiceCollectionExtensions
{
    extension(IServiceCollection services)
    {
        private void AddOrchestrations()
        {
            services.AddScoped<INavigationOrchestrationService, NavigationOrchestrationService>();
        }
    }
}