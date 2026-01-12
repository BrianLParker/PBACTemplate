// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// AdministrationOrchestrationService.Logging.cs See LICENSE.txt in the root folder of the solution.

namespace PBACTemplate.Services.Orchestrations.Administration;

public sealed partial class AdministrationOrchestrationService
{
    [LoggerMessage(
        Level = LogLevel.Error,
        Message = "Failed administration orchestration service error occurred, contact support.")]
    private partial void LogFailedAdministrationOrchestrationServiceException(Exception exception);
}