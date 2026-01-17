// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// StackWidthExtensions.cs See LICENSE.txt in the root folder of the solution.

namespace PBACTemplate.Client.Models;

public static class StackWidthExtensions
{
    extension(StackWidth width)
    {
        public string Width => width switch
        {
            StackWidth.FitContent => "fit-content",
            StackWidth.FullWidth => "100%",
            _ => string.Empty
        };
    }
}