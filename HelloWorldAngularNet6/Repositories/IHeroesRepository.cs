using HelloWorldAngularNet6.Models;

namespace HelloWorldAngularNet6.Repositories
{
    public interface IHeroesRepository
    {
        /// <summary>
        /// Gets all the heroes
        /// </summary>
        /// <returns>List of hero objects</returns>
        public Task<List<Hero>> GetAllAsync();

        /// <summary>
        /// Gets a hero based off the hero's id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Hero object</returns>
        public Task<Hero> GetByIdAsync(int id);

        /// <summary>
        /// Adds a hero to the db
        /// </summary>
        /// <param name="hero"></param>
        /// <returns>The added hero with the updated id number</returns>
        public Task<Hero> AddAsync(Hero hero);

        /// <summary>
        /// Updates a hero's data
        /// </summary>
        /// <param name="hero"></param>
        /// <returns>The updated hero object</returns>
        public Task<Hero> UpdateAsync(Hero hero);

        /// <summary>
        /// Deletes a hero
        /// </summary>
        /// <param name="hero"></param>
        public Task DeleteAsync(Hero hero);

        /// <summary>
        /// Checks to see if we can connect to the DB
        /// </summary>
        /// <returns>true if can connect to the db, false otherwise</returns>
        public bool CanConnect();

        /// <summary>
        /// Gets a list of heroes whose name contains the name parameter
        /// </summary>
        /// <param name="name"></param>
        /// <returns>A collection of heroes</returns>
        public Task<List<Hero>> GetHeroesByNameAsync(string name);
    }
}
