// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// NullTwoFactorException.cs See LICENSE.txt in the root folder of the solution.

namespace PBACTemplate.Services.Foundations.TwoFactor.Exceptions;

public class NullTwoFactorException(string message) : Exception(message);