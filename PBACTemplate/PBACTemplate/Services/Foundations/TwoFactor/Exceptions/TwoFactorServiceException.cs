// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// TwoFactorServiceException.cs See LICENSE.txt in the root folder of the solution.

namespace PBACTemplate.Services.Foundations.TwoFactor.Exceptions;

public class TwoFactorServiceException(string message, Exception innerException)
    : Exception(message, innerException);