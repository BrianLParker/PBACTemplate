// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// UserManagerBroker.Properties.cs See LICENSE.txt in the root folder of the solution.

using Microsoft.AspNetCore.Identity;
using PBACTemplate.Models.Users;

namespace PBACTemplate.Brokers.User;

public sealed partial class UserManagerBroker
{
    public ILogger Logger
    {
        get => userManager.Logger;
        set => userManager.Logger = value;
    }

    public IPasswordHasher<ApplicationUser> PasswordHasher
    {
        get => userManager.PasswordHasher;
        set => userManager.PasswordHasher = value;
    }

    public IList<IUserValidator<ApplicationUser>> UserValidators => userManager.UserValidators;

    public IList<IPasswordValidator<ApplicationUser>> PasswordValidators => userManager.PasswordValidators;

    public ILookupNormalizer KeyNormalizer
    {
        get => userManager.KeyNormalizer;
        set => userManager.KeyNormalizer = value;
    }

    public IdentityErrorDescriber ErrorDescriber
    {
        get => userManager.ErrorDescriber;
        set => userManager.ErrorDescriber = value;
    }

    public IdentityOptions Options
    {
        get => userManager.Options;
        set => userManager.Options = value;
    }

    public IServiceProvider ServiceProvider => userManager.ServiceProvider;
    public bool SupportsUserAuthenticationTokens => userManager.SupportsUserAuthenticationTokens;
    public bool SupportsUserAuthenticatorKey => userManager.SupportsUserAuthenticatorKey;
    public bool SupportsUserTwoFactorRecoveryCodes => userManager.SupportsUserTwoFactorRecoveryCodes;
    public bool SupportsUserTwoFactor => userManager.SupportsUserTwoFactor;
    public bool SupportsUserPassword => userManager.SupportsUserPassword;
    public bool SupportsUserSecurityStamp => userManager.SupportsUserSecurityStamp;
    public bool SupportsUserRole => userManager.SupportsUserRole;
    public bool SupportsUserLogin => userManager.SupportsUserLogin;
    public bool SupportsUserEmail => userManager.SupportsUserEmail;
    public bool SupportsUserPhoneNumber => userManager.SupportsUserPhoneNumber;
    public bool SupportsUserClaim => userManager.SupportsUserClaim;
    public bool SupportsUserLockout => userManager.SupportsUserLockout;
    public bool SupportsQueryableUsers => userManager.SupportsQueryableUsers;
    public bool SupportsUserPasskey => userManager.SupportsUserPasskey;
}