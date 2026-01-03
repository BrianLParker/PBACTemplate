// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// FailedPasswordServiceException.cs See LICENSE.txt in the root folder of the solution.

namespace PBACTemplate.Services.Foundations.Password.Exceptions;

public class FailedPasswordServiceException(string message, Exception innerException)
    : Exception(message, innerException);