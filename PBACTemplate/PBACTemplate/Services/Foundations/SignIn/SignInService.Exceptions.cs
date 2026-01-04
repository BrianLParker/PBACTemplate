// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// SignInService.Exceptions.cs See LICENSE.txt in the root folder of the solution.

using PBACTemplate.Services.Foundations.SignIn.Exceptions;

namespace PBACTemplate.Services.Foundations.SignIn;

public sealed partial class SignInService
{
    private ValueTask<T> TryCatch<T>(Func<ValueTask<T>> returningValueTaskFunction) =>
        ExecuteWithExceptionHandlingAsync(returningValueTaskFunction);

    private ValueTask TryCatch(Func<ValueTask> returningValueTaskFunction) =>
        ExecuteWithExceptionHandlingAsync(returningValueTaskFunction);

    private T TryCatch<T>(Func<T> returningFunction)
    {
        try
        {
            return returningFunction();
        }
        catch (NullSignInException)
        {
            throw;
        }
        catch (InvalidSignInException)
        {
            throw;
        }
        catch (Exception exception)
        {
            var failedServiceException =
                new FailedSignInServiceException(
                    "Failed sign-in service error occurred, contact support.",
                    exception);

            LogFailedSignInServiceException(failedServiceException);

            throw new SignInServiceException(
                "Sign-in service error occurred, contact support.",
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
        catch (NullSignInException)
        {
            throw;
        }
        catch (InvalidSignInException)
        {
            throw;
        }
        catch (Exception exception)
        {
            var failedServiceException =
                new FailedSignInServiceException(
                    "Failed sign-in service error occurred, contact support.",
                    exception);

            LogFailedSignInServiceException(failedServiceException);

            throw new SignInServiceException(
                "Sign-in service error occurred, contact support.",
                failedServiceException);
        }
    }

    private async ValueTask ExecuteWithExceptionHandlingAsync(Func<ValueTask> returningValueTaskFunction)
    {
        try
        {
            await returningValueTaskFunction();
        }
        catch (NullSignInException)
        {
            throw;
        }
        catch (InvalidSignInException)
        {
            throw;
        }
        catch (Exception exception)
        {
            var failedServiceException =
                new FailedSignInServiceException(
                    "Failed sign-in service error occurred, contact support.",
                    exception);

            LogFailedSignInServiceException(failedServiceException);

            throw new SignInServiceException(
                "Sign-in service error occurred, contact support.",
                failedServiceException);
        }
    }
}