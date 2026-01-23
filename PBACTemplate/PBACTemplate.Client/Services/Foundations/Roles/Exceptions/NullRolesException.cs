// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// NullRolesException.cs See LICENSE.txt in the root folder of the solution.

namespace PBACTemplate.Client.Services.Foundations.Roles.Exceptions;

public class NullRolesException(string message) : Exception(message);