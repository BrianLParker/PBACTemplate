[![.NET](https://github.com/BrianLParker/PBACTemplate/actions/workflows/dotnet.yml/badge.svg)](https://github.com/BrianLParker/PBACTemplate/actions/workflows/dotnet.yml)
[![License](https://img.shields.io/github/license/BrianLParker/PBACTemplate)](LICENSE.txt)
-
# Permission Based Access Control (PBAC)

### WIP 
This project is a work in progress. Features and implementations may change.

This repository will contain a template for implementing Permission Based Access Control (PBAC) in .NET 10 Blazor applications. PBAC is a flexible and scalable approach to managing user permissions based on specific actions and resources.

## Plan: Role & Permission Management UI

1) Permission catalog (static, grouped)
- Define a compile-time permissions catalog grouped by functional area (e.g., Users, Roles, Content, Reporting). Use a static class or readonly record collection exposed via an injectable provider for UI and seeding. Keep permission identifiers stable strings reused in authorization policies and role claims.

2) Data model and storage
- Represent roles and their assigned permissions as role claims (claim type "permission") or a role-permission join if using a custom store. Ensure the static catalog drives validation and seeding.

3) Service layer
- Add a RolePermissionsService to read the catalog, list roles, read role permissions, add/remove permissions to a role, and create/delete roles. Validate against the static catalog; log operations.

4) API endpoints (if hosted API) or direct store access (if WASM with server APIs)
- Expose endpoints for listing permissions, listing roles, creating roles, deleting roles, and updating role permissions (add/remove). Secure with authorization (e.g., policy: Permissions.Roles.Manage).

5) UI design (Blazor)
- Create a Roles page with: (a) roles table (name, description, counts), (b) add/delete role actions, (c) detail/edit drawer or dialog showing grouped permissions with checkboxes and bulk select per group, (d) search/filter by name and permission group. Include loading/error states.

6) Validation and UX safeguards
- Prevent duplicate role names; require non-empty names; confirm destructive actions (delete role, remove all permissions). Disable actions while pending.

7) Authorization integration
- Define authorization policies from the static permissions; drive component visibility/enablement from current user permissions.

8) Seeding and migrations
- Seed default roles and permissions from the static catalog. Add migrations if schema changes are needed for role-permission mapping.

9) Testing
- Unit-test the permissions catalog integrity (no duplicates, consistent groups); service operations (add/remove/lookup); and authorization policy registration. Add UI/component tests for role management flows (render, select, save, error states).