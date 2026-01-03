// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// FailedPasswordOperationException.cs See LICENSE.txt in the root folder of the solution.

namespace PBACTemplate.Services.Foundations.Password.Exceptions;

public class FailedPasswordOperationException(string message) : Exception(message);