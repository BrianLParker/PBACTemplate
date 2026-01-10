// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// FailedRoleClaimsOperationException.cs See LICENSE.txt in the root folder of the solution.

namespace PBACTemplate.Services.Foundations.RoleClaims.Exceptions;

public class FailedRoleClaimsOperationException(string message) : Exception(message);