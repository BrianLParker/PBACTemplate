// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// IPasskeysService.cs See LICENSE.txt in the root folder of the solution.

using Microsoft.AspNetCore.Identity;
using PBACTemplate.Data;

namespace PBACTemplate.Services.Foundations.Passkeys;

public interface IPasskeysService
{
    ValueTask<ApplicationUser> AddOrUpdatePasskeyAsync(ApplicationUser user, UserPasskeyInfo passkey);
    ValueTask<IList<UserPasskeyInfo>> RetrievePasskeysAsync(ApplicationUser user);
    ValueTask<UserPasskeyInfo?> RetrievePasskeyAsync(ApplicationUser user, byte[] credentialId);
    ValueTask<ApplicationUser?> RetrieveUserByPasskeyIdAsync(byte[] credentialId);
    ValueTask<ApplicationUser> RemovePasskeyAsync(ApplicationUser user, byte[] credentialId);
}