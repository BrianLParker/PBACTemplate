// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// Program.cs See LICENSE.txt in the root folder of the solution.

using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using PBACTemplate.Client.Brokers.Navigation;
using PBACTemplate.Client.Services.Foundations.Navigation;

namespace PBACTemplate.Client
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);

            builder.Services.AddAuthorizationCore();
            builder.Services.AddCascadingAuthenticationState();
            builder.Services.AddAuthenticationStateDeserialization();
            builder.Services.AddScoped<INavigationBroker, NavigationBroker>();
            builder.Services.AddScoped<INavigationService, NavigationService>();
            await builder.Build().RunAsync();
        }
    }
}
