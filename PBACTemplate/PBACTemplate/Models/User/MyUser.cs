// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// MyUser.cs See LICENSE.txt in the root folder of the solution.

using Microsoft.AspNetCore.Identity;

namespace PBACTemplate.Models.User;

public class MyUser
{
    [PersonalData]
    public string Id { get; set; } = default!;

    [ProtectedPersonalData]
    public string? UserName { get; set; }

    public string? NormalizedUserName { get; set; }

    [ProtectedPersonalData]
    public string? Email { get; set; }

    public string? NormalizedEmail { get; set; }

    [PersonalData]
    public bool EmailConfirmed { get; set; }

    public string? PasswordHash { get; set; }

    public string? SecurityStamp { get; set; } = Guid.NewGuid().ToString();

    public string? ConcurrencyStamp { get; set; } = Guid.NewGuid().ToString();

    [ProtectedPersonalData]
    public string? PhoneNumber { get; set; }

    [PersonalData]
    public bool PhoneNumberConfirmed { get; set; }

    [PersonalData]
    public bool TwoFactorEnabled { get; set; }

    public DateTimeOffset? LockoutEnd { get; set; }

    public bool LockoutEnabled { get; set; }

    public int AccessFailedCount { get; set; }
}

public static class MyUserExtensions
{
    extension(MyUser user)
    {
        public ApplicationUser ToApplicationUser() =>
            new ApplicationUser
            {
                Id = user.Id,
                UserName = user.UserName,
                NormalizedUserName = user.NormalizedUserName,
                Email = user.Email,
                NormalizedEmail = user.NormalizedEmail,
                EmailConfirmed = user.EmailConfirmed,
                PasswordHash = user.PasswordHash,
                SecurityStamp = user.SecurityStamp,
                ConcurrencyStamp = user.ConcurrencyStamp,
                PhoneNumber = user.PhoneNumber,
                PhoneNumberConfirmed = user.PhoneNumberConfirmed,
                TwoFactorEnabled = user.TwoFactorEnabled,
                LockoutEnd = user.LockoutEnd,
                LockoutEnabled = user.LockoutEnabled,
                AccessFailedCount = user.AccessFailedCount
            };
    }
    extension(ApplicationUser user)
    {
        public MyUser ToMyUser() =>
            new MyUser
            {
                Id = user.Id,
                UserName = user.UserName,
                NormalizedUserName = user.NormalizedUserName,
                Email = user.Email,
                NormalizedEmail = user.NormalizedEmail,
                EmailConfirmed = user.EmailConfirmed,
                PasswordHash = user.PasswordHash,
                SecurityStamp = user.SecurityStamp,
                ConcurrencyStamp = user.ConcurrencyStamp,
                PhoneNumber = user.PhoneNumber,
                PhoneNumberConfirmed = user.PhoneNumberConfirmed,
                TwoFactorEnabled = user.TwoFactorEnabled,
                LockoutEnd = user.LockoutEnd,
                LockoutEnabled = user.LockoutEnabled,
                AccessFailedCount = user.AccessFailedCount
            };
    }
}
