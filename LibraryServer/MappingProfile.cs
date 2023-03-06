using AutoMapper;
using LibraryServer.DTOs;
using LibraryServer.Models;

namespace LibraryServer
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Book, BookDTO>()
                .ForMember(dest => dest.Rating, act => act.MapFrom(src => src.Ratings.Select(s => s.Score)
                .DefaultIfEmpty(0).Average()))
                .ForMember(dest => dest.ReviewsNumber, act => act.MapFrom(src => src.Reviews.Count));

            CreateMap<BookCreationDTO, Book>().ReverseMap();

            CreateMap<ReviewCreationDTO, Review>();

            CreateMap<RatingCreationDTO, Rating>();

            CreateMap<Review, ReviewDTO>();

            CreateMap<Book, BookDetailsDTO>()
                .ForMember(dest => dest.Rating, act => act.MapFrom(src => src.Ratings.Select(s => s.Score)
                .DefaultIfEmpty(0).Average()))
                .ForMember(dest => dest.Reviews, act => act.MapFrom(src => src.Reviews));
        }
    }
}
