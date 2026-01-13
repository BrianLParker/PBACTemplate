// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// Program.cs See LICENSE.txt in the root folder of the solution.

using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using PBACTemplate.Client.Extensions;

namespace PBACTemplate.Client
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            WebAssemblyHostBuilder builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.Services.AddPBACServices();
            await builder.Build().RunAsync();
        }
    }
}
