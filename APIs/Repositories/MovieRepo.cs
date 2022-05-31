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
            return db.Movies.Include(m=>m.Genre).ToList();
        }
        public Movie? GetById(int id)
        {
            return db.Movies.Include(m => m.Genre).SingleOrDefault(m => m.Id == id);
        }
        public int Insert(Movie newMovie)
        {
            db.Movies.Add(newMovie);
            int rowsAffected = db.SaveChanges();
            return rowsAffected;
        }
        public int Update(Movie newMovie)
        {
            Movie? oldMovie = db.Movies.SingleOrDefault(m => m.Id == newMovie.Id);
            if (oldMovie == null) return 0;

            oldMovie.Title = newMovie.Title;
            oldMovie.Date = newMovie.Date;
            oldMovie.Image = newMovie.Image;
            oldMovie.Trailer = newMovie.Trailer;
            oldMovie.Limit = newMovie.Limit;
            oldMovie.Duration = newMovie.Duration;
            oldMovie.Description = newMovie.Description;
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
