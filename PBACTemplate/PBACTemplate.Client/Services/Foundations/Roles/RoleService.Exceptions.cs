// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// RoleService.Exceptions.cs See LICENSE.txt in the root folder of the solution.

using PBACTemplate.Client.Services.Foundations.Roles.Exceptions;

namespace PBACTemplate.Client.Services.Foundations.Roles;

public sealed partial class RoleService
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
        catch (NullRolesException)
        {
            throw;
        }
        catch (InvalidRolesException)
        {
            throw;
        }
        catch (FailedRolesOperationException)
        {
            throw;
        }
        catch (Exception exception)
        {
            var failedServiceException = new FailedRolesServiceException(
                "Failed roles service error occurred, contact support.",
                exception);

            LogFailedRolesServiceException(failedServiceException);

            throw new RolesServiceException(
                "Roles service error occurred, contact support.",
                failedServiceException);
        }
    }
}