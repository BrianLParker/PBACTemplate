// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// UserRolesService.Exceptions.cs See LICENSE.txt in the root folder of the solution.

using PBACTemplate.Services.Foundations.UserRoles.Exceptions;

namespace PBACTemplate.Services.Foundations.UserRoles;

public partial class UserRolesService
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
        catch (NullUserRolesException)
        {
            throw;
        }
        catch (InvalidUserRolesException)
        {
            throw;
        }
        catch (FailedUserRolesOperationException)
        {
            throw;
        }
        catch (Exception exception)
        {
            var failedServiceException =
                new FailedUserRolesServiceException(
                    "Failed user roles service error occurred, contact support.",
                    exception);

            LogFailedRolesServiceException(failedServiceException);

            throw new UserRolesServiceException(
                "User roles service error occurred, contact support.",
                failedServiceException);
        }
    }
}