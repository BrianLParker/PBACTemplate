// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// InvalidUserRolesException.cs See LICENSE.txt in the root folder of the solution.

namespace PBACTemplate.Services.Foundations.UserRoles.Exceptions;

public class InvalidUserRolesException(string message) : Exception(message);