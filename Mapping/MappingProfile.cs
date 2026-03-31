using AutoMapper;
using LibraryApi.Dtos.Books;
using LibraryApi.Dtos.Reviews;
using LibraryApi.Models;

namespace LibraryApi.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Book, BookResponse>();
        CreateMap<Review, ReviewResponse>();
        
    }
}