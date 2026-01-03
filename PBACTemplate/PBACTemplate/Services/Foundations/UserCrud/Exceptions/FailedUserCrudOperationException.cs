// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// FailedUserCrudOperationException.cs See LICENSE.txt in the root folder of the solution.

namespace PBACTemplate.Services.Foundations.UserCrud.Exceptions;

public class FailedUserCrudOperationException(string message) : Exception(message);