// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// NullNavigationException.cs See LICENSE.txt in the root folder of the solution.

namespace PBACTemplate.Client.Services.Foundations.Navigation.Exceptions;

public class NullNavigationException(string message) : Exception(message);