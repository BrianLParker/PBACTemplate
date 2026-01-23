// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// ServiceCollectionExtensions.cs See LICENSE.txt in the root folder of the solution.

using Microsoft.FluentUI.AspNetCore.Components;

namespace PBACTemplate.Client.Extensions;

public static partial class ServiceCollectionExtensions
{
    extension(IServiceCollection services)
    {
        public void AddPBACServices()
        {
            services.AddHttpClient();
            services.AddFluentUIComponents();
            services.AddAuthorizationCore();
            services.AddCascadingAuthenticationState();
            services.AddAuthenticationStateDeserialization();
            services.AddBrokers();
            services.AddFoundations();
            services.AddOrchestrations();
        }
    }
}
