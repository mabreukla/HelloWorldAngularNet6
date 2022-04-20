using HelloWorldAngularNet6.Models;

namespace HelloWorldAngularNet6.Services
{
    public interface IHeroesService
    {
        public List<Hero> GetAllHeroes();

        public Hero GetHero(int id);

        public Hero AddHero(Hero hero);

        public Hero UpdateHero(Hero hero);

        public void DeleteHero(Hero hero);
    }
}