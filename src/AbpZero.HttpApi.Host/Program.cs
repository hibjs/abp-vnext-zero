using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Events;

namespace AbpZero;

public class Program
{
    public static int Main(string[] args)
    {
        const string logOutputTemplate = "[{Timestamp:HH:mm:ss} {Level:u3}] {RequestId:l} {Message:lj} {NewLine}{Exception}";
        Log.Logger = new LoggerConfiguration()
#if DEBUG
            .MinimumLevel.Debug()
#else
                .MinimumLevel.Information()
#endif
            .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
            .Enrich.FromLogContext()
            .WriteTo.Async(c => c.File("logs/*.log", rollingInterval: RollingInterval.Day, retainedFileCountLimit: 7, outputTemplate: logOutputTemplate))
#if DEBUG
            .WriteTo.Async(c => c.Console(outputTemplate: logOutputTemplate))
#endif
            .CreateLogger();

        try
        {
            Log.Information("Starting web host");
            CreateHostBuilder(args).Build().Run();
            return 0;
        }
        catch (Exception ex)
        {
            Log.Fatal(ex, "Host terminated unexpectedly!");
            return 1;
        }
        finally
        {
            Log.CloseAndFlush();
        }
    }

    internal static IHostBuilder CreateHostBuilder(string[] args)
    {
        return Host.CreateDefaultBuilder(args)
            .AddAppSettingsSecretsJson()
            .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); })
            .UseAutofac()
            .UseSerilog();
    }
}