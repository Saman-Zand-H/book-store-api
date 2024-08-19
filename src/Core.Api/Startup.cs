using Account.Api.Controllers;
using Account.Api;
using Book.Api.Controllers;
using Book.Api;

namespace Core.Api
{
    public class Startup(IConfiguration configuration)
    {
        private readonly IConfiguration _configuration = configuration;

        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers()
                .AddJsonOptions(options => options.JsonSerializerOptions.PropertyNamingPolicy = null)
                .AddApplicationPart(typeof(UserController).Assembly)
                .AddApplicationPart(typeof(BookController).Assembly);

            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            // TODO: use environment variables
            AddAccount.RegisterServices(services, _configuration["Jwt:SecretKey"]!, _configuration["Jwt:Issuer"]!, _configuration["Jwt:Audience"]!);
            AddBook.RegisterServices(services);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthentication();

            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}