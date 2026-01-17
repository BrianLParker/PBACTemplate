// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// UserCrudService.Exceptions.cs See LICENSE.txt in the root folder of the solution.

using PBACTemplate.Services.Foundations.UserCrud.Exceptions;

namespace PBACTemplate.Services.Foundations.UserCrud;

public partial class UserCrudService
{
    private ValueTask<T> TryCatch<T>(Func<ValueTask<T>> returningValueTaskFunction) =>
        ExecuteWithExceptionHandlingAsync(returningValueTaskFunction);

    private T TryCatch<T>(Func<T> returningFunction) =>
        ExecuteWithExceptionHandling(returningFunction);

    private async ValueTask<T> ExecuteWithExceptionHandlingAsync<T>(
        Func<ValueTask<T>> returningValueTaskFunction)
    {
        try
        {
            return await returningValueTaskFunction();
        }
        catch (NullUserCrudException)
        {
            throw;
        }
        catch (InvalidUserCrudException)
        {
            throw;
        }
        catch (FailedUserCrudOperationException)
        {
            throw;
        }
        catch (Exception exception)
        {
            var failedServiceException =
                new FailedUserCrudServiceException(
                    "Failed user CRUD service error occurred, contact support.",
                    exception);

            LogFailedUserCrudServiceException(failedServiceException);

            throw new UserCrudServiceException(
                "User CRUD service error occurred, contact support.",
                failedServiceException);
        }
    }

    private T ExecuteWithExceptionHandling<T>(Func<T> returningFunction)
    {
        try
        {
            return returningFunction();
        }
        catch (NullUserCrudException)
        {
            throw;
        }
        catch (InvalidUserCrudException)
        {
            throw;
        }
        catch (FailedUserCrudOperationException)
        {
            throw;
        }
        catch (Exception exception)
        {
            var failedServiceException =
                new FailedUserCrudServiceException(
                    "Failed user CRUD service error occurred, contact support.",
                    exception);

            LogFailedUserCrudServiceException(failedServiceException);

            throw new UserCrudServiceException(
                "User CRUD service error occurred, contact support.",
                failedServiceException);
        }
    }
}