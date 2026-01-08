public async Task<ApplicationUser?> RetrieveUserAsync(ClaimsPrincipal principal)
{
    if (principal is null)
    {
        throw new NullUserNameException("Claims principal cannot be null.");
    }

    return await this.userManagerBroker.GetUserAsync(principal);
}