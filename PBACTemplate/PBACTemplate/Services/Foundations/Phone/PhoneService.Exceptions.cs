// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// PhoneService.Exceptions.cs See LICENSE.txt in the root folder of the solution.

using PBACTemplate.Services.Foundations.Phone.Exceptions;

namespace PBACTemplate.Services.Foundations.Phone;

public partial class PhoneService
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
        catch (NullPhoneException)
        {
            throw;
        }
        catch (InvalidPhoneException)
        {
            throw;
        }
        catch (FailedPhoneOperationException)
        {
            throw;
        }
        catch (Exception exception)
        {
            var failedServiceException =
                new FailedPhoneServiceException(
                    "Failed phone service error occurred, contact support.",
                    exception);

            LogFailedPhoneServiceException(failedServiceException);

            throw new PhoneServiceException(
                "Phone service error occurred, contact support.",
                failedServiceException);
        }
    }
}