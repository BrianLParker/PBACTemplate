// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// FailedRolesServiceException.cs See LICENSE.txt in the root folder of the solution.

namespace PBACTemplate.Services.Foundations.Roles.Exceptions;

public sealed class FailedRolesServiceException(string message, Exception innerException)
    : Exception(message, innerException);