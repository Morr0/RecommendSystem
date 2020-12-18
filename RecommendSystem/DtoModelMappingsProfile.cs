using AutoMapper;
using RecommendSystem.Dtos;
using RecommendSystem.Models;

namespace RecommendSystem
{
    public class DtoModelMappingsProfile : Profile
    {
        public DtoModelMappingsProfile()
        {
            CreateMap<ItemWriteDto, Item>();
            CreateMap<Item, ItemReadDto>();
            
            CreateMap<ReviewWriteDto, Review>();
            CreateMap<Review, ReviewReadDto>();

            CreateMap<ItemReview, ItemReviewReadDto>();
        }
    }
}