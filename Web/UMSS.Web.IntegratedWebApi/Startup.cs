using System;
using Serilog;
using AutoMapper;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UMSS.Web.IntegratedWebApi.ExtensionsAndMiddleWare;

namespace UMSS.Web.IntegratedWebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            //Getting the current Web Hosting Environment Value
            var enviromentValue = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            // Reading and building the Configurations of App as per the environment value
            var builder = new ConfigurationBuilder()
              .SetBasePath(environment.ContentRootPath)
              .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
              .AddJsonFile($"appsettings.{enviromentValue}.json", optional: false, reloadOnChange: true)
              .AddEnvironmentVariables();

            configuration = builder.Build();
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            var allowedOrigins = Configuration.GetSection("AppSettings:AllowCors").Get<string[]>();

            // Add service and create Policy with options
            services.AddCors(options =>
            {
                // TODO: add origins to config
                options.AddPolicy("CorsPolicy",
                    builder => builder.WithOrigins(allowedOrigins)
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials());
            });

            services.ConfigureSqlDbContext(Configuration);

            services.AddDataAccessDependencies();

            services.AddBusinessDependencies();

            //services.ConfigureAndValidate<AzureAdClientSettings>(Configuration);

            services.AddAutoMapper(typeof(Startup));

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "Integrated Api", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("CorsPolicy");

            // Hook in the global exception-handling middleware
            app.UseMiddleware(typeof(GlobalExceptionHandlingMiddleware));

            app.UseHttpsRedirection();

            app.UseSerilogRequestLogging();

            app.UseRouting();

            app.UseAuthorization();
           
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.RoutePrefix = "";
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Integrated Api V1");
            });

        }
    }
}
