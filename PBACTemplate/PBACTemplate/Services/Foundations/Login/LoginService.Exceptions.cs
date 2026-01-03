// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// LoginService.Exceptions.cs See LICENSE.txt in the root folder of the solution.

using PBACTemplate.Services.Foundations.Login.Exceptions;

namespace PBACTemplate.Services.Foundations.Login;

public partial class LoginService
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
        catch (NullLoginException)
        {
            throw;
        }
        catch (InvalidLoginException)
        {
            throw;
        }
        catch (FailedLoginOperationException)
        {
            throw;
        }
        catch (Exception exception)
        {
            var failedServiceException =
                new FailedLoginServiceException(
                    "Failed login service error occurred, contact support.",
                    exception);

            LogFailedLoginServiceException(failedServiceException);

            throw new LoginServiceException(
                "Login service error occurred, contact support.",
                failedServiceException);
        }
    }
}