// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// User.cs See LICENSE.txt in the root folder of the solution.

namespace PBACTemplate.Client.Models.Users;

public class User
{
    public string Id { get; set; } = string.Empty;

    public string UserName { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public bool EmailConfirmed { get; set; }

    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;

    public string PhoneNumber { get; set; } = string.Empty;

    public bool PhoneNumberConfirmed { get; set; }


    public DateTimeOffset? LockoutEnd { get; set; }

    public DateTimeOffset CreatedAt { get; set; }

    public DateTimeOffset UpdatedAt { get; set; }

    public DateTimeOffset? LastSignInAt { get; set; }

    public int AccessFailedCount { get; set; }

    public string? ConcurrencyStamp { get; set; }

    public string? AvatarUrl { get; set; }

    public List<string> Roles { get; set; } = new();
}
