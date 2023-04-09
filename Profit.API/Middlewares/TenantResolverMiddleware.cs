namespace Profit.API.Middlewares;

public sealed class TenantResolverMiddleware
{
    private readonly RequestDelegate _next;    

    public TenantResolverMiddleware(RequestDelegate next)
    {
        this._next = next;
    }

    public async Task Invoke(HttpContext context, IUnitOfWork _unitOfWork, TenantInfo _tenantInfo)
    {
        if (context.Request.Path.Value?.Contains(Routes.User.BaseUser, StringComparison.OrdinalIgnoreCase) ?? false)
        {
            await _next(context);
            return;
        }

        var tenant = context.Request.Headers["TenantId"].FirstOrDefault();
        if (string.IsNullOrEmpty(tenant))
        {
            throw new InvalidTenantException("TenantId header is required");
        }

        if (!Guid.TryParse(tenant, out Guid tenantId))
        {
            throw new InvalidTenantException("TenantId header is not in the correct format");
        }

        var username = GetUsernameFromAuthorizationHeader(context);

        try
        {            
            var user = await _unitOfWork.UserRepository.GetByUsername(username);
            
            if (!tenantId.Format().Equals(user.TenantId.Format()))
            {
                throw new InvalidTenantException("TenantId header does not match the user's tenant");
            }
        }
        catch (EntityNotFoundException)
        {
            throw new InvalidTenantException("TenantId header does not match the user's tenant");
        }

        _tenantInfo.SetTenantId(tenantId);

        await _next(context);
    }

    private static string GetUsernameFromAuthorizationHeader(HttpContext context)
    {
        var authorizationClaims = context.Request.Headers["Authorization"].FirstOrDefault();
        if (string.IsNullOrEmpty(authorizationClaims))
        {
            throw new InvalidCredentialsException("Authentication is required");
        }

        var encodedPayload = authorizationClaims.Split(".").Skip(1).FirstOrDefault();
        if (string.IsNullOrEmpty(encodedPayload))
        {
            throw new InvalidCredentialsException("Authentication is required");
        }

        var username = Helper.DecodeJwtPayload(encodedPayload)?.FirstOrDefault().Value;

        return username.ToString();
    }
}
