using Profit.Domain.Interfaces.Repositories;

try
{
    var builder = WebApplication.CreateBuilder(args);

    Log.Logger = new LoggerConfiguration()
        .ReadFrom.Configuration(builder.Configuration)
          .CreateLogger();

    builder.Services.Configure<JsonOptions>(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    });

    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwagger();
    builder.Services.AddOptionsConfigurations(builder.Configuration);
    builder.Services.AddGeneralDependencies();
    builder.Services.AddDbContext<ProfitDbContext>((serviceProvider, options) =>
    {
        var schemaInterceptor = serviceProvider.GetRequiredService<SchemaInterceptor>();
        var connectionStringOptions = serviceProvider.GetRequiredService<IOptions<ConnectionStringsOptions>>();
        options.UseSqlServer(connectionStringOptions.Value.ProfitConnection)
               .AddInterceptors(schemaInterceptor);
    });

    builder.Services.AddDbContext<AuthDbContext>((serviceProvider, options) =>
    {
        var connectionStringOptions = serviceProvider.GetRequiredService<IOptions<ConnectionStringsOptions>>();
        options.UseSqlServer(connectionStringOptions.Value.AuthConnection);
    });

    builder.Services.AddMapperProfiles();
    builder.Services.AddValidators();
    builder.Services.AddCacheServices();
    builder.Services.AddCqrsHandlers();
    builder.Services.AddCustomAuthentication(builder.Configuration.GetValue<string>("JwtAuthentication:Key"));
    builder.Services.AddCustomAuthorization();
    builder.Services.AddHealthChecks();
    builder.Services.AddMemoryCache();
    builder.Services.AddCors();

    var app = builder.Build();
    app.UseMiddleware<ExceptionHandlerMiddleware>();
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }
    app.MapHealthChecks(Routes.Health);
    app.UseCors(c => c.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
    app.UseMiddleware<TenantResolverMiddleware>();
    app.UseHttpsRedirection();

    app.ConfigureIngredientEndpoints();
    app.ConfigureProductEndpoints();
    app.ConfigureRecipeEndpoints();
    app.ConfigureUserEndpoints();
    app.ConfigureOrderEndpoints();

    await ExecuteMigrations(app);

    await app.RunAsync();
}
catch (Exception ex)
{
    Log.Fatal(ex.ToString());
    throw;
}
finally
{
    Log.CloseAndFlush();
}

static async Task ExecuteMigrations(WebApplication app)
{
    using var scope = app.Services.CreateScope();
    var migrator = scope.ServiceProvider.GetRequiredService<IMigratorApplication>();
    await migrator.RunMigrationsForAllTenantsAsync();
}