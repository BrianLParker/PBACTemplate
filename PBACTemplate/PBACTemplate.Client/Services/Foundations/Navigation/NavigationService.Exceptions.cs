// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// NavigationService.Exceptions.cs See LICENSE.txt in the root folder of the solution.

using PBACTemplate.Client.Services.Foundations.Navigation.Exceptions;

namespace PBACTemplate.Client.Services.Foundations.Navigation;

public sealed partial class NavigationService
{
    private void TryCatch(Action action)
    {
        try
        {
            action();
        }
        catch (NullNavigationException)
        {
            throw;
        }
        catch (InvalidNavigationException)
        {
            throw;
        }
        catch (Exception exception)
        {
            var failedServiceException =
                new FailedNavigationServiceException(
                    "Failed navigation service error occurred, contact support.",
                    exception);

            LogFailedNavigationServiceException(failedServiceException);

            throw new NavigationServiceException(
                "Navigation service error occurred, contact support.",
                failedServiceException);
        }
    }

    private T TryCatch<T>(Func<T> returningFunction)
    {
        try
        {
            return returningFunction();
        }
        catch (NullNavigationException)
        {
            throw;
        }
        catch (InvalidNavigationException)
        {
            throw;
        }
        catch (Exception exception)
        {
            var failedServiceException =
                new FailedNavigationServiceException(
                    "Failed navigation service error occurred, contact support.",
                    exception);

            LogFailedNavigationServiceException(failedServiceException);

            throw new NavigationServiceException(
                "Navigation service error occurred, contact support.",
                failedServiceException);
        }
    }
}