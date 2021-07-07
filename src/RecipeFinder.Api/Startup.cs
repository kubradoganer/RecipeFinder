using FluentValidation;
using Hellang.Middleware.ProblemDetails;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RecipeFinder.Api;
using RecipeFinder.Api.Extensions;
using RecipeFinder.Application.SeedWork;
using RecipeFinder.Infrastructure.Database.Contexts;
using RecipeFinder.Infrastructure.Processing;
using System;
using System.Reflection;
using RecipeFinder.Infrastructure.Domain.SeedWork;

namespace RecipeFinder
{
    public class Startup
    {
        private const string CONNECTION_STRING_KEY = "DefaultConnection";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddHttpContextAccessor();
            services.AddDbContext<RecipeFinderContext>(options =>
            {
                options.UseNpgsql(Configuration.GetConnectionString(CONNECTION_STRING_KEY),
                    npSqlOptions =>
                    {
                        npSqlOptions.CommandTimeout(3300);
                    });
            });

            services.AddSwagger();

            services.AddAutoMapper(cfg =>
            {
                cfg.AddMaps(AppDomain.CurrentDomain.GetAssemblies());
            }, AppDomain.CurrentDomain.GetAssemblies());

            services.AddProblemDetailsFromExceptions();

            Assembly[] assemblies = new[] { Assemblies.Application };

            services.AddMediatR(assemblies);
            AssemblyScanner.FindValidatorsInAssemblies(assemblies).ForEach(item => services.AddScoped(item.InterfaceType, item.ValidatorType));
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehaviour<,>));

            services.AddScoped<IUnitOfWork, UnitOfWork>();

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseProblemDetails();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwaggerWithUI();

            //AutoMigrate(app);
        }

        private void AutoMigrate(IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.CreateScope();
            using var context = serviceScope.ServiceProvider.GetService<RecipeFinderContext>();

            context.Database.Migrate();
        }
    }
}
