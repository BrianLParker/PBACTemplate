// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// NullRecoveryCodesException.cs See LICENSE.txt in the root folder of the solution.

namespace PBACTemplate.Services.Foundations.RecoveryCodes.Exceptions;

public class NullRecoveryCodesException(string message) : Exception(message);