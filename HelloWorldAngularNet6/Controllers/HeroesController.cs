using AutoMapper;
using HelloWorldAngularNet6.Classes;
using HelloWorldAngularNet6.Dtos;
using HelloWorldAngularNet6.Models;
using HelloWorldAngularNet6.Services;
using Microsoft.AspNetCore.Mvc;

namespace HelloWorldAngularNet6.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HeroesController : ControllerBase
    {
        // Fields
        IHeroesService _heroesService;
        IUniversesService _universesService;
        IMapper _mapper;

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="helloWorldContext"></param>
        /// <param name="heroesService"></param>
        public HeroesController(IMapper mapper, IHeroesService heroesService, IUniversesService universesService)
        {
            _mapper = mapper;
            _heroesService = heroesService;
            _universesService = universesService;
        }

        /// <summary>
        /// Gets all the heroes
        /// </summary>
        /// <returns>Returns all the heroes as a JSON array</returns>
        [HttpGet]
        [Route("")]
        public async Task<ActionResult<HeroReadDto[]>> GetAllAsync()
        {
            try
            {
                if (_heroesService.CanConnectToDb() == false)
                {
                    return StatusCode(500, "Unable to make a connection to the heroes database. Please check that the heroes database is running.");
                }

                List<Hero> allHeroes = await _heroesService.GetAllHeroesAsync();
                List<HeroReadDto> heroesReadDto = _mapper.Map<List<Hero>, List<HeroReadDto>>(allHeroes);

                return Ok(heroesReadDto);
            }
            catch (Exception ex)
            {
                // Ex message should be logged and never make it to prod
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Returns the hero based off the ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Returns the hero as a JSON</returns>
        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<HeroReadDto>> GetByIdAsync(int id)
        {
            try
            {
                if (_heroesService.CanConnectToDb() == false)
                {
                    return StatusCode(500, "Unable to make a connection to the heroes database. Please check that the heroes database is running.");
                }

                Task<Hero> getHeroById = _heroesService.GetHeroAsync(id);
                Hero foundHero = await getHeroById;
                if (foundHero == null)
                {
                    return BadRequest("The hero does not exist");
                }

                HeroReadDto heroDto = _mapper.Map<HeroReadDto>(foundHero);

                return Ok(heroDto);
            }
            catch (Exception ex)
            {
                // Ex message should be logged and never make it to prod
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Gets a list of heroes that contain the name parameter
        /// </summary>
        /// <param name="name"></param>
        /// <returns>
        /// List of hero objects
        /// Returns an empty list if none are found.                 
        /// </returns>
        [HttpGet]
        [Route("Search")]
        public async Task<ActionResult<HeroReadDto[]>> GetHeroesByName(string name)
        {
            try
            {
                Task<List<Hero>> getHeroesByName = _heroesService.GetHeroesByNameAsync(name);
                List<Hero> foundHeroes = await getHeroesByName;

                List<HeroReadDto> heroesDto = _mapper.Map<List<HeroReadDto>>(foundHeroes);

                return Ok(heroesDto);
            }
            catch(Exception ex)
            {
                // Ex message should be logged and never make it to prod
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Updates a hero
        /// </summary>
        /// <param name="heroCreateDto"></param>
        /// <returns>Returns the updated hero as a JSON</returns>
        [HttpPut]
        [Route("")]
        public async Task<ActionResult<Hero>> UpdateAsync(HeroCreateDto heroCreateDto)
        {
            try
            {
                if (_heroesService.CanConnectToDb() == false)
                {
                    return StatusCode(500, "Unable to make a connection to the heroes database. Please check that the heroes database is running.");
                }

                Task<Hero> findHero = _heroesService.GetHeroAsync(heroCreateDto.Id);
                Hero foundHero = await findHero;
                if (foundHero == null || foundHero.Id != heroCreateDto.Id)
                {
                    return BadRequest("Hero not found");
                }

                Task<Universe> findUniverse = _universesService.GetUniverseByNameAsync(heroCreateDto.Universe);
                Universe foundUniverse = await findUniverse;
                if (foundUniverse == null)
                {
                    return BadRequest("The chosen universe does not exist.");
                }

                Hero heroToUpdate = _mapper.Map<Hero>(heroCreateDto);
                heroToUpdate.UniverseId = foundUniverse.Id;

                Task<Hero> updateHero = _heroesService.UpdateHeroAsync(heroToUpdate);
                Hero updatedHero = await updateHero;

                Hero returnValue = new Hero();
                if (updatedHero != null)
                {
                    returnValue = updatedHero;
                }

                return Ok(returnValue);
            }
            catch (Exception ex)
            {
                // Ex message should be logged and never make it to prod
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Adds a hero to the database. The Hero's ID Must be 0
        /// </summary>
        /// <param name="heroCreateDto"></param>
        /// <returns>Returns the hero, with the new id, as a JSON</returns>
        [HttpPost]
        [Route("")]
        public async Task<ActionResult<HeroReadDto>> AddAsync(HeroCreateDto heroCreateDto)
        {
            try
            {
                if (_heroesService.CanConnectToDb() == false)
                {
                    return StatusCode(500, "Unable to make a connection to the heroes database. Please check that the heroes database is running.");
                }

                if (heroCreateDto == null)
                {
                    return BadRequest("Hero is null");
                }

                if (heroCreateDto.Id != null && heroCreateDto.Id != 0)
                {
                    return BadRequest("Hero id must be 0, not filled in, or null");
                }

                Task<Universe> findUniverse = _universesService.GetUniverseByNameAsync(heroCreateDto.Universe);
                Universe foundUniverse = await findUniverse;
                if (foundUniverse == null)
                {
                    return BadRequest("The chosen universe does not exist.");
                }

                Hero hero = _mapper.Map<Hero>(heroCreateDto);
                hero.UniverseId = foundUniverse.Id;

                Task<Hero> addHero = _heroesService.AddHeroAsync(hero);
                Hero addedHero = await addHero;

                // Checking to make sure the Id was updated after the hero was added to the db
                HeroReadDto returnValue = new HeroReadDto();
                if (addedHero.Id != 0)
                {
                    returnValue = _mapper.Map<HeroReadDto>(addedHero);

                    return Ok(returnValue);
                }
                else
                {
                    return StatusCode(500, returnValue);
                }
            }
            catch (Exception ex)
            {
                // Ex message should be logged and never make it to prod
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Deletes a hero based off an ID number
        /// </summary>
        /// <param name="id"></param>
        /// <returns>
        ///     Returns a 200 with a null JSON the hero was deleted successfully.
        ///     Returns a 500 with a message stating the hero was not deleted
        /// </returns>
        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult<Hero>> Delete(int id)
        {
            try
            {
                if (_heroesService.CanConnectToDb() == false)
                {
                    return StatusCode(500, "Unable to make a connection to the heroes database. Please check that the heroes database is running.");
                }

                Task<Hero> findHero = _heroesService.GetHeroAsync(id);
                Hero foundHero = await findHero;
                if (foundHero == null && foundHero.Id != id)
                {
                    return BadRequest("Hero not found");
                }

                Task deleteHero = _heroesService.DeleteHeroAsync(foundHero);
                await deleteHero;

                // Confirming the hero was deleted
                Task<Hero> confirmHeroWasDeleted = _heroesService.GetHeroAsync(foundHero.Id);
                Hero heroNotFound = await confirmHeroWasDeleted;
                if (heroNotFound == null)
                {
                    return Ok(heroNotFound);
                }
                else
                {
                    return StatusCode(500, "Hero was not deleted successfully");
                }                
            }
            catch (Exception ex)
            {
                // Ex message should be logged and never make it to prod
                return StatusCode(500, ex.Message);
            }
        }
    }
}
