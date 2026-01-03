// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// FailedSecurityOperationException.cs See LICENSE.txt in the root folder of the solution.

namespace PBACTemplate.Services.Foundations.Security.Exceptions;

public class FailedSecurityOperationException(string message) : Exception(message);