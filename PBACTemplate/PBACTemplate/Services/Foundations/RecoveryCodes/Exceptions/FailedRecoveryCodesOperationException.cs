// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// FailedRecoveryCodesOperationException.cs See LICENSE.txt in the root folder of the solution.

namespace PBACTemplate.Services.Foundations.RecoveryCodes.Exceptions;

public class FailedRecoveryCodesOperationException(string message) : Exception(message);