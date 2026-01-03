// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// FailedPasskeysServiceException.cs See LICENSE.txt in the root folder of the solution.

namespace PBACTemplate.Services.Foundations.Passkeys.Exceptions;

public class FailedPasskeysServiceException(string message, Exception innerException)
    : Exception(message, innerException);