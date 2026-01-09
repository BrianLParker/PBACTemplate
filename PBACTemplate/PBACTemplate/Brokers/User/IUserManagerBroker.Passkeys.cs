// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// IUserManagerBroker.Passkeys.cs See LICENSE.txt in the root folder of the solution.

using Microsoft.AspNetCore.Identity;
using PBACTemplate.Models.User;

namespace PBACTemplate.Brokers.User;

public partial interface IUserManagerBroker
{
    // Passkey operations
    Task<IdentityResult> AddOrUpdatePasskeyAsync(ApplicationUser user, UserPasskeyInfo passkey);
    Task<IList<UserPasskeyInfo>> GetPasskeysAsync(ApplicationUser user);
    Task<UserPasskeyInfo?> GetPasskeyAsync(ApplicationUser user, byte[] credentialId);
    Task<ApplicationUser?> FindByPasskeyIdAsync(byte[] credentialId);
    Task<IdentityResult> RemovePasskeyAsync(ApplicationUser user, byte[] credentialId);
}