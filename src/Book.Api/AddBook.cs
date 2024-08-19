using Book.Data;
using Book.Data.Repositories;
using Book.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Book.Api
{
    public class AddBook
    {
        public static void RegisterServices(IServiceCollection services, string connectionString)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(AddBook).Assembly));
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddDbContext<BookDbContext>(opts => opts.UseSqlServer(connectionString));
        }
    }

}