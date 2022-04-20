using HelloWorldAngularNet6.Classes;
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
        HelloWorldContext _db;
        IHeroesService _heroesService;

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="helloWorldContext"></param>
        /// <param name="heroesService"></param>
        public HeroesController(HelloWorldContext helloWorldContext, IHeroesService heroesService)
        {
            _db = helloWorldContext;
            _heroesService = heroesService;
        }

        /// <summary>
        /// Gets all the heroes
        /// </summary>
        /// <returns>Returns all the heroes as a JSON array</returns>
        [HttpGet]
        [Route("")]
        public ActionResult<Hero[]> GetAll()
        {
            if (_heroesService.CanConnectToDb() == false)
            {
                return StatusCode(500, "Unable to make a connection to the heroes database. Please check that the heroes database is running.");
            }

            List<Hero> allHeroes = _heroesService.GetAllHeroes();

            return Ok(allHeroes);
        }

        /// <summary>
        /// Returns the hero based off the ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Returns the hero as a JSON</returns>
        [HttpGet]
        [Route("{id}")]
        public ActionResult<Hero> GetById(int id)
        {
            if (_heroesService.CanConnectToDb() == false)
            {
                return StatusCode(500, "Unable to make a connection to the heroes database. Please check that the heroes database is running.");
            }

            Hero foundHero = _heroesService.GetHero(id);
            if (foundHero != null)
            {
                return StatusCode(500, foundHero);
            }

            return Ok(foundHero);
        }

        /// <summary>
        /// Updates a hero
        /// </summary>
        /// <param name="hero"></param>
        /// <returns>Returns the updated hero as a JSON</returns>
        [HttpPut]
        [Route("")]
        public ActionResult<Hero> Update(Hero hero)
        {
            if (_heroesService.CanConnectToDb() == false)
            {
                return StatusCode(500, "Unable to make a connection to the heroes database. Please check that the heroes database is running.");
            }

            Hero addedHero = _heroesService.UpdateHero(hero);
            Hero returnValue = new Hero();
            if (addedHero != null)
            {
                returnValue = addedHero;
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
        public ActionResult<Hero> Add(Hero hero)
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

            Hero addedHero = _heroesService.AddHero(hero);

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
        public ActionResult<Hero> Delete(int id)
        {
            if (_heroesService.CanConnectToDb() == false)
            {
                return StatusCode(500, "Unable to make a connection to the heroes database. Please check that the heroes database is running.");
            }

            Hero foundHero = _db.Heroes.Where<Hero>(x => x.Id == id).FirstOrDefault();
            if (foundHero != null && foundHero.Id == id)
            {
                Hero heroToDelete = foundHero;
                _heroesService.DeleteHero(heroToDelete);

                Hero heroNotFound = _heroesService.GetHero(heroToDelete.Id);
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
