// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// UserManagerBroker.Security.cs See LICENSE.txt in the root folder of the solution.

using Microsoft.AspNetCore.Identity;
using PBACTemplate.Data;

namespace PBACTemplate.Brokers.User;

public sealed partial class UserManagerBroker
{
    public Task<string> GetSecurityStampAsync(ApplicationUser user) =>
        userManager.GetSecurityStampAsync(user);

    public Task<IdentityResult> UpdateSecurityStampAsync(ApplicationUser user) =>
        userManager.UpdateSecurityStampAsync(user);

    public Task<byte[]> CreateSecurityTokenAsync(ApplicationUser user) =>
        userManager.CreateSecurityTokenAsync(user);

    public Task<string> GenerateConcurrencyStampAsync(ApplicationUser user) =>
        userManager.GenerateConcurrencyStampAsync(user);
}