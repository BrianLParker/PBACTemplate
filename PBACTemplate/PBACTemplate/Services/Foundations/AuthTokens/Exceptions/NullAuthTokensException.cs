// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// NullAuthTokensException.cs See LICENSE.txt in the root folder of the solution.

namespace PBACTemplate.Services.Foundations.AuthTokens.Exceptions;

public class NullAuthTokensException(string message) : Exception(message);