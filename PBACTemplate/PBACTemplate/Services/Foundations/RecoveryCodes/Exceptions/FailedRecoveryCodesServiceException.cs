// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// FailedRecoveryCodesServiceException.cs See LICENSE.txt in the root folder of the solution.

namespace PBACTemplate.Services.Foundations.RecoveryCodes.Exceptions;

public class FailedRecoveryCodesServiceException(string message, Exception innerException)
    : Exception(message, innerException);