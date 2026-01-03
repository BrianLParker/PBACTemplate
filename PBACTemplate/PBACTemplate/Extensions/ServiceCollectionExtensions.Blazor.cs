// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// ServiceCollectionExtensions.Blazor.cs See LICENSE.txt in the root folder of the solution.

using Microsoft.AspNetCore.Components.Authorization;
using PBACTemplate.Components.Account;

namespace PBACTemplate.Extensions;

public static partial class ServiceCollectionExtensions
{
    extension(IServiceCollection services)
    {
        internal void AddBlazor()
        {
            services.AddRazorComponents()
                .AddInteractiveServerComponents()
                .AddInteractiveWebAssemblyComponents()
                .AddAuthenticationStateSerialization();

            services.AddCascadingAuthenticationState();
            services.AddScoped<IdentityRedirectManager>();
            services.AddScoped<AuthenticationStateProvider, IdentityRevalidatingAuthenticationStateProvider>();
        }
    }
}
