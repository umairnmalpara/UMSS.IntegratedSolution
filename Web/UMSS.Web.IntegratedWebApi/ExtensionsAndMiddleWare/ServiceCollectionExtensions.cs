using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UMSS.Music.Business.Services.Implementation;
using UMSS.Music.Business.Services.Interface;
using UMSS.Music.DataAccess.UnitOfWork.Implementation;
using UMSS.Music.DataAccess.UnitOfWork.Interface;
using UMSS.Music.DataService;

namespace UMSS.Web.IntegratedWebApi.ExtensionsAndMiddleWare
{
    public static class ServiceCollectionExtensions
    {
        public static void ConfigureSqlDbContext(this IServiceCollection services, IConfiguration config)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));
            if (config == null) throw new ArgumentNullException(nameof(config));

            var connectionString = config.GetConnectionString("IntegratedDatabaseConnection");

            //Set Migrate
            //var optionsBuilder = new DbContextOptionsBuilder<IntegratedDatabaseContext>();
            //optionsBuilder.UseSqlServer(connectionString);
            //using (var context = new IntegratedDatabaseContext(optionsBuilder.Options))
            //{
            //	context.Database.Migrate();
            //}

            //Add Db Context
            services.AddDbContext<MusicDbContext>(options => 
                options.UseSqlServer(connectionString, b => b.MigrationsAssembly("UMSS.Music.DataService")));

        }

        public static void AddDataAccessDependencies(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddScoped<IMusicUnitOfWork, MusicUnitOfWork>();
        }

        public static void AddBusinessDependencies(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddTransient<IMusicService, MusicService>();
            services.AddTransient<IArtistService, ArtistService>();
        }

        public static IServiceCollection ConfigureAndValidateAppConfig<T,TValidator>(this IServiceCollection @this,IConfiguration config) where T : class where TValidator : AbstractValidator<T>,new() 
        => @this
            .Configure<T>(config.GetSection(typeof(T).Name))
            .PostConfigure<T>(settings =>
            {
                var validator = new TValidator();
                var validationResult = validator.Validate(settings);
                if (!validationResult.IsValid)
                {
                    var configErrors = validationResult.ValidationErrors().ToArray();
                    if (configErrors.Any())
                    {
                        var aggrErrors = string.Join(",", configErrors);
                        var count = configErrors.Length;
                        var configType = typeof(T).Name;
                        throw new ApplicationException(
                            $"Found {count} configuration error(s) in {configType}: {aggrErrors}");
                    }
                }

                //var configErrors = settings.ValidationErrors().ToArray();
                //if (configErrors.Any())
                //{
                //    var aggrErrors = string.Join(",", configErrors);
                //    var count = configErrors.Length;
                //    var configType = typeof(T).Name;
                //    throw new ApplicationException(
                //        $"Found {count} configuration error(s) in {configType}: {aggrErrors}");
                //}

            });
    }
}
