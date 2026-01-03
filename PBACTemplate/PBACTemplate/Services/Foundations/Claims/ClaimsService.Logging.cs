// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// ClaimsService.Logging.cs See LICENSE.txt in the root folder of the solution.

namespace PBACTemplate.Services.Foundations.Claims;

public sealed partial class ClaimsService
{
    [LoggerMessage(
        Level = LogLevel.Information,
        Message = "Adding claim {ClaimType} for user {UserId}")]
    private partial void LogAddingClaim(string userId, string claimType);

    [LoggerMessage(
        Level = LogLevel.Information,
        Message = "Adding {ClaimCount} claims for user {UserId}")]
    private partial void LogAddingClaims(string userId, int claimCount);

    [LoggerMessage(
        Level = LogLevel.Information,
        Message = "Replacing claim {OldClaimType} with {NewClaimType} for user {UserId}")]
    private partial void LogReplacingClaim(string userId, string oldClaimType, string newClaimType);

    [LoggerMessage(
        Level = LogLevel.Information,
        Message = "Removing claim {ClaimType} for user {UserId}")]
    private partial void LogRemovingClaim(string userId, string claimType);

    [LoggerMessage(
        Level = LogLevel.Information,
        Message = "Removing {ClaimCount} claims for user {UserId}")]
    private partial void LogRemovingClaims(string userId, int claimCount);

    [LoggerMessage(
        Level = LogLevel.Information,
        Message = "Retrieving claims for user {UserId}")]
    private partial void LogRetrievingClaims(string userId);

    [LoggerMessage(
        Level = LogLevel.Information,
        Message = "Retrieving users for claim {ClaimType}")]
    private partial void LogRetrievingUsersForClaim(string claimType);

    [LoggerMessage(
        Level = LogLevel.Error,
        Message = "Failed claims service error occurred, contact support.")]
    private partial void LogFailedClaimsServiceException(Exception exception);
}