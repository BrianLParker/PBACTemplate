// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// FailedLoginServiceException.cs See LICENSE.txt in the root folder of the solution.

namespace PBACTemplate.Services.Foundations.Login.Exceptions;

public class FailedLoginServiceException(string message, Exception innerException)
    : Exception(message, innerException);