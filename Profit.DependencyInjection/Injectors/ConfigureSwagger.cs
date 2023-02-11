﻿namespace Profit.DependencyInjection.Injectors;

public static class ConfigureSwagger
{
    public static IServiceCollection AddSwagger(this IServiceCollection services)
    {
        services.AddSwaggerGen(c =>
        {
            c.OperationFilter<AddHeaderOperationFilter>("TenantId", "Defines the Tenant for this request", false);

            c.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "Profit API",
                Version = "v1",
                Description = "Provides full control over Profit operation",
                Contact = new OpenApiContact() { Name = "Ironside Consultancy" }
            });

            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                In = ParameterLocation.Header,
                Description = "Utilize 'Bearer <TOKEN>'",
                Name = "Authorization",
                Type = SecuritySchemeType.ApiKey
            });

            c.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    }, new string[] { }
                }
            });

            c.EnableAnnotations();
        });

        return services;
    }
}
