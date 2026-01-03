// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// ClaimsServiceException.cs See LICENSE.txt in the root folder of the solution.

namespace PBACTemplate.Services.Foundations.Claims.Exceptions;

public class ClaimsServiceException(string message, Exception innerException)
    : Exception(message, innerException);