using APIs.Models;

namespace APIs.Repositories
{
    public interface IMovieActorRepo
    {
        List<MovieActor> GetAll();
        List<MovieActor> GetByActorID(int id);
        List<MovieActor> GetByMovieID(int id);
        int InsertMovieActors(int movieId, List<int> actorsIds);
        int Remove(MovieActor movieActor);
        int Update(MovieActor newMovieActor, int oldActorId);
    }
}