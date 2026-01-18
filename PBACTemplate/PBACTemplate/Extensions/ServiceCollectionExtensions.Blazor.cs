// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// ServiceCollectionExtensions.Blazor.cs See LICENSE.txt in the root folder of the solution.

using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.FluentUI.AspNetCore.Components;
using PBACTemplate.Components.Account;

namespace PBACTemplate.Extensions;

public static partial class ServiceCollectionExtensions
{
    extension(IServiceCollection services)
    {
        internal void AddBlazor()
        {
            services.AddFluentUIComponents();
            services.AddHttpClient();

            services.AddRazorComponents()
                .AddInteractiveServerComponents()
                .AddInteractiveWebAssemblyComponents()
                .AddAuthenticationStateSerialization(options =>
                {
                    options.SerializeAllClaims = true;
                });

            services.AddCascadingAuthenticationState();
            services.AddScoped<IdentityRedirectManager>();
            services.AddScoped<AuthenticationStateProvider, IdentityRevalidatingAuthenticationStateProvider>();
        }
    }
}
