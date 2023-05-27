const string RELATIVE_PATH = @"../../../../Profit.API";
var absolutePath = Path.GetFullPath(RELATIVE_PATH);

var configuration = new ConfigurationBuilder()
    .SetBasePath(absolutePath)
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddEnvironmentVariables()
    .Build();

Log.Logger = new LoggerConfiguration()
        .ReadFrom.Configuration(configuration)
          .CreateLogger();

var host = Host.CreateDefaultBuilder(args)
        .ConfigureServices(services =>
        {
            services.AddDbContext<AuthDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("AuthSqlServer")));
            services.AddSingleton<IConfiguration>(x => configuration);
            services.AddSingleton<MigratorApplication>();
            services.AddLogging(loggingBuilder => loggingBuilder.AddSerilog(dispose: true));
        }).Build();

var application = host.Services.GetService<MigratorApplication>();
await application.RunMigrationsForAllTenantsAsync();