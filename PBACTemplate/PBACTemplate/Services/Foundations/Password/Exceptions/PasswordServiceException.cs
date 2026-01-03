// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// PasswordServiceException.cs See LICENSE.txt in the root folder of the solution.

namespace PBACTemplate.Services.Foundations.Password.Exceptions;

public class PasswordServiceException(string message, Exception innerException)
    : Exception(message, innerException);