using Book.App.Commands;
using Book.Data.DbContexts;
using Book.Data.Repositories;
using Book.Domain.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Book.Api
{
    public class AddBook
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(AddBook).Assembly));

            services.AddScoped<IBookRepository, BookRepository>();
            services.AddDbContext<BookDbContext>();
        }
    }
}