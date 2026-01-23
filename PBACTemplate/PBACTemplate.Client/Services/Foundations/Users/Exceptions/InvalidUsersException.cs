// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// InvalidUsersException.cs See LICENSE.txt in the root folder of the solution.

namespace PBACTemplate.Client.Services.Foundations.Users.Exceptions;

public class InvalidUsersException(string message) : Exception(message);