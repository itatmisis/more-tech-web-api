﻿using JetBrains.Annotations;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace CryptoPunks.MoreTech.Platform.Extensions;

[PublicAPI]
public static class SwaggerExtension
{
    public static IServiceCollection AddSwagger(this IServiceCollection services, string serviceName, string version = "v1", bool useJwtAuth = false)
        => services.AddSwaggerGen(opt =>
        {
            opt.SwaggerDoc(version, new OpenApiInfo
            {
                Version = version,
                Title = serviceName,
            });
            if (!useJwtAuth)
                return;
            opt.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                In = ParameterLocation.Header,
                Description = "Please insert JWT with Bearer into field",
                Name = "Authorization",
                Type = SecuritySchemeType.ApiKey,
                Scheme = "Bearer",
                BearerFormat = "JWT"
            });
            opt.AddSecurityRequirement(new OpenApiSecurityRequirement
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
                    Array.Empty<string>()
                }
            });
        });
}
