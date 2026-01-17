// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// IconBase.razor.cs See LICENSE.txt in the root folder of the solution.

using Microsoft.AspNetCore.Components;

namespace PBACTemplate.Client.Components.Bases;

public partial class IconBase
{
    [Parameter, EditorRequired]
    public Models.Bases.Icon AppIcon { get; set; }
}