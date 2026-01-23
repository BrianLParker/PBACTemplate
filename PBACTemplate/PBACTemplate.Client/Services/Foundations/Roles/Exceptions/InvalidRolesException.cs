// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// InvalidRolesException.cs See LICENSE.txt in the root folder of the solution.

namespace PBACTemplate.Client.Services.Foundations.Roles.Exceptions;

public class InvalidRolesException(string message) : Exception(message);