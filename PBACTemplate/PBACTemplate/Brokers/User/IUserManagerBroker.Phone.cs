// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// IUserManagerBroker.Phone.cs See LICENSE.txt in the root folder of the solution.

using Microsoft.AspNetCore.Identity;
using PBACTemplate.Models.Users;

namespace PBACTemplate.Brokers.User;

public partial interface IUserManagerBroker
{
    // Phone number operations
    Task<string?> GetPhoneNumberAsync(ApplicationUser user);
    Task<IdentityResult> SetPhoneNumberAsync(ApplicationUser user, string? phoneNumber);
    Task<bool> IsPhoneNumberConfirmedAsync(ApplicationUser user);
    Task<string> GenerateChangePhoneNumberTokenAsync(ApplicationUser user, string phoneNumber);
    Task<bool> VerifyChangePhoneNumberTokenAsync(ApplicationUser user, string token, string phoneNumber);
    Task<IdentityResult> ChangePhoneNumberAsync(ApplicationUser user, string phoneNumber, string token);
}