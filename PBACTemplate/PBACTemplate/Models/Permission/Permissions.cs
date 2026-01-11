// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// Permissions.cs See LICENSE.txt in the root folder of the solution.

namespace PBACTemplate.Models.Permission;

public static class Permissions
{
    public static PermissionGroup[] Groups => [
        new PermissionGroup(1, "Administration"),
        new PermissionGroup(2, "Roles Management")
        ];
    public static ApplicationPermission AdministrationDashboard => new ApplicationPermission(1, nameof(AdministrationDashboard));
    public static ApplicationPermission RemoveUserAccount => new ApplicationPermission(1, nameof(RemoveUserAccount));
    public static ApplicationPermission DisableUserAccount => new ApplicationPermission(1, nameof(DisableUserAccount));
    public static ApplicationPermission RolesDashboard => new ApplicationPermission(2, nameof(RolesDashboard));
    public static ApplicationPermission AddRole => new ApplicationPermission(2, nameof(AddRole));
    public static ApplicationPermission DeleteRole => new ApplicationPermission(2, nameof(DeleteRole));
    public static ApplicationPermission AddPermissionToRole => new ApplicationPermission(2, nameof(AddPermissionToRole));
    public static ApplicationPermission RemovePermissionFromRole => new ApplicationPermission(2, nameof(RemovePermissionFromRole));
}