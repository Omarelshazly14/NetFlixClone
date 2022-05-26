using APIs.Models;

namespace APIs.Repositories
{
    public class MovieActorRepo : IMovieActorRepo
    {
        private readonly Context db;
        public MovieActorRepo(Context context)
        {
            this.db = context;
        }

        public List<MovieActor> GetAll()
        {
            return db.MovieActors.ToList();
        }
        public List<MovieActor> GetByMovieID(int id)
        {
            return db.MovieActors.Where(m => m.Movie_Id == id).ToList();
        }
        public List<MovieActor> GetByActorID(int id)
        {
            return db.MovieActors.Where(a => a.Actor_Id == id).ToList();
        }
        public int InsertMovieActors(int movieId, List<int> actorsIds)
        {
            MovieActor tempMovieActor = new MovieActor();
            foreach (var actorId in actorsIds)
            {
                tempMovieActor.Movie_Id = movieId;
                tempMovieActor.Actor_Id = actorId;
                db.MovieActors.Add(tempMovieActor);
            }
            int rowsAffected = db.SaveChanges();
            return rowsAffected;
        }
        public int Update(MovieActor newMovieActor, int oldActorId)
        {
            MovieActor? oldMovieActor = db.MovieActors.SingleOrDefault(m => m.Movie_Id == newMovieActor.Movie_Id && m.Actor_Id == oldActorId);
            if (oldMovieActor == null) return 0;

            oldMovieActor.Actor_Id = newMovieActor.Actor_Id;
            int rowsAffected = db.SaveChanges();
            return rowsAffected;
        }
        public int Remove(MovieActor movieActor)
        {
            MovieActor? MovieActor = db.MovieActors.SingleOrDefault(m => m.Movie_Id == movieActor.Movie_Id && m.Actor_Id == movieActor.Actor_Id);
            if (MovieActor == null) return 0;

            db.MovieActors.Remove(MovieActor);
            return db.SaveChanges();

        }
    }
}
