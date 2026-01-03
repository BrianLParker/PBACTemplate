// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// InvalidEmailException.cs See LICENSE.txt in the root folder of the solution.

namespace PBACTemplate.Services.Foundations.Email.Exceptions;

public class InvalidEmailException(string message) : Exception(message);