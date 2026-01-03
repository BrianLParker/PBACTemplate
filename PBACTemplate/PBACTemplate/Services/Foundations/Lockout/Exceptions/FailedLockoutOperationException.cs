// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// FailedLockoutOperationException.cs See LICENSE.txt in the root folder of the solution.

namespace PBACTemplate.Services.Foundations.Lockout.Exceptions;

public class FailedLockoutOperationException(string message) : Exception(message);