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
            CreateMap<Hero, HeroReadDto>();
            CreateMap<HeroReadDto, Hero>();
        }
    }
}
