using APIs.Models;

namespace APIs.Repositories
{
    public interface IMovieRepo
    {
        List<Movie> GetAll();
        Movie? GetById(int id);
        int Insert(Movie newMovie);
        int Remove(int id);
        int Update(Movie newMovie);
    }
}