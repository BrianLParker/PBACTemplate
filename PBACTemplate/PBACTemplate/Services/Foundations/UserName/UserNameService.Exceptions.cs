// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// UserNameService.Exceptions.cs See LICENSE.txt in the root folder of the solution.

using PBACTemplate.Services.Foundations.UserName.Exceptions;

namespace PBACTemplate.Services.Foundations.UserName;

public partial class UserNameService
{
    private ValueTask<T> TryCatch<T>(Func<ValueTask<T>> returningValueTaskFunction) =>
        ExecuteWithExceptionHandlingAsync(returningValueTaskFunction);

    private T TryCatch<T>(Func<T> returningFunction)
    {
        try
        {
            return returningFunction();
        }
        catch (NullUserNameException)
        {
            throw;
        }
        catch (FailedUserNameOperationException)
        {
            throw;
        }
        catch (Exception exception)
        {
            var failedServiceException =
                new FailedUserNameServiceException(
                    "Failed user name service error occurred, contact support.",
                    exception);

            LogFailedUserNameServiceException(failedServiceException);

            throw new UserNameServiceException(
                "User name service error occurred, contact support.",
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
        catch (NullUserNameException)
        {
            throw;
        }
        catch (FailedUserNameOperationException)
        {
            throw;
        }
        catch (Exception exception)
        {
            var failedServiceException =
                new FailedUserNameServiceException(
                    "Failed user name service error occurred, contact support.",
                    exception);

            LogFailedUserNameServiceException(failedServiceException);

            throw new UserNameServiceException(
                "User name service error occurred, contact support.",
                failedServiceException);
        }
    }
}