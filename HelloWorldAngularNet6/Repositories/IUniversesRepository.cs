using HelloWorldAngularNet6.Models;

namespace HelloWorldAngularNet6.Repositories
{
    public interface IUniversesRepository
    {
        /// <summary>
        /// Get all universes as a list
        /// </summary>
        /// <returns>Task of a list of universes</returns>
        public Task<List<Universe>> GetAllAsync();

        /// <summary>
        /// Gets a universe by Id
        /// </summary>
        /// <returns>Returns a task with the universe return object. Null if the universe is not found</returns>
        public Task<Universe> GetByIdAsync(int id);

        /// <summary>
        /// Gets a universe by Name
        /// </summary>
        /// <param name="name"></param>
        /// <returns>Returns a task with the universe as a return object. Null if universe not found</returns>
        public Task<Universe> GetByNameAsync(string name);
    }
}
