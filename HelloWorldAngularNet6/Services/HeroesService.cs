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
        public async Task<Hero> AddHeroAsync(Hero hero)
        {
            Task<Hero> addHero = _heroesRepository.AddAsync(hero);
            Hero AddedHero = await addHero;

            return AddedHero;
        }

        /// <summary>
        /// Deletes a hero from the repo
        /// The hero must exist
        /// </summary>
        /// <param name="hero"></param>
        public async Task DeleteHeroAsync(Hero hero)
        {
            Task deleteHero = _heroesRepository.DeleteAsync(hero);

            await deleteHero;
        }

        /// <summary>
        /// Gets a hero by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Returns a found hero. If the hero was not found then the returned object from the repo will be null</returns>
        public async Task<Hero> GetHeroAsync(int id)
        {
            Task<Hero> getHeroById = _heroesRepository.GetByIdAsync(id);
            Hero foundHero = await getHeroById;

            return foundHero;
        }

        /// <summary>
        /// Gets all the heroes
        /// </summary>
        /// <returns>Returns aa list of all the heroes as a Hero</returns>
        public async Task<List<Hero>> GetAllHeroesAsync()
        {
            List<Hero> allHeroes = await _heroesRepository.GetAllAsync();

            return allHeroes;
        }

        /// <summary>
        /// Updates a hero's data
        /// </summary>
        /// <param name="hero"></param>
        /// <returns>Returns the updated hero</returns>
        public async Task<Hero> UpdateHeroAsync(Hero hero)
        {
            Task<Hero> updateHero = _heroesRepository.UpdateAsync(hero);
            Hero updatedHero = await updateHero;

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
