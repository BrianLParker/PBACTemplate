// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// SignInServiceException.cs See LICENSE.txt in the root folder of the solution.

namespace PBACTemplate.Services.Foundations.SignIn.Exceptions;

public class SignInServiceException(string message, Exception innerException)
    : Exception(message, innerException);