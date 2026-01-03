// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// FailedSecurityServiceException.cs See LICENSE.txt in the root folder of the solution.

namespace PBACTemplate.Services.Foundations.Security.Exceptions;

public class FailedSecurityServiceException(string message, Exception innerException)
    : Exception(message, innerException);