﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace AbpZero;

public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddApplication<AbpZeroHttpApiHostModule>();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
    {
        app.InitializeApplication();
    }
}