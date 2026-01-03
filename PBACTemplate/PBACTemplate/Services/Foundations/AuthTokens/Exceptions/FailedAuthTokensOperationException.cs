// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// FailedAuthTokensOperationException.cs See LICENSE.txt in the root folder of the solution.

namespace PBACTemplate.Services.Foundations.AuthTokens.Exceptions;

public class FailedAuthTokensOperationException(string message) : Exception(message);