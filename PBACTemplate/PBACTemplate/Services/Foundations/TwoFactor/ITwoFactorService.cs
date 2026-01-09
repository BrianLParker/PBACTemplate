// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// ITwoFactorService.cs See LICENSE.txt in the root folder of the solution.

using PBACTemplate.Models.User;

namespace PBACTemplate.Services.Foundations.TwoFactor;

public interface ITwoFactorService
{
    ValueTask<bool> GetTwoFactorEnabledAsync(ApplicationUser user);
    ValueTask<ApplicationUser> SetTwoFactorEnabledAsync(ApplicationUser user, bool enabled);
    ValueTask<IList<string>> RetrieveValidTwoFactorProvidersAsync(ApplicationUser user);
    ValueTask<string> GenerateTwoFactorTokenAsync(ApplicationUser user, string tokenProvider);
    ValueTask<bool> VerifyTwoFactorTokenAsync(ApplicationUser user, string tokenProvider, string token);
}