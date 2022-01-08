using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace Cotacao.Infra.Dependencies
{
    public static class SwaggerDependency
    {
        public static IServiceCollection AddSwaggerDependency(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1",
                    new OpenApiInfo
                    {
                        Title = "Cotação API",
                        Version = "v1",
                        Description = "Esta API tem como finalidade disponibilizar CRUD para Cotação e itens da Cotação.",
                        Contact = new OpenApiContact { Name = "Bruno", Email = "b_marques85@live.com" }
                    });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Type = SecuritySchemeType.Http,
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Scheme = "bearer",
                    Description = "Please insert JWT token"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[] { }
                    }
                });
            });

            return services;
        }

        public static void UseSwaggerDependency(this IApplicationBuilder app)
        {
            app.UseSwagger(x =>
            {
                x.RouteTemplate = "swagger/{documentname}/swagger.json";
            });

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Cotação API");
                c.RoutePrefix = "swagger";
                c.DocumentTitle = "Cotação API";
                c.DocExpansion(DocExpansion.List);
            });
        }
    }

}
