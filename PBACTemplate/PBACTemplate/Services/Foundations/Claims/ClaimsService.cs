// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// ClaimsService.cs See LICENSE.txt in the root folder of the solution.

using PBACTemplate.Brokers.User;
using PBACTemplate.Models.Users;
using System.Security.Claims;

namespace PBACTemplate.Services.Foundations.Claims;

public sealed partial class ClaimsService(
    IUserManagerBroker userManagerBroker,
    ILogger<ClaimsService> logger) : IClaimsService
{
    private readonly IUserManagerBroker userManagerBroker = userManagerBroker;
    private readonly ILogger<ClaimsService> logger = logger;

    public ValueTask<ApplicationUser> AddClaimAsync(ApplicationUser user, Claim claim) =>
        TryCatch(async () =>
        {
            ValidateUser(user);
            ValidateClaim(claim);

            LogAddingClaim(user.Id, claim.Type);

            var result = await this.userManagerBroker.AddClaimAsync(user, claim);
            ValidateIdentityResult(result);

            return user;
        });

    public ValueTask<ApplicationUser> AddClaimsAsync(ApplicationUser user, IEnumerable<Claim> claims) =>
        TryCatch(async () =>
        {
            ValidateUser(user);
            ValidateClaims(claims);

            LogAddingClaims(user.Id, claims.Count());

            var result = await this.userManagerBroker.AddClaimsAsync(user, claims);
            ValidateIdentityResult(result);

            return user;
        });

    public ValueTask<ApplicationUser> ReplaceClaimAsync(ApplicationUser user, Claim claim, Claim newClaim) =>
        TryCatch(async () =>
        {
            ValidateUser(user);
            ValidateClaim(claim, nameof(claim));
            ValidateClaim(newClaim, nameof(newClaim));

            LogReplacingClaim(user.Id, claim.Type, newClaim.Type);

            var result = await this.userManagerBroker.ReplaceClaimAsync(user, claim, newClaim);
            ValidateIdentityResult(result);

            return user;
        });

    public ValueTask<ApplicationUser> RemoveClaimAsync(ApplicationUser user, Claim claim) =>
        TryCatch(async () =>
        {
            ValidateUser(user);
            ValidateClaim(claim);

            LogRemovingClaim(user.Id, claim.Type);

            var result = await this.userManagerBroker.RemoveClaimAsync(user, claim);
            ValidateIdentityResult(result);

            return user;
        });

    public ValueTask<ApplicationUser> RemoveClaimsAsync(ApplicationUser user, IEnumerable<Claim> claims) =>
        TryCatch(async () =>
        {
            ValidateUser(user);
            ValidateClaims(claims);

            LogRemovingClaims(user.Id, claims.Count());

            var result = await this.userManagerBroker.RemoveClaimsAsync(user, claims);
            ValidateIdentityResult(result);

            return user;
        });

    public ValueTask<IList<Claim>> RetrieveClaimsAsync(ApplicationUser user) =>
        TryCatch(async () =>
        {
            ValidateUser(user);

            LogRetrievingClaims(user.Id);

            return await this.userManagerBroker.GetClaimsAsync(user);
        });

    public ValueTask<IList<ApplicationUser>> RetrieveUsersForClaimAsync(Claim claim) =>
        TryCatch(async () =>
        {
            ValidateClaim(claim);

            LogRetrievingUsersForClaim(claim.Type);

            return await this.userManagerBroker.GetUsersForClaimAsync(claim);
        });
}