using System.ComponentModel.DataAnnotations.Schema;

namespace APIs.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string Poster { get; set; }
        public float Average_Rating { get; set; }

        // Foreign Keys
        [ForeignKey("Genre")]
        public int Genre_Id { get; set; }

        //Navigation Properties
        public virtual Genre Genre { get; set; }
        public virtual List<MovieActor> MovieActors { get; set; }
    }
}
