namespace PBACTemplate.Services.Foundations.Roles.Exceptions;

public sealed class RolesServiceException(string message, Exception innerException)
    : Exception(message, innerException);