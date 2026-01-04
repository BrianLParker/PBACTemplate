// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// FailedSignInServiceException.cs See LICENSE.txt in the root folder of the solution.

namespace PBACTemplate.Services.Foundations.SignIn.Exceptions;

public class FailedSignInServiceException(string message, Exception innerException)
    : Exception(message, innerException);