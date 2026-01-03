// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// FailedPasskeysOperationException.cs See LICENSE.txt in the root folder of the solution.

namespace PBACTemplate.Services.Foundations.Passkeys.Exceptions;

public class FailedPasskeysOperationException(string message) : Exception(message);