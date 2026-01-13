// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// ButtonAppearanceExtensions.cs See LICENSE.txt in the root folder of the solution.

namespace PBACTemplate.Client.Models;

public static class ButtonAppearanceExtensions
{
    extension(ButtonAppearance appearance)
    {
        public Microsoft.FluentUI.AspNetCore.Components.Appearance FluentAppearance
        {
            get
            {
                return appearance switch
                {
                    ButtonAppearance.Default => Microsoft.FluentUI.AspNetCore.Components.Appearance.Neutral,
                    ButtonAppearance.Primary => Microsoft.FluentUI.AspNetCore.Components.Appearance.Accent,
                    _ => Microsoft.FluentUI.AspNetCore.Components.Appearance.Neutral,
                };
            }
        }
    }
}