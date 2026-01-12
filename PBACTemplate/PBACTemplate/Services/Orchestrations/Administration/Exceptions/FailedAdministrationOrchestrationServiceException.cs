// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// FailedAdministrationOrchestrationServiceException.cs See LICENSE.txt in the root folder of the solution.

namespace PBACTemplate.Services.Orchestrations.Administration.Exceptions;

public class FailedAdministrationOrchestrationServiceException(string message, Exception innerException)
    : Exception(message, innerException);