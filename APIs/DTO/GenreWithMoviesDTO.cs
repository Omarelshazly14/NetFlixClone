using APIs.Models;

namespace APIs.DTO
{
    public class GenreWithMoviesDTO
    {
        public int Id { get; set; }
        public string Genre_Name { get; set; }
        public List<Movie> Genre_Movies { get; set; }
    }
}
