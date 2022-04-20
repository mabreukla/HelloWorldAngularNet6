using HelloWorldAngularNet6.Models;
using HelloWorldAngularNet6.Repositories;

namespace HelloWorldAngularNet6.Services
{
    public class HeroesService : IHeroesService
    {
        // Fields
        private IHeroesRepository _heroesRepository;

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="heroesRepository"></param>
        public HeroesService(IHeroesRepository heroesRepository)
        {
            _heroesRepository = heroesRepository;
        }

        /// <summary>
        /// Adds a hero to the repo
        /// </summary>
        /// <param name="hero"></param>
        /// <returns>Returns the added hero</returns>
        public Hero AddHero(Hero hero)
        {
            Hero heroToBeAdded = hero;
            Hero AddedHero = _heroesRepository.Add(heroToBeAdded);

            return AddedHero;
        }

        /// <summary>
        /// Deletes a hero from the repo
        /// </summary>
        /// <param name="hero"></param>
        public void DeleteHero(Hero hero)
        {
            Hero heroToBeDeleted = hero;
            _heroesRepository.Delete(heroToBeDeleted);
        }

        /// <summary>
        /// Gets a hero by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Returns a found hero. If the hero was not found then the returned object from the repo will be null</returns>
        public Hero GetHero(int id)
        {
            Hero foundHero = _heroesRepository.GetById(id);

            return foundHero;
        }

        /// <summary>
        /// Gets all the heroes
        /// </summary>
        /// <returns>Returns aa list of all the heroes as a Hero</returns>
        public List<Hero> GetAllHeroes()
        {
            List<Hero> heroes = _heroesRepository.GetAll();

            return heroes;
        }

        /// <summary>
        /// Updates a hero's data
        /// </summary>
        /// <param name="hero"></param>
        /// <returns>Returns the updated hero</returns>
        public Hero UpdateHero(Hero hero)
        {
            Hero heroToUpdate = hero;
            Hero updatedHero = _heroesRepository.Update(heroToUpdate);

            return updatedHero;
        }

        /// <summary>
        /// Checks to see if the repo is usable
        /// </summary>
        /// <returns>Returns true if the repo is usable, false otherwise</returns>
        public bool CanConnectToDb()
        {
            bool canConnectToServer = _heroesRepository.CanConnect();

            return canConnectToServer;
        }
    }
}
