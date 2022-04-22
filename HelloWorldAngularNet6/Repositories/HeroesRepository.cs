using HelloWorldAngularNet6.Classes;
using HelloWorldAngularNet6.Models;
using Microsoft.EntityFrameworkCore;

namespace HelloWorldAngularNet6.Repositories
{
    public class HeroesRepository : IHeroesRepository
    {
        // Fields
         HelloWorldContext _db;

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="db"></param>
        public HeroesRepository(HelloWorldContext db)
        {
            _db = db;
        }

        /// <summary>
        /// Adds a hero to the db
        /// </summary>
        /// <param name="hero"></param>
        /// <returns>The added hero with the updated id number</returns>
        public async Task<Hero> AddAsync(Hero hero)
        {
            Hero heroToAdd = hero;
            await _db.Heroes.AddAsync(heroToAdd);
            await _db.SaveChangesAsync();

            return heroToAdd;
        }

        /// <summary>
        /// Checks to see if we can connect to the DB
        /// </summary>
        /// <returns>true if can connect to the db, false otherwise</returns>
        public bool CanConnect()
        {
            bool canConnect = _db.Database.CanConnect();

            return canConnect;
        }

        /// <summary>
        /// Deletes a hero
        /// </summary>
        /// <param name="hero"></param>
        public async Task DeleteAsync(Hero hero)
        {
            _db.Remove(hero);
            await _db.SaveChangesAsync();
        }

        /// <summary>
        /// Gets all the heroes
        /// </summary>
        /// <returns>List of hero objects</returns>
        public async Task<List<Hero>> GetAllAsync()
        {
            List<Hero> heroes = await _db.Heroes
                .Include(h => h.Universe)
                .ToListAsync();

            return heroes;
        }

        /// <summary>
        /// Gets a hero based off the hero's id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Hero object, returns null the hero was not found</returns>
        public async Task<Hero> GetByIdAsync(int id)
        {
            Hero? hero = await _db.Heroes
                .Include(h => h.Universe)
                .FirstOrDefaultAsync(h => h.Id == id);

            return hero;
        }

        /// <summary>
        /// Updates a hero's data
        /// </summary>
        /// <param name="hero"></param>
        /// <returns>The updated hero object</returns>
        public async Task<Hero> UpdateAsync(Hero hero)
        {
            _db.Heroes.Update(hero);
            await _db.SaveChangesAsync();

            return hero;
        }
    }
}
