using AutoMapper;
using HelloWorldAngularNet6.Dtos;
using HelloWorldAngularNet6.Models;

namespace HelloWorldAngularNet6.MapperProfiles
{
    /// <summary>
    /// Hero profile that defines the mappings for hero related classes
    /// </summary>
    public class HeroProfile : Profile
    {
        public HeroProfile()
        {
            // Source -> Target
            CreateMap<Hero, HeroReadDto>()
                .ForMember(d => d.Universe, h => h.MapFrom(o => o.Universe.Name));
            // Can be refactored out to it's own profile
            CreateMap<Universe, HeroReadDto>()
                .ForMember(d => d.Universe, u => u.MapFrom(n => n.Name))
                .ForMember(d => d.Name, opt => opt.Ignore())
                .ForMember(d => d.Id, opt => opt.Ignore());
            // Can be refactored out to it's own profile
            CreateMap<HeroCreateDto, Hero>()
                .ForMember(h => h.Universe, opt => opt.Ignore());
        }
    }
}
