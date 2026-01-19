namespace PBACTemplate.Services.Foundations.Roles.Exceptions;

public sealed class FailedRolesOperationException(string message) : Exception(message);