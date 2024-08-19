using System.Text;
using Account.App.Settings;
using Account.Data;
using Account.Data.Repositories;
using Account.Domain.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace Account.Api
{
    public class AddAccount
    {
        public static IServiceCollection RegisterServices(
            IServiceCollection services,
            string secretKey,
            string issuer,
            string audience,
            string connectionString
        )
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(AddAccount).Assembly));
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddDbContext<AccountDbContext>(opts => opts.UseSqlServer(connectionString));

            var jwtSettings = new JwtSettings
            {
                ExpiryInMinutes = 60,
                SecretKey = secretKey,
                Issuer = issuer,
                Audience = audience
            };
            services.AddSingleton(jwtSettings);

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtSettings.SecretKey)),
                    ValidAudience = jwtSettings.Audience,
                    ValidIssuer = jwtSettings.Issuer
                };
            });

            return services;
        }
    }
}