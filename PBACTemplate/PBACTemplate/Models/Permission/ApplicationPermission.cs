// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// ApplicationPermission.cs See LICENSE.txt in the root folder of the solution.

namespace PBACTemplate.Models.Permission;

public sealed record ApplicationPermission(int PermissionGroup, string Name);