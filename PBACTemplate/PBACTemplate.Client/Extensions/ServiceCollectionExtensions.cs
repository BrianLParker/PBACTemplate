// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// ServiceCollectionExtensions.cs See LICENSE.txt in the root folder of the solution.

using Microsoft.FluentUI.AspNetCore.Components;
using PBACTemplate.Client.Brokers.Navigation;
using PBACTemplate.Client.Services.Foundations.Navigation;

namespace PBACTemplate.Client.Extensions;

public static partial class ServiceCollectionExtensions
{
    extension(IServiceCollection services)
    {
        public void AddPBACServices()
        {
            services.AddFluentUIComponents();
            services.AddAuthorizationCore();
            services.AddCascadingAuthenticationState();
            services.AddAuthenticationStateDeserialization();
            services.AddScoped<INavigationBroker, NavigationBroker>();
            services.AddScoped<INavigationService, NavigationService>();
        }
    }
}
