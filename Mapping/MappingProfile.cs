using AutoMapper;
using LibraryApi.Dtos.Books;
using LibraryApi.Dtos.Reviews;
using LibraryApi.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace LibraryApi.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Book, BookResponse>()
            .ForMember(dest => dest.AverageRating, opt => opt.MapFrom(src => 
                src.Reviews != null && src.Reviews.Any() 
                ? src.Reviews.Average(r => r.Rating) 
                : 0))
            .ForMember(dest => dest.ReviewsCount, opt => opt.MapFrom(src => 
                src.Reviews != null ? src.Reviews.Count : 0));

        CreateMap<Book, BookDetailsResponse>()
            .IncludeBase<Book, BookResponse>();

        CreateMap<UpdateBookRequest, Book>()
            .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
    
        CreateMap<Review, ReviewResponse>();
    }
}