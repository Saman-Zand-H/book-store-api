using BookStore.Api.DTOs;
using BookStore.Api.Models;
using Mapster;

namespace BookStore.Api.Mapping
{
    public class BookMappingConfig
    {
        public static void RegisterMappings()
        {
            TypeAdapterConfig<Book, BookCreateDto>.NewConfig();
            TypeAdapterConfig<Book, BookUpdateDto>.NewConfig();
            TypeAdapterConfig<Book, BookReadDto>.NewConfig();
        }
    }
}