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
        IMapper _mapper;

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="helloWorldContext"></param>
        /// <param name="heroesService"></param>
        public HeroesController(HelloWorldContext helloWorldContext, IHeroesService heroesService, IMapper mapper)
        {
            _heroesService = heroesService;
            _mapper = mapper;
        }

        /// <summary>
        /// Gets all the heroes
        /// </summary>
        /// <returns>Returns all the heroes as a JSON array</returns>
        [HttpGet]
        [Route("")]
        public async Task<ActionResult<HeroReadDto[]>> GetAllAsync()
        {
            if (_heroesService.CanConnectToDb() == false)
            {
                return StatusCode(500, "Unable to make a connection to the heroes database. Please check that the heroes database is running.");
            }

            List<Hero> allHeroes = await _heroesService.GetAllHeroesAsync();
            List<HeroReadDto> heroesDto = _mapper.Map<List<HeroReadDto>>(allHeroes);

            return Ok(heroesDto);
        }

        /// <summary>
        /// Returns the hero based off the ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Returns the hero as a JSON</returns>
        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<Hero>> GetByIdAsync(int id)
        {
            if (_heroesService.CanConnectToDb() == false)
            {
                return StatusCode(500, "Unable to make a connection to the heroes database. Please check that the heroes database is running.");
            }

            Task<Hero> getHeroById = _heroesService.GetHeroAsync(id);
            Hero foundHero = await getHeroById;

            if (foundHero == null)
            {
                return StatusCode(500);
            }

            HeroReadDto heroDto = _mapper.Map<HeroReadDto>(foundHero);

            return Ok(heroDto);
        }

        /// <summary>
        /// Updates a hero
        /// </summary>
        /// <param name="hero"></param>
        /// <returns>Returns the updated hero as a JSON</returns>
        [HttpPut]
        [Route("")]
        public async Task<ActionResult<Hero>> UpdateAsync(Hero hero)
        {
            if (_heroesService.CanConnectToDb() == false)
            {
                return StatusCode(500, "Unable to make a connection to the heroes database. Please check that the heroes database is running.");
            }

            Task<Hero> findHero = _heroesService.GetHeroAsync(hero.Id);
            Hero foundHero = await findHero;
            if (foundHero == null || foundHero.Id != hero.Id)
            {
                return BadRequest("Hero not found");
            }

            Task<Hero> updateHero = _heroesService.UpdateHeroAsync(hero);
            Hero updatedHero = await updateHero;

            Hero returnValue = new Hero();
            if (updatedHero != null)
            {
                returnValue = updatedHero;
            }

            return Ok(returnValue);
        }

        /// <summary>
        /// Adds a hero to the database. The Hero's ID Must be 0
        /// </summary>
        /// <param name="hero"></param>
        /// <returns>Returns the hero, with the new id, as a JSON</returns>
        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Hero>> AddAsync(Hero hero)
        {
            if (_heroesService.CanConnectToDb() == false)
            {
                return StatusCode(500, "Unable to make a connection to the heroes database. Please check that the heroes database is running.");
            }

            if (hero == null)
            {
                return BadRequest("Hero is null");
            }

            if (hero.Id != null && hero.Id != 0)
            {
                return BadRequest("Hero id must be 0, not filled in, or null");
            }

            Task<Hero> addHero = _heroesService.AddHeroAsync(hero);
            Hero addedHero = await addHero;

            // Checking to make sure the Id was updated after the hero was added to the db
            Hero returnValue = new Hero();
            if (addedHero.Id != 0)
            {
                returnValue = addedHero;

                return Ok(returnValue);
            }
            else
            {
                return StatusCode(500, returnValue);
            }
        }

        /// <summary>
        /// Deletes a hero based off an ID number
        /// </summary>
        /// <param name="id"></param>
        /// <returns>
        ///     Returns a 200 with a null JSON the hero was deleted successfully.
        ///     Returns a 500 with the existing hero if the hero was not deleted
        /// </returns>
        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult<Hero>> Delete(int id)
        {
            if (_heroesService.CanConnectToDb() == false)
            {
                return StatusCode(500, "Unable to make a connection to the heroes database. Please check that the heroes database is running.");
            }

            Task<Hero> findHero = _heroesService.GetHeroAsync(id);
            Hero foundHero = await findHero;
            if (foundHero != null && foundHero.Id == id)
            {
                Task deleteHero = _heroesService.DeleteHeroAsync(foundHero);
                await deleteHero;

                Task<Hero> confirmHeroWasDeleted = _heroesService.GetHeroAsync(foundHero.Id);
                Hero heroNotFound = await confirmHeroWasDeleted;
                if(heroNotFound == null)
                {
                    return Ok(heroNotFound);
                }
                else
                {
                    return StatusCode(500, heroNotFound);
                }    
            }
            else
            {
                return BadRequest("Hero not found");
            }
        }
    }
}
