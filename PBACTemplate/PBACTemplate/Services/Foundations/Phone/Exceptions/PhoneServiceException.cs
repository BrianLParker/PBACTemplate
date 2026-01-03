// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// PhoneServiceException.cs See LICENSE.txt in the root folder of the solution.

namespace PBACTemplate.Services.Foundations.Phone.Exceptions;

public class PhoneServiceException(string message, Exception innerException)
    : Exception(message, innerException);