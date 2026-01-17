// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// AppButton.razor.cs See LICENSE.txt in the root folder of the solution.

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using PBACTemplate.Client.Models;

namespace PBACTemplate.Client.Components;

public partial class AppButton
{
    [Parameter]
    public RenderFragment? ChildContent { get; set; }

    [Parameter]
    public EventCallback<MouseEventArgs> OnClick { get; set; }

    [Parameter]
    public ButtonAppearance Appearance { get; set; } = ButtonAppearance.Default;

    [Parameter(CaptureUnmatchedValues = true)]
    public Dictionary<string, object>? AdditionalAttributes { get; set; }
}