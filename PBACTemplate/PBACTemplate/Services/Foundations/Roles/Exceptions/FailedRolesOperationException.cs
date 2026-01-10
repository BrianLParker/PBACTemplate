// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// FailedRolesOperationException.cs See LICENSE.txt in the root folder of the solution.

namespace PBACTemplate.Services.Foundations.Roles.Exceptions;

public class FailedRolesOperationException(string message) : Exception(message);