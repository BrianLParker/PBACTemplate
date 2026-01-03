// Copyright (c) 2026, Brian Parker. All Rights Reserved.
// TokensService.Exceptions.cs See LICENSE.txt in the root folder of the solution.

using PBACTemplate.Services.Foundations.Tokens.Exceptions;

namespace PBACTemplate.Services.Foundations.Tokens;

public partial class TokensService
{
    private ValueTask<T> TryCatch<T>(Func<ValueTask<T>> returningValueTaskFunction) =>
        ExecuteWithExceptionHandlingAsync(returningValueTaskFunction);

    private async ValueTask<T> ExecuteWithExceptionHandlingAsync<T>(
        Func<ValueTask<T>> returningValueTaskFunction)
    {
        try
        {
            return await returningValueTaskFunction();
        }
        catch (NullTokensException)
        {
            throw;
        }
        catch (InvalidTokensException)
        {
            throw;
        }
        catch (Exception exception)
        {
            var failedServiceException =
                new FailedTokensServiceException(
                    "Failed tokens service error occurred, contact support.",
                    exception);

            LogFailedTokensServiceException(failedServiceException);

            throw new TokensServiceException(
                "Tokens service error occurred, contact support.",
                failedServiceException);
        }
    }
}