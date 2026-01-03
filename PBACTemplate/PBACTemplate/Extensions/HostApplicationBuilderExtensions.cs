// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// HostApplicationBuilderExtensions.cs See LICENSE.txt in the root folder of the solution.

namespace PBACTemplate.Extensions;

public static class HostApplicationBuilderExtensions
{
    extension(IHostApplicationBuilder builder)
    {
        public void AddPBAC()
        {
            builder.Services.AddBlazor();
            builder.Services.AddServices();
            builder.Services.AddIdentity(builder.Configuration);
        }
    }
}
