// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// RecoveryCodesServiceException.cs See LICENSE.txt in the root folder of the solution.

namespace PBACTemplate.Services.Foundations.RecoveryCodes.Exceptions;

public class RecoveryCodesServiceException(string message, Exception innerException)
    : Exception(message, innerException);