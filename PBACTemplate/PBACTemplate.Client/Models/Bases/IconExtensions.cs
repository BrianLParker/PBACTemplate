// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// IconExtensions.cs See LICENSE.txt in the root folder of the solution.

namespace PBACTemplate.Client.Models.Bases;

public static class IconExtensions
{
    extension(Models.Bases.Icon icon)
    {
        public Microsoft.FluentUI.AspNetCore.Components.Icon ToFluentIcon() => icon.icon;
    }
}