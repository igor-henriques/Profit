﻿namespace Profit.DependencyInjection.Injectors;

public static class ConfigureGeneralDependencies
{
    public static IServiceCollection AddGeneralDependencies(this IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddLogging(loggingBuilder => loggingBuilder.AddSerilog(dispose: true));
        return services;
    }
}
