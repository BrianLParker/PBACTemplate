// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// NullPasswordException.cs See LICENSE.txt in the root folder of the solution.

namespace PBACTemplate.Services.Foundations.Password.Exceptions;

public class NullPasswordException(string message) : Exception(message);