// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// AppIcon.razor.cs See LICENSE.txt in the root folder of the solution.

using Microsoft.AspNetCore.Components;

namespace PBACTemplate.Client.Components;

public partial class AppIcon
{
    [Parameter, EditorRequired]
    public required Models.Bases.Icon Icon { get; set; }
}