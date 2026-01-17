// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// AccountOrchestrationService.cs See LICENSE.txt in the root folder of the solution.

using Microsoft.AspNetCore.Identity;
using PBACTemplate.Models.Users;
using PBACTemplate.Services.Foundations.AuthTokens;
using PBACTemplate.Services.Foundations.Claims;
using PBACTemplate.Services.Foundations.Email;
using PBACTemplate.Services.Foundations.Lockout;
using PBACTemplate.Services.Foundations.Login;
using PBACTemplate.Services.Foundations.Passkeys;
using PBACTemplate.Services.Foundations.Password;
using PBACTemplate.Services.Foundations.Phone;
using PBACTemplate.Services.Foundations.RecoveryCodes;
using PBACTemplate.Services.Foundations.Security;
using PBACTemplate.Services.Foundations.Tokens;
using PBACTemplate.Services.Foundations.TwoFactor;
using PBACTemplate.Services.Foundations.UserCrud;
using PBACTemplate.Services.Foundations.UserName;
using PBACTemplate.Services.Foundations.UserOptions;
using PBACTemplate.Services.Foundations.UserRoles;

namespace PBACTemplate.Services.Orchestrations.Account;

public sealed partial class AccountOrchestrationService(
    IUserNameService userNameService,
    IUserCrudService userCrudService,
    ITwoFactorService twoFactorService,
    ITokensService tokensService,
    ISecurityService securityService,
    IUserRolesService rolesService,
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
    ILogger<AccountOrchestrationService> logger) : IAccountOrchestrationService
{
    private readonly IAuthTokensService authTokensService = authTokensService;
    private readonly IUserOptionsService userOptionsService = userOptionsService;
    private readonly ILogger<AccountOrchestrationService> logger = logger;
    private readonly IClaimsService claimsService = claimsService;
    private readonly IEmailService emailService = emailService;
    private readonly ILockoutService lockoutService = lockoutService;
    private readonly ILoginService loginService = loginService;
    private readonly IPasskeysService passkeysService = passkeysService;
    private readonly IPasswordService passwordService = passwordService;
    private readonly IPhoneService phoneService = phoneService;
    private readonly IRecoveryCodesService recoveryCodesService = recoveryCodesService;
    private readonly IUserRolesService rolesService = rolesService;
    private readonly ISecurityService securityService = securityService;
    private readonly ITokensService tokensService = tokensService;
    private readonly ITwoFactorService twoFactorService = twoFactorService;
    private readonly IUserCrudService userCrudService = userCrudService;
    private readonly IUserNameService userNameService = userNameService;

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
