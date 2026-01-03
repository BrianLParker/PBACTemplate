// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// NullSecurityException.cs See LICENSE.txt in the root folder of the solution.

namespace PBACTemplate.Services.Foundations.Security.Exceptions;

public class NullSecurityException(string message) : Exception(message);