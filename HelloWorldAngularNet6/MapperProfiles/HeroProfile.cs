using AutoMapper;
using HelloWorldAngularNet6.Dtos;
using HelloWorldAngularNet6.Models;

namespace HelloWorldAngularNet6.MapperProfiles
{
    public class HeroProfile : Profile
    {
        public HeroProfile()
        {
            // Source -> Target
            CreateMap<Hero, HeroReadDto>()
                .ForMember(d => d.Universe, opt => opt.Ignore());
            CreateMap<Universe, HeroReadDto>()
                .ForMember(h => h.Universe, u => u.MapFrom(n => n.Name))
                .ForMember(h => h.Name, opt => opt.Ignore())
                .ForMember(h => h.Id, opt => opt.Ignore());
            CreateMap<HeroReadDto, Hero>();
        }
    }
}
