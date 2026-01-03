// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// FailedLoginOperationException.cs See LICENSE.txt in the root folder of the solution.

namespace PBACTemplate.Services.Foundations.Login.Exceptions;

public class FailedLoginOperationException(string message) : Exception(message);