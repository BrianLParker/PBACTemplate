// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// NullRoleClaimsException.cs See LICENSE.txt in the root folder of the solution.

namespace PBACTemplate.Services.Foundations.RoleClaims.Exceptions;

public class NullRoleClaimsException(string message) : Exception(message);