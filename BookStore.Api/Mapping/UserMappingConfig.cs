using BookStore.Api.DTOs;
using BookStore.Api.Models;
using Mapster;

namespace BookStore.Api.Mapping
{
    public class UserMappingConfig
    {
        public static void RegisterMappings()
        {
            TypeAdapterConfig<User, UserCreateDto>.NewConfig();

            TypeAdapterConfig<User, UserReadDto>.NewConfig()
                .Map(dest => dest.DateJoined, src => src.DateJoined.ToString());
        }
    }
}