// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// SecurityService.Exceptions.cs See LICENSE.txt in the root folder of the solution.

using PBACTemplate.Services.Foundations.Security.Exceptions;

namespace PBACTemplate.Services.Foundations.Security;

public partial class SecurityService
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
        catch (NullSecurityException)
        {
            throw;
        }
        catch (FailedSecurityOperationException)
        {
            throw;
        }
        catch (Exception exception)
        {
            var failedServiceException =
                new FailedSecurityServiceException(
                    "Failed security service error occurred, contact support.",
                    exception);

            LogFailedSecurityServiceException(failedServiceException);

            throw new SecurityServiceException(
                "Security service error occurred, contact support.",
                failedServiceException);
        }
    }
}