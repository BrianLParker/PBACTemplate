// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// FailedNavigationServiceException.cs See LICENSE.txt in the root folder of the solution.

namespace PBACTemplate.Client.Services.Foundations.Navigation.Exceptions;

public class FailedNavigationServiceException(string message, Exception innerException)
    : Exception(message, innerException);