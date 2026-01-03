// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// NullPhoneException.cs See LICENSE.txt in the root folder of the solution.

namespace PBACTemplate.Services.Foundations.Phone.Exceptions;

public class NullPhoneException(string message) : Exception(message);