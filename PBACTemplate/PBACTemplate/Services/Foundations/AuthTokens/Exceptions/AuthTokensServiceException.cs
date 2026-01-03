// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// AuthTokensServiceException.cs See LICENSE.txt in the root folder of the solution.

namespace PBACTemplate.Services.Foundations.AuthTokens.Exceptions;

public class AuthTokensServiceException(string message, Exception innerException)
    : Exception(message, innerException);