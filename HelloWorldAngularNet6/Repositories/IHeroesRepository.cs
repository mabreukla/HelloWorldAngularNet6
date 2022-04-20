using HelloWorldAngularNet6.Models;

namespace HelloWorldAngularNet6.Repositories
{
    public interface IHeroesRepository
    {
        /// <summary>
        /// Gets all the heroes
        /// </summary>
        /// <returns>List of hero objects</returns>
        public List<Hero> GetAll();

        /// <summary>
        /// Gets a hero based off the hero's id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Hero object</returns>
        public Hero GetById(int id);

        /// <summary>
        /// Adds a hero to the db
        /// </summary>
        /// <param name="hero"></param>
        /// <returns>The added hero with the updated id number</returns>
        public Hero Add(Hero hero);

        /// <summary>
        /// Updates a hero's data
        /// </summary>
        /// <param name="hero"></param>
        /// <returns>The updated hero object</returns>
        public Hero Update(Hero hero);

        /// <summary>
        /// Deletes a hero
        /// </summary>
        /// <param name="hero"></param>
        public void Delete(Hero hero);

        /// <summary>
        /// Checks to see if we can connect to the DB
        /// </summary>
        /// <returns>true if can connect to the db, false otherwise</returns>
        public bool CanConnect();
    }
}
