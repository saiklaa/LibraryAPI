using AutoMapper;
using LibraryApi.Dtos.Books;
using LibraryApi.Dtos.Reviews;
using LibraryApi.Models;


namespace LibraryApi.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Book, BookResponse>()
            .ForMember(dest => dest.AverageRating, opt => opt.MapFrom(src =>
                src.Reviews.Any() ? src.Reviews.Average(r => r.Rating) : 0))
            .ForMember(dest => dest.ReviewsCount, opt => opt.MapFrom(src => src.Reviews.Count));

        CreateMap<Book, BookDetailsResponse>()
            .IncludeBase<Book, BookResponse>()
            .ForMember(dest => dest.Reviews, opt => opt.MapFrom(src => src.Reviews));

        
        CreateMap<CreateBookRequest, Book>();
        
        CreateMap<UpdateBookRequest, Book>()
            .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

        // Review mappings
        CreateMap<Review, ReviewResponse>();
        CreateMap<CreateReviewRequest, Review>();
    }
}