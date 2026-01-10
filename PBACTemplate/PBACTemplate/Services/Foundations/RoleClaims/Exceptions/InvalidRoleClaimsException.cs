// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// InvalidRoleClaimsException.cs See LICENSE.txt in the root folder of the solution.

namespace PBACTemplate.Services.Foundations.RoleClaims.Exceptions;

public class InvalidRoleClaimsException(string message) : Exception(message);