// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// Icon.cs See LICENSE.txt in the root folder of the solution.

namespace PBACTemplate.Client.Models.Bases;

public class Icon(Microsoft.FluentUI.AspNetCore.Components.Icon icon)
{
    public readonly Microsoft.FluentUI.AspNetCore.Components.Icon icon = icon;
}

public class Icon<T>() : Icon(new T())
    where T : Microsoft.FluentUI.AspNetCore.Components.Icon, new()
{ }