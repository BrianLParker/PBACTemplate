// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// ISecurityService.cs See LICENSE.txt in the root folder of the solution.

using PBACTemplate.Data;

namespace PBACTemplate.Services.Foundations.Security;

public interface ISecurityService
{
    ValueTask<string> RetrieveSecurityStampAsync(ApplicationUser user);
    ValueTask<ApplicationUser> UpdateSecurityStampAsync(ApplicationUser user);
    ValueTask<byte[]> CreateSecurityTokenAsync(ApplicationUser user);
    ValueTask<string> GenerateConcurrencyStampAsync(ApplicationUser user);
}