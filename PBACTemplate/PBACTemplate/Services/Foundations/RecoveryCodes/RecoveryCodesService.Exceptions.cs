// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// RecoveryCodesService.Exceptions.cs See LICENSE.txt in the root folder of the solution.

using PBACTemplate.Services.Foundations.RecoveryCodes.Exceptions;

namespace PBACTemplate.Services.Foundations.RecoveryCodes;

public partial class RecoveryCodesService
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
        catch (NullRecoveryCodesException)
        {
            throw;
        }
        catch (InvalidRecoveryCodesException)
        {
            throw;
        }
        catch (FailedRecoveryCodesOperationException)
        {
            throw;
        }
        catch (Exception exception)
        {
            var failedServiceException =
                new FailedRecoveryCodesServiceException(
                    "Failed recovery codes service error occurred, contact support.",
                    exception);

            LogFailedRecoveryCodesServiceException(failedServiceException);

            throw new RecoveryCodesServiceException(
                "Recovery codes service error occurred, contact support.",
                failedServiceException);
        }
    }
}