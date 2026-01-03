// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// PasskeysServiceException.cs See LICENSE.txt in the root folder of the solution.

namespace PBACTemplate.Services.Foundations.Passkeys.Exceptions;

public class PasskeysServiceException(string message, Exception innerException)
    : Exception(message, innerException);