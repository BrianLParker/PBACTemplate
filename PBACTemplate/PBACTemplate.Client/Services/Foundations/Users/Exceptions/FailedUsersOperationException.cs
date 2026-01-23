// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// FailedUsersOperationException.cs See LICENSE.txt in the root folder of the solution.

namespace PBACTemplate.Client.Services.Foundations.Users.Exceptions;

public class FailedUsersOperationException(string message) : Exception(message);