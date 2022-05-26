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
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MovieActor>().HasKey(m => new { m.Movie_Id, m.Actor_Id });
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<MovieActor> MovieActors { get; set; }
    }
}
