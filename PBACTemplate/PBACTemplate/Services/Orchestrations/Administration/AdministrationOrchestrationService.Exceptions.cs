// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// AdministrationOrchestrationService.Exceptions.cs See LICENSE.txt in the root folder of the solution.

using PBACTemplate.Services.Orchestrations.Administration.Exceptions;

namespace PBACTemplate.Services.Orchestrations.Administration;

public sealed partial class AdministrationOrchestrationService
{
    private async ValueTask<T> TryCatch<T>(Func<ValueTask<T>> returningTask)
    {
        try
        {
            return await returningTask();
        }
        catch (Exception exception)
        {
            var failedServiceException =
                new FailedAdministrationOrchestrationServiceException(
                    "Failed administration orchestration service error occurred, contact support.",
                    exception);

            LogFailedAdministrationOrchestrationServiceException(failedServiceException);

            throw new AdministrationOrchestrationServiceException(
                "Administration orchestration service error occurred, contact support.",
                failedServiceException);
        }
    }
}