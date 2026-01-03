// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// EmailServiceException.cs See LICENSE.txt in the root folder of the solution.

namespace PBACTemplate.Services.Foundations.Email.Exceptions;

public class EmailServiceException(string message, Exception innerException)
    : Exception(message, innerException);