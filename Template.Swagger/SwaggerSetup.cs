using Microsoft.Extensions.DependencyInjection;
using System;
using Microsoft.OpenApi.Models;
using System.IO;
using Microsoft.AspNetCore.Builder;

namespace Template.Swagger
{
    public static class SwaggerSetup
    {
        public static IServiceCollection AddSwaggerConfiguration(this IServiceCollection services)
        {
            return services.AddSwaggerGen(opt =>
            {
                opt.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Template .Net Core",
                    Version = "v1",
                    Description = "Tutorial de desenvolvimento com .Net Core e Angular",
                    Contact = new OpenApiContact
                    {
                        Name = "Ederson Furlan",
                        Email = "edersonmello@msn.com"
                    }
                });

                string xmlPath = Path.Combine("wwwroot", "api-doc.xml");
                opt.IncludeXmlComments(xmlPath);
            });
        }

        public static IApplicationBuilder UseSwaggerConfiguration(this IApplicationBuilder app)
        {
            return app.UseSwagger().UseSwaggerUI(c =>
            {
                c.RoutePrefix = "documentation";
                c.SwaggerEndpoint("../swagger/v1/swagger.json", "API v1");
            });
        }
    }
}
