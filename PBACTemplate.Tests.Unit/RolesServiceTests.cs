// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// RolesServiceTests.cs See LICENSE.txt in the root folder of the solution.

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.Extensions.Logging;
using PBACTemplate.Brokers.Roles;
using PBACTemplate.Services.Foundations.Roles;
using System.Linq.Expressions;

namespace PBACTemplate.Tests.Unit;

public partial class RolesServiceTests
{
    private readonly Mock<IRoleManagerBroker> roleManagerBrokerMock;
    private readonly Mock<ILogger<RolesService>> loggerMock;
    private readonly IRolesService rolesService;

    public RolesServiceTests()
    {
        this.roleManagerBrokerMock = new Mock<IRoleManagerBroker>();
        this.loggerMock = new Mock<ILogger<RolesService>>();

        this.loggerMock.Setup(logger =>
            logger.IsEnabled(It.IsAny<LogLevel>()))
                .Returns(true);

        this.rolesService = new RolesService(
            this.roleManagerBrokerMock.Object,
            this.loggerMock.Object);
    }

    private static string GetRandomString() => Guid.NewGuid().ToString();

    private static IdentityRole CreateRole(string? name = null) =>
        new(name ?? GetRandomString());

    private static IdentityError CreateIdentityError(string description) =>
        new() { Description = description };

    private static IQueryable<IdentityRole> CreateAsyncQueryableRoles(params IdentityRole[] roles) =>
        new TestAsyncEnumerable<IdentityRole>(roles);

    private void VerifyNoOtherBrokerCalls() =>
        this.roleManagerBrokerMock.VerifyNoOtherCalls();

    // Async queryable helpers for ToListAsync
    private sealed class TestAsyncEnumerable<T> :
        EnumerableQuery<T>, IAsyncEnumerable<T>, IQueryable<T>
    {
        public TestAsyncEnumerable(IEnumerable<T> enumerable) : base(enumerable) { }
        public TestAsyncEnumerable(Expression expression) : base(expression) { }

        public IAsyncEnumerator<T> GetAsyncEnumerator(CancellationToken cancellationToken = default) =>
            new TestAsyncEnumerator<T>(this.AsEnumerable().GetEnumerator());

        IQueryProvider IQueryable.Provider => new TestAsyncQueryProvider<T>(this);
    }

    private sealed class TestAsyncEnumerator<T>(IEnumerator<T> inner) : IAsyncEnumerator<T>
    {
        public T Current => inner.Current;

        public ValueTask DisposeAsync()
        {
            inner.Dispose();
            return ValueTask.CompletedTask;
        }

        public ValueTask<bool> MoveNextAsync() => new(inner.MoveNext());
    }

    private sealed class TestAsyncQueryProvider<TEntity>(IQueryProvider inner) : IAsyncQueryProvider
    {
        public IQueryable CreateQuery(Expression expression) =>
            new TestAsyncEnumerable<TEntity>(expression);

        public IQueryable<TElement> CreateQuery<TElement>(Expression expression) =>
            new TestAsyncEnumerable<TElement>(expression);

        public object? Execute(Expression expression) =>
            inner.Execute(expression);

        public TResult Execute<TResult>(Expression expression) =>
            inner.Execute<TResult>(expression);

        public IAsyncEnumerable<TResult> ExecuteAsync<TResult>(Expression expression) =>
            new TestAsyncEnumerable<TResult>(expression);

        public TResult ExecuteAsync<TResult>(
            Expression expression,
            CancellationToken cancellationToken) =>
            Execute<TResult>(expression);
    }
}