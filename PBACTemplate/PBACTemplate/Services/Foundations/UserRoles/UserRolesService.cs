// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// UserRolesService.cs See LICENSE.txt in the root folder of the solution.

using PBACTemplate.Brokers.User;
using PBACTemplate.Models.Users;

namespace PBACTemplate.Services.Foundations.UserRoles;

public sealed partial class UserRolesService(
    IUserManagerBroker userManagerBroker,
    ILogger<UserRolesService> logger) : IUserRolesService
{
    private readonly IUserManagerBroker userManagerBroker = userManagerBroker;
    private readonly ILogger<UserRolesService> logger = logger;

    public ValueTask<ApplicationUser> AddToRoleAsync(ApplicationUser user, string role) =>
        TryCatch(async () =>
        {
            ValidateUser(user);
            ValidateRole(role);

            LogAddingToRole(user.Id, role);

            var result = await this.userManagerBroker.AddToRoleAsync(user, role);
            ValidateIdentityResult(result);

            return user;
        });

    public ValueTask<ApplicationUser> AddToRolesAsync(ApplicationUser user, IEnumerable<string> roles) =>
        TryCatch(async () =>
        {
            ValidateUser(user);
            ValidateRoles(roles);

            LogAddingToRoles(user.Id, roles.Count());

            var result = await this.userManagerBroker.AddToRolesAsync(user, roles);
            ValidateIdentityResult(result);

            return user;
        });

    public ValueTask<ApplicationUser> RemoveFromRoleAsync(ApplicationUser user, string role) =>
        TryCatch(async () =>
        {
            ValidateUser(user);
            ValidateRole(role);

            LogRemovingFromRole(user.Id, role);

            var result = await this.userManagerBroker.RemoveFromRoleAsync(user, role);
            ValidateIdentityResult(result);

            return user;
        });

    public ValueTask<ApplicationUser> RemoveFromRolesAsync(ApplicationUser user, IEnumerable<string> roles) =>
        TryCatch(async () =>
        {
            ValidateUser(user);
            ValidateRoles(roles);

            LogRemovingFromRoles(user.Id, roles.Count());

            var result = await this.userManagerBroker.RemoveFromRolesAsync(user, roles);
            ValidateIdentityResult(result);

            return user;
        });

    public ValueTask<IList<string>> RetrieveRolesAsync(ApplicationUser user) =>
        TryCatch(async () =>
        {
            ValidateUser(user);

            LogRetrievingRoles(user.Id);

            return await this.userManagerBroker.GetRolesAsync(user);
        });

    public ValueTask<bool> IsInRoleAsync(ApplicationUser user, string role) =>
        TryCatch(async () =>
        {
            ValidateUser(user);
            ValidateRole(role);

            LogCheckingIsInRole(user.Id, role);

            return await this.userManagerBroker.IsInRoleAsync(user, role);
        });

    public ValueTask<IList<ApplicationUser>> RetrieveUsersInRoleAsync(string roleName) =>
        TryCatch(async () =>
        {
            ValidateRole(roleName);

            LogRetrievingUsersInRole(roleName);

            return await this.userManagerBroker.GetUsersInRoleAsync(roleName);
        });
}