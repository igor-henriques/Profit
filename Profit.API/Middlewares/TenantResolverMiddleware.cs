namespace Profit.API.Middlewares;

public sealed class TenantResolverMiddleware
{
    private readonly RequestDelegate _next;
    private readonly IUnitOfWork _unitOfWork;

    public TenantResolverMiddleware(
        RequestDelegate next,
        IUnitOfWork unitOfWork)
    {
        this._next = next;
        _unitOfWork = unitOfWork;
    }

    public async Task Invoke(HttpContext context)
    {
        if (context.Request.Path.Value?.StartsWith(Routes.User.Create, StringComparison.OrdinalIgnoreCase) ?? false
            && context.Request.Method.Equals(HttpMethods.Post, StringComparison.OrdinalIgnoreCase))
        {
            await _next(context);
            return;
        }
        
        var tenant = context.Request.Headers["TenantId"];

        if (string.IsNullOrEmpty(tenant))
        {
            throw new InvalidTenantException("TenantId header is required");
        }

        if (!Guid.TryParse(tenant, out Guid tenantId))
        {
            throw new InvalidTenantException("TenantId header is not in the correct format");
        }

        _unitOfWork.SetTenant(tenantId);
        await _next(context);
    }
}
