// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// ApiAdministrationUsersEndpointsTests.cs See LICENSE.txt in the root folder of the solution.

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using PBACTemplate.Client.Models.Users;
using PBACTemplate.Services.Foundations.Users;
using System.Collections.Immutable;
using System.Security.Claims;
using System.Text.Encodings.Web;

namespace PBACTemplate.Tests.Integration;

public partial class ApiAdministrationUsersEndpointsTests : IClassFixture<WebApplicationFactory<Program>>
{
    private const string TestScheme = "TestAuth";
    private readonly WebApplicationFactory<Program> factory;

    public ApiAdministrationUsersEndpointsTests(WebApplicationFactory<Program> baseFactory)
    {
        this.factory = baseFactory.WithWebHostBuilder(builder =>
        {
            builder.ConfigureServices(services =>
            {
                services.AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = TestScheme;
                    options.DefaultChallengeScheme = TestScheme;
                })
                .AddScheme<AuthenticationSchemeOptions, TestAuthHandler>(TestScheme, _ => { });

                services.AddAuthorization();

                // Replace the real user service with a deterministic test double
                services.RemoveAll<IUserService>();

                var users = new List<User>
                {
                    new() { Id = "1", UserName = "alice", Email = "alice@example.com", FirstName = "Alice", LastName = "Anderson" },
                    new() { Id = "2", UserName = "bob",   Email = "bob@example.com",   FirstName = "Bob",   LastName = "Baker" }
                };

                var userServiceMock = new Mock<IUserService>();

                userServiceMock.Setup(svc => svc.RetrieveUsersAsync())
                    .ReturnsAsync(users.ToImmutableList());

                userServiceMock.Setup(svc => svc.RetrieveUserByIdAsync("1"))
                    .ReturnsAsync(users[0]);
                userServiceMock.Setup(svc => svc.RetrieveUserByIdAsync("2"))
                    .ReturnsAsync(users[1]);
                userServiceMock.Setup(svc => svc.RetrieveUserByIdAsync("missing"))
                    .ReturnsAsync((User?)null);

                userServiceMock.Setup(svc => svc.CreateUserAsync(It.IsAny<User>()))
                    .ReturnsAsync((User user) =>
                    {
                        if (string.IsNullOrWhiteSpace(user.Id))
                        {
                            user.Id = Guid.NewGuid().ToString();
                        }

                        users.Add(user);
                        return user;
                    });

                userServiceMock.Setup(svc => svc.UpdateUserAsync(It.IsAny<string>(), It.IsAny<User>()))
                    .ReturnsAsync((string userId, User user) =>
                    {
                        user.Id = userId;
                        return user;
                    });

                userServiceMock.Setup(svc => svc.RemoveUserAsync(It.IsAny<string>()))
                    .ReturnsAsync(true);

                services.AddSingleton(userServiceMock.Object);
            });
        });
    }

    private sealed class TestAuthHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        public TestAuthHandler(
            IOptionsMonitor<AuthenticationSchemeOptions> options,
            ILoggerFactory logger,
            UrlEncoder encoder,
            ISystemClock clock)
            : base(options, logger, encoder, clock)
        {
        }

        protected override Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            var identity = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Name, "TestUser")
            }, TestScheme);

            var principal = new ClaimsPrincipal(identity);
            var ticket = new AuthenticationTicket(principal, TestScheme);

            return Task.FromResult(AuthenticateResult.Success(ticket));
        }
    }
}
