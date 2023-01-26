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
	builder.Services.AddDbContext<ProfitDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer")));
	builder.Services.AddMapperProfiles();
	builder.Services.AddValidators();
	builder.Services.AddCqrsHandlers();
	builder.Services.AddGeneralDependencies();

	var app = builder.Build();

	if (app.Environment.IsDevelopment())
	{
		app.UseSwagger();
		app.UseSwaggerUI();
	}

	app.UseHttpsRedirection();
	app.UseMiddleware<ExceptionHandlerMiddleware>();

	app.ConfigureIngredientEndpoints();

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