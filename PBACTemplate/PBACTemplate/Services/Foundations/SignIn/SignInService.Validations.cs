// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// SignInService.Validations.cs See LICENSE.txt in the root folder of the solution.

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using PBACTemplate.Models.User;
using PBACTemplate.Services.Foundations.SignIn.Exceptions;
using System.Security.Claims;

namespace PBACTemplate.Services.Foundations.SignIn;

public sealed partial class SignInService
{
    private static void ValidateUser(ApplicationUser user)
    {
        if (user is null)
        {
            throw new NullSignInException("User cannot be null.");
        }
    }

    private static void ValidatePrincipal(ClaimsPrincipal principal)
    {
        if (principal is null)
        {
            throw new NullSignInException("Claims principal cannot be null.");
        }
    }

    private static void ValidateAuthenticationProperties(AuthenticationProperties authenticationProperties)
    {
        if (authenticationProperties is null)
        {
            throw new NullSignInException("Authentication properties cannot be null.");
        }
    }

    private static void ValidateClaims(IEnumerable<Claim> claims)
    {
        if (claims is null)
        {
            throw new NullSignInException("Claims cannot be null.");
        }
    }

    private static void ValidatePassword(string password)
    {
        if (string.IsNullOrWhiteSpace(password))
        {
            throw new InvalidSignInException("Password cannot be null or whitespace.");
        }
    }

    private static void ValidateUserName(string userName)
    {
        if (string.IsNullOrWhiteSpace(userName))
        {
            throw new InvalidSignInException("User name cannot be null or whitespace.");
        }
    }

    private static void ValidateCode(string code)
    {
        if (string.IsNullOrWhiteSpace(code))
        {
            throw new InvalidSignInException("Code cannot be null or whitespace.");
        }
    }

    private static void ValidateRecoveryCode(string recoveryCode)
    {
        if (string.IsNullOrWhiteSpace(recoveryCode))
        {
            throw new InvalidSignInException("Recovery code cannot be null or whitespace.");
        }
    }

    private static void ValidateProvider(string provider)
    {
        if (string.IsNullOrWhiteSpace(provider))
        {
            throw new InvalidSignInException("Provider cannot be null or whitespace.");
        }
    }

    private static void ValidateLoginProvider(string loginProvider)
    {
        if (string.IsNullOrWhiteSpace(loginProvider))
        {
            throw new InvalidSignInException("Login provider cannot be null or whitespace.");
        }
    }

    private static void ValidateProviderKey(string providerKey)
    {
        if (string.IsNullOrWhiteSpace(providerKey))
        {
            throw new InvalidSignInException("Provider key cannot be null or whitespace.");
        }
    }

    private static void ValidateExternalLoginInfo(ExternalLoginInfo externalLoginInfo)
    {
        if (externalLoginInfo is null)
        {
            throw new NullSignInException("External login info cannot be null.");
        }
    }

    private static void ValidatePasskeyUserEntity(PasskeyUserEntity passkeyUserEntity)
    {
        if (passkeyUserEntity is null)
        {
            throw new NullSignInException("Passkey user entity cannot be null.");
        }
    }

    private static void ValidateCredentialJson(string credentialJson)
    {
        if (string.IsNullOrWhiteSpace(credentialJson))
        {
            throw new InvalidSignInException("Credential JSON cannot be null or whitespace.");
        }
    }
}