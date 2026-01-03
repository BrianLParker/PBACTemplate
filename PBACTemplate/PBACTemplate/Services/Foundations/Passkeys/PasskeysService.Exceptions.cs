// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// PasskeysService.Exceptions.cs See LICENSE.txt in the root folder of the solution.

using PBACTemplate.Services.Foundations.Passkeys.Exceptions;

namespace PBACTemplate.Services.Foundations.Passkeys;

public partial class PasskeysService
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
        catch (NullPasskeysException)
        {
            throw;
        }
        catch (InvalidPasskeysException)
        {
            throw;
        }
        catch (FailedPasskeysOperationException)
        {
            throw;
        }
        catch (Exception exception)
        {
            var failedServiceException =
                new FailedPasskeysServiceException(
                    "Failed passkeys service error occurred, contact support.",
                    exception);

            LogFailedPasskeysServiceException(failedServiceException);

            throw new PasskeysServiceException(
                "Passkeys service error occurred, contact support.",
                failedServiceException);
        }
    }
}