using HelloWorldAngularNet6.Models;

namespace HelloWorldAngularNet6.Services
{
    public interface IHeroesService
    {
        /// <summary>
        /// Gets all the heroes
        /// </summary>
        /// <returns>Returns aa list of all the heroes as a Hero</returns>
        public List<Hero> GetAllHeroes();

        /// <summary>
        /// Gets a hero by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Returns a found hero. If the hero was not found then the returned object from the repo will be null</returns>
        public Hero GetHero(int id);

        /// <summary>
        /// Adds a hero to the repo
        /// </summary>
        /// <param name="hero"></param>
        /// <returns>Returns the added hero</returns>
        public Hero AddHero(Hero hero);

        /// <summary>
        /// Updates a hero's data
        /// </summary>
        /// <param name="hero"></param>
        /// <returns>Returns the updated hero</returns>
        public Hero UpdateHero(Hero hero);

        /// <summary>
        /// Deletes a hero from the repo
        /// </summary>
        /// <param name="hero"></param>
        public void DeleteHero(Hero hero);

        /// <summary>
        /// Checks to see if the repo is usable
        /// </summary>
        /// <returns>Returns true if the repo is usable, false otherwise</returns>
        public bool CanConnectToDb();
    }
}