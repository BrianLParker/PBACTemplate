// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// FailedUserCrudServiceException.cs See LICENSE.txt in the root folder of the solution.

namespace PBACTemplate.Services.Foundations.UserCrud.Exceptions;

public class FailedUserCrudServiceException(string message, Exception innerException)
    : Exception(message, innerException);