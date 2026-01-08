// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// SignInServiceTests.cs See LICENSE.txt in the root folder of the solution.

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using PBACTemplate.Brokers.SignIn;
using PBACTemplate.Data;
using PBACTemplate.Services.Foundations.SignIn;
using System.Security.Claims;

namespace PBACTemplate.Tests.Unit;

public partial class SignInServiceTests
{
    private readonly Mock<ISignInManagerBroker> signInManagerBrokerMock;
    private readonly Mock<ILogger<SignInService>> loggerMock;
    private readonly ISignInService signInService;

    public SignInServiceTests()
    {
        this.signInManagerBrokerMock = new Mock<ISignInManagerBroker>();
        this.loggerMock = new Mock<ILogger<SignInService>>();

        this.loggerMock.Setup(logger =>
            logger.IsEnabled(It.IsAny<LogLevel>()))
                .Returns(true);

        this.signInService = new SignInService(
            this.signInManagerBrokerMock.Object,
            this.loggerMock.Object);
    }

    private static ApplicationUser CreateUser() => new() { Id = Guid.NewGuid().ToString() };
    private static string GetRandomString() => Guid.NewGuid().ToString();
    private static byte[] GetRandomBytes() => Guid.NewGuid().ToByteArray();
    private static Claim CreateClaim() => new(ClaimTypes.Name, GetRandomString());
    private static ClaimsPrincipal CreatePrincipal() => new(new ClaimsIdentity(new[] { CreateClaim() }, "TestAuth"));
    private static AuthenticationProperties CreateAuthProperties() => new();
    private static ExternalLoginInfo CreateExternalLoginInfo() =>
        new(new ClaimsPrincipal(), GetRandomString(), GetRandomString(), GetRandomString());
    private static PasskeyUserEntity CreatePasskeyUserEntity() =>
        new() { Name = GetRandomString(), DisplayName = GetRandomString(), Id = GetRandomString() };

    private void VerifyNoOtherBrokerCalls() =>
        this.signInManagerBrokerMock.VerifyNoOtherCalls();


    private static UserPasskeyInfo CreatePasskey()
    {
        byte[] credentialId = GetRandomBytes();
        byte[] userHandle = GetRandomBytes();
        byte[] userId = GetRandomBytes();
        byte[] publicKey = new byte[] { 1, 2, 3, 4 };
        DateTimeOffset createdAt = DateTimeOffset.UtcNow;
        uint signatureCounter = 1;
        string[]? devicePublicKeys = null;
        bool isBackupEligible = true;
        bool isBackupState = false;
        bool isDiscoverable = true;

        return new UserPasskeyInfo(
            credentialId,
            userHandle,
            createdAt,
            signatureCounter,
            devicePublicKeys,
            isBackupEligible,
            isBackupState,
            isDiscoverable,
            userId,
            publicKey);
    }
}