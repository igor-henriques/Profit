namespace Profit.API.Middlewares;

public sealed class TenantResolverMiddleware
{
    private readonly RequestDelegate _next;

    public TenantResolverMiddleware(RequestDelegate next)
    {
        this._next = next;
    }

    public async Task Invoke(HttpContext context, IReadOnlyUserRepository _readOnlyUserRepo, ITenantInfo _tenantInfo)
    {
        if (context.Request.Path.Value?.Contains(Routes.User.BaseUser, StringComparison.OrdinalIgnoreCase) ?? false)
        {
            await _next(context);
            return;
        }

        var username = GetUsernameFromAuthorizationHeader(context);
        var userTenant = await _readOnlyUserRepo.GetTenantIdByUsername(username);
        _tenantInfo.SetTenantId(userTenant);

        await _next(context);
    }
    private static string GetUsernameFromAuthorizationHeader(HttpContext context)
    {
        var authorizationClaims = context.Request.Headers["Authorization"].FirstOrDefault();
        if (string.IsNullOrEmpty(authorizationClaims))
        {
            throw new InvalidCredentialsException("Authentication is required");
        }

        var encodedPayload = authorizationClaims?.Split(".")?.Skip(1)?.FirstOrDefault();
        if (string.IsNullOrEmpty(encodedPayload))
        {
            throw new InvalidCredentialsException("Authentication is required");
        }

        var username = Helper.DecodeJwtPayload(encodedPayload)?.FirstOrDefault().Value;

        return username?.ToString();
    }
}
