// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// UserOrchestrationService.cs See LICENSE.txt in the root folder of the solution.

using Microsoft.AspNetCore.Identity;
using PBACTemplate.Data;
using PBACTemplate.Services.Foundations.AuthTokens;
using PBACTemplate.Services.Foundations.Claims;
using PBACTemplate.Services.Foundations.Email;
using PBACTemplate.Services.Foundations.Lockout;
using PBACTemplate.Services.Foundations.Login;
using PBACTemplate.Services.Foundations.Passkeys;
using PBACTemplate.Services.Foundations.Password;
using PBACTemplate.Services.Foundations.Phone;
using PBACTemplate.Services.Foundations.RecoveryCodes;
using PBACTemplate.Services.Foundations.Roles;
using PBACTemplate.Services.Foundations.Security;
using PBACTemplate.Services.Foundations.Tokens;
using PBACTemplate.Services.Foundations.TwoFactor;
using PBACTemplate.Services.Foundations.UserCrud;
using PBACTemplate.Services.Foundations.UserName;
using PBACTemplate.Services.Foundations.UserOptions;

namespace PBACTemplate.Services.Orchestrations.Users;

public partial class UserOrchestrationService(
    IUserNameService userNameService,
    IUserCrudService userCrudService,
    ITwoFactorService twoFactorService,
    ITokensService tokensService,
    ISecurityService securityService,
    IRolesService rolesService,
    IRecoveryCodesService recoveryCodesService,
    IPhoneService phoneService,
    IPasswordService passwordService,
    IPasskeysService passkeysService,
    ILoginService loginService,
    ILockoutService lockoutService,
    IEmailService emailService,
    IClaimsService claimsService,
    IAuthTokensService authTokensService,
    IUserOptionsService userOptionsService,
    ILogger<UserOrchestrationService> logger) : IUserOrchestrationService
{
    private readonly IAuthTokensService authTokensService = authTokensService;
    private readonly IUserOptionsService userOptionsService = userOptionsService;
    private readonly ILogger<UserOrchestrationService> logger = logger;
    private readonly IClaimsService claimsService = claimsService;
    private readonly IEmailService emailService = emailService;
    private readonly ILockoutService lockoutService = lockoutService;
    private readonly ILoginService loginService = loginService;
    private readonly IPasskeysService passkeysService = passkeysService;
    private readonly IPasswordService passwordService = passwordService;
    private readonly IPhoneService phoneService = phoneService;
    private readonly IRecoveryCodesService recoveryCodesService = recoveryCodesService;
    private readonly IRolesService rolesService = rolesService;
    private readonly ISecurityService securityService = securityService;
    private readonly ITokensService tokensService = tokensService;
    private readonly ITwoFactorService twoFactorService = twoFactorService;
    private readonly IUserCrudService userCrudService = userCrudService;
    private readonly IUserNameService userNameService = userNameService;

    // Properties - These would typically be injected or configured
    public ILogger Logger
    {
        get => userOptionsService.Logger;
        set => userOptionsService.Logger = value;
    }

    public IPasswordHasher<ApplicationUser> PasswordHasher
    {
        get => userOptionsService.PasswordHasher;
        set => userOptionsService.PasswordHasher = value;
    }

    public IList<IUserValidator<ApplicationUser>> UserValidators => userOptionsService.UserValidators;

    public IList<IPasswordValidator<ApplicationUser>> PasswordValidators => userOptionsService.PasswordValidators;

    public ILookupNormalizer KeyNormalizer
    {
        get => userOptionsService.KeyNormalizer;
        set => userOptionsService.KeyNormalizer = value;
    }

    public IdentityErrorDescriber ErrorDescriber
    {
        get => userOptionsService.ErrorDescriber;
        set => userOptionsService.ErrorDescriber = value;
    }

    public IdentityOptions Options
    {
        get => userOptionsService.Options;
        set => userOptionsService.Options = value;
    }

    public IServiceProvider ServiceProvider => userOptionsService.ServiceProvider;
    public bool SupportsUserAuthenticationTokens => userOptionsService.SupportsUserAuthenticationTokens;
    public bool SupportsUserAuthenticatorKey => userOptionsService.SupportsUserAuthenticatorKey;
    public bool SupportsUserTwoFactorRecoveryCodes => userOptionsService.SupportsUserTwoFactorRecoveryCodes;
    public bool SupportsUserTwoFactor => userOptionsService.SupportsUserTwoFactor;
    public bool SupportsUserPassword => userOptionsService.SupportsUserPassword;
    public bool SupportsUserSecurityStamp => userOptionsService.SupportsUserSecurityStamp;
    public bool SupportsUserRole => userOptionsService.SupportsUserRole;
    public bool SupportsUserLogin => userOptionsService.SupportsUserLogin;
    public bool SupportsUserEmail => userOptionsService.SupportsUserEmail;
    public bool SupportsUserPhoneNumber => userOptionsService.SupportsUserPhoneNumber;
    public bool SupportsUserClaim => userOptionsService.SupportsUserClaim;
    public bool SupportsUserLockout => userOptionsService.SupportsUserLockout;
    public bool SupportsQueryableUsers => userOptionsService.SupportsQueryableUsers;
    public bool SupportsUserPasskey => userOptionsService.SupportsUserPasskey;
    public IQueryable<ApplicationUser> Users => userOptionsService.Users;
}
