// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// ServiceCollectionExtensions.cs See LICENSE.txt in the root folder of the solution.

namespace PBACTemplate.Extensions;

public static partial class ServiceCollectionExtensions
{

    extension(IServiceCollection services)
    {
        internal void AddServices()
        {
            services.AddBrokers();
            services.AddFoundations();
            services.AddOrchestrations();
        }
    }
}
