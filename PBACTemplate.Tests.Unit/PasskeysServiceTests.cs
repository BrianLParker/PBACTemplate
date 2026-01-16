// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// PasskeysServiceTests.cs See LICENSE.txt in the root folder of the solution.

using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using PBACTemplate.Brokers.User;
using PBACTemplate.Models.Users;
using PBACTemplate.Services.Foundations.Passkeys;

namespace PBACTemplate.Tests.Unit;

public partial class PasskeysServiceTests
{
    private readonly Mock<IUserManagerBroker> userManagerBrokerMock;
    private readonly Mock<ILogger<PasskeysService>> loggerMock;
    private readonly IPasskeysService passkeysService;

    public PasskeysServiceTests()
    {
        this.userManagerBrokerMock = new Mock<IUserManagerBroker>();
        this.loggerMock = new Mock<ILogger<PasskeysService>>();

        this.loggerMock.Setup(logger =>
            logger.IsEnabled(It.IsAny<LogLevel>()))
                .Returns(true);

        this.passkeysService = new PasskeysService(
            this.userManagerBrokerMock.Object,
            this.loggerMock.Object);
    }

    private static ApplicationUser CreateUser() => new() { Id = Guid.NewGuid().ToString() };
    private static UserPasskeyInfo CreatePasskey()
    {
        byte[] credentialId = CreateCredentialId();
        byte[] userHandle = Guid.NewGuid().ToByteArray();
        byte[] userId = Guid.NewGuid().ToByteArray();
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
    private static byte[] CreateCredentialId() => Guid.NewGuid().ToByteArray();
    private static string GetRandomString() => Guid.NewGuid().ToString();

    private void VerifyNoOtherBrokerCalls() =>
        this.userManagerBrokerMock.VerifyNoOtherCalls();
}