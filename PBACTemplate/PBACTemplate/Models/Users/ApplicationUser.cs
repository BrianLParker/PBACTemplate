// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// ApplicationUser.cs See LICENSE.txt in the root folder of the solution.

using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace PBACTemplate.Models.Users;

public class ApplicationUser : IdentityUser
{
    [PersonalData]
    [MaxLength(100)]
    public string FirstName { get; set; } = string.Empty;

    [PersonalData]
    [MaxLength(100)]
    public string LastName { get; set; } = string.Empty;
}


