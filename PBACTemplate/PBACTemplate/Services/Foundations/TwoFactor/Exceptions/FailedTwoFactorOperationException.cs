// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// FailedTwoFactorOperationException.cs See LICENSE.txt in the root folder of the solution.

namespace PBACTemplate.Services.Foundations.TwoFactor.Exceptions;

public class FailedTwoFactorOperationException(string message) : Exception(message);