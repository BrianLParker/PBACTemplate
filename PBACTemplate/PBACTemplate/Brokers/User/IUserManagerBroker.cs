// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// IUserManagerBroker.cs See LICENSE.txt in the root folder of the solution.

using Microsoft.AspNetCore.Identity;
using PBACTemplate.Models.Users;

namespace PBACTemplate.Brokers.User;

/// <summary>
/// Interface for UserManagerBroker exposing all inherited public methods from UserManager.
/// </summary>
public partial interface IUserManagerBroker : IDisposable
{
    // Properties
    IQueryable<ApplicationUser> Users { get; }
    ILogger Logger { get; set; }
    IPasswordHasher<ApplicationUser> PasswordHasher { get; set; }
    IList<IUserValidator<ApplicationUser>> UserValidators { get; }
    IList<IPasswordValidator<ApplicationUser>> PasswordValidators { get; }
    ILookupNormalizer KeyNormalizer { get; set; }
    IdentityErrorDescriber ErrorDescriber { get; set; }
    IdentityOptions Options { get; set; }
    IServiceProvider ServiceProvider { get; }
    bool SupportsUserAuthenticationTokens { get; }
    bool SupportsUserAuthenticatorKey { get; }
    bool SupportsUserTwoFactorRecoveryCodes { get; }
    bool SupportsUserTwoFactor { get; }
    bool SupportsUserPassword { get; }
    bool SupportsUserSecurityStamp { get; }
    bool SupportsUserRole { get; }
    bool SupportsUserLogin { get; }
    bool SupportsUserEmail { get; }
    bool SupportsUserPhoneNumber { get; }
    bool SupportsUserClaim { get; }
    bool SupportsUserLockout { get; }
    bool SupportsQueryableUsers { get; }
    bool SupportsUserPasskey { get; }
}