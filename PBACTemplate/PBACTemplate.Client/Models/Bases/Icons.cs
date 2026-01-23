// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// Icons.cs See LICENSE.txt in the root folder of the solution.

namespace PBACTemplate.Client.Models.Bases;

using FluentIcons = Microsoft.FluentUI.AspNetCore.Components.Icons.Regular.Size20;

public static class Icons
{
    public static class Size20
    {
        public class Menu : Icon<FluentIcons.Navigation>;
        public class Add : Icon<FluentIcons.Add>;
        public class Edit : Icon<FluentIcons.Edit>;
        public class Delete : Icon<FluentIcons.Delete>;
        public class Save : Icon<FluentIcons.Save>;
        public class Dismiss : Icon<FluentIcons.Dismiss>;
        public class Home : Icon<FluentIcons.Home>;

        public class Counter : Icon<FluentIcons.Counter>;
    }
}
