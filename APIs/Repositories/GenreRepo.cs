using APIs.Models;
using Microsoft.EntityFrameworkCore;

namespace APIs.Repositories
{
    public class GenreRepo : IGenreRepo
    {
        private readonly Context db;
        public GenreRepo(Context context)
        {
            this.db = context;
        }

        public List<Genre> GetAll()
        {
            return db.Genres.ToList();
        }
        public Genre? GetById(int id)
        {
            return db.Genres.Include(g=>g.Movies).SingleOrDefault(g => g.Id == id);
        }
        public int Insert(Genre newGenre)
        {
            db.Genres.Add(newGenre);
            int rowsAffected = db.SaveChanges();
            return rowsAffected;
        }
        public int Update(Genre newGenre)
        {
            Genre? oldGenre = db.Genres.SingleOrDefault(g => g.Id == newGenre.Id);
            if (oldGenre == null) return 0;

            oldGenre.Name = newGenre.Name;
            int rowsAffected = db.SaveChanges();
            return rowsAffected;
        }
        public int Remove(int id)
        {
            Genre? genre = db.Genres.SingleOrDefault(g => g.Id == id);
            if (genre == null) return 0;

            db.Genres.Remove(genre);
            return db.SaveChanges();

        }
    }
}
