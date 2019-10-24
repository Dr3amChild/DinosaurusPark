using AutoMapper;
using DinosaurusPark.Contracts.Models;
using DinosaurusPark.Extensions;
using DinosaurusPark.WebApplication.Responses;

namespace DinosaurusPark.WebApplication.Mapping
{
    public class AppMappingProfile : Profile
    {
        public AppMappingProfile()
        {
            CreateMap<Bogus.DataSets.Name.Gender, Gender>();

            CreateMap<Dinosaur, DinosaurResponse>()
                .ForMember(dst => dst.Species, opt => opt.MapFrom(src => src.Species.Name))
                .ForMember(dst => dst.Gender, opt => opt.MapFrom(src => src.Gender.GetDescription()))
                .ForMember(dst => dst.FoodType, opt => opt.MapFrom(src => src.Species.FoodType.GetDescription()))
                .ForMember(dst => dst.Description, opt => opt.MapFrom(src => src.Species.Description));
        }
    }
}