// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// RoleClaimsServiceException.cs See LICENSE.txt in the root folder of the solution.

namespace PBACTemplate.Services.Foundations.RoleClaims.Exceptions;

public class RoleClaimsServiceException(string message, Exception innerException)
    : Exception(message, innerException);