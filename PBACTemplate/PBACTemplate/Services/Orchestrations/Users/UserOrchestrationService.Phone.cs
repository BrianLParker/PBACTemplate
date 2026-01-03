// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// UserOrchestrationService.Phone.cs See LICENSE.txt in the root folder of the solution.

using Microsoft.AspNetCore.Identity;
using PBACTemplate.Data;

namespace PBACTemplate.Services.Orchestrations.Users;

public partial class UserOrchestrationService
{
    public async Task<string?> GetPhoneNumberAsync(ApplicationUser user) =>
        await this.phoneService.RetrievePhoneNumberAsync(user);

    public async Task<IdentityResult> SetPhoneNumberAsync(ApplicationUser user, string? phoneNumber)
    {
        await this.phoneService.SetPhoneNumberAsync(user, phoneNumber);

        return IdentityResult.Success;
    }

    public async Task<bool> IsPhoneNumberConfirmedAsync(ApplicationUser user) =>
        await this.phoneService.IsPhoneNumberConfirmedAsync(user);

    public async Task<string> GenerateChangePhoneNumberTokenAsync(ApplicationUser user, string phoneNumber) =>
        await this.phoneService.GenerateChangePhoneNumberTokenAsync(user, phoneNumber);

    public async Task<bool> VerifyChangePhoneNumberTokenAsync(ApplicationUser user, string token, string phoneNumber) =>
        await this.phoneService.VerifyChangePhoneNumberTokenAsync(user, token, phoneNumber);

    public async Task<IdentityResult> ChangePhoneNumberAsync(ApplicationUser user, string phoneNumber, string token)
    {
        await this.phoneService.ChangePhoneNumberAsync(user, phoneNumber, token);

        return IdentityResult.Success;
    }
}