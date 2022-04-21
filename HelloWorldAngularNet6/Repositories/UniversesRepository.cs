using HelloWorldAngularNet6.Classes;
using HelloWorldAngularNet6.Models;
using Microsoft.EntityFrameworkCore;

namespace HelloWorldAngularNet6.Repositories
{
    public class UniversesRepository : IUniversesRepository
    {
        // Fields
        HelloWorldContext _db;

        public UniversesRepository(HelloWorldContext db)
        {
            _db = db;
        }

        /// <summary>
        /// Gets a list of all the universes
        /// </summary>
        /// <returns>Returns a task with the list of universes aas the return object</returns>
        public async Task<List<Universe>> GetAllAsync()
        {
            List<Universe> universes = await _db.Universes.ToListAsync();

            return universes;
        }

        /// <summary>
        /// Gets a universe based off the ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Returns a task with the universe as the return object or null if not found</returns>
        public async Task<Universe> GetByIdAsync(int id)
        {
            Universe? universe = await _db.Universes.FirstOrDefaultAsync(x => x.Id == id);

            return universe;
        }
    }
}
