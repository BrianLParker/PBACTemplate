// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// InvalidLoginException.cs See LICENSE.txt in the root folder of the solution.

namespace PBACTemplate.Services.Foundations.Login.Exceptions;

public class InvalidLoginException(string message) : Exception(message);