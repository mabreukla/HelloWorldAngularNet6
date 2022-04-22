using HelloWorldAngularNet6.Models;
using HelloWorldAngularNet6.Repositories;

namespace HelloWorldAngularNet6.Services
{
    public class UniversesService : IUniversesService
    {
        // Fields
        private IUniversesRepository _universesRepository;

        public UniversesService(IUniversesRepository universesRepository)
        {
            _universesRepository = universesRepository;
        }

        /// <summary>
        /// Get all the universes
        /// </summary>
        /// <returns>Task with a return object of a list of universes</returns>
        public async Task<List<Universe>> GetAllUniversesAsync()
        {
            Task<List<Universe>> getUniverses = _universesRepository.GetAllAsync();
            List<Universe> universes = await getUniverses;

            return universes;
        }

        /// <summary>
        /// Gets a universe by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Task with a universe return object</returns>
        public async Task<Universe> GetUniverseByIdAsync(int id)
        {
            Task<Universe> getUniverse = _universesRepository.GetByIdAsync(id);
            Universe universe = await getUniverse;

            return universe;
        }

        /// <summary>
        /// Returns a Universe by name
        /// </summary>
        /// <param name="name"></param>
        /// <returns>Returns a task with a universe return object. Return null if the object is not found.</returns>
        public async Task<Universe> GetUniverseByNameAsync(string name)
        {
            Task<Universe> getUniverse = _universesRepository.GetByNameAsync(name);
            Universe universe = await getUniverse;

            return universe;
        }
    }
}
