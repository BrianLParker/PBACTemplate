// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// NavigationService.Validations.cs See LICENSE.txt in the root folder of the solution.

using PBACTemplate.Client.Services.Foundations.Navigation.Exceptions;

namespace PBACTemplate.Client.Services.Foundations.Navigation;

public sealed partial class NavigationService
{
    private static void ValidateUri(string uri)
    {
        if (uri is null)
        {
            throw new NullNavigationException("URI cannot be null.");
        }
    }

    private static void ValidateParameterName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new InvalidNavigationException("Parameter name cannot be null or whitespace.");
        }
    }

    private static void ValidateParameters(IReadOnlyDictionary<string, object?> parameters)
    {
        if (parameters is null)
        {
            throw new NullNavigationException("Parameters dictionary cannot be null.");
        }
    }
}