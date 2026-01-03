// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// FailedUserNameServiceException.cs See LICENSE.txt in the root folder of the solution.

namespace PBACTemplate.Services.Foundations.UserName.Exceptions;

public class FailedUserNameServiceException(string message, Exception innerException)
    : Exception(message, innerException);