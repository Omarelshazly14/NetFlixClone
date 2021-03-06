using System.ComponentModel.DataAnnotations.Schema;

namespace APIs.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Date { get; set; }
        public string Image { get; set; }
        public string Trailer { get; set; }
        public int Limit { get; set; }
        public string Duration { get; set; }
        public string Description { get; set; }

        // Foreign Keys
        [ForeignKey("Genre")]
        public int Genre_Id { get; set; }

        //Navigation Properties
        public virtual Genre Genre { get; set; }
    }
}
