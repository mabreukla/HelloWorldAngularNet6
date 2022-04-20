using HelloWorldAngularNet6.Models;

namespace HelloWorldAngularNet6.Repositories
{
    public interface IHeroesRepository
    {
        public List<Hero> GetAll();
        public Hero GetById(int id);
        public Hero Add(Hero hero);
        public Hero Update(Hero hero);
        public void Delete(Hero hero);
    }
}
