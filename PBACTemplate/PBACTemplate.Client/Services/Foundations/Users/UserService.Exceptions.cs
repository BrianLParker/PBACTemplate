// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// UserService.Exceptions.cs See LICENSE.txt in the root folder of the solution.

using PBACTemplate.Client.Services.Foundations.Users.Exceptions;

namespace PBACTemplate.Client.Services.Foundations.Users;

public sealed partial class UserService
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
        catch (NullUsersException)
        {
            throw;
        }
        catch (InvalidUsersException)
        {
            throw;
        }
        catch (FailedUsersOperationException)
        {
            throw;
        }
        catch (Exception exception)
        {
            var failedServiceException =
                new FailedUsersServiceException(
                    "Failed users service error occurred, contact support.",
                    exception);

            LogFailedUsersServiceException(failedServiceException);

            throw new UsersServiceException(
                "Users service error occurred, contact support.",
                failedServiceException);
        }
    }
}