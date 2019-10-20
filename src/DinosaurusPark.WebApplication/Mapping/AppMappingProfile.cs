using AutoMapper;
using DinosaurusPark.Contracts.Models;
using DinosaurusPark.WebApplication.Responses;

namespace DinosaurusPark.WebApplication.Mapping
{
    public class AppMappingProfile : Profile
    {
        public AppMappingProfile()
        {
            CreateMap<Bogus.DataSets.Name.Gender, Gender>();

            CreateMap<Dinosaur, DinosaurResponse>()
                .ForMember(dst => dst.Species, opt => opt.MapFrom(src => src.Species.Name));
        }
    }
}