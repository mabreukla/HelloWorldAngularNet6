using HelloWorldAngularNet6.Classes;
using HelloWorldAngularNet6.Models;
using Microsoft.EntityFrameworkCore;

namespace HelloWorldAngularNet6.Repositories
{
    public class HeroesRepository : IHeroesRepository
    {
        // Fields
         HelloWorldContext _db;

        public HeroesRepository(HelloWorldContext db)
        {
            _db = db;
        }

        public Hero Add(Hero hero)
        {
            Hero heroToAdd = hero;
            _db.Heroes.Add(heroToAdd);
            _db.SaveChanges();

            return heroToAdd;
        }

        public void Delete(Hero hero)
        {
            _db.Remove(hero);
            _db.SaveChanges();
        }

        public List<Hero> GetAll()
        {
            List<Hero> heroes = _db.Heroes.ToList<Hero>();

            return heroes;
        }

        public Hero GetById(int id)
        {
            Hero hero = _db.Heroes.FirstOrDefault(h => h.Id == id);

            return hero;
        }

        public Hero Update(Hero hero)
        {
            _db.Heroes.Update(hero);
            _db.SaveChanges();

            return hero;
        }
    }
}
