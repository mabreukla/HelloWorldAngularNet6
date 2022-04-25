using HelloWorldAngularNet6.Models;

namespace HelloWorldAngularNet6.Services
{
    public interface IHeroesService
    {
        /// <summary>
        /// Gets all the heroes
        /// </summary>
        /// <returns>Returns aa list of all the heroes as a Hero</returns>
        public Task<List<Hero>> GetAllHeroesAsync();

        /// <summary>
        /// Gets a hero by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Returns a found hero. If the hero was not found then the returned object from the repo will be null</returns>
        public Task<Hero> GetHeroAsync(int id);

        /// <summary>
        /// Adds a hero to the repo
        /// </summary>
        /// <param name="hero"></param>
        /// <returns>Returns the added hero</returns>
        public Task<Hero> AddHeroAsync(Hero hero);

        /// <summary>
        /// Updates a hero's data
        /// </summary>
        /// <param name="hero"></param>
        /// <returns>Returns the updated hero</returns>
        public Task<Hero> UpdateHeroAsync(Hero hero);

        /// <summary>
        /// Deletes a hero from the repo
        /// </summary>
        /// <param name="hero"></param>
        public Task DeleteHeroAsync(Hero hero);

        /// <summary>
        /// Checks to see if the repo is usable
        /// </summary>
        /// <returns>Returns true if the repo is usable, false otherwise</returns>
        public bool CanConnectToDb();

        /// <summary>
        /// Get's a colection of heroes by name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public Task<List<Hero>> GetHeroesByNameAsync(string name);
    }
}