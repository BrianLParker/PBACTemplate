// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// ServiceCollectionExtensions.Brokers.cs See LICENSE.txt in the root folder of the solution.

using PBACTemplate.Brokers.Roles;
using PBACTemplate.Brokers.SignIn;
using PBACTemplate.Brokers.User;
using PBACTemplate.Client.Brokers.DateTimes;
using PBACTemplate.Client.Brokers.Navigation;

namespace PBACTemplate.Extensions;

public static partial class ServiceCollectionExtensions
{
    extension(IServiceCollection services)
    {
        void AddBrokers()
        {
            services.AddScoped<IDateTimeBroker, DateTimeBroker>();
            services.AddScoped<IUserManagerBroker, UserManagerBroker>();
            services.AddScoped<ISignInManagerBroker, SignInManagerBroker>();
            services.AddScoped<INavigationBroker, NavigationBroker>();
            services.AddScoped<IRoleManagerBroker, RoleManagerBroker>();
        }
    }
}
