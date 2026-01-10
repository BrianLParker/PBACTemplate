// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// FailedRoleClaimsServiceException.cs See LICENSE.txt in the root folder of the solution.

namespace PBACTemplate.Services.Foundations.RoleClaims.Exceptions;

public class FailedRoleClaimsServiceException(string message, Exception innerException)
    : Exception(message, innerException);