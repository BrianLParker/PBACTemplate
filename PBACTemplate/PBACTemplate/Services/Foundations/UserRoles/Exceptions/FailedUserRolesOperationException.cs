// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// FailedUserRolesOperationException.cs See LICENSE.txt in the root folder of the solution.

namespace PBACTemplate.Services.Foundations.UserRoles.Exceptions;

public class FailedUserRolesOperationException(string message) : Exception(message);