// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// FailedUsersServiceException.cs See LICENSE.txt in the root folder of the solution.

namespace PBACTemplate.Services.Foundations.Users.Exceptions;

public class FailedUsersServiceException(string message, Exception innerException)
    : Exception(message, innerException);