try
{
    var configuration = BuildConfiguration();

    Log.Logger = new LoggerConfiguration()
            .ReadFrom.Configuration(configuration)
              .CreateLogger();

    var authConnection = configuration.GetConnectionString("AuthConnection");
    var profitConnection = configuration.GetConnectionString("ProfitConnection");

    Console.WriteLine(authConnection);
    Console.WriteLine(profitConnection);

    var host = Host.CreateDefaultBuilder(args)
            .ConfigureServices(services =>
            {
                services.AddDbContext<ProfitDbContext>(options => options.UseSqlServer(authConnection), ServiceLifetime.Singleton, ServiceLifetime.Singleton);
                services.AddDbContext<AuthDbContext>(options => options.UseSqlServer(authConnection), ServiceLifetime.Singleton, ServiceLifetime.Singleton);
                services.Configure<ConnectionStringsOptions>(configuration.GetSection("ConnectionStrings"));
                services.AddSingleton<MigratorApplication>();
                services.AddLogging(loggingBuilder => loggingBuilder.AddSerilog(dispose: true));
            }).Build();

    var application = host.Services.GetService<MigratorApplication>();
    await application.RunMigrationsForAllTenantsAsync();
}
catch (Exception ex) when (ex is not HostAbortedException)
{
    Console.WriteLine(ex.ToString());
    throw;
}

static IConfiguration BuildConfiguration()
{
    const string RELATIVE_PATH = @"../../../../Profit.API";
    var absolutePath = Path.GetFullPath(RELATIVE_PATH);

    if (!Directory.Exists(absolutePath) || !Directory.GetFiles(absolutePath, "*", SearchOption.AllDirectories).Any(file => file.Contains("appsettings")))
    {
        absolutePath = Path.GetFullPath("../Profit.API/");
    }

    var builder = new ConfigurationBuilder();
    builder.SetBasePath(absolutePath)
        .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

    builder.AddUserSecrets(Assembly.GetExecutingAssembly(), optional: true);

    var configuration = builder.Build();

    return configuration;
}