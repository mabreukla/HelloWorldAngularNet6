using HelloWorldAngularNet6.Classes;
using HelloWorldAngularNet6.Models;
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
            List<Hero> returnValue = new List<Hero>();

            // Manual
            //returnValue = _db.Set<Hero>().ToList<Hero>();

            // Auto
            returnValue = _db.Heroes.ToList<Hero>();

            return Ok(returnValue);
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<Hero> GetById(int id)
        {
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
    }
}
