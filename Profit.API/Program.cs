using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Profit.Infrastructure.Repository;

try
{
	var builder = WebApplication.CreateBuilder(args);

	Log.Logger = new LoggerConfiguration()
		.ReadFrom.Configuration(builder.Configuration)
		  .Enrich.FromLogContext()
		  .WriteTo.Console()
		  .CreateLogger();

	builder.Services.AddEndpointsApiExplorer();
	builder.Services.AddSwaggerGen();
	builder.Services.AddDbContext<ProfitDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("ProfitSqlServer")));	
	builder.Services.AddMapperProfiles();
	builder.Services.AddValidators();
	builder.Services.AddCacheServices(builder.Configuration.GetConnectionString("Redis"));
	builder.Services.AddCqrsHandlers();
	builder.Services.AddCommandBatchProcessors();
	builder.Services.AddGeneralDependencies();
	builder.Services.AddCustomAuthentication(builder.Configuration.GetValue<string>("JwtAuthentication:Key"));
	builder.Services.AddCustomAuthorization();
	builder.Services.AddHealthChecks();
	builder.Services.AddMemoryCache();
	builder.Services.AddCors();

	var app = builder.Build();

	if (app.Environment.IsDevelopment())
	{
		app.UseSwagger();
		app.UseSwaggerUI();
	}
	app.MapHealthChecks("/health");
	app.UseCors(c => c.AllowAnyOrigin());
	app.UseHttpsRedirection();
	app.UseMiddleware<ExceptionHandlerMiddleware>();

	app.ConfigureIngredientEndpoints();
	app.ConfigureUserEndpoints();

	app.Run();
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