using APIs.Models;
using Microsoft.EntityFrameworkCore;

namespace APIs.Repositories
{
    public class ActorRepo : IActorRepo
    {
        private readonly Context db;
        public ActorRepo(Context context)
        {
            this.db = context;
        }

        public List<Actor> GetAll()
        {
            return db.Actors.ToList();
        }
        public Actor? GetById(int id)
        {
            return db.Actors.Include(a=>a.ActorMovies).ThenInclude(a=>a.Movie).SingleOrDefault(a => a.Id == id);
        }
        public int Insert(Actor newActor)
        {
            db.Actors.Add(newActor);
            int rowsAffected = db.SaveChanges();
            return rowsAffected;
        }
        public int Update(Actor newActor)
        {
            Actor? oldActor = db.Actors.SingleOrDefault(a => a.Id == newActor.Id);
            if (oldActor == null) return 0;

            oldActor.Name = newActor.Name;
            int rowsAffected = db.SaveChanges();
            return rowsAffected;
        }
        public int Remove(int id)
        {
            Actor? Actor = db.Actors.SingleOrDefault(a => a.Id == id);
            if (Actor == null) return 0;

            db.Actors.Remove(Actor);
            return db.SaveChanges();

        }
    }
}
