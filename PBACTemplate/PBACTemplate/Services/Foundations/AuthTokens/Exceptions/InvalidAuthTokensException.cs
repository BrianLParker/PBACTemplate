// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// InvalidAuthTokensException.cs See LICENSE.txt in the root folder of the solution.

namespace PBACTemplate.Services.Foundations.AuthTokens.Exceptions;

public class InvalidAuthTokensException(string message) : Exception(message);