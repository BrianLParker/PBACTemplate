// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// ClaimsService.Exceptions.cs See LICENSE.txt in the root folder of the solution.

using PBACTemplate.Services.Foundations.Claims.Exceptions;

namespace PBACTemplate.Services.Foundations.Claims;

public sealed partial class ClaimsService
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
        catch (NullClaimsException)
        {
            throw;
        }
        catch (InvalidClaimsException)
        {
            throw;
        }
        catch (FailedClaimsOperationException)
        {
            throw;
        }
        catch (Exception exception)
        {
            var failedServiceException =
                new FailedClaimsServiceException(
                    "Failed claims service error occurred, contact support.",
                    exception);

            LogFailedClaimsServiceException(failedServiceException);

            throw new ClaimsServiceException(
                "Claims service error occurred, contact support.",
                failedServiceException);
        }
    }
}