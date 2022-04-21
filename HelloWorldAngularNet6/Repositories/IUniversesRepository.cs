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
        /// <returns></returns>
        public Task<Universe> GetByIdAsync(int id);
    }
}
