// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// ApiAdministrationRolesEndpointsTests.cs See LICENSE.txt in the root folder of the solution.

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using PBACTemplate.Services.Foundations.Roles;
using PBACTemplate.Services.Foundations.Roles.Exceptions;
using System.Security.Claims;
using System.Text.Encodings.Web;

namespace PBACTemplate.Tests.Integration;

public partial class ApiAdministrationRolesEndpointsTests : IClassFixture<WebApplicationFactory<Program>>
{
    private const string TestScheme = "TestAuth";
    private readonly WebApplicationFactory<Program> factory;

    public ApiAdministrationRolesEndpointsTests(WebApplicationFactory<Program> baseFactory)
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

                services.RemoveAll<IRolesService>();

                var rolesServiceMock = new Mock<IRolesService>();

                rolesServiceMock.Setup(svc => svc.RetrieveRolesAsync())
                    .ReturnsAsync(["Admin", "Manager"]);

                rolesServiceMock.Setup(svc => svc.RetrieveRoleAsync("Admin"))
                    .ReturnsAsync("Admin");

                rolesServiceMock.Setup(svc => svc.CreateRoleAsync("NewRole"))
                    .ReturnsAsync("NewRole");

                rolesServiceMock.Setup(svc => svc.UpdateRoleAsync("Old", "New"))
                    .ReturnsAsync("New");

                rolesServiceMock.Setup(svc => svc.RemoveRoleAsync("Gone"))
                    .ReturnsAsync(true);

                rolesServiceMock.Setup(svc => svc.RetrieveRoleAsync("Missing"))
                    .ThrowsAsync(new NullRolesException("Role 'Missing' was not found."));

                services.AddSingleton(rolesServiceMock.Object);
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