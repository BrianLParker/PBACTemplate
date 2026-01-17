// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// AccountOrchestrationService.Passkeys.cs See LICENSE.txt in the root folder of the solution.

using Microsoft.AspNetCore.Identity;
using PBACTemplate.Models.Users;

namespace PBACTemplate.Services.Orchestrations.Account;

public partial class AccountOrchestrationService
{
    public async Task<IdentityResult> AddOrUpdatePasskeyAsync(ApplicationUser user, UserPasskeyInfo passkey)
    {
        await this.passkeysService.AddOrUpdatePasskeyAsync(user, passkey);

        return IdentityResult.Success;
    }

    public async Task<IList<UserPasskeyInfo>> GetPasskeysAsync(ApplicationUser user) =>
        await this.passkeysService.RetrievePasskeysAsync(user);

    public async Task<UserPasskeyInfo?> GetPasskeyAsync(ApplicationUser user, byte[] credentialId) =>
        await this.passkeysService.RetrievePasskeyAsync(user, credentialId);

    public async Task<ApplicationUser?> FindByPasskeyIdAsync(byte[] credentialId) =>
        await this.passkeysService.RetrieveUserByPasskeyIdAsync(credentialId);

    public async Task<IdentityResult> RemovePasskeyAsync(ApplicationUser user, byte[] credentialId)
    {
        await this.passkeysService.RemovePasskeyAsync(user, credentialId);

        return IdentityResult.Success;
    }
}