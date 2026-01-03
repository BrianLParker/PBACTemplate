// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// AuthTokensService.Exceptions.cs See LICENSE.txt in the root folder of the solution.

using PBACTemplate.Services.Foundations.AuthTokens.Exceptions;

namespace PBACTemplate.Services.Foundations.AuthTokens;

public partial class AuthTokensService
{
    private ValueTask<T> TryCatch<T>(Func<ValueTask<T>> returningValueTaskFunction) =>
        ExecuteWithExceptionHandlingAsync(returningValueTaskFunction);

    private T TryCatch<T>(Func<T> returningFunction)
    {
        try
        {
            return returningFunction();
        }
        catch (NullAuthTokensException)
        {
            throw;
        }
        catch (InvalidAuthTokensException)
        {
            throw;
        }
        catch (FailedAuthTokensOperationException)
        {
            throw;
        }
        catch (Exception exception)
        {
            var failedServiceException =
                new FailedAuthTokensServiceException(
                    "Failed auth tokens service error occurred, contact support.",
                    exception);

            LogFailedAuthTokensServiceException(failedServiceException);

            throw new AuthTokensServiceException(
                "Auth tokens service error occurred, contact support.",
                failedServiceException);
        }
    }

    private async ValueTask<T> ExecuteWithExceptionHandlingAsync<T>(
        Func<ValueTask<T>> returningValueTaskFunction)
    {
        try
        {
            return await returningValueTaskFunction();
        }
        catch (NullAuthTokensException)
        {
            throw;
        }
        catch (InvalidAuthTokensException)
        {
            throw;
        }
        catch (FailedAuthTokensOperationException)
        {
            throw;
        }
        catch (Exception exception)
        {
            var failedServiceException =
                new FailedAuthTokensServiceException(
                    "Failed auth tokens service error occurred, contact support.",
                    exception);

            LogFailedAuthTokensServiceException(failedServiceException);

            throw new AuthTokensServiceException(
                "Auth tokens service error occurred, contact support.",
                failedServiceException);
        }
    }
}