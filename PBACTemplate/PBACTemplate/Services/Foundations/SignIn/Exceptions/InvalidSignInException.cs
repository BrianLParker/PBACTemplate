// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// InvalidSignInException.cs See LICENSE.txt in the root folder of the solution.

namespace PBACTemplate.Services.Foundations.SignIn.Exceptions;

public class InvalidSignInException(string message) : Exception(message);