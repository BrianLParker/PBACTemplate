// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// NullUserCrudException.cs See LICENSE.txt in the root folder of the solution.

namespace PBACTemplate.Services.Foundations.UserCrud.Exceptions;

public class NullUserCrudException(string message) : Exception(message);