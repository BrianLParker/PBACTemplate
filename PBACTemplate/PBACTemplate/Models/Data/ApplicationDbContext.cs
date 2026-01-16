// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// ApplicationDbContext.cs See LICENSE.txt in the root folder of the solution.

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PBACTemplate.Models.Users;

namespace PBACTemplate.Models.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
    {
    }
}
