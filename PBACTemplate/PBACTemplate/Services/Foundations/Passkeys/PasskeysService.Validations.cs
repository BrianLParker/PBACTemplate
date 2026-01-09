// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// PasskeysService.Validations.cs See LICENSE.txt in the root folder of the solution.

using Microsoft.AspNetCore.Identity;
using PBACTemplate.Models.User;
using PBACTemplate.Services.Foundations.Passkeys.Exceptions;

namespace PBACTemplate.Services.Foundations.Passkeys;

public partial class PasskeysService
{
    private static void ValidateUser(ApplicationUser user)
    {
        if (user is null)
        {
            throw new NullPasskeysException("User cannot be null.");
        }
    }

    private static void ValidatePasskey(UserPasskeyInfo passkey)
    {
        if (passkey is null)
        {
            throw new NullPasskeysException("Passkey cannot be null.");
        }
    }

    private static void ValidateCredentialId(byte[] credentialId)
    {
        if (credentialId is null || credentialId.Length == 0)
        {
            throw new InvalidPasskeysException("Credential ID cannot be null or empty.");
        }
    }

    private static void ValidateIdentityResult(IdentityResult result)
    {
        if (!result.Succeeded)
        {
            var errors = string.Join(", ", result.Errors.Select(e => e.Description));

            throw new FailedPasskeysOperationException(
                $"Identity operation failed: {errors}");
        }
    }
}