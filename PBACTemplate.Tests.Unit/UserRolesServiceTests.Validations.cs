// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// UserRolesServiceTests.Validations.cs See LICENSE.txt in the root folder of the solution.

using Microsoft.AspNetCore.Identity;
using PBACTemplate.Data;
using PBACTemplate.Services.Foundations.UserRoles.Exceptions;

namespace PBACTemplate.Tests.Unit;

public partial class UserRolesServiceTests
{
    [Fact]
    public async Task ShouldThrowNullUserRolesExceptionOnAddToRoleAsyncIfUserIsNull()
    {
        // Given
        ApplicationUser? nullUser = null;
        string role = GetRandomString();
        var expectedException = new NullUserRolesException("User cannot be null.");

        // When
        Func<Task> action = async () => await this.userRolesService
            .AddToRoleAsync(nullUser!, role);

        // Then
        NullUserRolesException actualException =
            await Assert.ThrowsAsync<NullUserRolesException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);

        this.userManagerBrokerMock.Verify(broker =>
            broker.AddToRoleAsync(
                It.IsAny<ApplicationUser>(),
                It.IsAny<string>()),
            Times.Never);

        VerifyNoOtherBrokerCalls();
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("   ")]
    public async Task ShouldThrowInvalidUserRolesExceptionOnAddToRoleAsyncIfRoleIsInvalid(
        string? invalidRole)
    {
        // Given
        ApplicationUser user = CreateUser();
        var expectedException = new InvalidUserRolesException(
            "Role name cannot be null or whitespace.");

        // When
        Func<Task> action = async () => await this.userRolesService
            .AddToRoleAsync(user, invalidRole!);

        // Then
        InvalidUserRolesException actualException =
            await Assert.ThrowsAsync<InvalidUserRolesException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);

        this.userManagerBrokerMock.Verify(broker =>
            broker.AddToRoleAsync(
                It.IsAny<ApplicationUser>(),
                It.IsAny<string>()),
            Times.Never);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldThrowNullUserRolesExceptionOnAddToRolesAsyncIfUserIsNull()
    {
        // Given
        ApplicationUser? nullUser = null;
        IEnumerable<string> roles = CreateRoles(GetRandomString());
        var expectedException = new NullUserRolesException("User cannot be null.");

        // When
        Func<Task> action = async () => await this.userRolesService
            .AddToRolesAsync(nullUser!, roles);

        // Then
        NullUserRolesException actualException =
            await Assert.ThrowsAsync<NullUserRolesException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);

        this.userManagerBrokerMock.Verify(broker =>
            broker.AddToRolesAsync(
                It.IsAny<ApplicationUser>(),
                It.IsAny<IEnumerable<string>>()),
            Times.Never);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldThrowNullUserRolesExceptionOnAddToRolesAsyncIfRolesIsNull()
    {
        // Given
        ApplicationUser user = CreateUser();
        IEnumerable<string>? nullRoles = null;
        var expectedException = new NullUserRolesException("Roles collection cannot be null.");

        // When
        Func<Task> action = async () => await this.userRolesService
            .AddToRolesAsync(user, nullRoles!);

        // Then
        NullUserRolesException actualException =
            await Assert.ThrowsAsync<NullUserRolesException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);

        this.userManagerBrokerMock.Verify(broker =>
            broker.AddToRolesAsync(
                It.IsAny<ApplicationUser>(),
                It.IsAny<IEnumerable<string>>()),
            Times.Never);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldThrowInvalidUserRolesExceptionOnAddToRolesAsyncIfRolesIsEmpty()
    {
        // Given
        ApplicationUser user = CreateUser();
        IEnumerable<string> emptyRoles = Array.Empty<string>();
        var expectedException = new InvalidUserRolesException("Roles collection cannot be empty.");

        // When
        Func<Task> action = async () => await this.userRolesService
            .AddToRolesAsync(user, emptyRoles);

        // Then
        InvalidUserRolesException actualException =
            await Assert.ThrowsAsync<InvalidUserRolesException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);

        this.userManagerBrokerMock.Verify(broker =>
            broker.AddToRolesAsync(
                It.IsAny<ApplicationUser>(),
                It.IsAny<IEnumerable<string>>()),
            Times.Never);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldThrowNullUserRolesExceptionOnRemoveFromRoleAsyncIfUserIsNull()
    {
        // Given
        ApplicationUser? nullUser = null;
        string role = GetRandomString();
        var expectedException = new NullUserRolesException("User cannot be null.");

        // When
        Func<Task> action = async () => await this.userRolesService
            .RemoveFromRoleAsync(nullUser!, role);

        // Then
        NullUserRolesException actualException =
            await Assert.ThrowsAsync<NullUserRolesException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);

        this.userManagerBrokerMock.Verify(broker =>
            broker.RemoveFromRoleAsync(
                It.IsAny<ApplicationUser>(),
                It.IsAny<string>()),
            Times.Never);

        VerifyNoOtherBrokerCalls();
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("   ")]
    public async Task ShouldThrowInvalidUserRolesExceptionOnRemoveFromRoleAsyncIfRoleIsInvalid(
        string? invalidRole)
    {
        // Given
        ApplicationUser user = CreateUser();
        var expectedException = new InvalidUserRolesException(
            "Role name cannot be null or whitespace.");

        // When
        Func<Task> action = async () => await this.userRolesService
            .RemoveFromRoleAsync(user, invalidRole!);

        // Then
        InvalidUserRolesException actualException =
            await Assert.ThrowsAsync<InvalidUserRolesException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);

        this.userManagerBrokerMock.Verify(broker =>
            broker.RemoveFromRoleAsync(
                It.IsAny<ApplicationUser>(),
                It.IsAny<string>()),
            Times.Never);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldThrowNullUserRolesExceptionOnRemoveFromRolesAsyncIfUserIsNull()
    {
        // Given
        ApplicationUser? nullUser = null;
        IEnumerable<string> roles = CreateRoles(GetRandomString());
        var expectedException = new NullUserRolesException("User cannot be null.");

        // When
        Func<Task> action = async () => await this.userRolesService
            .RemoveFromRolesAsync(nullUser!, roles);

        // Then
        NullUserRolesException actualException =
            await Assert.ThrowsAsync<NullUserRolesException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);

        this.userManagerBrokerMock.Verify(broker =>
            broker.RemoveFromRolesAsync(
                It.IsAny<ApplicationUser>(),
                It.IsAny<IEnumerable<string>>()),
            Times.Never);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldThrowNullUserRolesExceptionOnRemoveFromRolesAsyncIfRolesIsNull()
    {
        // Given
        ApplicationUser user = CreateUser();
        IEnumerable<string>? nullRoles = null;
        var expectedException = new NullUserRolesException("Roles collection cannot be null.");

        // When
        Func<Task> action = async () => await this.userRolesService
            .RemoveFromRolesAsync(user, nullRoles!);

        // Then
        NullUserRolesException actualException =
            await Assert.ThrowsAsync<NullUserRolesException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);

        this.userManagerBrokerMock.Verify(broker =>
            broker.RemoveFromRolesAsync(
                It.IsAny<ApplicationUser>(),
                It.IsAny<IEnumerable<string>>()),
            Times.Never);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldThrowInvalidUserRolesExceptionOnRemoveFromRolesAsyncIfRolesIsEmpty()
    {
        // Given
        ApplicationUser user = CreateUser();
        IEnumerable<string> emptyRoles = Array.Empty<string>();
        var expectedException = new InvalidUserRolesException("Roles collection cannot be empty.");

        // When
        Func<Task> action = async () => await this.userRolesService
            .RemoveFromRolesAsync(user, emptyRoles);

        // Then
        InvalidUserRolesException actualException =
            await Assert.ThrowsAsync<InvalidUserRolesException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);

        this.userManagerBrokerMock.Verify(broker =>
            broker.RemoveFromRolesAsync(
                It.IsAny<ApplicationUser>(),
                It.IsAny<IEnumerable<string>>()),
            Times.Never);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldThrowNullUserRolesExceptionOnRetrieveRolesAsyncIfUserIsNull()
    {
        // Given
        ApplicationUser? nullUser = null;
        var expectedException = new NullUserRolesException("User cannot be null.");

        // When
        Func<Task> action = async () => await this.userRolesService
            .RetrieveRolesAsync(nullUser!);

        // Then
        NullUserRolesException actualException =
            await Assert.ThrowsAsync<NullUserRolesException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);

        this.userManagerBrokerMock.Verify(broker =>
            broker.GetRolesAsync(It.IsAny<ApplicationUser>()),
            Times.Never);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldThrowNullUserRolesExceptionOnIsInRoleAsyncIfUserIsNull()
    {
        // Given
        ApplicationUser? nullUser = null;
        string role = GetRandomString();
        var expectedException = new NullUserRolesException("User cannot be null.");

        // When
        Func<Task> action = async () => await this.userRolesService
            .IsInRoleAsync(nullUser!, role);

        // Then
        NullUserRolesException actualException =
            await Assert.ThrowsAsync<NullUserRolesException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);

        this.userManagerBrokerMock.Verify(broker =>
            broker.IsInRoleAsync(
                It.IsAny<ApplicationUser>(),
                It.IsAny<string>()),
            Times.Never);

        VerifyNoOtherBrokerCalls();
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("   ")]
    public async Task ShouldThrowInvalidUserRolesExceptionOnIsInRoleAsyncIfRoleIsInvalid(
        string? invalidRole)
    {
        // Given
        ApplicationUser user = CreateUser();
        var expectedException = new InvalidUserRolesException(
            "Role name cannot be null or whitespace.");

        // When
        Func<Task> action = async () => await this.userRolesService
            .IsInRoleAsync(user, invalidRole!);

        // Then
        InvalidUserRolesException actualException =
            await Assert.ThrowsAsync<InvalidUserRolesException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);

        this.userManagerBrokerMock.Verify(broker =>
            broker.IsInRoleAsync(
                It.IsAny<ApplicationUser>(),
                It.IsAny<string>()),
            Times.Never);

        VerifyNoOtherBrokerCalls();
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("   ")]
    public async Task ShouldThrowInvalidUserRolesExceptionOnRetrieveUsersInRoleAsyncIfRoleIsInvalid(
        string? invalidRole)
    {
        // Given
        var expectedException = new InvalidUserRolesException(
            "Role name cannot be null or whitespace.");

        // When
        Func<Task> action = async () => await this.userRolesService
            .RetrieveUsersInRoleAsync(invalidRole!);

        // Then
        InvalidUserRolesException actualException =
            await Assert.ThrowsAsync<InvalidUserRolesException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);

        this.userManagerBrokerMock.Verify(broker =>
            broker.GetUsersInRoleAsync(It.IsAny<string>()),
            Times.Never);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldThrowFailedUserRolesOperationExceptionOnAddToRoleAsyncIfIdentityResultFailed()
    {
        // Given
        ApplicationUser user = CreateUser();
        string role = GetRandomString();
        var identityError = new IdentityError { Description = GetRandomString() };
        IdentityResult failedResult = IdentityResult.Failed(identityError);

        this.userManagerBrokerMock.Setup(broker =>
            broker.AddToRoleAsync(user, role))
                .ReturnsAsync(failedResult);

        var expectedException = new FailedUserRolesOperationException(
            $"User roles identity operation failed: {identityError.Description}");

        // When
        Func<Task> action = async () => await this.userRolesService
            .AddToRoleAsync(user, role);

        // Then
        FailedUserRolesOperationException actualException =
            await Assert.ThrowsAsync<FailedUserRolesOperationException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);

        this.userManagerBrokerMock.Verify(broker =>
            broker.AddToRoleAsync(user, role),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldThrowFailedUserRolesOperationExceptionOnAddToRolesAsyncIfIdentityResultFailed()
    {
        // Given
        ApplicationUser user = CreateUser();
        IEnumerable<string> roles = CreateRoles(GetRandomString());
        var identityError = new IdentityError { Description = GetRandomString() };
        IdentityResult failedResult = IdentityResult.Failed(identityError);

        this.userManagerBrokerMock.Setup(broker =>
            broker.AddToRolesAsync(user, roles))
                .ReturnsAsync(failedResult);

        var expectedException = new FailedUserRolesOperationException(
            $"User roles identity operation failed: {identityError.Description}");

        // When
        Func<Task> action = async () => await this.userRolesService
            .AddToRolesAsync(user, roles);

        // Then
        FailedUserRolesOperationException actualException =
            await Assert.ThrowsAsync<FailedUserRolesOperationException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);

        this.userManagerBrokerMock.Verify(broker =>
            broker.AddToRolesAsync(user, roles),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldThrowFailedUserRolesOperationExceptionOnRemoveFromRoleAsyncIfIdentityResultFailed()
    {
        // Given
        ApplicationUser user = CreateUser();
        string role = GetRandomString();
        var identityError = new IdentityError { Description = GetRandomString() };
        IdentityResult failedResult = IdentityResult.Failed(identityError);

        this.userManagerBrokerMock.Setup(broker =>
            broker.RemoveFromRoleAsync(user, role))
                .ReturnsAsync(failedResult);

        var expectedException = new FailedUserRolesOperationException(
            $"User roles identity operation failed: {identityError.Description}");

        // When
        Func<Task> action = async () => await this.userRolesService
            .RemoveFromRoleAsync(user, role);

        // Then
        FailedUserRolesOperationException actualException =
            await Assert.ThrowsAsync<FailedUserRolesOperationException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);

        this.userManagerBrokerMock.Verify(broker =>
            broker.RemoveFromRoleAsync(user, role),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }

    [Fact]
    public async Task ShouldThrowFailedUserRolesOperationExceptionOnRemoveFromRolesAsyncIfIdentityResultFailed()
    {
        // Given
        ApplicationUser user = CreateUser();
        IEnumerable<string> roles = CreateRoles(GetRandomString(), GetRandomString());
        var identityError = new IdentityError { Description = GetRandomString() };
        IdentityResult failedResult = IdentityResult.Failed(identityError);

        this.userManagerBrokerMock.Setup(broker =>
            broker.RemoveFromRolesAsync(user, roles))
                .ReturnsAsync(failedResult);

        var expectedException = new FailedUserRolesOperationException(
            $"User roles identity operation failed: {identityError.Description}");

        // When
        Func<Task> action = async () => await this.userRolesService
            .RemoveFromRolesAsync(user, roles);

        // Then
        FailedUserRolesOperationException actualException =
            await Assert.ThrowsAsync<FailedUserRolesOperationException>(action);

        Assert.Equal(expectedException.Message, actualException.Message);

        this.userManagerBrokerMock.Verify(broker =>
            broker.RemoveFromRolesAsync(user, roles),
            Times.Once);

        VerifyNoOtherBrokerCalls();
    }
}