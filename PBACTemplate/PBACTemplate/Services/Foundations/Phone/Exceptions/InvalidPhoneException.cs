// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// InvalidPhoneException.cs See LICENSE.txt in the root folder of the solution.

namespace PBACTemplate.Services.Foundations.Phone.Exceptions;

public class InvalidPhoneException(string message) : Exception(message);