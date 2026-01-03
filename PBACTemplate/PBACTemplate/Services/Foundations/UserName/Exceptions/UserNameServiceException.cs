// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// UserNameServiceException.cs See LICENSE.txt in the root folder of the solution.

namespace PBACTemplate.Services.Foundations.UserName.Exceptions;

public class UserNameServiceException(string message, Exception innerException)
    : Exception(message, innerException);