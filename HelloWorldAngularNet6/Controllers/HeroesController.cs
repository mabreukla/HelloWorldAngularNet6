using HelloWorldAngularNet6.Classes;
using HelloWorldAngularNet6.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HelloWorldAngularNet6.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HeroesController : ControllerBase
    {
        HelloWorldContext _db;

        public HeroesController(HelloWorldContext helloWorldContext)
        {
            _db = helloWorldContext;
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
            returnValue = _db.Heroes.ToList<Hero>();

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

            Hero returnValue = new Hero();

            Hero foundHero = _db.Heroes.Where(x => x.Id == id).FirstOrDefault();
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

            _db.Heroes.Update(hero);
            _db.SaveChanges();

            Hero returnValue = new Hero();
            Hero addedHero = _db.Heroes.Where<Hero>(x => x.Id == hero.Id).FirstOrDefault();
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

            _db.Heroes.Add(hero);
            _db.SaveChanges();

            Hero returnValue = new Hero();
            Hero addedHero = _db.Heroes.Where<Hero>(x => x.Id == hero.Id).FirstOrDefault();
            if (addedHero != null)
            {
                returnValue = addedHero;
            }
            else
            {
                BadRequest("Hero was not added successfully");
            }

            return Ok(returnValue);
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
                Hero deletedHero = new Hero();
                deletedHero = foundHero;
                _db.Remove(foundHero);
                _db.SaveChanges();

                return Ok(deletedHero);
            }
            else
            {
                return BadRequest("Hero not found");
            }
        }
    }
}
