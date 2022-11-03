using AutoMapper;

namespace Houseseekers.API.Profiles
{
    public class CategoryProfle : Profile
    {
        public CategoryProfle()
        {
            CreateMap<Models.Category, Models.DTOs.CategoryDTO>()
                .ForMember(dest => dest.CategoryName, options => options.MapFrom(src => src.Name))
                .ReverseMap();
        }
    }
}
