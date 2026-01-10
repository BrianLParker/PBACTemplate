// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// RoleClaimsService.Exceptions.cs See LICENSE.txt in the root folder of the solution.

using PBACTemplate.Services.Foundations.RoleClaims.Exceptions;

namespace PBACTemplate.Services.Foundations.RoleClaims;

public sealed partial class RoleClaimsService
{
    private ValueTask<T> TryCatch<T>(Func<ValueTask<T>> returningValueTaskFunction) =>
        ExecuteWithExceptionHandlingAsync(returningValueTaskFunction);

    private async ValueTask<T> ExecuteWithExceptionHandlingAsync<T>(
        Func<ValueTask<T>> returningValueTaskFunction)
    {
        try
        {
            return await returningValueTaskFunction();
        }
        catch (NullRoleClaimsException)
        {
            throw;
        }
        catch (InvalidRoleClaimsException)
        {
            throw;
        }
        catch (FailedRoleClaimsOperationException)
        {
            throw;
        }
        catch (Exception exception)
        {
            var failedServiceException =
                new FailedRoleClaimsServiceException(
                    "Failed role claims service error occurred, contact support.",
                    exception);

            LogFailedRoleClaimsServiceException(failedServiceException);

            throw new RoleClaimsServiceException(
                "Role claims service error occurred, contact support.",
                failedServiceException);
        }
    }
}