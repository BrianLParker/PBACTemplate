// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// UserManagerBroker.cs See LICENSE.txt in the root folder of the solution.

using Microsoft.AspNetCore.Identity;
using PBACTemplate.Data;

namespace PBACTemplate.Brokers.User;

public sealed partial class UserManagerBroker(
    UserManager<ApplicationUser> userManager) : IUserManagerBroker
{
    private readonly UserManager<ApplicationUser> userManager = userManager;

    public void Dispose() => userManager.Dispose();
}
