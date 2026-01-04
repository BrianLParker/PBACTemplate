// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// ServiceCollectionExtensions.Brokers.cs See LICENSE.txt in the root folder of the solution.

using PBACTemplate.Brokers.SignIn;
using PBACTemplate.Brokers.User;

namespace PBACTemplate.Extensions;

public static partial class ServiceCollectionExtensions
{
    extension(IServiceCollection services)
    {
        void AddBrokers()
        {
            services.AddScoped<IUserManagerBroker, UserManagerBroker>();
            services.AddScoped<ISignInManagerBroker, SignInManagerBroker>();
        }
    }
}
