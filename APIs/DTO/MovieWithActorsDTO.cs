using APIs.Models;

namespace APIs.DTO
{
    public class MovieWithActorsDTO
    {
        public int Id { get; set; }
        public string? Movie_Name { get; set; }
        public List<Actor>? Movie_Actors { get; set; }
    }
}
