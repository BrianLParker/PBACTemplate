// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// InvalidRecoveryCodesException.cs See LICENSE.txt in the root folder of the solution.

namespace PBACTemplate.Services.Foundations.RecoveryCodes.Exceptions;

public class InvalidRecoveryCodesException(string message) : Exception(message);