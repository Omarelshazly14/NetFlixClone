using Microsoft.EntityFrameworkCore;

namespace APIs.Models
{
    public class Context:DbContext
    {
        public Context()
        {
        }
        public Context(DbContextOptions options):base(options)
        {
        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Genre> Genres { get; set; }
    }
}
