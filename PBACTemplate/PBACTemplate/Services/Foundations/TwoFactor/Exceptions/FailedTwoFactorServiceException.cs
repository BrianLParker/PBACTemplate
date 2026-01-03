// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// FailedTwoFactorServiceException.cs See LICENSE.txt in the root folder of the solution.

namespace PBACTemplate.Services.Foundations.TwoFactor.Exceptions;

public class FailedTwoFactorServiceException(string message, Exception innerException)
    : Exception(message, innerException);