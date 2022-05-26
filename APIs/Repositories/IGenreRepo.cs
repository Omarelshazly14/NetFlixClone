using APIs.Models;

namespace APIs.Repositories
{
    public interface IGenreRepo
    {
        List<Genre> GetAll();
        Genre? GetById(int id);
        int Insert(Genre newGenre);
        int Remove(int id);
        int Update(Genre newGenre);
    }
}