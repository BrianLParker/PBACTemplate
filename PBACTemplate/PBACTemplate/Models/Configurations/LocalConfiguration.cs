// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// LocalConfiguration.cs See LICENSE.txt in the root folder of the solution.

namespace PBACTemplate.Models.Configurations;

public class LocalConfiguration
{
    public PBAC PBAC { get; set; } = default!;
}

public class PBAC
{
    public string InitialUser { get; set; } = default!;
}
