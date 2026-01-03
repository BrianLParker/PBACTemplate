// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// NullTokensException.cs See LICENSE.txt in the root folder of the solution.

namespace PBACTemplate.Services.Foundations.Tokens.Exceptions;

public class NullTokensException(string message) : Exception(message);