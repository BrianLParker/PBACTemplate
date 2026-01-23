// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// UsersServiceException.cs See LICENSE.txt in the root folder of the solution.

namespace PBACTemplate.Client.Services.Foundations.Users.Exceptions;

public class UsersServiceException(string message, Exception innerException)
    : Exception(message, innerException);