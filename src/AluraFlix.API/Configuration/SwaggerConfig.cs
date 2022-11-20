using Microsoft.OpenApi.Models;
using Swashbuckle.Swagger;
using System.Reflection;

namespace AluraFlix.API.Configuration;

public static class SwaggerConfig
{
    public static IServiceCollection AddSwaggerConfig(this IServiceCollection services)
    {
        services.AddSwaggerGen(option =>
        {
            option.SwaggerDoc("v1", new OpenApiInfo
            {
                Version = "v1",
                Title = "AluraFlix API",
                Description = "API RESTful desenvolvida no Alura Challenge Back-End #5",
                Contact = new OpenApiContact
                {
                    Name= "Jackson S. Maciel",
                    Email= "jacksons.m2018@gmail.com",
                    Url= new Uri("https://www.linkedin.com/in/jacksonsmaciel/")
                }
            });

            var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            option.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));

            option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                In = ParameterLocation.Header,
                Description = "Por favor, entre com o token valido.",
                Name = "Autenticação",
                Type = SecuritySchemeType.Http,
                BearerFormat = "JWT",
                Scheme = "Bearer"
            });
            option.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type=ReferenceType.SecurityScheme,
                            Id="Bearer"
                        }
                    },
                new string[]{}
                }
            });
        });

        return services;
    }
}
