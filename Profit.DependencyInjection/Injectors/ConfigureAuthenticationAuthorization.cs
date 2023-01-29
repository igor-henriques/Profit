using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Profit.Core.Shared;
using System.Security.Claims;
using System.Text;

namespace Profit.DependencyInjection.Injectors;     

public static class ConfigureAuthenticationAuthorization
{
    public static void AddCustomAuthentication(
        this IServiceCollection services,
        string jwtBearerKey)
    {
        ArgumentValidator.ThrowIfNullOrEmpty(jwtBearerKey);

        services.AddAuthentication(opt =>
        {
            opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(jwt =>
        {
            jwt.RequireHttpsMetadata = true;
            jwt.SaveToken = true;
            jwt.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtBearerKey)),
                ValidateIssuer = false,
                ValidateAudience = false,
            };
        });
    }

    public static void AddCustomAuthorization(
        this IServiceCollection services)
    {
        services.AddAuthorization(options =>
        {
            options.AddPolicy("AdminsOnly", policy => policy.RequireClaim(ClaimTypes.Role, "Admin"));
            options.AddPolicy("EmployeesAtLeast", policy => policy.RequireClaim(ClaimTypes.Role, "Admin", "Employee"));
        });
    }
}
