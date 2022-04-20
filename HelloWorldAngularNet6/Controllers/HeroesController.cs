using HelloWorldAngularNet6.Classes;
using HelloWorldAngularNet6.Models;
using HelloWorldAngularNet6.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
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

        public HeroesController(HelloWorldContext helloWorldContext, IHeroesService heroesService)
        {
            _db = helloWorldContext;
            _heroesService = heroesService;
        }


        [HttpGet]
        [Route("")]
        public ActionResult<Hero[]> GetAll()
        {
            if (_db.Database.CanConnect() == false)
            {
                return StatusCode(500, "Unable to make a connection to the heroes database. Please check that the heroes database is running.");
            }

            List<Hero> returnValue = new List<Hero>();
            returnValue = _heroesService.GetAllHeroes();

            return Ok(returnValue);
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<Hero> GetById(int id)
        {
            if (_db.Database.CanConnect() == false)
            {
                return StatusCode(500, "Unable to make a connection to the heroes database. Please check that the heroes database is running.");
            }

            Hero foundHero = _heroesService.GetHero(id);
            Hero returnValue = new Hero();
            if (foundHero != null)
            {
                returnValue = foundHero;
            }

            return Ok(returnValue);
        }

        [HttpPut]
        [Route("")]
        public ActionResult<Hero> Update(Hero hero)
        {
            if (_db.Database.CanConnect() == false)
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

        [HttpPost]
        [Route("")]
        public ActionResult<Hero> Add(Hero hero)
        {
            if (_db.Database.CanConnect() == false)
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

        [HttpDelete]
        [Route("{id}")]
        public ActionResult<Hero> Delete(int id)
        {
            if (_db.Database.CanConnect() == false)
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
