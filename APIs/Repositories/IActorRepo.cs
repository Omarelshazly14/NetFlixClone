using APIs.Models;

namespace APIs.Repositories
{
    public interface IActorRepo
    {
        List<Actor> GetAll();
        Actor? GetById(int id);
        int Insert(Actor newActor);
        int Remove(int id);
        int Update(Actor newActor);
    }
}