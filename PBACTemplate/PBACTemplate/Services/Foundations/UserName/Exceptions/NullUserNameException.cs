// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// NullUserNameException.cs See LICENSE.txt in the root folder of the solution.

namespace PBACTemplate.Services.Foundations.UserName.Exceptions;

public class NullUserNameException(string message) : Exception(message);