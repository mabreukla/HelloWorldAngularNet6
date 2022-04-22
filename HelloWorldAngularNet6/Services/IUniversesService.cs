using HelloWorldAngularNet6.Models;

namespace HelloWorldAngularNet6.Services
{
    public interface IUniversesService
    {
        /// <summary>
        /// Get all universes
        /// </summary>
        /// <returns>Returns a task with a list of universes return object</returns>
        public Task<List<Universe>> GetAllUniversesAsync();

        /// <summary>
        /// Get universe by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Returns a task with a universe return object. Returns null if object not found.</returns>
        public Task<Universe> GetUniverseByIdAsync(int id);

        /// <summary>
        /// Returns a Universe by name
        /// </summary>
        /// <param name="name"></param>
        /// <returns>Returns a task with a universe return object. Return null if the object is not found.</returns>
        public Task<Universe> GetUniverseByNameAsync(string name);
    }
}
