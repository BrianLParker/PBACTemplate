// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// ITokensService.cs See LICENSE.txt in the root folder of the solution.

using PBACTemplate.Models.User;

namespace PBACTemplate.Services.Foundations.Tokens;

public interface ITokensService
{
    ValueTask<string> GenerateUserTokenAsync(ApplicationUser user, string tokenProvider, string purpose);
    ValueTask<bool> VerifyUserTokenAsync(ApplicationUser user, string tokenProvider, string purpose, string token);
}