// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// LoginServiceException.cs See LICENSE.txt in the root folder of the solution.

namespace PBACTemplate.Services.Foundations.Login.Exceptions;

public class LoginServiceException(string message, Exception innerException)
    : Exception(message, innerException);