// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// LockoutService.Exceptions.cs See LICENSE.txt in the root folder of the solution.

using PBACTemplate.Services.Foundations.Lockout.Exceptions;

namespace PBACTemplate.Services.Foundations.Lockout;

public partial class LockoutService
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
        catch (NullLockoutException)
        {
            throw;
        }
        catch (FailedLockoutOperationException)
        {
            throw;
        }
        catch (Exception exception)
        {
            var failedServiceException =
                new FailedLockoutServiceException(
                    "Failed lockout service error occurred, contact support.",
                    exception);

            LogFailedLockoutServiceException(failedServiceException);

            throw new LockoutServiceException(
                "Lockout service error occurred, contact support.",
                failedServiceException);
        }
    }
}