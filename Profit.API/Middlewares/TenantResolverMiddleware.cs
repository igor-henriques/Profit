namespace Profit.API.Middlewares;

public sealed class TenantResolverMiddleware
{
    private readonly RequestDelegate _next;

    public TenantResolverMiddleware(RequestDelegate next)
    {
        this._next = next;
    }

    public async Task Invoke(HttpContext context, IUnitOfWork _unitOfWork)
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

        await _unitOfWork.SetTenantEnsuringCreation(tenantId);
        await _next(context);
    }
}
