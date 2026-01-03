// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// InvalidPasswordException.cs See LICENSE.txt in the root folder of the solution.

namespace PBACTemplate.Services.Foundations.Password.Exceptions;

public class InvalidPasswordException(string message) : Exception(message);