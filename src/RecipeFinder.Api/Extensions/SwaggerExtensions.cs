using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;

namespace RecipeFinder.Api.Extensions
{
    public static class SwaggerExtensions
    {
        private const string SERVICE_NAME = "Recipe Finder";
        private static readonly string[] _assemblies = { "RecipeFinder.Api", "RecipeFinder.Application", "RecipeFinder.Domain", "RecipeFinder.Infrastructure" };

        public static IApplicationBuilder UseSwaggerWithUI(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(s =>
            {
                s.RoutePrefix = "help";
                s.SwaggerEndpoint("../swagger/v1/swagger.json", SERVICE_NAME);
                s.InjectStylesheet("../css/swagger.min.css");
            });

            return app;
        }

        public static IServiceCollection AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo()
                {
                    Title = SERVICE_NAME,
                    Version = $"{FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location).ProductVersion}"
                });

                foreach (var assemblyName in _assemblies)
                {
                    var xmlFile = $"{assemblyName}.xml";
                    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                    if (File.Exists(xmlPath))
                    {
                        c.IncludeXmlComments(xmlPath);
                    }
                }

                c.CustomSchemaIds(type => type.ToString());
            });

            return services;
        }
    }
}
