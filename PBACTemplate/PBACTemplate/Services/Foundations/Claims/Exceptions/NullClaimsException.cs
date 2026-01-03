// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// NullClaimsException.cs See LICENSE.txt in the root folder of the solution.

namespace PBACTemplate.Services.Foundations.Claims.Exceptions;

public class NullClaimsException(string message) : Exception(message);