using LIBRARY_MANAGEMENT_SYSTEM.Utilities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace LIBRARY_MANAGEMENT_SYSTEM.Extensions
{
    public static class JwtExtensions
    {
        public static void ConfigureJwtAuthentication(this WebApplicationBuilder builder)
        {
           
            builder.Services.Configure<JwtSettings>(
                builder.Configuration.GetSection("JwtSettings"));

         
            var jwtSection = builder.Configuration.GetSection("JwtSettings");
            var jwtSettings = jwtSection.Get<JwtSettings>();

            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,

                        ValidIssuer = jwtSettings.Issuer,
                        ValidAudience = jwtSettings.Audience,
                        IssuerSigningKey = new SymmetricSecurityKey(
                            Encoding.UTF8.GetBytes(jwtSettings.Key)),

                        ClockSkew = TimeSpan.Zero
                    };
                });

            builder.Services.AddAuthorization();
        }
    }
}
