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
                .ForMember(d => d.Universe, h => h.MapFrom(o => o.Universe.Name));
            CreateMap<Universe, HeroReadDto>()
                .ForMember(d => d.Universe, u => u.MapFrom(n => n.Name))
                .ForMember(d => d.Name, opt => opt.Ignore())
                .ForMember(d => d.Id, opt => opt.Ignore());
            CreateMap<HeroCreateDto, Hero>()
                .ForMember(h => h.Universe, opt => opt.Ignore());
        }
    }
}
