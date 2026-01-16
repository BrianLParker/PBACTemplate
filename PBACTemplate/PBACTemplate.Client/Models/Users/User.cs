// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// User.cs See LICENSE.txt in the root folder of the solution.

namespace PBACTemplate.Client.Models.Users;

public class User
{
    public string Id { get; set; } = default!;

    public string? UserName { get; set; }

    public string? NormalizedUserName { get; set; }

    public string? Email { get; set; }

    public string? NormalizedEmail { get; set; }

    public bool EmailConfirmed { get; set; }

    public string? PasswordHash { get; set; }

    public string? SecurityStamp { get; set; } = default!;

    public string? ConcurrencyStamp { get; set; } = default!;

    public string? PhoneNumber { get; set; }

    public bool PhoneNumberConfirmed { get; set; }

    public bool TwoFactorEnabled { get; set; }

    public DateTimeOffset? LockoutEnd { get; set; }

    public bool LockoutEnabled { get; set; }

    public int AccessFailedCount { get; set; }
}

