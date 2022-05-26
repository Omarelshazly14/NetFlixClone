using APIs.Models;
using Microsoft.EntityFrameworkCore;

namespace APIs.Repositories
{
    public class MovieRepo : IMovieRepo
    {
        private readonly Context db;
        public MovieRepo(Context context)
        {
            this.db = context;
        }
        public List<Movie> GetAll()
        {
            return db.Movies.ToList();
        }
        public Movie? GetById(int id)
        {
            return db.Movies.Include(m => m.MovieActors).ThenInclude(m => m.Actor).SingleOrDefault(m => m.Id == id);
        }
        public int Insert(Movie newMovie)
        {
            db.Movies.Add(newMovie);
            int rowsAffected = db.SaveChanges();
            return rowsAffected;
        }
        public int Update(Movie newMovie)
        {
            Movie? oldMovie = db.Movies.SingleOrDefault(a => a.Id == newMovie.Id);
            if (oldMovie == null) return 0;

            oldMovie.Name = newMovie.Name;
            oldMovie.Date = newMovie.Date;
            oldMovie.Poster = newMovie.Poster;
            oldMovie.Average_Rating = newMovie.Average_Rating;
            oldMovie.Genre_Id = newMovie.Genre_Id;
            int rowsAffected = db.SaveChanges();
            return rowsAffected;
        }
        public int Remove(int id)
        {
            Movie? movie = db.Movies.SingleOrDefault(m => m.Id == id);
            if (movie == null) return 0;

            db.Movies.Remove(movie);
            return db.SaveChanges();

        }
    }
}
