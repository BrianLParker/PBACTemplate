// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// TokensServiceException.cs See LICENSE.txt in the root folder of the solution.

namespace PBACTemplate.Services.Foundations.Tokens.Exceptions;

public class TokensServiceException(string message, Exception innerException)
    : Exception(message, innerException);