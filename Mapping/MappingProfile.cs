using AutoMapper;
using LibraryApi.Dtos.Books;
using LibraryApi.Models;

namespace LibraryApi.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Book, BookResponse>();
        
    }
}