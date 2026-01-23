// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// ServiceCollectionExtensions.Foundations.cs See LICENSE.txt in the root folder of the solution.

using PBACTemplate.Client.Services.Foundations.Navigation;
using PBACTemplate.Client.Services.Foundations.Roles;
using PBACTemplate.Client.Services.Foundations.Users;

namespace PBACTemplate.Client.Extensions;

public static partial class ServiceCollectionExtensions
{
    extension(IServiceCollection services)
    {
        private void AddFoundations()
        {
            services.AddScoped<INavigationService, NavigationService>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<IUserService, UserService>();
        }
    }
}