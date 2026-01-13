// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// AppPageHeader.razor.cs See LICENSE.txt in the root folder of the solution.

using Microsoft.AspNetCore.Components;

namespace PBACTemplate.Client.Components;

public partial class AppPageHeader
{
    [Parameter, EditorRequired]
    public string Title { get; set; }
}