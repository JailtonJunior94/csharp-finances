using Finances.API.Configurations;
using Finances.API.Middlewares;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Prometheus;
using Prometheus.DotNetRuntime;
using System;
using System.IO.Compression;
using System.Net.Mime;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Finances.API
{
    public class Startup
    {
        public static IDisposable Collector;
        public IConfiguration Configuration { get; }

        public Startup(IHostEnvironment hostEnvironment)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(hostEnvironment.ContentRootPath)
                .AddJsonFile($"appsettings.{hostEnvironment.EnvironmentName}.json", true, true)
                .AddEnvironmentVariables();

            Configuration = builder.Build();
            Collector = ConfigureCollector();
        }

        public IDisposable ConfigureCollector()
        {
            _ = DotNetRuntimeStatsBuilder.Default();
            DotNetRuntimeStatsBuilder.Builder builder = DotNetRuntimeStatsBuilder.Customize()
                .WithContentionStats(CaptureLevel.Informational)
                .WithGcStats(CaptureLevel.Verbose)
                .WithThreadPoolStats(CaptureLevel.Informational)
                .WithExceptionStats(CaptureLevel.Errors)
                .WithJitStats();

            return builder.StartCollecting();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers().AddJsonOptions(opts =>
            {
                opts.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
            });

            services.AddResponseCompression();
            services.Configure<GzipCompressionProviderOptions>(options =>
            {
                options.Level = CompressionLevel.Fastest;
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Finances.API", Version = "v1" });
            });
            services.AddDependencies();
            services.AddHealthChecks();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Finances.API v1"));

            app.UseHealthChecks("/health", new HealthCheckOptions
            {
                ResponseWriter = async (context, report) =>
                {
                    var result = JsonSerializer.Serialize(new
                    {
                        currentTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                        statusApplication = report.Status.ToString(),
                    });

                    context.Response.ContentType = MediaTypeNames.Application.Json;
                    await context.Response.WriteAsync(result);
                }
            });

            app.UseRouting();
            app.UseAuthorization();
            app.UseRequestResponseLogging();
            app.UseResponseCompression();
            app.UseHttpMetrics();
            app.UseMetricServer();

            app.UseMiddleware<ErrorHandlerMiddleware>();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
