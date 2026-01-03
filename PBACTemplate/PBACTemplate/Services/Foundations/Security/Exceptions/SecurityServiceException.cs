// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// SecurityServiceException.cs See LICENSE.txt in the root folder of the solution.

namespace PBACTemplate.Services.Foundations.Security.Exceptions;

public class SecurityServiceException(string message, Exception innerException)
    : Exception(message, innerException);