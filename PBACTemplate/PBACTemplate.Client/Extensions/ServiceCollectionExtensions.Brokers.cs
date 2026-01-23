// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// ServiceCollectionExtensions.Brokers.cs See LICENSE.txt in the root folder of the solution.

using PBACTemplate.Client.Brokers.DateTimes;
using PBACTemplate.Client.Brokers.HttpClients;
using PBACTemplate.Client.Brokers.Navigation;

namespace PBACTemplate.Client.Extensions;

public static partial class ServiceCollectionExtensions
{
    extension(IServiceCollection services)
    {
        private void AddBrokers()
        {
            services.AddScoped<IDateTimeBroker, DateTimeBroker>();
            services.AddScoped<INavigationBroker, NavigationBroker>();
            services.AddScoped<IHttpClientBroker, HttpClientBroker>();
        }
    }
}
