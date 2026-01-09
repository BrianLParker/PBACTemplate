// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// UserManagerBroker.Passkeys.cs See LICENSE.txt in the root folder of the solution.

using Microsoft.AspNetCore.Identity;
using PBACTemplate.Models.User;

namespace PBACTemplate.Brokers.User;

public sealed partial class UserManagerBroker
{
    public Task<IdentityResult> AddOrUpdatePasskeyAsync(ApplicationUser user, UserPasskeyInfo passkey) =>
        userManager.AddOrUpdatePasskeyAsync(user, passkey);

    public Task<IList<UserPasskeyInfo>> GetPasskeysAsync(ApplicationUser user) =>
        userManager.GetPasskeysAsync(user);

    public Task<UserPasskeyInfo?> GetPasskeyAsync(ApplicationUser user, byte[] credentialId) =>
        userManager.GetPasskeyAsync(user, credentialId);

    public Task<ApplicationUser?> FindByPasskeyIdAsync(byte[] credentialId) =>
        userManager.FindByPasskeyIdAsync(credentialId);

    public Task<IdentityResult> RemovePasskeyAsync(ApplicationUser user, byte[] credentialId) =>
        userManager.RemovePasskeyAsync(user, credentialId);
}