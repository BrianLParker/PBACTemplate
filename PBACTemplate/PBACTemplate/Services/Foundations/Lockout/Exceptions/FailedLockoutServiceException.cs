// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// FailedLockoutServiceException.cs See LICENSE.txt in the root folder of the solution.

namespace PBACTemplate.Services.Foundations.Lockout.Exceptions;

public class FailedLockoutServiceException(string message, Exception innerException)
    : Exception(message, innerException);