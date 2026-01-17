// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// HorizontalStackBase.razor.cs See LICENSE.txt in the root folder of the solution.

using Microsoft.AspNetCore.Components;
using PBACTemplate.Client.Models;

namespace PBACTemplate.Client.Components.Bases;

public partial class HorizontalStackBase
{
    [Parameter]
    public RenderFragment? ChildContent { get; set; }

    [Parameter]
    public StackWidth Width { get; set; } = StackWidth.FitContent;
}
