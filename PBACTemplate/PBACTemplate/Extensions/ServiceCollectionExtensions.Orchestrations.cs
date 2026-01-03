// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// ServiceCollectionExtensions.Orchestrations.cs See LICENSE.txt in the root folder of the solution.

using PBACTemplate.Services.Orchestrations.Users;

namespace PBACTemplate.Extensions;

public static partial class ServiceCollectionExtensions
{
    extension(IServiceCollection services)
    {
        void AddOrchestrations()
        {
            services.AddScoped<IUserOrchestrationService, UserOrchestrationService>();
        }
    }
}
