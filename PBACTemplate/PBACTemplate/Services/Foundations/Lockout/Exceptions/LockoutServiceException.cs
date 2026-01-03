// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// LockoutServiceException.cs See LICENSE.txt in the root folder of the solution.

namespace PBACTemplate.Services.Foundations.Lockout.Exceptions;

public class LockoutServiceException(string message, Exception innerException)
    : Exception(message, innerException);