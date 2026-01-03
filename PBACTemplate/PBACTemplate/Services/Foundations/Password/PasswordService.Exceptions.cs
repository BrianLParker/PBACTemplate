// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// PasswordService.Exceptions.cs See LICENSE.txt in the root folder of the solution.

using PBACTemplate.Services.Foundations.Password.Exceptions;

namespace PBACTemplate.Services.Foundations.Password;

public partial class PasswordService
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
        catch (NullPasswordException)
        {
            throw;
        }
        catch (InvalidPasswordException)
        {
            throw;
        }
        catch (FailedPasswordOperationException)
        {
            throw;
        }
        catch (Exception exception)
        {
            var failedServiceException =
                new FailedPasswordServiceException(
                    "Failed password service error occurred, contact support.",
                    exception);

            LogFailedPasswordServiceException(failedServiceException);

            throw new PasswordServiceException(
                "Password service error occurred, contact support.",
                failedServiceException);
        }
    }
}