// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// TwoFactorService.Exceptions.cs See LICENSE.txt in the root folder of the solution.

using PBACTemplate.Services.Foundations.TwoFactor.Exceptions;

namespace PBACTemplate.Services.Foundations.TwoFactor;

public partial class TwoFactorService
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
        catch (NullTwoFactorException)
        {
            throw;
        }
        catch (InvalidTwoFactorException)
        {
            throw;
        }
        catch (FailedTwoFactorOperationException)
        {
            throw;
        }
        catch (Exception exception)
        {
            var failedServiceException =
                new FailedTwoFactorServiceException(
                    "Failed two-factor service error occurred, contact support.",
                    exception);

            LogFailedTwoFactorServiceException(failedServiceException);

            throw new TwoFactorServiceException(
                "Two-factor service error occurred, contact support.",
                failedServiceException);
        }
    }
}