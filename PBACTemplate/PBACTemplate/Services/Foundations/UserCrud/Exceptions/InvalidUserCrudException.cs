// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// InvalidUserCrudException.cs See LICENSE.txt in the root folder of the solution.

namespace PBACTemplate.Services.Foundations.UserCrud.Exceptions;

public class InvalidUserCrudException(string message) : Exception(message);