namespace PBACTemplate.Services.Foundations.Roles.Exceptions;

public sealed class FailedRolesServiceException(string message, Exception innerException)
    : Exception(message, innerException);