// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// FailedUserNameOperationException.cs See LICENSE.txt in the root folder of the solution.

namespace PBACTemplate.Services.Foundations.UserName.Exceptions;

public class FailedUserNameOperationException(string message) : Exception(message);