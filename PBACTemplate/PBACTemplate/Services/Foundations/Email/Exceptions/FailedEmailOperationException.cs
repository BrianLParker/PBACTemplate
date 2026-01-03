// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// FailedEmailOperationException.cs See LICENSE.txt in the root folder of the solution.

namespace PBACTemplate.Services.Foundations.Email.Exceptions;

public class FailedEmailOperationException(string message) : Exception(message);