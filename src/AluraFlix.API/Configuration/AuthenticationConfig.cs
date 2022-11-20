using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace AluraFlix.API.Configuration;

public static class AuthenticationConfig
{
    public static IServiceCollection AddAuthenticationConfig(
        this IServiceCollection services, IConfiguration configuration)
    {
        var key = configuration.GetRequiredSection("Settings:Jwt:ChaveToken").Value;
        var keyBytes = Encoding.ASCII.GetBytes(key);

        services.AddAuthentication(x =>
        {
            x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

        }).AddJwtBearer(x =>
        {
            x.RequireHttpsMetadata = false;
            x.SaveToken = true;
            x.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(keyBytes),
                ValidateIssuer = false,
                ValidateAudience = false
            };
        });

        return services;
    }
}
