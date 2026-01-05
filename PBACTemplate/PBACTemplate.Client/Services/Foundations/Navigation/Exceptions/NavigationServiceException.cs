// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// NavigationServiceException.cs See LICENSE.txt in the root folder of the solution.

namespace PBACTemplate.Client.Services.Foundations.Navigation.Exceptions;

public class NavigationServiceException(string message, Exception innerException)
    : Exception(message, innerException);