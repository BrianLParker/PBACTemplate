// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// UserGridSortByExtensions.cs See LICENSE.txt in the root folder of the solution.

using PBACTemplate.Models.Users;

namespace PBACTemplate.Models.Administration;

public static class UserGridSortByExtensions
{
    extension(UserGridSortBy sortBy)
    {
        public string DisplayText =>
            sortBy switch
            {
                UserGridSortBy.EmailConfirmed => "Email Confirmed",
                UserGridSortBy.LockoutEnabled => "Lockout Enabled",
                UserGridSortBy.Email => "Email",
                UserGridSortBy.UserName => "User Name",
                _ => "User Name"
            };

        public string PropertyName =>
            sortBy switch
            {
                UserGridSortBy.EmailConfirmed => nameof(ApplicationUser.EmailConfirmed),
                UserGridSortBy.Email => nameof(ApplicationUser.Email),
                UserGridSortBy.LockoutEnabled => nameof(ApplicationUser.LockoutEnabled),
                UserGridSortBy.UserName => nameof(ApplicationUser.UserName),
                _ => nameof(ApplicationUser.UserName)
            };
    }
}
