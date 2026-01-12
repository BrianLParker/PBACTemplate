// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// IAccountOrchestrationService.cs See LICENSE.txt in the root folder of the solution.

using Microsoft.AspNetCore.Identity;
using PBACTemplate.Models.User;

namespace PBACTemplate.Services.Orchestrations.Account;

/// <summary>
/// Interface for UserManagerBroker exposing all inherited public methods from UserManager.
/// </summary>
public partial interface IAccountOrchestrationService
{
    // Properties
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
    IQueryable<ApplicationUser> Users { get; }
}