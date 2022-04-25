using HelloWorldAngularNet6.Models;
using HelloWorldAngularNet6.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HelloWorldAngularNet6.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UniversesController : ControllerBase
    {
        // Fields
        IUniversesService _universesService;

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="universesService"></param>
        public UniversesController(IUniversesService universesService)
        {
            _universesService = universesService;
        }

        /// <summary>
        /// Get's all available universes
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Universe>>> GetAllAsync()
        {
            Task<List<Universe>> getAllUniverses = _universesService.GetAllUniversesAsync();
            List<Universe> universes = await getAllUniverses;

            return Ok(universes);
        }

        /// <summary>
        /// Get's a universe by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<Universe>> GetByIdAsync(int id)
        {
            Task<Universe> getUniverseById = _universesService.GetUniverseByIdAsync(id);
            Universe universe = await getUniverseById;

            return Ok(universe);
        }
    }
}
