// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// UserRolesServiceException.cs See LICENSE.txt in the root folder of the solution.

namespace PBACTemplate.Services.Foundations.UserRoles.Exceptions;

public class UserRolesServiceException(string message, Exception innerException)
    : Exception(message, innerException);