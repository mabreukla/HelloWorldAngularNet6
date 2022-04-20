using HelloWorldAngularNet6.Models;
using HelloWorldAngularNet6.Repositories;

namespace HelloWorldAngularNet6.Services
{
    public class HeroesService : IHeroesService
    {
        // Fields
        private IHeroesRepository _heroesRepository;

        public HeroesService(IHeroesRepository heroesRepository)
        {
            _heroesRepository = heroesRepository;
        }

        public Hero AddHero(Hero hero)
        {
            Hero heroToBeAdded = hero;
            Hero AddedHero = _heroesRepository.Add(heroToBeAdded);

            return AddedHero;
        }

        public void DeleteHero(Hero hero)
        {
            Hero heroToBeDeleted = hero;
            _heroesRepository.Delete(heroToBeDeleted);
        }

        public Hero GetHero(int id)
        {
            Hero hero = null;
            hero = _heroesRepository.GetById(id);

            return hero;
        }

        public List<Hero> GetAllHeroes()
        {
            List<Hero> heroes = new List<Hero>();
            heroes = _heroesRepository.GetAll();

            return heroes;
        }

        public Hero UpdateHero(Hero hero)
        {
            Hero heroToUpdate = hero;
            Hero updatedHero = _heroesRepository.Update(heroToUpdate);

            return updatedHero;
        }
    }
}
