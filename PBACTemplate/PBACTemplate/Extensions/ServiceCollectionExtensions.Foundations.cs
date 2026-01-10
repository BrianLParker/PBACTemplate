// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// ServiceCollectionExtensions.Foundations.cs See LICENSE.txt in the root folder of the solution.

using PBACTemplate.Client.Services.Foundations.Navigation;
using PBACTemplate.Services.Foundations.AuthTokens;
using PBACTemplate.Services.Foundations.Claims;
using PBACTemplate.Services.Foundations.Email;
using PBACTemplate.Services.Foundations.Lockout;
using PBACTemplate.Services.Foundations.Login;
using PBACTemplate.Services.Foundations.Passkeys;
using PBACTemplate.Services.Foundations.Password;
using PBACTemplate.Services.Foundations.Phone;
using PBACTemplate.Services.Foundations.RecoveryCodes;
using PBACTemplate.Services.Foundations.RoleClaims;
using PBACTemplate.Services.Foundations.Roles;
using PBACTemplate.Services.Foundations.Security;
using PBACTemplate.Services.Foundations.SignIn;
using PBACTemplate.Services.Foundations.Tokens;
using PBACTemplate.Services.Foundations.TwoFactor;
using PBACTemplate.Services.Foundations.UserCrud;
using PBACTemplate.Services.Foundations.UserName;
using PBACTemplate.Services.Foundations.UserOptions;
using PBACTemplate.Services.Foundations.UserRoles;

namespace PBACTemplate.Extensions;

public static partial class ServiceCollectionExtensions
{
    extension(IServiceCollection services)
    {
        void AddFoundations()
        {
            services.AddScoped<IAuthTokensService, AuthTokensService>();
            services.AddScoped<IClaimsService, ClaimsService>();
            services.AddScoped<IEmailService, EmailService>();
            services.AddScoped<ILockoutService, LockoutService>();
            services.AddScoped<ILoginService, LoginService>();
            services.AddScoped<IPasskeysService, PasskeysService>();
            services.AddScoped<IPasswordService, PasswordService>();
            services.AddScoped<IPhoneService, PhoneService>();
            services.AddScoped<IRecoveryCodesService, RecoveryCodesService>();
            services.AddScoped<IUserRolesService, UserRolesService>();
            services.AddScoped<ISecurityService, SecurityService>();
            services.AddScoped<ITokensService, TokensService>();
            services.AddScoped<ITwoFactorService, TwoFactorService>();
            services.AddScoped<IUserCrudService, UserCrudService>();
            services.AddScoped<IUserNameService, UserNameService>();
            services.AddScoped<IUserOptionsService, UserOptionsService>();
            services.AddScoped<ISignInService, SignInService>();
            services.AddScoped<INavigationService, NavigationService>();
            services.AddScoped<IRoleClaimsService, RoleClaimsService>();
            services.AddScoped<IRolesService, RolesService>();
        }
    }
}
