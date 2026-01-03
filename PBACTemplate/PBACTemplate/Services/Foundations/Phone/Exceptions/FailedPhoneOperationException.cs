// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// FailedPhoneOperationException.cs See LICENSE.txt in the root folder of the solution.

namespace PBACTemplate.Services.Foundations.Phone.Exceptions;

public class FailedPhoneOperationException(string message) : Exception(message);