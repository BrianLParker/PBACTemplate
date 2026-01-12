// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// AdministrationOrchestrationServiceException.cs See LICENSE.txt in the root folder of the solution.

namespace PBACTemplate.Services.Orchestrations.Administration.Exceptions;

public class AdministrationOrchestrationServiceException(string message, Exception innerException)
    : Exception(message, innerException);