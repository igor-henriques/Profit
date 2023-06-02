const string RELATIVE_PATH = @"../../../../Profit.API";
var absolutePath = Path.GetFullPath(RELATIVE_PATH);

var configuration = BuildConfiguration();

Log.Logger = new LoggerConfiguration()
        .ReadFrom.Configuration(configuration)
          .CreateLogger();

var host = Host.CreateDefaultBuilder(args)
        .ConfigureServices(services =>
        {
            services.AddDbContext<AuthDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("AuthConnection")));
            services.AddSingleton<IConfiguration>(x => configuration);
            services.AddSingleton<MigratorApplication>();
            services.AddLogging(loggingBuilder => loggingBuilder.AddSerilog(dispose: true));
        }).Build();

var application = host.Services.GetService<MigratorApplication>();
await application.RunMigrationsForAllTenantsAsync();

static IConfiguration BuildConfiguration()
{
    const string RELATIVE_PATH = @"../../../../Profit.API";
    var absolutePath = Path.GetFullPath(RELATIVE_PATH);

    var builder = new ConfigurationBuilder();
    builder.SetBasePath(absolutePath)
        .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

    var environmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
    if (environmentName == null || string.Equals(environmentName, "Development", StringComparison.OrdinalIgnoreCase))
    {
        builder.AddUserSecrets(Assembly.GetExecutingAssembly(), optional: true);
    }

    var configuration = builder.Build();

    return configuration;
}