using HelloWorldAngularNet6.Models;

namespace HelloWorldAngularNet6.Services
{
    public interface IUniversesService
    {
        public Task<List<Universe>> GetAllUniversesAsync();

        public Task<Universe> GetUniverseByIdAsync(int id);
    }
}
