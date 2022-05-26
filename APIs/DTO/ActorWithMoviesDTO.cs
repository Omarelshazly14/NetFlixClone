using APIs.Models;

namespace APIs.DTO
{
    public class ActorWithMoviesDTO
    {
        public int Id { get; set; }
        public string? Actor_Name { get; set; }
        public List<Movie>? Actor_Movies { get; set; }
    }
}
