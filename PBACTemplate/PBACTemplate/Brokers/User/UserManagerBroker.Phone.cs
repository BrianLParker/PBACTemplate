// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// UserManagerBroker.Phone.cs See LICENSE.txt in the root folder of the solution.

using Microsoft.AspNetCore.Identity;
using PBACTemplate.Models.Users;

namespace PBACTemplate.Brokers.User;

public sealed partial class UserManagerBroker
{
    public Task<string?> GetPhoneNumberAsync(ApplicationUser user) =>
        userManager.GetPhoneNumberAsync(user);

    public Task<IdentityResult> SetPhoneNumberAsync(ApplicationUser user, string? phoneNumber) =>
        userManager.SetPhoneNumberAsync(user, phoneNumber);

    public Task<bool> IsPhoneNumberConfirmedAsync(ApplicationUser user) =>
        userManager.IsPhoneNumberConfirmedAsync(user);

    public Task<string> GenerateChangePhoneNumberTokenAsync(ApplicationUser user, string phoneNumber) =>
        userManager.GenerateChangePhoneNumberTokenAsync(user, phoneNumber);

    public Task<bool> VerifyChangePhoneNumberTokenAsync(ApplicationUser user, string token, string phoneNumber) =>
        userManager.VerifyChangePhoneNumberTokenAsync(user, token, phoneNumber);

    public Task<IdentityResult> ChangePhoneNumberAsync(ApplicationUser user, string phoneNumber, string token) =>
        userManager.ChangePhoneNumberAsync(user, phoneNumber, token);
}