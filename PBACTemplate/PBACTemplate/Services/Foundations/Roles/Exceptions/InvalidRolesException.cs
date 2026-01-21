// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// InvalidRolesException.cs See LICENSE.txt in the root folder of the solution.

namespace PBACTemplate.Services.Foundations.Roles.Exceptions;

public sealed class InvalidRolesException(string message) : Exception(message);