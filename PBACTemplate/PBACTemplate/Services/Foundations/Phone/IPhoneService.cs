// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// IPhoneService.cs See LICENSE.txt in the root folder of the solution.

using PBACTemplate.Models.Users;

namespace PBACTemplate.Services.Foundations.Phone;

public interface IPhoneService
{
    ValueTask<string?> RetrievePhoneNumberAsync(ApplicationUser user);
    ValueTask<ApplicationUser> SetPhoneNumberAsync(ApplicationUser user, string? phoneNumber);
    ValueTask<bool> IsPhoneNumberConfirmedAsync(ApplicationUser user);
    ValueTask<string> GenerateChangePhoneNumberTokenAsync(ApplicationUser user, string phoneNumber);
    ValueTask<bool> VerifyChangePhoneNumberTokenAsync(ApplicationUser user, string token, string phoneNumber);
    ValueTask<ApplicationUser> ChangePhoneNumberAsync(ApplicationUser user, string phoneNumber, string token);
}