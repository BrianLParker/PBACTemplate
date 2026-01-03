// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// NullLockoutException.cs See LICENSE.txt in the root folder of the solution.

namespace PBACTemplate.Services.Foundations.Lockout.Exceptions;

public class NullLockoutException(string message) : Exception(message);