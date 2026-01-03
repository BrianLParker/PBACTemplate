// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// EmailService.Exceptions.cs See LICENSE.txt in the root folder of the solution.

using PBACTemplate.Services.Foundations.Email.Exceptions;

namespace PBACTemplate.Services.Foundations.Email;

public partial class EmailService
{
    private ValueTask<T> TryCatch<T>(Func<ValueTask<T>> returningValueTaskFunction) =>
        ExecuteWithExceptionHandlingAsync(returningValueTaskFunction);

    private T TryCatch<T>(Func<T> returningFunction)
    {
        try
        {
            return returningFunction();
        }
        catch (NullEmailException)
        {
            throw;
        }
        catch (InvalidEmailException)
        {
            throw;
        }
        catch (FailedEmailOperationException)
        {
            throw;
        }
        catch (Exception exception)
        {
            var failedServiceException =
                new FailedEmailServiceException(
                    "Failed email service error occurred, contact support.",
                    exception);

            LogFailedEmailServiceException(failedServiceException);

            throw new EmailServiceException(
                "Email service error occurred, contact support.",
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
        catch (NullEmailException)
        {
            throw;
        }
        catch (InvalidEmailException)
        {
            throw;
        }
        catch (FailedEmailOperationException)
        {
            throw;
        }
        catch (Exception exception)
        {
            var failedServiceException =
                new FailedEmailServiceException(
                    "Failed email service error occurred, contact support.",
                    exception);

            LogFailedEmailServiceException(failedServiceException);

            throw new EmailServiceException(
                "Email service error occurred, contact support.",
                failedServiceException);
        }
    }
}