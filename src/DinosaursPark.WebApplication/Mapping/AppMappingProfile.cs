using AutoMapper;
using DinosaursPark.Contracts.Models;
using DinosaursPark.Extensions;
using DinosaursPark.WebApplication.Responses;

namespace DinosaursPark.WebApplication.Mapping
{
    public class AppMappingProfile : Profile
    {
        public AppMappingProfile()
        {
            CreateMap<Bogus.DataSets.Name.Gender, Gender>();

            CreateMap<Dinosaur, SimpleDinosaurResponse>()
                .ForMember(dst => dst.Species, opt => opt.MapFrom(src => src.Species.Name));

            CreateMap<Dinosaur, DinosaurResponse>()
                .IncludeBase<Dinosaur, SimpleDinosaurResponse>()
                .ForMember(dst => dst.Gender, opt => opt.MapFrom(src => src.Gender.GetDescription()))
                .ForMember(dst => dst.FoodType, opt => opt.MapFrom(src => src.Species.FoodType.GetDescription()))
                .ForMember(dst => dst.Description, opt => opt.MapFrom(src => src.Species.Description));

            CreateMap<ParkInformation, ParkInformationResponse>()
                .ForMember(d => d.SpeciesCount, opt => opt.Ignore())
                .ForMember(d => d.DinosaursCount, opt => opt.Ignore());

            CreateMap<(ParkInformation parkInfo, CountInformation countInfo), ParkInformationResponse>()
                .ConvertUsing((source, _, context) =>
                {
                    var result = context.Mapper.Map<ParkInformationResponse>(source.parkInfo);
                    result.SpeciesCount = source.countInfo.SpeciesCount;
                    result.DinosaursCount = source.countInfo.DinosaurssCount;
                    return result;
                });
        }
    }
}