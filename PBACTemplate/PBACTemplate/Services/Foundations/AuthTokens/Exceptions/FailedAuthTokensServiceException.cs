// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// FailedAuthTokensServiceException.cs See LICENSE.txt in the root folder of the solution.

namespace PBACTemplate.Services.Foundations.AuthTokens.Exceptions;

public class FailedAuthTokensServiceException(string message, Exception innerException)
    : Exception(message, innerException);